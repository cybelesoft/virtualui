unit ThinVnc.RadiusClient;
{$I ThinVnc.DelphiVersion.inc}
{$DEFINE RADIUS_LOG}
interface

uses
  IdBaseComponent, IdComponent, IdUDPBase, IdUDPClient, SyncObjs,
  Classes, ThinVnc.EAPMethods;

const
  RADIUS_DATA_WAIT_TIMEOUT = 10000; // 10 s
  RADIUS_DATA_RETRY_COUNT = 3;
  RADIUS_AUTHENTICATION_PORT = 1812;
  RADIUS_ACCOUNTING_PORT = 1813;

  MS_RAS_Vendor : Cardinal = 311;
  MS_CHAP_Challenge : Byte = 11;
  MS_CHAP_Response : Byte = 1;
  MS_CHAP2_Response : Byte = 25;
  MS_CHAP_Domain : Byte = 10;

  RADIUS_INI_SECTION = 'RADIUS';

type
  TRadiusCode = ( rcAccessRequest = 1, rcAccessAccept = 2, rcAccessReject = 3,
    rcAccountingRequest = 4, rcAccountingResponse = 5, rcAccessChallenge = 11,
    rcStatusServer = 12, rcStatusClient = 13, rcReserved = 255  );

  TRadiusServiceType = ( rstLogin = 1, rstFramed = 2, rstCallbackLogin = 3,
    rstCallbackFramed = 4, rstOutbound = 5, rstAdministrative = 6,
    rstNASPrompt = 7, rstAuthenticateOnly = 8, rstCallbackNASPRompt = 9,
    rstCallCheck = 10, rstCallbackAdministrative = 11 );

  TRadiusFramedProtocol = ( rfpPPP = 1, rfpSLIP = 2, rfpARAP = 3, rfpGandalf = 4, rfpXylogics = 5, rfpX75Synchronous = 6);

  TRadiusAttributeType = ( ratUserName = 1, ratUserPassword = 2, ratCHAPPassword = 3,
    ratNASIPAddress = 4, ratNASPort = 5, ratServiceType = 6,  ratFramedProtocol = 7,
    ratFramedIPAddress = 8, ratFramedIPNetmask = 9, ratFramedRouting = 10, ratFilterId = 11,
    ratFramedMTU = 12, ratFramedCompression = 13,  ratLoginIPHost = 14, ratLoginService = 15,
    ratLoginTCPPort = 16, ratReplyMessage = 18, ratCallbackNumber = 19, ratCallbackId = 20,
    ratFramedRoute = 22, ratFramedIPXNetwork = 23, ratState = 24, ratClass = 25,
    ratVendorSpecific = 26, ratSessionTimeout = 27, ratIdleTimeout = 28, ratTerminationAction = 29,
    ratCalledStationId = 30, ratCallingStationId = 31, ratNASIdentifier = 32, ratProxyState = 33,
    ratLoginLATService = 34, ratLoginLATNode = 35, ratLoginLATGroup = 36, ratFramedAppleTalkLink = 37,
    ratFramedAppleTalkNetwork = 38, ratFramedAppleTalkZone = 39, ratCHAPChallenge = 60,
    ratNASPortType = 61, ratPortLimit = 62, ratLoginLATPort = 63,

    ratARAPPassword = 70, ratARAPFeatures = 71, ratARAPZoneAccess = 72, ratARAPSecurity = 73, ratARAPSecurityData = 74,
    ratPasswordRetry = 75, ratPrompt = 76, ratConnectInfo = 77, ratConfigurationToken = 78, ratEAPMessage = 79,
    ratMessageAuthenticator = 80, ratARAPChallengeResponse = 84, ratAcctInterimInterval = 85, ratNASPortId = 87,
    ratFramedPool = 88, ratAcctInputGigawords = 52, ratAcctOutputGigawords = 53, ratEventTimestamp = 55 );

  TRadiusLoginType = ( rltPAP, rltCHAP, rltMSCHAP, rltMSCHAPv2, rltEAP );

  TRadiusAttribute = record
    raType : TRadiusAttributeType;
    Length : Byte;
    Value : RawByteString;
  end;
  PRadiusAttribute = ^TRadiusAttribute;

  TRadiusClient = class;

  TRadiusPacket = class
  private
    fCode : TRadiusCode;
    fIdentifier : Byte;
    fAuthenticator : RawByteString;
    fClient : TRadiusClient;
    fAttributes : TList;
    procedure FreeAttributes;
    function GetAttribute(Index: Integer): PRadiusAttribute; inline;
  protected
    function Generate_CHAP_Password(const APassword : RawByteString; const Id : Byte) : RawByteString;
    function Generate_Password(const APassword : RawByteString) : RawByteString;
    function Generate_NTResponse_Password(const AUsername, APassword : RawByteString; var AChallenge : RawByteString; const Chap2 : Boolean = False) : RawByteString;
    function GetLength : Word;
  public
    procedure AddAttributeMSCHAPUserPass(const AUsername, APassword : RawByteString; const Chap2 : Boolean = False);
    procedure AddAttributeCHAPPassword(const APassword : RawByteString);
    procedure AddAttributePassword(const APassword : RawByteString);
    constructor Create(const ACode : TRadiusCode; AClient : TRadiusClient);
    destructor Destroy; override;

    procedure AddAttribute(const attr : PRadiusAttribute);
    procedure SaveToStream(Stream : TStream);
    procedure LoadFromString(const Data : RawByteString);
    procedure SaveToString(var Data : RawByteString);
    function VerifyAuthenticator(const PrevPacket : TRadiusPacket) : Boolean;
    function GetAttributeValue(const attr : TRadiusAttributeType) : RawByteString;
    function HasAttribute(const attr : TRadiusAttributeType) : Boolean;
    function RemoveAttribute(const attr : TRadiusAttributeType) : Boolean;
    procedure FinalizePacket(const PrevPacket : TRadiusPacket);

    property Authenticator : RawByteString read fAuthenticator;
    property Code : TRadiusCode read fCode;
    property Identifier : Byte read fIdentifier;
    property PktLength : Word read GetLength;
    property Client : TRadiusClient read fClient;
  end;

  TRadiusEvent = procedure (Sender : TObject; Packet : TRadiusPacket) of object;
  TRadiusAnswerListener = class(TThread)
  private
    fPacketSend : RawByteString;
    fIteration : Integer;
    fClient : TRadiusClient;
    fTimeout : Word;

    fOnChallenge : TRadiusEvent;
    fOnReject : TRadiusEvent;
    fOnNoAnswer : TRadiusEvent;
    fOnAccept : TRadiusEvent;

    fSyncPacket: TRadiusPacket;
    fSyncEvent: TRadiusEvent;
    procedure SynchronizeEvent(Evt: TRadiusEvent; Pkt: TRadiusPacket);
    procedure Synchronized;
  protected
    procedure Execute; override;
  public
    constructor Create(const APacketSend : RawByteString; AClient : TRadiusClient; const ATimeout : Word = RADIUS_DATA_WAIT_TIMEOUT);

    property OnChallenge : TRadiusEvent read fOnChallenge write fOnChallenge;
    property OnReject : TRadiusEvent read fOnReject write fOnReject;
    property OnAccept : TRadiusEvent read fOnAccept write fOnAccept;
    property OnNoAnswer : TRadiusEvent read fOnNoAnswer write fOnNoAnswer;
  end;

  TRadiusLogLines = procedure (Sender : TRadiusClient; Lines : TStringList) of object;
  TRadiusLoginEvent = procedure (Sender : TRadiusClient; Packet : TRadiusPacket) of object;
  TRadiusLoginAnswer = ( rlaNoAnswer, rlaReject, rlaSuccess, rlaChallenge );
  TRadiusClient = class
  private
    fUDPClient : TIdUDPClient;
    fLoginType : TRadiusLoginType;
    fLastIdentifier : Byte;
    fOnLoginSuccess : TRadiusLoginEvent;
    fOnLoginReject : TRadiusLoginEvent;
    fOnLoginChallenge : TRadiusLoginEvent;
    fOnLoginNoAnswer : TRadiusLoginEvent;
{$IFDEF RADIUS_LOG}
    fOnLogLines : TRadiusLogLines;
{$ENDIF RADIUS_LOG}
    fSecret : RawByteString;
    fEAP : TEap;
    fCertFile : WideString;
    fUserName : WideString;

    FSynchronizeEvents: Boolean;
    FAnswer : TRadiusLoginAnswer;
    fAnswerEvent : TEvent;
    FAnswerPacket : TRadiusPacket;
    FAnswerSync : Boolean;
  protected
    function WaitForData(const Timeout : Word = RADIUS_DATA_WAIT_TIMEOUT) : RawByteString;

    procedure NoAnswer(Sender : TObject; Packet : TRadiusPacket);
    procedure Reject(Sender : TObject; Packet : TRadiusPacket);
    procedure Challenge(Sender : TObject; Packet : TRadiusPacket);
    procedure Success(Sender : TObject; Packet : TRadiusPacket);
    procedure TakeCareOfAnswers(const Packet : RawByteString);
{$IFDEF RADIUS_LOG}
    procedure LogInfo(const Text : String);
{$ENDIF RADIUS_LOG}
  public
{$IFDEF RADIUS_LOG}
    procedure LogPacket(const Data : RawByteString);
    procedure LogVendorSpecificPacket(const Data : RawByteString; Lines : TStringList);
    procedure LogEAPPacketData(const Data : RawByteString; Lines : TStringList);
{$ENDIF RADIUS_LOG}
    function Login(const Username, Password : String) : Boolean;
    function SyncLogin(const Username, Password : String; var Answer : TRadiusLoginAnswer; var Packet : TRadiusPacket) : Boolean;
    procedure SetRadiusServer(const Host : AnsiString; const Port : Integer; const Secret : RawByteString);
    property Secret : RawByteString read fSecret;
    function GetNewPacketIdentifier : Byte;
    constructor Create(SyncEvents: Boolean = False);
    destructor Destroy; override;
{$IFDEF RADIUS_LOG}
    property OnLogLines : TRadiusLogLines read fOnLogLines write fOnLogLines;
{$ENDIF RADIUS_LOG}
    property OnLoginSuccess : TRadiusLoginEvent read fOnLoginSuccess write fOnLoginSuccess;
    property OnLoginChallenge : TRadiusLoginEvent read fOnLoginChallenge write fOnLoginChallenge;
    property OnLoginReject : TRadiusLoginEvent read fOnLoginReject write fOnLoginReject;
    property OnLoginNoAnswer : TRadiusLoginEvent read fOnLoginNoAnswer write fOnLoginNoAnswer;
    property LoginType : TRadiusLoginType read fLoginType write fLoginType;
    property CertFile : WideString read fCertFile write fCertFile;
  end;

  function RadiusTextAttribute(const AAttType : TRadiusAttributeType; const Value : Utf8String) : PRadiusAttribute;
  function RadiusStringAttribute(const AAttType : TRadiusAttributeType; const Value : RawByteString) : PRadiusAttribute;
  function RadiusAddressAttribute(const AAttType : TRadiusAttributeType; const Value : int32) : PRadiusAttribute;
  function RadiusIntegerAttribute(const AAttType : TRadiusAttributeType; const Value : uint32) : PRadiusAttribute;
  function RadiusTimeAttribute(const AAttType : TRadiusAttributeType; const Value : uint32) : PRadiusAttribute;

  function RadiusAttUserName(const AUsername : WideString) : PRadiusAttribute; inline;
  function RadiusAttNASIpAddress(const AAddress : uint32) : PRadiusAttribute;
  function RadiusAttNASPort(const APort : Word) : PRadiusAttribute;
  function RadiusAttServiceType(const AServiceType : TRadiusServiceType) : PRadiusAttribute;
  function RadiusAttFramedProtocol(const AFramedProtocol : TRadiusFramedProtocol) : PRadiusAttribute;
  function RadiusAttMessageAuthenticator(const BasePacket : TRadiusPacket) : PRadiusAttribute;
  function PacketClone(const Packet : TRadiusPacket) : TRadiusPacket;

implementation

uses
  ThinVnc.OverbyteIcsMD5, ThinVnc.OverbyteIcsMD4, ThinVnc.OverbyteIcsDES,
{$IFDEF DELPHIXE}
  IdHashSHA,
{$ELSE}
  IdHashSHA1, IdHash,
{$ENDIF}
  IdGlobal, SysUtils;

function MD5(const Value : RawByteString) : RawByteString;
begin
  result := GetMD5(PAnsiChar(Value), Length(Value));
  HexToBin(PAnsiChar(Result), PAnsiChar(Result), Length(Result) div 2);
  SetLength(Result, Length(result) div 2);
end;

function Swap4(value : uint32) : uint32; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  result := ((Value shr 24) and $000000FF) or ((Value shr 8) and $0000FF00) or ((Value shl 24) and $FF000000) or ((Value shl 8) and $00FF0000);
end;

function StringToBytes(const Value : RawByteString) : TIdBytes; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(Result, Length(Value));
  Move(Value[1], Result[0], Length(Value));
end;

function BytesToString(const Value : TIdBytes) : RawByteString; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(result, Length(Value));
  Move(Value[0], result[1], Length(Value));
end;

function StrToHex(const Value : RawByteString) : RawByteString; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(Result, Length(Value) * 2);
  BinToHex(PAnsiChar(Value), PAnsiChar(result), Length(Value));
end;

function HexToStr(const Value : RawByteString) : RawByteString; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(Result, Length(Value) div 2);
  HexToBin(PAnsiChar(Value), PAnsiChar(result), Length(Value));
end;

function WordToStr(const Value : Word) : RawByteString; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(result, 2);
  Move(Value, result[1], 2);
end;

function DWordToStr(const Value : Cardinal) : RawByteString; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(result, 4);
  Move(Value, result[1], 4);
end;

function ByteToStr(const Value : Byte) : RawByteString; {$IFNDEF DEBUG}inline;{$ENDIF}
begin
  SetLength(result, 1);
  result[1] := AnsiChar(Value);
end;

function hmac(const text, key : RawByteString) : RawByteString;
var
  vIndex : Integer;
  vipad, vopad : RawByteString;
  vtk : RawByteString;
begin
  (* if key is longer than 64 bytes reset it to key=MD5(key) *)
  if Length(key) > 64
    then vtk := MD5(key)
    else vtk := key;

  (*
   * the HMAC_MD5 transform looks like:
   *
   * MD5(K XOR opad, MD5(K XOR ipad, text))
   *
   * where K is an n byte key
   * ipad is the byte 0x36 repeated 64 times
   * opad is the byte 0x5c repeated 64 times
   * and text is the data being protected
   *)

  // start out by storing key in pads
  SetLength(vipad, 64);
  SetLength(vopad, 64);

  // XOR key with ipad and opad values
  for vIndex := 1 to 64 do
  begin
    if vIndex <= Length(vtk) then
    begin
      vipad[vIndex] := AnsiChar(Ord(vtk[vIndex]) xor $36);
      vopad[vIndex] := AnsiChar(Ord(vtk[vIndex]) xor $5C);
    end else
    begin
      vipad[vIndex] := AnsiChar($36);
      vopad[vIndex] := AnsiChar($5C);
    end;
  end;

  // perform inner MD5
  result := Md5(vipad+text);
  // perform outer MD5
  result := Md5(vopad+result);
end;

function RadiusTextAttribute(const AAttType : TRadiusAttributeType; const Value : Utf8String) : PRadiusAttribute;
begin
  New(Result);
  result.raType := AAttType;
  result.Length := Length(Value)+2;
  SetLength(Result.Value, Length(Value));
  Move(Value[1], result.Value[1], Length(Value));
end;

function RadiusStringAttribute(const AAttType : TRadiusAttributeType; const Value : RawByteString) : PRadiusAttribute;
begin
  New(Result);
  result.raType := AAttType;
  result.Length := Length(Value)+2;
  SetLength(result.Value, Length(Value));
  Move(Value[1], result.Value[1], Length(Value));
end;

function RadiusAddressAttribute(const AAttType : TRadiusAttributeType; const Value : int32) : PRadiusAttribute;
var
  val : int32;
begin
  New(Result);
  result.raType := AAttType;
  result.Length := SizeOf(Value)+2;
  SetLength(result.Value, SizeOf(Value));
  val := Swap4(Value);
  Move(val, result.Value[1], SizeOf(val));
end;

function RadiusIntegerAttribute(const AAttType : TRadiusAttributeType; const Value : uint32) : PRadiusAttribute;
var
  val : uint32;
begin
  New(Result);
  result.raType := AAttType;
  result.Length := SizeOf(Value)+2;
  SetLength(result.Value, SizeOf(Value));
  val := Swap4(Value);
  Move(val, result.Value[1], SizeOf(val));
end;

function RadiusTimeAttribute(const AAttType : TRadiusAttributeType; const Value : uint32) : PRadiusAttribute;
var
  val : uint32;
begin
  New(Result);
  result.raType := AAttType;
  result.Length := SizeOf(Value)+2;
  SetLength(result.Value, SizeOf(Value));
  val := Swap4(Value);
  Move(val, result.Value[1], SizeOf(val));
end;

function RadiusAttUserName(const AUsername : WideString) : PRadiusAttribute;
begin
  result := RadiusTextAttribute(ratUserName, AUsername);
end;

function RadiusAttNASIpAddress(const AAddress : uint32) : PRadiusAttribute;
begin
  result := RadiusAddressAttribute(ratNASIPAddress, AAddress);
end;

function RadiusAttNASPort(const APort : Word) : PRadiusAttribute;
begin
  result := RadiusIntegerAttribute(ratNASPort, APort);
end;

function RadiusAttServiceType(const AServiceType : TRadiusServiceType) : PRadiusAttribute;
begin
  result := RadiusIntegerAttribute(ratServiceType, Ord(AServiceType));
end;

function RadiusAttFramedProtocol(const AFramedProtocol : TRadiusFramedProtocol) : PRadiusAttribute;
begin
  result := RadiusIntegerAttribute(ratFramedProtocol, Ord(AFramedProtocol));
end;

function RadiusAttMessageAuthenticator(const BasePacket : TRadiusPacket) : PRadiusAttribute;
var
  vText : RawByteString;
  vLength : Word;
begin
  BasePacket.SaveToString(vText);
  vLength := Length(vText)+18;
  vLength := ((vLength shr 8) and $FF) or ((vLength and $FF) shl 8);
  vText := Copy(vText, 1, 2) + WordToStr(vLength) + Copy(vText, 5, Length(vText)-4) + AnsiChar(Ord(ratMessageAuthenticator)) + AnsiChar(18) + StringOfChar(#0, 16);
  result := RadiusStringAttribute(ratMessageAuthenticator, hmac(vText, BasePacket.Client.Secret));
end;

function PacketClone(const Packet : TRadiusPacket) : TRadiusPacket;
var
  str : RawByteString;
begin
  Packet.SaveToString(str);
  result := TRadiusPacket.Create(rcAccessRequest, Packet.Client);
  result.LoadFromString(str);
end;

{ Radius Client }

constructor TRadiusClient.Create(SyncEvents: Boolean);
begin
  inherited Create;
  FSynchronizeEvents := SyncEvents;
  fUDPClient := TIdUDPClient.Create(nil);
  fUDPClient.Port := RADIUS_AUTHENTICATION_PORT;
  fEAP := TEap.Create;
  fLastIdentifier := 0;
  fLoginType := rltPAP;
  fAnswerEvent := TEvent.Create(nil, True, False, '');
  FAnswerSync := False;
end;

destructor TRadiusClient.Destroy;
begin
  FreeAndNil(fAnswerEvent);
  FreeAndNil(fEAP);
  FreeAndNil(fUDPClient);
  inherited;
end;

procedure TRadiusClient.SetRadiusServer(const Host : AnsiString; const Port : Integer; const Secret : RawByteString);
begin
  fSecret := Secret;
  fUDPClient.Host := Host;
  fUDPClient.Port := Port;
  fUDPClient.Connect;
end;

function TRadiusClient.GetNewPacketIdentifier : Byte;
begin
  if fLastIdentifier < 255
    then Inc(fLastIdentifier)
    else fLastIdentifier := 0;
  result := fLastIdentifier;
end;

function IpToUINT32(const x1,x2,x3,x4 : Byte) : uint32; inline;
begin
  result := (x1 shl 24) or (x2 shl 16) or (x3 shl 8) or x4;
end;

function TRadiusClient.WaitForData(const Timeout : Word = RADIUS_DATA_WAIT_TIMEOUT) : RawByteString;
var
  vBuff : TIdBytes;
  vDataRead : Word;
begin
  SetLength(vBuff, 64*1024);
  Result := '';

  vDataRead := fUDPClient.ReceiveBuffer(vBuff, Timeout);
  SetLength(result, vDataRead);
  Move(vBuff[0], Result[1], vDataRead);
end;

procedure TRadiusClient.Success(Sender : TObject; Packet : TRadiusPacket);
begin
{$IFDEF RADIUS_LOG}
  LogInfo('---- SUCESSFULY CONNECTED ----');
{$ENDIF RADIUS_LOG}
  if FAnswerSync then
  begin
    FAnswer := rlaSuccess;
    FAnswerPacket := PacketClone(Packet);
    fAnswerEvent.SetEvent;
  end else
    if Assigned(fOnLoginSuccess) then fOnLoginSuccess(Self, Packet);
end;

procedure TRadiusClient.NoAnswer(Sender : TObject; Packet : TRadiusPacket);
begin
{$IFDEF RADIUS_LOG}
  LogInfo('---- NO ANSWER RECEIVED ----');
{$ENDIF RADIUS_LOG}
  if FAnswerSync then
  begin
    FAnswer := rlaNoAnswer;
    FAnswerPacket := PacketClone(Packet);
    fAnswerEvent.SetEvent;
  end else
    if Assigned(fOnLoginNoAnswer) then fOnLoginNoAnswer(Self, Packet);
end;

procedure TRadiusClient.Reject(Sender : TObject; Packet : TRadiusPacket);
begin
{$IFDEF RADIUS_LOG}
  LogInfo('---- CONNECTION REJECTED ----');
{$ENDIF RADIUS_LOG}
  if FAnswerSync then
  begin
    FAnswer := rlaReject;
    FAnswerPacket := PacketClone(Packet);
    fAnswerEvent.SetEvent;
  end else
    if Assigned(fOnLoginReject) then fOnLoginReject(Self, Packet);
end;

{$IFDEF RADIUS_LOG}
procedure TRadiusClient.LogInfo(const Text : String);
var
  Lines : TStringList;
begin
  if not Assigned(fOnLogLines) then Exit;
  Lines := TStringList.Create;
  try
    Lines.Add(Text);
    fOnLogLines(Self,Lines);
  finally
    Lines.Free;
  end;
end;
{$ENDIF RADIUS_LOG}

procedure TRadiusClient.Challenge(Sender : TObject; Packet : TRadiusPacket);
var
  vEAPResponse : RawByteString;
  vRespPacket : TRadiusPacket;
  vPendingSend : Word;
begin
  if (fLoginType = rltEAP) and (Packet.HasAttribute(ratEAPMessage)) then
  begin
    // EAP Message Handle
    fEAP.Response(Packet.GetAttributeValue(ratEAPMessage));
    if not fEAP.Step then raise Exception.Create('EAP Step Failed!');
    vEAPResponse := fEAP.TakeData;
    vPendingSend := Length(vEAPResponse);

    vRespPacket := TRadiusPacket.Create(rcAccessRequest, Self);
    try
      vRespPacket.AddAttribute(RadiusAttUserName(fUserName));
      while vPendingSend > 0 do
      begin
        vRespPacket.AddAttribute(RadiusStringAttribute(ratEAPMessage, Copy(vEAPResponse, Length(vEAPResponse)-vPendingSend+1, 253)));
        if Length(vEAPResponse) > 253 then Dec(vPendingSend, 253) else vPendingSend := 0;
      end;
      if Packet.HasAttribute(ratState) then
        vRespPacket.AddAttribute(RadiusStringAttribute(ratState, Packet.GetAttributeValue(ratState)));
      vRespPacket.AddAttribute(RadiusAttMessageAuthenticator(vRespPacket));

      vRespPacket.SaveToString(vEAPResponse);
{$IFDEF RADIUS_LOG}
      LogPacket(vEAPResponse);
{$ENDIF}
      fUDPClient.SendBuffer(StringToBytes(vEAPResponse));
      TakeCareOfAnswers(vEAPResponse);
    finally
      vRespPacket.Free;
    end;
  end else
  if FAnswerSync then
  begin
    FAnswer := rlaSuccess;
    FAnswerPacket := PacketClone(Packet);
    fAnswerEvent.SetEvent;
  end else
    if Assigned(fOnLoginChallenge) then fOnLoginChallenge(Self, Packet);
end;

procedure TRadiusClient.TakeCareOfAnswers(const Packet : RawByteString);
var
  vAnswerThread : TRadiusAnswerListener;
begin
  vAnswerThread := TRadiusAnswerListener.Create(Packet, Self);
  vAnswerThread.OnChallenge := Challenge;
  vAnswerThread.OnReject := Reject;
  vAnswerThread.OnAccept := Success;
  vAnswerThread.OnNoAnswer := NoAnswer;
  {$IFDEF DELPHIXE3}
  vAnswerThread.Start;
  {$ELSE}
  vAnswerThread.Resume;
  {$ENDIF}
end;

function TRadiusClient.Login(const Username, Password : String) : Boolean;
var
  vPacket : TRadiusPacket;
  vData : RawByteString;
begin
  result := False;
  fUserName := UserName;
  vPacket := TRadiusPacket.Create(rcAccessRequest, Self);
  try
    vPacket.AddAttribute(RadiusAttUserName(Username));

    if fLoginType <> rltEAP then
    begin
      case fLoginType of
        rltPAP      : vPacket.AddAttributePassword(Password);
        rltCHAP     : vPacket.AddAttributeCHAPPassword(Password);
        rltMSCHAP   : vPacket.AddAttributeMSCHAPUserPass(Username, Password);
        rltMSCHAPv2 : vPacket.AddAttributeMSCHAPUserPass(Username, Password, True);
      end;
    end else
    begin
      fEAP.SetLoginInfo(Username, Password);
      fEAP.Start;
      if not fEAP.Step then
        raise Exception.Create('EAP Step Failed');

      vPacket.AddAttribute(RadiusStringAttribute(ratEAPMessage, fEAP.TakeData));
      vPacket.AddAttribute(RadiusAttMessageAuthenticator(vPacket));
    end;

    vPacket.SaveToString(vData);
{$IFDEF RADIUS_LOG}
    LogPacket(vData);
{$ENDIF}

    fUDPClient.SendBuffer(StringToBytes(vData));
    TakeCareOfAnswers(vData);
  finally
    vPacket.Free;
  end;
end;

function TRadiusClient.SyncLogin(const Username, Password : String; var Answer : TRadiusLoginAnswer; var Packet : TRadiusPacket) : Boolean;
begin
  FAnswerSync := True;
  result := Login(Username, Password);
  fAnswerEvent.WaitFor(INFINITE);
  Answer := FAnswer;
  Packet := FAnswerPacket;
  FAnswerSync := False;
end;

{$IFDEF RADIUS_LOG}
procedure TRadiusClient.LogPacket(const Data : RawByteString);
var
  Lines : TStringList;
  Buff : RawByteString;
  CurrPos : Integer;
  AttType : TRadiusAttributeType;
  AttLen : Byte;
  AttText : UTF8String;
  AttValue : uint32;
begin
  if not Assigned(fOnLogLines) then Exit;
  if Data = '' then Exit;
  
  if (Length(Data) < 20)  then raise Exception.Create('Invalid data packet!');

  Lines := TStringList.Create;
  try
    case TRadiusCode(Ord(Data[1])) of
      rcAccessRequest: Lines.Add('CODE: Access-Request');
      rcAccessAccept: Lines.Add('CODE: Access-Accept');
      rcAccessReject: Lines.Add('CODE: Access-Reject');
      rcAccountingRequest: Lines.Add('CODE: Accounting-Request');
      rcAccountingResponse: Lines.Add('CODE: Accounting-Response');
      rcAccessChallenge: Lines.Add('CODE: Access-Challenge');
      rcStatusServer: Lines.Add('CODE: Status-Server');
      rcStatusClient: Lines.Add('CODE: Status-Client');
      rcReserved: Lines.Add('CODE: Reserved');
    else
      Lines.Add('CODE: INVALID');
    end;
    Lines.Add(Format('Identifier: %u', [Ord(Data[2])]));
    Lines.Add(Format('Length: %u', [(Ord(Data[3]) shl 8) or Ord(Data[4])]));
    SetLength(Buff, 32);
    BinToHex(PAnsiChar(@Data[5]), PAnsiChar(Buff), 16);
    Lines.Add(Format('Authenticator: %s', [Buff]));
    // attributes
    CurrPos := 20;
    while Length(Data) > CurrPos+3 do
    begin
      AttType := TRadiusAttributeType(ord(Data[CurrPos+1]));
      AttLen := ord(Data[CurrPos+2]);
      Lines.Add('--Attribute--');
      case AttType of
        ratUserName : Lines.Add('Type: User-Name');
        ratUserPassword : Lines.Add('Type: User-Password');
        ratCHAPPassword : Lines.Add('Type: CHAP-Password');
        ratNASIPAddress : Lines.Add('Type: NAS-IP-Address');
        ratNASPort: Lines.Add('Type: NAS-Port');
        ratServiceType: Lines.Add('Type: Service-Type');
        ratFramedProtocol: Lines.Add('Type: Framed-Protocol');
        ratFramedIPAddress: Lines.Add('Type: Framed-IP-Address');
        ratFramedIPNetmask: Lines.Add('Type: Framed-IP-Netmask');
        ratFramedRouting: Lines.Add('Type: Framed-Routing');
        ratFilterId: Lines.Add('Type: Filter-Id');
        ratFramedMTU: Lines.Add('Type: Framed-MTU');
        ratFramedCompression: Lines.Add('Type: Framed-Compression');
        ratLoginIPHost: Lines.Add('Type: Login-IP-Host');
        ratLoginService: Lines.Add('Type: Login-Service');
        ratLoginTCPPort: Lines.Add('Type: Login-TCP-Port');
        ratReplyMessage: Lines.Add('Type: Reply-Message');
        ratCallbackNumber: Lines.Add('Type: Callback-Number');
        ratCallbackId: Lines.Add('Type: Callback-Id');
        ratFramedRoute: Lines.Add('Type: Framed-Route');
        ratFramedIPXNetwork: Lines.Add('Type: Framed-IPX-Network');
        ratState: Lines.Add('Type: State');
        ratClass: Lines.Add('Type: Class');
        ratVendorSpecific: Lines.Add('Type: Vendor-Specific');
        ratSessionTimeout: Lines.Add('Type: Session-Timeout');
        ratIdleTimeout: Lines.Add('Type: Idle-Timeout');
        ratTerminationAction: Lines.Add('Type: Termination-Action');
        ratCalledStationId: Lines.Add('Type: Called-Station-Id');
        ratCallingStationId: Lines.Add('Type: Calling-Station-Id');
        ratNASIdentifier: Lines.Add('Type: NAS-Identifier');
        ratProxyState: Lines.Add('Type: Proxy-State');
        ratLoginLATService: Lines.Add('Type: Login-LAT-Service');
        ratLoginLATNode: Lines.Add('Type: Login-LAT-Node');
        ratLoginLATGroup: Lines.Add('Type: Login-LAT-Group');
        ratFramedAppleTalkLink: Lines.Add('Type: Framed-AppleTalk-Link');
        ratFramedAppleTalkNetwork: Lines.Add('Type: Framed-AppleTalk-Network');
        ratFramedAppleTalkZone: Lines.Add('Type: Framed-AppleTalk-Zone');
        ratCHAPChallenge: Lines.Add('Type: CHAP-Challenge');
        ratNASPortType: Lines.Add('Type: NAS-Port-Type');
        ratPortLimit: Lines.Add('Type: Port-Limit');
        ratLoginLATPort: Lines.Add('Type: Login-LAT-Port');
        ratARAPPassword: Lines.Add('Type: ARAP-Password');
        ratARAPFeatures: Lines.Add('Type: ARAP-Features');
        ratARAPZoneAccess: Lines.Add('Type: ARAP-Zone-Access');
        ratARAPSecurity: Lines.Add('Type: ARAP-Security');
        ratARAPSecurityData: Lines.Add('Type: ARAP-Security-Data');
        ratPasswordRetry: Lines.Add('Type: ARAP-Password-Retry');
        ratPrompt: Lines.Add('Type: Prompt');
        ratConnectInfo: Lines.Add('Type: Connect-Info');
        ratConfigurationToken: Lines.Add('Type: Configuration-Token');
        ratEAPMessage: Lines.Add('Type: EAP-Message');
        ratMessageAuthenticator: Lines.Add('Type: Message-Authenticator');
        ratARAPChallengeResponse: Lines.Add('Type: ARAP-Challenge-Response');
        ratAcctInterimInterval: Lines.Add('Type: Acct-Interim-Interval');
        ratNASPortId: Lines.Add('Type: NAS-Port-Id');
        ratFramedPool: Lines.Add('Type: Framed-Pool');
        ratAcctInputGigawords: Lines.Add('Type: Acct-Input-Gigawords');
        ratAcctOutputGigawords: Lines.Add('Type: Acct-Output-Gigawords');
        ratEventTimestamp: Lines.Add('Type: Event-Timestamp');
      else
        Lines.Add('Type: INVALID');
      end;
      Lines.Add(Format('Length: %u', [AttLen]));
      if AttType in [ratReplyMessage, ratUserName] then
      begin
        SetLength(AttText, AttLen-2);
        Move(Data[CurrPos+3], AttText[1], AttLen-2);
        Lines.Add('Text: '+AttText);
      end else
      if AttType in [ratNASPort, ratFilterId, ratFramedMTU,
        ratSessionTimeout, ratIdleTimeout, ratCalledStationId, ratNASPortType,
        ratPortLimit, ratLoginLATPort, ratCallingStationId, ratFramedProtocol,
        ratServiceType] then
      begin
        Move(Data[CurrPos+3], AttValue, SizeOf(AttValue));
        Lines.Add(Format('Value: %u', [Swap4(AttValue)]));
      end else
      if AttType in [ratUserPassword] then
      begin
        SetLength(AttText, (AttLen-2)*2);
        BinToHex(PAnsiChar(@Data[CurrPos+3]), PAnsiChar(AttText), Length(AttText));
        Lines.Add('Hex-Text: '+AttText);
      end else
      if AttType in [ratVendorSpecific] then
      begin
        LogVendorSpecificPacket(Copy(Data, CurrPos+3, AttLen-2), Lines);
      end else
      begin
        Lines.Add('Dump: '+StrToHex(Copy(Data, CurrPos+3, AttLen-2)));
      end;
      Inc(CurrPos, AttLen);
    end;

    LogEAPPacketData(Data, Lines);

    // finally send log
    fOnLogLines(self, Lines);
  finally
    Lines.Free;
  end;
end;

procedure TRadiusClient.LogVendorSpecificPacket(const Data : RawByteString; Lines : TStringList);
var
  AttVendor : Cardinal;
  AttVendorType : Byte;
  AttVendorLength : Byte;
begin
  Move(Data[1], AttVendor, 4);
  if Swap4(AttVendor) = MS_RAS_Vendor then
  begin
    Lines.Add('Vendor: Microsoft');
    AttVendorType := Ord(Data[5]);
    AttVendorLength := Ord(Data[6]);
    if AttVendorType = 11 then Lines.Add('Vendor-Type: MS-CHAP-Challenge') else
    if AttVendorType = 1 then Lines.Add('Vendor-Type: MS-CHAP-Response') else
    if AttVendorType = 10 then Lines.Add('Vendor-Type: MS-CHAP-Domain') else
    if AttVendorType = 2 then Lines.Add('Vendor-Type: MS-CHAP-Error') else
    if AttVendorType = 3 then Lines.Add('Vendor-Type: MS-CHAP-PW-1') else
    if AttVendorType = 4 then Lines.Add('Vendor-Type: MS-CHAP-PW-2') else
    if AttVendorType = 5 then Lines.Add('Vendor-Type: MS-CHAP-LM-Enc-PW') else
    if AttVendorType = 6 then Lines.Add('Vendor-Type: MS-CHAP-NT-Enc-PW') else
    if AttVendorType = 25 then Lines.Add('Vendor-Type: MS-CHAP2-Response') else
    if AttVendorType = 26 then Lines.Add('Vendor-Type: MS-CHAP2-Success') else
    if AttVendorType = 27 then Lines.Add('Vendor-Type: MS-CHAP2-PW') else
    if AttVendorType = 12 then Lines.Add('Vendor-Type: MS-CHAP-MPPE-Keys') else
    if AttVendorType = 16 then Lines.Add('Vendor-Type: MS-MPPE-Send-Key') else
    if AttVendorType = 17 then Lines.Add('Vendor-Type: MS-MPPE-Recv-Key') else
    if AttVendorType = 7 then Lines.Add('Vendor-Type: MS-MPPE-Encryption-Policy') else
    if AttVendorType = 8 then Lines.Add('Vendor-Type: MS-MPPE-Encryption-Types') else
    if AttVendorType = 13 then Lines.Add('Vendor-Type: MS-BAP-Usage') else
    if AttVendorType = 14 then Lines.Add('Vendor-Type: MS-Link-Utilization-Threshold') else
    if AttVendorType = 15 then Lines.Add('Vendor-Type: MS-Link-Drop-Time-Limit') else
    if AttVendorType = 19 then Lines.Add('Vendor-Type: MS-Old-ARAP-Password Attribute') else
    if AttVendorType = 20 then Lines.Add('Vendor-Type: MS-New-ARAP-Password Attribute') else
    if AttVendorType = 21 then Lines.Add('Vendor-Type: MS-ARAP-Password-Change-Reason') else
    if AttVendorType = 33 then Lines.Add('Vendor-Type: MS-ARAP-Challenge') else
    if AttVendorType = 9 then Lines.Add('Vendor-Type: MS-RAS-Vendor') else
    if AttVendorType = 18 then Lines.Add('Vendor-Type: MS-RAS-Version') else
    if AttVendorType = 22 then Lines.Add('Vendor-Type: MS-Filter Attribute') else
    if AttVendorType = 23 then Lines.Add('Vendor-Type: MS-Acct-Auth-Type') else
    if AttVendorType = 24 then Lines.Add('Vendor-Type: MS-Acct-EAP-Type') else
    if AttVendorType = 28 then Lines.Add('Vendor-Type: MS-Primary-DNS-Server') else
    if AttVendorType = 29 then Lines.Add('Vendor-Type: MS-Secondary-DNS-Server') else
    if AttVendorType = 30 then Lines.Add('Vendor-Type: MS-Primary-NBNS-Server') else
    if AttVendorType = 31 then Lines.Add('Vendor-Type: MS-Secondary-NBNS-Server') else
      Lines.Add(Format('Vendor-Type: Unknown (0x%s)', [IntToHex(AttVendorType, 2)]));

    Lines.Add(Format('Vendor-Length: %u', [AttVendorLength]));
    Lines.Add(Format('Vendor-Data: %s', [StrToHex(Copy(Data, 7, AttVendorLength-2))]));
  end else
    Lines.Add(Format('Vendor: Unknown (0x%s)', [IntToHex(AttVendor, 8)]));
end;

procedure TRadiusClient.LogEAPPacketData(const Data : RawByteString; Lines : TStringList);
var
  packet : TRadiusPacket;
  eapMsg : RawByteString;
  stream : TMemoryStream;
  cVal : Byte;
  vStr : RawByteString;
  wValue : Word;
  pkgCode : Byte;
begin
  packet := TRadiusPacket.Create(rcAccessRequest, self);
  try
    packet.LoadFromString(Data);
    eapMsg := packet.GetAttributeValue(ratEAPMessage);
  finally
    packet.Free;
  end;
  if eapMsg = '' then Exit;

  Lines.Add(' -- EAP Message Found! -- ');

  stream := TMemoryStream.Create;
  try
    stream.Write(eapMsg[1], Length(eapMsg));
    stream.Seek(0, soFromBeginning);

    stream.Read(pkgCode, 1);
    case pkgCode of
      1: vStr := 'Request';
      2: vStr := 'Response';
      3: vStr := 'Success';
      4: vStr := 'Failure';
    else
      vStr := 'INVALID!';
    end;
    Lines.Add(Format('Code: %u (%s)', [pkgCode, vStr]));
    stream.Read(cVal, 1);
    Lines.Add(Format('Identifier: %u', [cVal]));
    stream.Read(wValue, 2);
    Lines.Add(Format('Length: %u', [Swap(wValue)]));
    if pkgCode in [1, 2] then
    begin
      stream.Read(cVal, 1);
      case cVal of
        1: vStr := 'Identity';
        2: vStr := 'Notification';
        3: vStr := 'Nak (Response only)';
        4: vStr := 'MD5-Challenge';
        5: vStr := 'One Time Password (OTP)';
        6: vStr := 'Generic Token Card (GTC)';
        13: vStr := 'EAP-TLS';
        17: vStr := 'EAP_LEAP';
        18: vStr := 'EAP-SIM';
        21: vStr := 'EAP-TTLS';
        23: vStr := 'EAP-AKA';
        25: vStr := 'PEAP';
        26: vStr := 'EAP_MSCHAPV2';
        32: vStr := 'EAP-POTP';
        33: vStr := 'EAP_TLV';
        38: vStr := 'EAP_TNC';
        43: vStr := 'EAP-FAST';
        46: vStr := 'EAP_PAX';
        47: vStr := 'EAP-PSK';
        48: vStr := 'EAP_SAKE';
        49: vStr := 'EAP-IKEv2';
        50: vStr := 'EAP_AKA_PRIME';
        51: vStr := 'EAP_GPSK';
        52: vStr := 'EAP_PWD';
        254: vStr := 'Expanded Types';
        255: vStr := 'Experimental use';
      else
        vStr := 'INVALID!';
      end;
      Lines.Add(Format('Type: %u (%s)', [cVal, vStr]));
      if cVal = 1 then
      begin
        SetLength(vStr, stream.Size-stream.Position);
        stream.Read(vStr[1], stream.Size-stream.Position);
        Lines.Add(Format('Type-Data: %s', [vStr]));
      end;
    end;

  finally
    stream.Free;
  end;


end;
{$ENDIF RADIUS_LOG}

{ Radius Packet }

constructor TRadiusPacket.Create(const ACode : TRadiusCode; AClient : TRadiusClient);
var
  vIndex : Integer;
begin
  inherited Create;
  Randomize;
  fIdentifier := AClient.GetNewPacketIdentifier;
  fClient := AClient;
  fCode := ACode;
  fAttributes := TList.Create;

  SetLength(fAuthenticator, 16);
  for vIndex := 1 to 16 do
     fAuthenticator[vIndex] := AnsiChar(Random(255));
end;

destructor TRadiusPacket.Destroy;
begin
  FreeAttributes;
  FreeAndNil(fAttributes);
  inherited;
end;

procedure TRadiusPacket.AddAttributeMSCHAPUserPass(const AUsername, APassword : RawByteString; const Chap2 : Boolean = False);
var
  vDomain : RawByteString;
  vChallenge : RawByteString;
  vNTResponse : RawByteString;
  vIndex : Integer;
begin
  if Pos('\', AUsername) > 0
    then vDomain := Copy(AUsername, 1, Pos('\', AUsername))
    else vDomain := '';

  SetLength(vChallenge, 16);
  for vIndex := 1 to 16 do
    vChallenge[vIndex] := AnsiChar(Random($FF));

  vNTResponse := Generate_NTResponse_Password(AUsername, APassword, vChallenge, Chap2);
  if Chap2 then
  begin
    AddAttribute(RadiusStringAttribute(ratVendorSpecific, DWordToStr(Swap4(MS_RAS_Vendor))+ByteToStr(MS_CHAP_Challenge)+ByteToStr(Length(fAuthenticator)+2)+fAuthenticator));
    AddAttribute(RadiusStringAttribute(ratVendorSpecific, DWordToStr(Swap4(MS_RAS_Vendor))+ByteToStr(MS_CHAP2_Response)+ByteToStr(Length(vNTResponse)+2)+vNTResponse));
  end else
  begin
    AddAttribute(RadiusStringAttribute(ratVendorSpecific, DWordToStr(Swap4(MS_RAS_Vendor))+ByteToStr(MS_CHAP_Challenge)+ByteToStr(Length(vChallenge)+2)+vChallenge));
    AddAttribute(RadiusStringAttribute(ratVendorSpecific, DWordToStr(Swap4(MS_RAS_Vendor))+ByteToStr(MS_CHAP_Response)+ByteToStr(Length(vNTResponse)+2)+vNTResponse));
  end;

  if vDomain <> '' then
    AddAttribute(RadiusStringAttribute(ratVendorSpecific, DWordToStr(Swap4(MS_RAS_Vendor))+ByteToStr(MS_CHAP_Domain)+ByteToStr(Length(vDomain)+2)+vDomain));
end;

procedure TRadiusPacket.AddAttributeCHAPPassword(const APassword : RawByteString);
var
  vId : Byte;
  vPass : RawByteString;
begin
  vId := Random(255);
  vPass := Generate_CHAP_Password(APassword, vId);
  AddAttribute(RadiusStringAttribute(ratCHAPPassword, AnsiChar(vId)+vPass));
end;

procedure TRadiusPacket.AddAttributePassword(const APassword : RawByteString);
begin
  AddAttribute(RadiusStringAttribute(ratUserPassword, Generate_Password(APassword)));
end;

// CHAP-Password = MD5(ID + PASSWORD + CHALLENGE)
// CHALLENGE = CHAP-Challenge or Request Authenticator field
function TRadiusPacket.Generate_CHAP_Password(const APassword : RawByteString; const Id : Byte) : RawByteString;
var
  vEncode : RawByteString;
begin
  vEncode := AnsiChar(Id)+APassword+fAuthenticator;
  result := MD5(vEncode);
end;

function TRadiusPacket.Generate_Password(const APassword : RawByteString) : RawByteString;
var
  vPassword : RawByteString;
  vFMD5 : RawByteString;
  vBin : RawByteString;
  vXOR : RawByteString;
  Index : Integer;
  Section : Integer;
begin
  // The password is first padded at the end with nulls to a multiple of 16 octets.
  vPassword := APAssword + StringOfChar(#0, 16 - Length(APassword) mod 16);
  // A one-way MD5 hash is calculated over a stream of octets consisting of the shared secret followed by the Request Authenticator
  vFMD5 := fClient.Secret+fAuthenticator;
  // This value is XORed with the first 16 octet segment of the password and placed
  // in the first 16 octets of the String field of the User-Password Attribute
  SetLength(vXOR, Length(vPassword));
  SetLength(vBin, 16);
  Section := 1;
  while Section < Length(vPassword) do
  begin
    vFMD5 := MD5(vFMD5);
    for Index := Section to Section+16 do
      vXOR[Index] := AnsiChar(Ord(vPassword[Index]) xor Ord(vFMD5[Index-Section+1]));
    // If the password is longer than 16 characters, a second one-way MD5 hash is calculated over a
    // stream of octets consisting of the shared secret followed by the result of the first xor
    vFMD5 := fClient.Secret+Copy(vXOR, Section, Section+16);
    // That hash is XORed with the second 16 octet segment of the password and
    // placed in the second 16 octets of the String field of the User-Password Attribute.
    Inc(Section, 16);
  end;

  result := vXOR;
end;

function ParityBitStream(const Value : RawByteString) : RawByteString;
var
  vIndex : Integer;
  {$IFNDEF WIN32}
  vPIdx : Integer;
  {$ENDIF}
  vCurrPos : Word;
  vOdd : Boolean;
begin
  SetLength(result, 8);
  for vIndex := 0 to 7 do
  begin
    vCurrPos := vIndex * 7;
    if vIndex < 7 then
    begin
      result[vIndex+1] := AnsiChar(((Ord(Value[vCurrPos div 8 + 1]) shl (vCurrPos mod 8)) or (Ord(Value[vCurrPos div 8 + 2]) shr (8-vCurrPos mod 8))) and $FE);
    end else
      result[vIndex+1] := AnsiChar(Ord(Value[7]) shl 1);

    {$IFDEF WIN32}
    { Get parity directly from CPU FLAGS register }
    asm
      pushf;
      pop ax;
      and ax, 4;
      mov vOdd, al;
    end;
    {$ELSE}
    vOdd := True;
    for vPIdx := 1 to 7 do
      if ((1 shl vPIdx) and Ord(result[vIndex+1])) > 0 then vOdd := not vOdd;
    {$ENDIF}
    if vOdd then
      Inc(result[vIndex+1]);
  end;
end;

function TRadiusPacket.Generate_NTResponse_Password(const AUsername, APassword : RawByteString; var AChallenge : RawByteString; const Chap2 : Boolean = False) : RawByteString;
const
  MSCHAP_NT_CHALLENGE_SIZE = 8;
  MSCHAP2_CHALLENGE_SIZE = 16;
  NT_PASSWORD_HASH_SIZE = 16;
  MSCHAP_NT_RESPONSE_SIZE = 21;
var
  vPassHash : RawByteString;
  vIndex : Integer;
  vMSCHAPAtts : RawByteString;
  vPeerChallenge : RawByteString;

  function ChallengeHash(const peer_challenge, auth_challenge, username : RawByteString) : RawByteString;
  var
    vSHA1 : TIdHashSHA1;
    vUser : RawByteString;
    vSlash : Byte;
    {$IFNDEF DELPHIXE3}
    Stream: TStream;
    Buffer: RawByteString;
    HashRec: T5x4LongWordRecord;
    vBytes : TIdBytes;
    {$ENDIF}
  begin
    vSlash := Pos('\', username);
    if vSlash > 0
      then vUser := Copy(username, vSlash+1, Length(username)-vSlash-1)
      else vUser := username;

    vSHA1 := TIdHashSHA1.Create;
    try
      {$IFDEF DELPHIXE3}
      result := BytesToString(vSHA1.HashBytes(StringToBytes(peer_challenge+auth_challenge+vUser)));
      {$ELSE}
      Stream := TMemoryStream.Create;
      try
        Buffer := peer_challenge+auth_challenge+vUser;
        Stream.Write(Buffer[1], Length(Buffer));
        Stream.Seek(0, soFromBeginning);
        HashRec := vSHA1.HashValue(Stream);
        SetLength(vBytes, SizeOf(HashRec));
        Move(HashRec[0], vBytes, SizeOf(HashRec));
        result := BytesToString(vBytes);
      finally
        STream;
      end;
      {$ENDIF}
    finally
      vSHA1.Free;
    end;
    SetLength(result, MSCHAP_NT_CHALLENGE_SIZE);
  end;

  function ChallengeResponse(const AChallenge, APasswordHash : RawByteString) : RawByteString;
  var
    hash : RawByteString; //array[0..MSCHAP_NT_RESPONSE_SIZE] of Byte;
    resEnc : TArrayOf8Bytes;
    val : TArrayOf8Bytes;

    function StrTo8Bytes(const Value : RawByteString) : TArrayOf8Bytes; //inline;
    begin
      FillChar(result, 8, 0);
      Move(Value[1], Result[0], Length(Value));
    end;

  begin
    SetLength(result, 24);
    SetLength(hash, MSCHAP_NT_RESPONSE_SIZE);
    FillChar(hash[1], MSCHAP_NT_RESPONSE_SIZE, 0);
    Move(APasswordHash[1], hash[1], NT_PASSWORD_HASH_SIZE);
    Move(AChallenge[1], val[0], 8);
    DES(val, resEnc, StrTo8Bytes(ParityBitStream(Copy(hash, 1, 7))), True); Move(resEnc[0], result[1], 8);
    DES(val, resEnc, StrTo8Bytes(ParityBitStream(Copy(hash, 8, 7))), True); Move(resEnc[0], result[9], 8);
    DES(val, resEnc, StrTo8Bytes(ParityBitStream(Copy(hash, 15, 7))), True); Move(resEnc[0], result[17], 8);
  end;

begin
  // hash password
  SetLength(vPassHash, Length(APassword)*2);
  for vIndex := 1 to Length(APassword) do
  begin
    vPassHash[vIndex*2-1] := APassword[vIndex];
    vPassHash[vIndex*2] := AnsiChar(0);
  end;
  vPassHash := MD4String(vPassHash);

  vPeerChallenge := AChallenge;
  AChallenge := ChallengeHash(vPeerChallenge, fAuthenticator, AUsername);

  SetLength(vMSCHAPAtts, 26);
  FillChar(vMSCHAPAtts[1], 26, 0);

  if Chap2 then
  begin
    Move(vPeerChallenge[1], vMSCHAPAtts[3], Length(vPeerChallenge));
    result := vMSCHAPAtts+ChallengeResponse(AChallenge, vPassHash);
  end else
  begin
    vMSCHAPAtts[2] := AnsiChar(1);
    // generate challenge hash
    result := vMSCHAPAtts+ChallengeResponse(AChallenge, vPassHash);
  end;
end;

procedure TRadiusPacket.AddAttribute(const attr : PRadiusAttribute);
begin
  fAttributes.Add(attr);
end;

procedure TRadiusPacket.SaveToStream(Stream : TStream);
var
  vLength : Word;
  vIndex : Integer;
begin
  vLength := 20;
  for vIndex := 0 to fAttributes.Count-1 do
    Inc(vLength, GetAttribute(vIndex).Length);
  vLength := ((vLength shr 8) and $FF) or ((vLength and $FF) shl 8);

  Stream.Write(fCode, 1);
  Stream.Write(fIdentifier, 1);
  Stream.Write(vLength, 2);
  Stream.Write(fAuthenticator[1], 16);
  for vIndex := 0 to fAttributes.Count-1 do
    with GetAttribute(vIndex)^ do
    begin
      Stream.Write(raType, 1);
      Stream.Write(Length, 1);
      Stream.Write(Value[1], System.Length(Value));
    end;
end;

procedure TRadiusPacket.SaveToString(var Data : RawByteString);
var
  vStream : TMemoryStream;
begin
  vStream := TMemoryStream.Create;
  try
    SaveToStream(vStream);
    vStream.Seek(0, soFromBeginning);
    SetLength(Data, vStream.Size);
    vStream.Read(Data[1], vStream.Size);
  finally
    vStream.Free;
  end;
end;

procedure TRadiusPacket.LoadFromString(const Data : RawByteString);
var
  vLength : Word;
  vCurrPos : Integer;
  vAttribute : PRadiusAttribute;
begin
  fCode := TRadiusCode(Ord(Data[1]));
  fIdentifier := Ord(Data[2]);
  vLength := (Ord(Data[3]) shl 8) or Ord(Data[4]);
  SetLength(fAuthenticator, 16);
  Move(Data[5], fAuthenticator[1], 16);
  vCurrPos := 20;
  while vLength > vCurrPos+3 do
  begin
    New(vAttribute);
    vAttribute.raType := TRadiusAttributeType(ord(Data[vCurrPos+1]));
    vAttribute.Length := ord(Data[vCurrPos+2]);
    vAttribute.Value := Copy(Data, vCurrPos+3, vAttribute.Length-2);
    fAttributes.Add(vAttribute);
    Inc(vCurrPos, vAttribute.Length);
  end;
end;

function TRadiusPacket.VerifyAuthenticator(const PrevPacket : TRadiusPacket) : Boolean;
var
  vExpectedAuthenticator : RawByteString;
  vCurrPacket : RawByteString;
begin
  result := False;
  if Code in [rcAccessAccept, rcAccessReject, rcAccessChallenge] then
  begin
    SaveToString(vCurrPacket);
    vExpectedAuthenticator := MD5(Copy(vCurrPacket, 1, 4)+PrevPacket.Authenticator+Copy(vCurrPacket, 21, Length(vCurrPacket)-20)+fClient.Secret);
    result := vExpectedAuthenticator = fAuthenticator;
  end;
end;

function TRadiusPacket.GetLength : Word;
var
  vIndex : Integer;
begin
  result := 20;
  for vIndex := 0 to fAttributes.Count-1 do
    with GetAttribute(vIndex)^ do
      Inc(result, Length);
end;

function TRadiusPacket.HasAttribute(const attr : TRadiusAttributeType) : Boolean;
var
  vIndex : Integer;
begin
  result := False;
  for vIndex := 0 to fAttributes.Count-1 do
    if GetAttribute(vIndex).raType = attr then
    begin
      result := True;
      Break;
    end;
end;

function TRadiusPacket.RemoveAttribute(const attr : TRadiusAttributeType) : Boolean;
var
  vIndex : Integer;
begin
  result := False;
  for vIndex := 0 to fAttributes.Count-1 do
    if GetAttribute(vIndex).raType = attr then
    begin
      Dispose(fAttributes[vIndex]);
      fAttributes.Delete(vIndex);
      result := True;
      Break;
    end;
end;

function TRadiusPacket.GetAttribute(Index: Integer): PRadiusAttribute;
begin
  Result := PRadiusAttribute(fAttributes[Index]);
end;

function TRadiusPacket.GetAttributeValue(const attr : TRadiusAttributeType) : RawByteString;
var
  vIndex : Integer;
begin
  result := '';
  for vIndex := 0 to fAttributes.Count-1 do
    if GetAttribute(vIndex).raType = attr then
    begin
      result := result+GetAttribute(vIndex).Value;
    end;
end;

procedure TRadiusPacket.FinalizePacket(const PrevPacket : TRadiusPacket);
var
  vCurrPacket : RawByteString;
begin
  if not Assigned(PrevPacket) then Exit;
  if PrevPacket.Code in  [rcAccessReject, rcAccessChallenge, rcAccessAccept] then
  begin
    SaveToString(vCurrPacket);
    fAuthenticator := MD5(Copy(vCurrPacket, 1, 4)+PrevPacket.Authenticator+Copy(vCurrPacket, 21, Length(vCurrPacket)-20)+fClient.Secret);
  end;
end;

procedure TRadiusPacket.FreeAttributes;
var
  vIndex : Integer;
begin
  for vIndex := fAttributes.Count-1 downto 0 do
  begin
    Dispose(fAttributes[vIndex]);
    fAttributes.Delete(vIndex);
  end;
end;

{ TRadiusAnswerListener }

constructor TRadiusAnswerListener.Create(const APacketSend : RawByteString; AClient : TRadiusClient; const ATimeout : Word);
begin
  inherited Create(True);
  fClient := AClient;
  fPacketSend := APacketSend;
  fTimeout := ATimeout;
  FreeOnTerminate := True;
end;

procedure TRadiusAnswerListener.Execute;
var
  vResult : RawByteString;
  vPacket : TRadiusPacket;
  vPrevPacket : TRadiusPacket;
begin
  vPrevPacket := TRadiusPacket.Create(rcAccessRequest, fClient);
  try
    vPrevPacket.LoadFromString(fPacketSend);

    while fIteration < RADIUS_DATA_RETRY_COUNT do
    begin
      vResult := fClient.WaitForData(fTimeout);
{$IFDEF RADIUS_LOG}
      fClient.LogPacket(vResult);
{$ENDIF}

      if vResult <> '' then
      begin
        vPacket := TRadiusPacket.Create(rcAccessRequest, fClient);
        try
          vPacket.LoadFromString(vResult);
          if vPacket.VerifyAuthenticator(vPrevPacket) then
          begin
            if (vPacket.Code = rcAccessChallenge) and Assigned(fOnChallenge) then
              SynchronizeEvent(fOnChallenge, vPacket)
            else
            if (vPacket.Code = rcAccessAccept) and Assigned(fOnChallenge) then
              SynchronizeEvent(fOnAccept, vPacket)
            else
            if (vPacket.Code = rcAccessReject) and Assigned(fOnReject) then
              SynchronizeEvent(fOnReject, vPacket);
            Break; // delegate control back to the Client Manager
          end;
        finally
          vPacket.Free;
        end;

      end;
      // resend packet
      fClient.fUDPClient.SendBuffer(StringToBytes(fPacketSend));
      Inc(fIteration);
    end;
    if (fIteration >= RADIUS_DATA_RETRY_COUNT) and Assigned(fOnNoAnswer) then
      SynchronizeEvent(fOnNoAnswer, vPrevPacket);
  finally
    vPrevPacket.Free;
  end;
end;

procedure TRadiusAnswerListener.Synchronized;
begin
  fSyncEvent(Self, fSyncPacket);
end;

procedure TRadiusAnswerListener.SynchronizeEvent(Evt: TRadiusEvent;
  Pkt: TRadiusPacket);
begin
  fSyncPacket := Pkt;
  fSyncEvent := Evt;
  if fClient.FSynchronizeEvents then
    Synchronize(nil, Synchronized) else
    Synchronized;
end;

end.

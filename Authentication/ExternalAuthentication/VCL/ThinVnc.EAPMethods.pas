unit ThinVnc.EAPMethods;
{$I ThinVnc.DelphiVersion.inc}
interface

uses
  Windows, SysUtils, Classes;

type
{$IFNDEF DELPHIXE3}
  UInt32 = Cardinal;
  Int32 = Integer;
  RawByteString = AnsiString;
  PAnsiChar = PChar;
{$ENDIF}
{$IFDEF WIN64}
  size_t = UInt64;
{$ELSE}
  size_t = UInt32;
{$ENDIF}

  wpabuf  = record
    size : size_t; // total size of the allocated buffer
    used : size_t; // length of data in the buffer
    buf  : PByte;  // pointer to the head of the buffer
    flags : UInt32;
  end;
  pwpabuf = ^wpabuf;

  eap_method_type = record
	  vendor : integer;
	  method : uint32;
  end;
  peap_method_type = ^eap_method_type;

  eap_peer_data = record
    user : PAnsiChar;
    password : PAnsiChar;

    anonymous_identity : PAnsiChar;
    ca_cert : PAnsiChar;
    ca_path : PAnsiChar;
    client_cert : PAnsiChar;
    private_key : PAnsiChar;
    private_key_passwd : PAnsiChar;
    dh_file : PAnsiChar;
    subject_match : PAnsiChar;
    altsubject_match : PAnsiChar;
    ca_cert2 : PAnsiChar;
    client_cert2 : PAnsiChar;
    private_key2 : PAnsiChar;
    private_key2_passwd : PAnsiChar;
    dh_file2 : PAnsiChar;
    subject_match2 : PAnsiChar;
    altsubject_match2 : PAnsiChar;
    eap_methods : peap_method_type;
    phase1 : PAnsiChar;
    phase2 : PAnsiChar;
    pcsc : PAnsiChar;
    pin : PAnsiChar;
    engine : Integer;
    engine_id : PAnsiChar;
    engine2 : Int32;
    pin2 : PAnsiChar;
    engine2_id : PAnsiChar;
    key_id : PAnsiChar;
    cert_id : PAnsiChar;
    ca_cert_id : PAnsiChar;

    key2_id : PAnsiChar;
    cert2_id : PAnsiChar;
    fragment_size : Int32;

    resp : pwpabuf;
(*	struct eap_peer_ctx *eap_ctx;
	struct eapol_callbacks *eap_cb;
	struct eap_config *eap_conf;*)
  end;
  peap_peer_data = ^eap_peer_data;


type
  TEap = class
    private
      FEapData : peap_peer_data;
      FRunning : Boolean;
    protected
      procedure LoadIniValues;
      procedure ClearIniValues;
    public
      constructor Create;
      destructor Destroy; override;
      procedure SetLoginInfo(const AUser, APass : RawByteString);
      procedure Start;
      procedure Stop;
      function Step : Boolean;
      function TakeData : RawByteString;
      procedure Response(const Value : RawByteString);
  end;

implementation

uses
  IniFiles, ThinVnc.Paths;

var
  hIdEapMethods : THandle;

const
  EAPMETHODS_DLL_name = 'eap_methods.dll';
  EAP_IDENTIFY_HEX = '0100000501';
  RADIUS_INI_SECTION = 'RADIUS';

var
  eap_example_peer_init : function (eap_data : peap_peer_data) : integer; cdecl;
  eap_example_peer_deinit : procedure (eap_data : peap_peer_data); cdecl;
  eap_example_peer_step : procedure (eap_data : peap_peer_data); cdecl;
  create_eap_peer_data : function () : peap_peer_data; cdecl;
  free_eap_peer_data : procedure (eap_data : peap_peer_data); cdecl;
  eap_load_data : procedure (eap_data : peap_peer_data; const data : PByte; data_len : size_t); cdecl;

function HexToStr(const Value : RawByteString) : RawByteString; inline;
begin
  SetLength(Result, Length(Value) div 2);
  HexToBin(PAnsiChar(Value), PAnsiChar(result), Length(Value));
end;

function CreatePChar(const Value : string; const NullIfEmpty : Boolean = False) : PAnsiChar; inline; overload;
var
  Raw: RawByteString;
begin
  Raw := AnsiString(Value);
  if NullIfEmpty and (Raw = '') then Result := nil else
  begin
    Result := GetMemory(Length(Raw)+1);
    Move(Raw[1], Result[0], Length(Raw));
    Result[Length(Raw)] := #0;
  end;
end;

{$IFDEF DELPHIXE3}
function CreatePChar(const Value : RawByteString; const NullIfEmpty : Boolean = False) : PAnsiChar; inline; overload;
begin
  if NullIfEmpty and (Value = '') then Result := nil else
  begin
    Result := GetMemory(Length(Value)+1);
    Move(Value[1], Result[0], Length(Value));
    Result[Length(Value)] := #0;
  end;
end;
{$ENDIF}

// -------------------------- Basic API Functions ----------------------

function LoadFunctionCLib(const FceName: {$IFDEF UNDER_CE}TIdUnicodeString{$ELSE}string{$ENDIF}; const ACritical : Boolean = True): Pointer;
begin
  Result := {$IFDEF WIN32_OR_WIN64_OR_WINCE}Windows.{$ENDIF}GetProcAddress(hIdEapMethods, {$IFDEF UNDER_CE}PWideChar{$ELSE}PChar{$ENDIF}(FceName));
  if ACritical then
  begin
    if Result = nil then begin
      //FFailedFunctionLoadList.Add(FceName);
    end;
  end;
end;

function Load: Boolean;
begin
  Result := False;
  if hIdEapMethods = 0 then
  begin
    hIdEapMethods := SafeLoadLibrary(EAPMETHODS_DLL_name);
    if hIdEapMethods = 0 then exit;
    @eap_example_peer_init := LoadFunctionCLib('eap_example_peer_init');
    @eap_example_peer_deinit := LoadFunctionCLib('eap_example_peer_deinit');
    @eap_example_peer_step := LoadFunctionCLib('eap_example_peer_step');
    @create_eap_peer_data := LoadFunctionCLib('create_eap_peer_data');
    @free_eap_peer_data := LoadFunctionCLib('free_eap_peer_data');
    @eap_load_data := LoadFunctionCLib('eap_load_data');
    Result := True;
  end;
end;

{ TEap }

constructor TEap.Create;
begin
  inherited;
  Load;
  if hIdEapMethods <> 0 then
    FEapData := create_eap_peer_data
end;

destructor TEap.Destroy;
begin
  if FRunning then Stop;
  if hIdEapMethods <> 0 then
    free_eap_peer_data(FEapData);
  inherited;
end;

procedure TEap.SetLoginInfo(const AUser, APass : RawByteString);
begin
  FEapData.user := CreatePChar(AUser);
  FEapData.password := CreatePChar(APass);
end;

procedure TEap.LoadIniValues;
var
  IniFile : TIniFile;
  IniFileName : String;
begin
  IniFileName := ThinVncSettingsPath + ThinVncIniFileName;
  if not FileExists(IniFileName) then Exit;

  IniFile := TIniFile.Create(IniFileName);
  try
    FEapData.anonymous_identity := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'anonymous_identity',''), True);
    FEapData.ca_cert := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'ca_cert',''), True);
    FEapData.ca_path := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'ca_path',''), True);
    FEapData.client_cert := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'client_cert',''), True);
    FEapData.private_key := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'private_key',''), True);
    FEapData.private_key_passwd := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'private_key_passwd',''), True);
    FEapData.dh_file := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'dh_file',''), True);
    FEapData.subject_match := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'subject_match',''), True);
    FEapData.altsubject_match := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'altsubject_match',''), True);
    FEapData.ca_cert2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'ca_cert2',''), True);
    FEapData.client_cert2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'client_cert2',''), True);
    FEapData.private_key2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'private_key2',''), True);
    FEapData.private_key2_passwd := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'private_key2_passwd',''), True);
    FEapData.dh_file2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'dh_file2',''), True);
    FEapData.subject_match2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'subject_match2',''), True);
    FEapData.altsubject_match2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'altsubject_match2',''), True);
    if IniFile.ValueExists(RADIUS_INI_SECTION,'eap_methods_vendor') and IniFile.ValueExists(RADIUS_INI_SECTION,'eap_methods_method') then
    begin
      FEapData.eap_methods := GetMemory(SizeOf(eap_method_type));
      FEapData.eap_methods.vendor := IniFile.ReadInteger(RADIUS_INI_SECTION,'eap_methods_vendor',0);
      FEapData.eap_methods.method := Cardinal(IniFile.ReadInteger(RADIUS_INI_SECTION,'eap_methods_method',0));
    end;
    FEapData.phase1 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'phase1',''), True);
    FEapData.phase2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'phase2',''), True);
    FEapData.pcsc := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'pcsc',''), True);
    FEapData.pin := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'pin',''), True);
    FEapData.engine := IniFile.ReadInteger(RADIUS_INI_SECTION,'engine', 0);
    FEapData.engine_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'engine_id',''), True);
    FEapData.engine2 := IniFile.ReadInteger(RADIUS_INI_SECTION,'engine2', 0);
    FEapData.pin2 := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'pin2',''), True);
    FEapData.engine2_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'engine2_id',''), True);
    FEapData.key_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'key_id',''), True);
    FEapData.cert_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'cert_id',''), True);
    FEapData.ca_cert_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'ca_cert_id',''), True);
    FEapData.key2_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'key2_id',''), True);
    FEapData.cert2_id := CreatePChar(IniFile.ReadString(RADIUS_INI_SECTION,'cert2_id',''), True);
    FEapData.fragment_size := IniFile.ReadInteger(RADIUS_INI_SECTION,'fragment_size',0);
  finally
    IniFile.Free;
  end;
end;

procedure TEap.ClearIniValues;
begin
  if Assigned(FEapData.anonymous_identity) then FreeMemory(FEapData.anonymous_identity);
  if Assigned(FEapData.ca_cert) then FreeMemory(FEapData.ca_cert);
  if Assigned(FEapData.ca_path) then FreeMemory(FEapData.ca_path);
  if Assigned(FEapData.client_cert) then FreeMemory(FEapData.client_cert);
  if Assigned(FEapData.private_key) then FreeMemory(FEapData.private_key);
  if Assigned(FEapData.private_key_passwd) then FreeMemory(FEapData.private_key_passwd);
  if Assigned(FEapData.dh_file) then FreeMemory(FEapData.dh_file);
  if Assigned(FEapData.subject_match) then FreeMemory(FEapData.subject_match);
  if Assigned(FEapData.altsubject_match) then FreeMemory(FEapData.altsubject_match);
  if Assigned(FEapData.ca_cert2) then FreeMemory(FEapData.ca_cert2);
  if Assigned(FEapData.client_cert2) then FreeMemory(FEapData.client_cert2);
  if Assigned(FEapData.private_key2) then FreeMemory(FEapData.private_key2);
  if Assigned(FEapData.private_key2_passwd) then FreeMemory(FEapData.private_key2_passwd);
  if Assigned(FEapData.dh_file2) then FreeMemory(FEapData.dh_file2);
  if Assigned(FEapData.subject_match2) then FreeMemory(FEapData.subject_match2);
  if Assigned(FEapData.altsubject_match2) then FreeMemory(FEapData.altsubject_match2);
  if Assigned(FEapData.phase1) then FreeMemory(FEapData.phase1);
  if Assigned(FEapData.phase2) then FreeMemory(FEapData.phase2);
  if Assigned(FEapData.pcsc) then FreeMemory(FEapData.pcsc);
  if Assigned(FEapData.pin) then FreeMemory(FEapData.pin);
  if Assigned(FEapData.engine_id) then FreeMemory(FEapData.engine_id);
  if Assigned(FEapData.pin2) then FreeMemory(FEapData.pin2);
  if Assigned(FEapData.engine2_id) then FreeMemory(FEapData.engine2_id);
  if Assigned(FEapData.key_id) then FreeMemory(FEapData.key_id);
  if Assigned(FEapData.cert_id) then FreeMemory(FEapData.cert_id);
  if Assigned(FEapData.ca_cert_id) then FreeMemory(FEapData.ca_cert_id);
  if Assigned(FEapData.key2_id) then FreeMemory(FEapData.key2_id);
  if Assigned(FEapData.cert2_id) then FreeMemory(FEapData.cert2_id);
  if Assigned(FEapData.eap_methods) then FreeMemory(FEapData.eap_methods);
end;

procedure TEap.Start;
begin
  if FRunning then Exit;
  LoadIniValues;
  if eap_example_peer_init(FEapData) < 0 then Exit;
  FRunning := True;
  Response(HexToStr(EAP_IDENTIFY_HEX));
end;

procedure TEap.Response(const Value : RawByteString);
begin
  eap_load_data(FEapData, PByte(PAnsiChar(Value)), Length(Value));
end;

procedure TEap.Stop;
begin
  if not FRunning then Exit;
  eap_example_peer_deinit(FEapData);
  ClearIniValues;
  FRunning := False;
end;

function TEap.Step : Boolean;
begin
  eap_example_peer_step(FEapData);
  result := Assigned(FEapData.resp) and (FEapData.resp.size > 0);
end;

function TEap.TakeData : RawByteString;
begin
  if not Assigned(FEapData.resp) then
    raise Exception.Create('No data available');

  SetLength(result, FEapData.resp.used);
  Move(FEapData.resp.buf^, result[1], FEapData.resp.used);
end;

initialization
//  Load;
finalization
  if hIdEapMethods <> 0 then
  begin
    hIdEapMethods := 0;
    FreeLibrary(hIdEapMethods);
  end;
end.

unit RemotePrinter_SDK;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// $Rev: 52393 $
// File generated on 04/30/2020 6:12:59 PM from Type Library described below.

// ************************************************************************  //
// Type Lib: C:\GitHub\dev-vclib\products\vclib\bin32\Thinfinity.RemotePrinter.dll (1)
// LIBID: {82EB5ECE-3997-42FA-9982-656CCA275506}
// LCID: 0
// Helpfile: 
// HelpString: 
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\SysWOW64\stdole2.tlb)
// SYS_KIND: SYS_WIN32
// Errors:
//   Hint: TypeInfo 'Type' changed to 'Type_'
// ************************************************************************ //
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}
{$VARPROPSETTER ON}
{$ALIGN 4}

interface

uses Winapi.Windows, SysUtils, Registry, System.Classes, System.Variants, System.Win.StdVCL, Vcl.Graphics, Vcl.OleServer, Winapi.ActiveX;

{$REGION 'RemotePrinter_TLB Declaration'}
// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLASS_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  RemotePrinterMajorVersion = 1;
  RemotePrinterMinorVersion = 0;

  LIBID_RemotePrinter: TGUID = '{82EB5ECE-3997-42FA-9982-656CCA275506}';

  IID_IPrinter: TGUID = '{211F21DB-409D-454A-90BB-F39C489608EA}';
  CLASS_Printer: TGUID = '{659F0A04-EDFB-4A61-B105-C035AB62553F}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library                    
// *********************************************************************//
// Constants for enum Encode
type
  Encode = TOleEnum;
const
  PRINT_ENCODE_ANSI = $00000000;
  PRINT_ENCODE_UTF8 = $00000001;

// Constants for enum Type_
type
  Type_ = TOleEnum;
const
  PRINT_TYPE_RAW = $00000001;
  PRINT_TYPE_XPS = $00000003;
  PRINT_TYPE_PDF = $00000004;
  PRINT_TYPE_DIRECT = $00000005;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  IPrinter = interface;
  IPrinterDisp = dispinterface;

// *********************************************************************//
// Interface: IPrinter
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {211F21DB-409D-454A-90BB-F39C489608EA}
// *********************************************************************//
  IPrinter = interface(IDispatch)
    ['{211F21DB-409D-454A-90BB-F39C489608EA}']
    function BeginDoc(PrintType: Integer; const PrinterName: WideString; const DocName: WideString;
                      Encoding: Integer; out DocID: WideString): WordBool; safecall;
    function Print(const DocID: WideString; const Data: WideString): WordBool; safecall;
    function EndDoc(const DocID: WideString): WordBool; safecall;
    function Abort(const DocID: WideString): WordBool; safecall;
    procedure LastError(out ErrorCode: Integer; out ErrorMessage: WideString); safecall;
    function GetPrinters(const Delimiter: WideString; out Printers: WideString): WordBool; safecall;
    function PrintFile(PrintType: Integer; const FileName: WideString;
                        const PrinterName: WideString): WordBool; safecall;
  end;

// *********************************************************************//
// DispIntf:  IPrinterDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {211F21DB-409D-454A-90BB-F39C489608EA}
// *********************************************************************//
  IPrinterDisp = dispinterface
    ['{211F21DB-409D-454A-90BB-F39C489608EA}']
    function BeginDoc(PrintType: Integer; const PrinterName: WideString; const DocName: WideString;
                      Encoding: Integer; out DocID: WideString): WordBool; dispid 201;
    function Print(const DocID: WideString; const Data: WideString): WordBool; dispid 202;
    function EndDoc(const DocID: WideString): WordBool; dispid 203;
    function Abort(const DocID: WideString): WordBool; dispid 204;
    procedure LastError(out ErrorCode: Integer; out ErrorMessage: WideString); dispid 205;
    function GetPrinters(const Delimiter: WideString; out Printers: WideString): WordBool; dispid 206;
    function PrintFile(PrintType: Integer; const FileName: WideString;
                        const PrinterName: WideString): WordBool; dispid 207;
  end;

// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TPrinter
// Help String      : Thinfinity Printer Channel API (RemotePrinter)
// Default Interface: IPrinter
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TPrinter = class(TInterfacedObject, IPrinter)
  private
    FIPrinter: IPrinter;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;
  public
    constructor Create;
    destructor Destroy; override;
    function BeginDoc(PrintType: Integer; const PrinterName: WideString; const DocName: WideString;
                      Encoding: Integer; out DocID: WideString): WordBool; safecall;
    function Print(const DocID: WideString; const Data: WideString): WordBool; safecall;
    function EndDoc(const DocID: WideString): WordBool; safecall;
    function Abort(const DocID: WideString): WordBool; safecall;
    procedure LastError(out ErrorCode: Integer; out ErrorMessage: WideString); safecall;
    function GetPrinters(const Delimiter: WideString; out Printers: WideString): WordBool; safecall;
    function PrintFile(PrintType: Integer; const FileName: WideString;
                        const PrinterName: WideString): WordBool; safecall;
  end;

{$ENDREGION 'RemotePrinter_TLB Declaration'}

/// <summary>
///   Returns a global TPrinter object.
/// </summary>
function RemotePrinter: TPrinter;
/// <summary>
///   Returns the path where Thinfinity.RemotePrinter.dll is located.
/// </summary>
function GetDllDir:string;

implementation

uses IniFiles;

var
  GRemotePrinter: TPrinter;
  LibHandle: THandle;
  DllGetInstance: function(var Value: IPrinter):HResult; stdcall;

{$IFDEF DELPHI5}
//DELPHI5
function IsDebuggerPresent: BOOL; stdcall; external 'kernel32.dll' name 'IsDebuggerPresent';
function IncludeTrailingPathDelimiter(Value: String): String;
var L: Integer;
begin
  Result := Value;
  L := Length(Result);
  if (L > 0) and (Result[L] <> '\') then
    Result := Result + '\';
end;
procedure RaiseLastOSError;
begin
  RaiseLastWin32Error;
end;
{$ELSE}
//DELPHI6 and DELPHI7
  {$IFDEF DELPHI2010_PLUS}
  {$ELSE}
  function IsDebuggerPresent: BOOL; stdcall; external 'kernel32.dll' name 'IsDebuggerPresent';
  {$ENDIF}
{$ENDIF}

function RemotePrinter: TPrinter;
begin
  if not Assigned(GRemotePrinter) then begin
    GRemotePrinter := TPrinter.Create();
  end;
  Result := GRemotePrinter;
end;

function GetModulePath: string;
begin
  SetLength(Result, MAX_PATH);
  SetLength(Result, GetModuleFileName(0, PChar(Result), MAX_PATH));
  Result := ExtractFilePath(Result);
end;

function GetDllDir: string;
var
  reg: TRegistry;
  key32, key64, aux: string;
  DevMode: Boolean;
  Ini: TIniFile;
begin
  aux := '';
  Result := '';
{$IFDEF FPC}
  DevMode := IsDebuggerPresent;
{$ELSE}
  {$IFDEF DELPHI6_PLUS} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
  DevMode := ((DebugHook <> 0) or IsDebuggerPresent);
  {$IFDEF DELPHI6_PLUS} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
{$ENDIF}
  key32 := '\SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\RemotePrinter';
  key64 := '\SOFTWARE\Cybele Software\Setups\Thinfinity\RemotePrinter';
  if DevMode then
  begin
    aux := '\Dev';
  end else if FileExists(GetModulePath + 'OEM.ini') then
  begin
    Ini := TIniFile.Create(GetModulePath + 'OEM.ini');
    try
      key32 := Ini.ReadString('PATHS', 'Key32', key32);
      key64 := Ini.ReadString('PATHS', 'Key64', key64);
    finally
      Ini.Free;
    end;
  end;
  reg := TRegistry.Create(KEY_QUERY_VALUE or KEY_ENUMERATE_SUB_KEYS);
  try
    reg.RootKey:=HKEY_LOCAL_MACHINE;
    if reg.OpenKeyReadOnly(key32+aux) or
      reg.OpenKeyReadOnly(key64+aux) then
    begin
      {$IFDEF WIN32}
      if Reg.ValueExists('TargetDir_x86') then
        Result := IncludeTrailingPathDelimiter(reg.ReadString('TargetDir_x86'));
      {$ELSE}
      if Reg.ValueExists('TargetDir_x64') then
        Result := IncludeTrailingPathDelimiter(reg.ReadString('TargetDir_x64'));
      {$ENDIF}
    end
    else
      Result := ExtractFilePath(ParamStr(0));
  finally
    reg.Free;
  end;
end;

procedure LoadLib;
var
  Filename: string;
begin
 if LibHandle = 0 then
  begin
    Filename := 'Thinfinity.RemotePrinter.dll';
    LibHandle := LoadLibrary(PChar(GetDllDir + Filename));
    if LibHandle = 0 then Exit;
    try
      @DllGetInstance := GetProcAddress(LibHandle, 'DllGetInstance');
      if Pointer(@DllGetInstance) = nil then RaiseLastOSError;
    except
      FreeLibrary(LibHandle);
      LibHandle := 0;
      raise;
    end;
  end;
end;


{$REGION 'RemotePrinter_TLB Implementation'}

function TPrinter.GetTypeInfoCount(out Count: Integer): HResult;
begin
  if Assigned(FIPrinter) then
  Result := FIPrinter.GetTypeInfoCount(Count)
  else begin
    Result := 0;
    Count := 0;
  end;
end;

function TPrinter.GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult;
begin
  if Assigned(FIPrinter) then
    Result := FIPrinter.GetTypeInfo(Index, LocaleID, TypeInfo)
  else begin
    Result := E_NOTIMPL;
    Pointer(TypeInfo) := nil;
  end;
end;

function TPrinter.GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  if Assigned(FIPrinter) then
    Result := FIPrinter.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs)
  else
    Result := E_NOTIMPL;
end;

function TPrinter.Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
begin
  if Assigned(FIPrinter) then
    Result := FIPrinter.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr)
  else
    Result := E_NOTIMPL;
end;

constructor TPrinter.Create();
begin
if Assigned(DllGetInstance) then
  begin
    DllGetInstance(FIPrinter);
  end;
end;

destructor TPrinter.Destroy;
begin
  inherited Destroy;
end;

/// <summary>
/// BeginDoc to initiate a print job to the remote printer.
/// If the print job is sent successfully, this result true.
/// Otherwise the LastError inform that happend.
/// the application calls EndDoc to end the print job.
/// </summary>
function TPrinter.BeginDoc(PrintType: Integer; const PrinterName: WideString;
                           const DocName: WideString; Encoding: Integer; out DocID: WideString): WordBool;
begin
  Result := False;
  if Assigned(FIPrinter) then
    Result := FIPrinter.BeginDoc(PrintType, PrinterName, DocName, Encoding, DocID);
end;

/// <summary>
/// Print and send data to remote printer directly
/// when EndDoc is called the Print Job will start.
/// </summary>
function TPrinter.Print(const DocID: WideString; const Data: WideString): WordBool;
begin
  Result := False;
  if Assigned(FIPrinter) then
    Result := FIPrinter.Print(DocID, Data);
end;

/// <summary>
/// EndDoc to start the remote Printer job.
/// if Sucessfull return true. Otherwise see the error calling LastError.
/// </summary>
function TPrinter.EndDoc(const DocID: WideString): WordBool;
begin
  Result := False;
  if Assigned(FIPrinter) then
  Result := FIPrinter.EndDoc(DocID);
end;

/// <summary>
/// You can cancel printing by calling Abort.
/// In case of error, after StartDoc you must abort.
/// </summary>
function TPrinter.Abort(const DocID: WideString): WordBool;
begin
  Result := False;
  if Assigned(FIPrinter) then
    Result := FIPrinter.Abort(DocID);
end;

/// <summary>
/// Its show the last error found.
/// </summary>
procedure TPrinter.LastError(out ErrorCode: Integer; out ErrorMessage: WideString);
begin
  if Assigned(FIPrinter) then
    FIPrinter.LastError(ErrorCode, ErrorMessage);
end;

/// <summary>
/// Gets the list of remote printers names.
/// </summary>
function TPrinter.GetPrinters(const Delimiter: WideString; out Printers: WideString): WordBool;
begin
  Result := False;
  if Assigned(FIPrinter) then
    Result := FIPrinter.GetPrinters(Delimiter, Printers);
end;

function TPrinter.PrintFile(PrintType: Integer; const FileName: WideString;
                            const PrinterName: WideString): WordBool;
begin
  Result := False;
  if Assigned(FIPrinter) then
    Result := FIPrinter.PrintFile(PrintType, FileName, PrinterName);
end;
{$ENDREGION 'RemotePrinter_TLB Implementation'}

initialization
  LoadLib;
finalization
  FreeAndNil(GRemotePrinter);
end.

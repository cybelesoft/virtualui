library Thinfinity.Server.ExternalAuth.WinLogon;

{ Important note about DLL memory management: ShareMem must be the
  first unit in your library's USES clause AND your project's (select
  Project-View Source) USES clause if your DLL exports any procedures or
  functions that pass strings as parameters or function results. This
  applies to all strings passed to and from your DLL--even those that
  are nested in records and classes. ShareMem is the interface unit to
  the BORLNDMM.DLL shared memory manager, which must be deployed along
  with your DLL. To avoid using BORLNDMM.DLL, pass string information
  using PChar or ShortString parameters. }

uses
  System.SysUtils,
  System.Classes,
  Winapi.Windows,
  System.StrUtils;

{$R *.res}

function ValidateUser(const UserName, Password, Metadata: PWideChar;
  SecurityRole, WinUser, WinPass, CustomData: PWideChar;
  var Handled: Boolean): Cardinal; stdcall;
var
  I: Integer;
  lpszDomain, lpszUserName: string;
  Token: THandle;
begin
  Handled := True;
  I := Pos('\', UserName);
  if I = 0 then
  begin
    lpszDomain := '';
    lpszUserName := UserName;
  end else begin
    lpszDomain := Copy(UserName, 1, I - 1);
    lpszUserName := Copy(UserName, I + 1, MaxInt);
  end;
  if LogonUser(PChar(lpszUserName), PChar(lpszDomain), PChar(Password), LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, Token) then
    Result := NO_ERROR else
    Result := GetLastError;
  if Result = NO_ERROR then
  begin
    CloseHandle(Token);
    StrPCopy(SecurityRole, StrPas(UserName));
    StrPCopy(WinUser, StrPas(UserName));
    StrPCopy(WinPass, StrPas(Password));
    StrPCopy(CustomData, Format('{"loggedOn":"%s"}', [FormatDateTime('YYYY-MM-DD HH:NN:SS.ZZZ', Now)]));
  end;
end;

exports
  ValidateUser;

end.

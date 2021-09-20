library Thinfinity.Server.ExternalAuth.IniFile;

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
  System.IniFiles,
  Winapi.Windows;

{$R *.res}

function ValidateUser(const UserName, Password, Metadata: PWideChar;
  SecurityRole, WinUser, WinPass, CustomData: PWideChar;
  var Handled: Boolean): Cardinal; stdcall;
var
  FileName: string;
  FindUser: WideString;
  MapRole: WideString;
  IniFile: TIniFile;
begin
  Handled := True;
  FileName := GetModuleName(HInstance);
  FileName := ExtractFilePath(FileName) + 'IniFile\AllowedUsers.ini';
  IniFile := TIniFile.Create(FileName);
  try
    if IniFile.ReadString('USERS', UserName, '') = Password then
    begin
      Result := NO_ERROR;
      MapRole := IniFile.ReadString('ROLES', UserName, '');
      StrPCopy(SecurityRole, StrPas(PWideChar(MapRole)));
      StrPCopy(CustomData, Format('{"user":"%s"}', [UserName]));
      Exit;
    end;
  finally
    IniFile.Free;
  end;
  Result := ERROR_BAD_USERNAME;
end;

exports
  ValidateUser;

end.


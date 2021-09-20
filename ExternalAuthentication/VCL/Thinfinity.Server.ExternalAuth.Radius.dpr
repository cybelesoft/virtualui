library Thinfinity.Server.ExternalAuth.Radius;

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
  System.IniFiles,
  ThinVnc.Log,
  ThinVnc.EncrDecr,
  ThinVnc.RadiusClient;

{$R *.res}

var
  gConfigPath: string;
  gConfigFile: string;

procedure SetEnvironment(const ConfigPath, ConfigFile: PWideChar); stdcall;
begin
  LogMethod('Radius', 'SetEnvironment');
  LogInfo('ConfigPath: %s', [ConfigPath]);
  LogInfo('ConfigFile: %s', [ConfigFile]);
  gConfigPath := ConfigPath;
  gConfigFile := ConfigFile;
end;

function ValidateUser(const UserName, Password, Metadata: PWideChar;
  SecurityRole, WinUser, WinPass, CustomData: PWideChar;
  var Handled: Boolean): Cardinal; stdcall;
var
  IniFile: TIniFile;
  RadiusClient : TRadiusClient;
  Answer : TRadiusLoginAnswer;
  Packet : TRadiusPacket;
begin
  Handled := True;
  IniFile := TIniFile.Create(gConfigPath + gConfigFile);
  try
    if not IniFile.ReadBool('RADIUS', 'Enabled', False) then
    begin
      Result := ERROR_INSUFFICIENT_BUFFER;
      Exit;
    end;
    RadiusClient := TRadiusClient.Create;
    try
      RadiusClient.SetRadiusServer(IniFile.ReadString('RADIUS', 'Server', ''), StrToIntDef(IniFile.ReadString('RADIUS', 'Port', ''), 1812), DecryptString(IniFile.ReadString('RADIUS', 'Secret', ''), True));
      RadiusClient.LoginType := TRadiusLoginType(IniFile.ReadInteger('RADIUS', 'AuthType', 0));
      RadiusClient.SyncLogin(Username, Password, Answer, Packet);
      try
        if Answer = rlaSuccess then
        begin
          Result := NO_ERROR;
          StrPCopy(SecurityRole, StrPas(UserName));
          StrPCopy(WinUser, StrPas(UserName));
          StrPCopy(WinPass, StrPas(Password));
          StrPCopy(CustomData, Format('{"loggedOn":"%s"}', [FormatDateTime('YYYY-MM-DD HH:NN:SS.ZZZ', Now)]));
        end else
          Result := ERROR_INVALID_PASSWORD;
      finally
        Packet.Free;
      end;
    finally
      RadiusClient.Free;
    end;
  finally
    IniFile.Free;
  end;
end;

exports
  SetEnvironment,
  ValidateUser;

begin
  Product := 'VirtualUISdk';
  CreateLog;
end.


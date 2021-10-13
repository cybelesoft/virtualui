/// <summary>
///   This unit contains wrapper classes to the VirtualUI COM API, to make
///   easier the use of VirtualUI in the application.
/// </summary>
unit VirtualUI_SDK;
{$IFDEF FPC}
  {$mode Delphi}
  {$H+}
{$ELSE}
  {$IFDEF VER90}{$DEFINE NOTSUPPORTED}{$ENDIF}
  {$IFDEF VER100}{$DEFINE NOTSUPPORTED}{$ENDIF}
  {$IFDEF VER110}{$DEFINE NOTSUPPORTED}{$ENDIF}
  {$IFDEF VER120}{$DEFINE NOTSUPPORTED}{$ENDIF}
  {$IFDEF NOTSUPPORTED}
  STOP! // This compiler version is not supported through this library
  {$ENDIF}
  {$IFDEF VER130}
    {$DEFINE DELPHI5}
  {$ELSE}
    {$IF CompilerVersion >= 14}
      {$DEFINE DELPHI6_PLUS}
    {$IFEND}
    {$IF CompilerVersion >= 21}
      {$DEFINE DELPHI2010_PLUS}
    {$IFEND}
    {$IF CompilerVersion >= 22}
      {$DEFINE DELPHIXE_PLUS}
    {$IFEND}
    {$IF CompilerVersion >= 23}
      {$DEFINE DELPHIXE2_PLUS}
    {$IFEND}
  {$ENDIF}
{$ENDIF}
interface

uses Windows, SysUtils, Registry, ActiveX, ComObj
  {$IFDEF DELPHI6_PLUS},Variants{$ENDIF};

const
  OPT_PLAYDELAY    = $00000001;

  // TypeLibrary Major and minor versions
  VirtualUIMajorVersion = 1;
  VirtualUIMinorVersion = 0;

  LIBID_VirtualUI: TGUID = '{602E7D48-65C8-4FF0-B8C9-0B5D6444C0DD}';

  IID_IVirtualUI: TGUID = '{4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511}';
  DIID_IEvents: TGUID = '{1C5700BC-2317-4062-B614-0A4E286CFE68}';
  CLASS_VirtualUI_: TGUID = '{FD75863C-3C8B-486D-8859-FF09944E354C}';
  IID_IBrowserInfo: TGUID = '{4D9F5347-460B-4275-BDF2-F2738E7F6757}';
  CLASS_BrowserInfo: TGUID = '{E7E261CC-7722-466E-BD13-3D323E2700AA}';
  IID_IDevServer: TGUID = '{B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80}';
  CLASS_DevServer: TGUID = '{641E179D-7971-4C53-9AEB-B56519C9BE8A}';
  IID_IClientSettings: TGUID = '{439624CA-ED33-47BE-9211-91290F29584A}';
  CLASS_ClientSettings: TGUID = '{21952973-879D-4709-B7C9-EE01CEB53E2F}';

  IID_IJSValue: TGUID = '{6DE2E6A0-3C3A-47DC-9A93-928135EDAC90}';
  CLASS_JSValue: TGUID = '{A57C4C20-5764-44CE-9BF1-791BAE24DE47}';
  IID_IJSNamedValue: TGUID = '{E492419B-00AC-4A91-9AE9-9A82B07E89AE}';
  CLASS_JSNamedValue: TGUID = '{CA50114F-A140-4F0C-B59D-EF8BE48A960D}';
  IID_IJSObject: TGUID = '{59342310-79A7-4B14-8B63-6DF05609AE30}';
  DIID_IJSObjectEvents: TGUID = '{A3D640E8-CD18-4196-A1A2-C87C82B0F88B}';
  CLASS_JSObject: TGUID = '{AEF8F61A-6AD3-4128-A55A-DE4B5FAE8772}';
  IID_IJSObjects: TGUID = '{C2406011-568E-4EAC-B95C-EF29E4806B86}';
  CLASS_JSObjects: TGUID = '{D9FCD94A-816F-4F65-A958-E27757FEB443}';
  IID_IJSProperty: TGUID = '{1F95C0E9-E7BF-48C9-AA35-88AD0149109B}';
  CLASS_JSProperty: TGUID = '{8CA91877-612B-40A8-BC01-9D6FE744A763}';
  IID_IJSProperties: TGUID = '{FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C}';
  CLASS_JSProperties: TGUID = '{D9D8A613-7603-4243-A8CE-9DFF6C1B61F1}';
  IID_IJSArgument: TGUID = '{8F8C4462-D7B5-4696-BAD5-16DFAA6E2601}';
  CLASS_JSArgument: TGUID = '{7B35A051-270C-4AD5-B5DC-E8A2F40A763A}';
  IID_IJSArguments: TGUID = '{FC097EF5-6D8A-4C80-A2AD-382FDC75E901}';
  CLASS_JSArguments: TGUID = '{7E1B6C68-1236-4C60-A6CB-B21AE3392F52}';
  IID_IJSMethod: TGUID = '{C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E}';
  CLASS_JSMethod: TGUID = '{FE458A7D-4523-4123-BD22-643DF9FDB40C}';
  IID_IJSMethods: TGUID = '{E4CB461F-586E-4121-ABD7-345B87BC423A}';
  CLASS_JSMethods: TGUID = '{F7257AE9-DF71-4B22-BF5C-87FF0B8DC050}';
  IID_IJSEvent: TGUID = '{8B66EACD-9619-43CF-9196-DCDA17F5500E}';
  CLASS_JSEvent: TGUID = '{5F7B6683-1966-4940-81C6-D193DC76717B}';
  IID_IJSEvents: TGUID = '{6AE952B3-B6DA-4C81-80FF-D0A162E11D02}';
  CLASS_JSEvents: TGUID = '{1F89D193-9196-4928-8D0A-CB2BF9D6B915}';
  IID_IJSBinding: TGUID = '{ACFC2953-37F1-479E-B405-D0BB75E156E6}';
  IID_IJSCallback: TGUID = '{ADD570A0-491A-4E40-8120-57B4D1245FD3}';
  IID_IRecorder: TGUID = '{D89DA2B6-B7BF-4065-80F5-6D78B331C7DD}';
  CLASS_Recorder: TGUID = '{0FCB73F2-3DFC-41BD-95B8-E80F93E8AAFB}';
  IID_IRecTrack: TGUID = '{D4744AE1-70CB-43DD-BEA5-A5310B2E24C6}';
  CLASS_RecTrack: TGUID = '{3914D764-CE39-4BFD-8A44-B66ACE11964F}';
  IID_IRecTracks: TGUID = '{AB45B615-9309-471E-A455-3FE93F88E674}';
  CLASS_RecTracks: TGUID = '{DE457068-59B5-4CEC-B47C-406B9C69F4C6}';
  IID_IFileSystemFilter: TGUID = '{3FE99D2F-0CFC-43D1-B762-0C7C15EB872E}';
  CLASS_FileSystemFilter: TGUID = '{6D4BFB79-42EC-4645-B3EF-45863313E0BA}';
  IID_IRegistryFilter: TGUID = '{4834F840-915B-488B-ADEA-98890A04CEE6}';
  CLASS_RegistryFilter: TGUID = '{021CCCAA-498A-4E30-A84C-483ABDDBC1AB}';
  IID_IHTMLDoc: TGUID = '{A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0}';
  CLASS_HTMLDoc: TGUID = '{E5B8CA73-B236-4350-BC12-917F0D687227}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library
// *********************************************************************//
// Constants for enum IJSDataType
type
  IJSDataType = TOleEnum;
const
  JSDT_NULL = $00000000;
  JSDT_STRING = $00000001;
  JSDT_INT = $00000002;
  JSDT_BOOL = $00000003;
  JSDT_FLOAT = $00000004;
  JSDT_JSON = $00000005;

// Constants for enum Orientation
type
  Orientation = TOleEnum;
const
  PORTRAIT = $00000000;
  LANDSCAPE = $00000001;

// Constants for enum MouseMoveGestureStyle
type
  MouseMoveGestureStyle = TOleEnum;
const
  MM_STYLE_RELATIVE = $00000000;
  MM_STYLE_ABSOLUTE = $00000001;

// Constants for enum MouseMoveGestureAction
type
  MouseMoveGestureAction = TOleEnum;
const
  MM_ACTION_MOVE = $00000000;
  MM_ACTION_WHEEL = $00000001;

// Constants for enum RecorderState
type
  RecorderState = TOleEnum;
const
  Inactive = $00000000;
  Recording = $00000001;
  Playing = $00000002;

// Constants for enum DragAction
type
  DragAction = TOleEnum;
const
  DA_START = $00000000;
  DA_OVER = $00000001;
  DA_DROP = $00000002;
  DA_CANCEL = $00000003;
  DA_ERROR = $00000063;

// Constants for enum Options
type
  Options = TOleEnum;

const
  OPT_APPINVISIBLE = $00000001;
  OPT_IGNORE_MOUSEMOVE = $00000002;
  OPT_NODEFAULT_PRINTER = $00000004;
  OPT_NOHTML_DRAG = $00000010;
  OPT_NOHTML_SIZE = $00000040;
  OPT_JSRO_SYNCCALLS = $00000020;
  OPT_CLIPBOARD_LOCAL = $00000100;
  OPT_SUPRESS_PRINT_DIALOG = $00000200;
  OPT_AUTODOWNLOAD = $00001000;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary
// *********************************************************************//
  IVirtualUI = interface;
  IVirtualUIDisp = dispinterface;
  IEvents = dispinterface;
  IBrowserInfo = interface;
  IBrowserInfoDisp = dispinterface;
  IDevServer = interface;
  IDevServerDisp = dispinterface;
  IClientSettings = interface;
  IClientSettingsDisp = dispinterface;
  IJSValue = interface;
  IJSValueDisp = dispinterface;
  IJSNamedValue = interface;
  IJSNamedValueDisp = dispinterface;
  IJSObject = interface;
  IJSObjectDisp = dispinterface;
  IJSObjectEvents = dispinterface;
  IJSObjects = interface;
  IJSObjectsDisp = dispinterface;
  IJSProperty = interface;
  IJSPropertyDisp = dispinterface;
  IJSProperties = interface;
  IJSPropertiesDisp = dispinterface;
  IJSArgument = interface;
  IJSArgumentDisp = dispinterface;
  IJSArguments = interface;
  IJSArgumentsDisp = dispinterface;
  IJSMethod = interface;
  IJSMethodDisp = dispinterface;
  IJSMethods = interface;
  IJSMethodsDisp = dispinterface;
  IJSEvent = interface;
  IJSEventDisp = dispinterface;
  IJSEvents = interface;
  IJSEventsDisp = dispinterface;
  IJSBinding = interface;
  IJSBindingDisp = dispinterface;
  IJSCallback = interface;
  IJSCallbackDisp = dispinterface;
  IRecorder = interface;
  IRecorderDisp = dispinterface;
  IRecTrack = interface;
  IRecTrackDisp = dispinterface;
  IRecTracks = interface;
  IRecTracksDisp = dispinterface;
  IFileSystemFilter = interface;
  IFileSystemFilterDisp = dispinterface;
  IRegistryFilter = interface;
  IRegistryFilterDisp = dispinterface;
  IHTMLDoc = interface;
  IHTMLDocDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library
// (NOTE: Here we map each CoClass to its Default Interface)
// *********************************************************************//
  VirtualUI_ = IVirtualUI;
  BrowserInfo = IBrowserInfo;
  DevServer = IDevServer;
  ClientSettings = IClientSettings;
  JSValue = IJSValue;
  JSNamedValue = IJSNamedValue;
  JSObject = IJSObject;
  JSObjects = IJSObjects;
  JSProperty = IJSProperty;
  JSProperties = IJSProperties;
  JSArgument = IJSArgument;
  JSArguments = IJSArguments;
  JSMethod = IJSMethod;
  JSMethods = IJSMethods;
  JSEvent = IJSEvent;
  JSEvents = IJSEvents;
  Recorder = IRecorder;
  RecTrack = IRecTrack;
  RecTracks = IRecTracks;
  FileSystemFilter = IFileSystemFilter;
  RegistryFilter = IRegistryFilter;
  HTMLDoc = IHTMLDoc;


// *********************************************************************//
// Interface: IVirtualUI
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511}
// *********************************************************************//
  IVirtualUI = interface(IDispatch)
    ['{4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511}']
    function Start(Timeout: Integer): WordBool; safecall;
    procedure Stop; safecall;
    function Get_Active: WordBool; safecall;
    function Get_Enabled: WordBool; safecall;
    procedure Set_Enabled(Value: WordBool); safecall;
    function Get_DevMode: WordBool; safecall;
    procedure Set_DevMode(Value: WordBool); safecall;
    function Get_StdDialogs: WordBool; safecall;
    procedure Set_StdDialogs(Value: WordBool); safecall;
    function Get_BrowserInfo: IBrowserInfo; safecall;
    function Get_DevServer: IDevServer; safecall;
    function Get_ClientSettings: IClientSettings; safecall;
    procedure DownloadFile(const LocalFilename: WideString; const RemoteFilename: WideString;
                           const MimeType: WideString); safecall;
    procedure PrintPdf(const AFileName: WideString); safecall;
    procedure OpenLinkDlg(const url: WideString; const caption: WideString); safecall;
    procedure SendMessage(const Data: WideString); safecall;
    procedure AllowExecute(const Filename: WideString); safecall;
    procedure SetImageQualityByWnd(Wnd: Integer; const Class_: WideString; Quality: Integer); safecall;
    procedure UploadFile(const ServerDirectory: WideString); safecall;
    function TakeScreenshot(Wnd: Integer; const FileName: WideString): WordBool; safecall;
    procedure ShowVirtualKeyboard; safecall;
    function Get_Recorder: IRecorder; safecall;
    procedure PreviewPdf(const AFileName: WideString); safecall;
    function Get_FileSystemFilter: IFileSystemFilter; safecall;
    function Get_RegistryFilter: IRegistryFilter; safecall;
    function Get_Options: LongWord; safecall;
    procedure Set_Options(Value: LongWord); safecall;
    function Get_HTMLDoc: IHTMLDoc; safecall;
    function UploadFileEx(const ServerDirectory: WideString; out FileName: WideString): WordBool; safecall;
    procedure Suspend; safecall;
    procedure Resume; safecall;
    function FlushWindow(Wnd: Integer): WordBool; safecall;
    property Active: WordBool read Get_Active;
    property Enabled: WordBool read Get_Enabled write Set_Enabled;
    property DevMode: WordBool read Get_DevMode write Set_DevMode;
    property StdDialogs: WordBool read Get_StdDialogs write Set_StdDialogs;
    property BrowserInfo: IBrowserInfo read Get_BrowserInfo;
    property DevServer: IDevServer read Get_DevServer;
    property ClientSettings: IClientSettings read Get_ClientSettings;
    property Recorder: IRecorder read Get_Recorder;
    property FileSystemFilter: IFileSystemFilter read Get_FileSystemFilter;
    property RegistryFilter: IRegistryFilter read Get_RegistryFilter;
    property Options: LongWord read Get_Options write Set_Options;
    property HTMLDoc: IHTMLDoc read Get_HTMLDoc;
  end;

// *********************************************************************//
// DispIntf:  IVirtualUIDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511}
// *********************************************************************//
  IVirtualUIDisp = dispinterface
    ['{4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511}']
    function Start(Timeout: Integer): WordBool; dispid 102;
    procedure Stop; dispid 103;
    property Active: WordBool readonly dispid 104;
    property Enabled: WordBool dispid 106;
    property DevMode: WordBool dispid 105;
    property StdDialogs: WordBool dispid 107;
    property BrowserInfo: IBrowserInfo readonly dispid 101;
    property DevServer: IDevServer readonly dispid 110;
    property ClientSettings: IClientSettings readonly dispid 111;
    procedure DownloadFile(const LocalFilename: WideString; const RemoteFilename: WideString;
                           const MimeType: WideString); dispid 112;
    procedure PrintPdf(const AFileName: WideString); dispid 113;
    procedure OpenLinkDlg(const url: WideString; const caption: WideString); dispid 114;
    procedure SendMessage(const Data: WideString); dispid 115;
    procedure AllowExecute(const Filename: WideString); dispid 116;
    procedure SetImageQualityByWnd(Wnd: Integer; const Class_: WideString; Quality: Integer); dispid 117;
    procedure UploadFile(const ServerDirectory: WideString); dispid 118;
    function TakeScreenshot(Wnd: Integer; const FileName: WideString): WordBool; dispid 119;
    procedure ShowVirtualKeyboard; dispid 120;
    property Recorder: IRecorder readonly dispid 121;
    procedure PreviewPdf(const AFileName: WideString); dispid 122;
    property FileSystemFilter: IFileSystemFilter readonly dispid 201;
    property RegistryFilter: IRegistryFilter readonly dispid 202;
    property Options: LongWord dispid 203;
    property HTMLDoc: IHTMLDoc readonly dispid 204;
    function UploadFileEx(const ServerDirectory: WideString; out FileName: WideString): WordBool; dispid 205;
    procedure Suspend; dispid 206;
    procedure Resume; dispid 207;
    function FlushWindow(Wnd: Integer): WordBool; dispid 208;
  end;

// *********************************************************************//
// DispIntf:  IEvents
// Flags:     (0)
// GUID:      {1C5700BC-2317-4062-B614-0A4E286CFE68}
// *********************************************************************//
  IEvents = dispinterface
    ['{1C5700BC-2317-4062-B614-0A4E286CFE68}']
    procedure OnGetUploadDir(var Directory: WideString; var Handled: WordBool); dispid 101;
    procedure OnBrowserResize(var Width: Integer; var Height: Integer; var ResizeMaximized: WordBool); dispid 102;
    procedure OnClose; dispid 103;
    procedure OnReceiveMessage(const Data: WideString); dispid 104;
    procedure OnDownloadEnd(const Filename: WideString); dispid 105;
    procedure OnRecorderChanged; dispid 106;
    function OnUploadEnd(const FileName: WideString): HResult; dispid 107;
    function OnDragFile(Action: DragAction; X: Integer; Y: Integer; const Filenames: WideString): HResult; dispid 201;
	procedure OnSaveDialog(const Filename: WideString); dispid 202;
  end;

// *********************************************************************//
// Interface: IHTMLDoc
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0}
// *********************************************************************//
  IHTMLDoc = interface(IDispatch)
    ['{A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0}']
    procedure CreateSessionURL(const Url: WideString; const Filename: WideString); safecall;
    procedure CreateComponent(const Id: WideString; const Html: WideString; ReplaceWnd: SYSUINT); safecall;
    function GetSafeURL(const Filename: WideString; Minutes: Integer): WideString; safecall;
    procedure LoadScript(const Url: WideString; const Filename: WideString); safecall;
    procedure ImportHTML(const Url: WideString; const Filename: WideString); safecall;
  end;

// *********************************************************************//
// DispIntf:  IHTMLDocDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0}
// *********************************************************************//
  IHTMLDocDisp = dispinterface
    ['{A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0}']
    procedure CreateSessionURL(const Url: WideString; const Filename: WideString); dispid 204;
    procedure CreateComponent(const Id: WideString; const Html: WideString; ReplaceWnd: SYSUINT); dispid 205;
    function GetSafeURL(const Filename: WideString; Minutes: Integer): WideString; dispid 206;
    procedure LoadScript(const Url: WideString; const Filename: WideString); dispid 207;
    procedure ImportHTML(const Url: WideString; const Filename: WideString); dispid 201;
  end;

// *********************************************************************//
// Interface: IBrowserInfo
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4D9F5347-460B-4275-BDF2-F2738E7F6757}
// *********************************************************************//
  IBrowserInfo = interface(IDispatch)
    ['{4D9F5347-460B-4275-BDF2-F2738E7F6757}']
    function Get_ViewWidth: Integer; safecall;
    procedure Set_ViewWidth(Value: Integer); safecall;
    function Get_ViewHeight: Integer; safecall;
    procedure Set_ViewHeight(Value: Integer); safecall;
    function Get_BrowserWidth: Integer; safecall;
    function Get_BrowserHeight: Integer; safecall;
    function Get_ScreenWidth: Integer; safecall;
    function Get_ScreenHeight: Integer; safecall;
    function Get_Username: WideString; safecall;
    function Get_IPAddress: WideString; safecall;
    function Get_UserAgent: WideString; safecall;
    function Get_ScreenResolution: Integer; safecall;
    function Get_Orientation: Orientation; safecall;
    function Get_UniqueBrowserId: WideString; safecall;
    function GetCookie(const Name: WideString): WideString; safecall;
    procedure SetCookie(const Name, Value, Expires: WideString); safecall;
    function Get_Location: WideString; safecall;
    function Get_CustomData: WideString; safecall;
    procedure Set_CustomData(const Value: WideString); safecall;
    function Get_SelectedRule: WideString; safecall;
    function Get_ExtraData: WideString; safecall;
    function GetExtraDataValue(const Name: WideString): WideString; safecall;
    property ViewWidth: Integer read Get_ViewWidth write Set_ViewWidth;
    property ViewHeight: Integer read Get_ViewHeight write Set_ViewHeight;
    property BrowserWidth: Integer read Get_BrowserWidth;
    property BrowserHeight: Integer read Get_BrowserHeight;
    property ScreenWidth: Integer read Get_ScreenWidth;
    property ScreenHeight: Integer read Get_ScreenHeight;
    property Username: WideString read Get_Username;
    property IPAddress: WideString read Get_IPAddress;
    property UserAgent: WideString read Get_UserAgent;
    property ScreenResolution: Integer read Get_ScreenResolution;
    property Orientation: Orientation read Get_Orientation;
    property UniqueBrowserId: WideString read Get_UniqueBrowserId;
    property Location: WideString read Get_Location;
    property CustomData: WideString read Get_CustomData write Set_CustomData;
    property SelectedRule: WideString read Get_SelectedRule;
    property ExtraData: WideString read Get_ExtraData;
  end;

// *********************************************************************//
// DispIntf:  IBrowserInfoDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4D9F5347-460B-4275-BDF2-F2738E7F6757}
// *********************************************************************//
  IBrowserInfoDisp = dispinterface
    ['{4D9F5347-460B-4275-BDF2-F2738E7F6757}']
    property ViewWidth: Integer dispid 101;
    property ViewHeight: Integer dispid 102;
    property BrowserWidth: Integer readonly dispid 103;
    property BrowserHeight: Integer readonly dispid 104;
    property ScreenWidth: Integer readonly dispid 105;
    property ScreenHeight: Integer readonly dispid 106;
    property Username: WideString readonly dispid 107;
    property IPAddress: WideString readonly dispid 109;
    property UserAgent: WideString readonly dispid 110;
    property ScreenResolution: Integer readonly dispid 111;
    property Orientation: Orientation readonly dispid 201;
    property UniqueBrowserId: WideString readonly dispid 202;
    function GetCookie(const Name: WideString): WideString; dispid 203;
    procedure SetCookie(const Name: WideString; const Value: WideString; const Expires: WideString); dispid 204;
    property Location: WideString readonly dispid 205;
    property CustomData: WideString dispid 206;
    property SelectedRule: WideString readonly dispid 207;
    property ExtraData: WideString readonly dispid 208;
    function GetExtraDataValue(const Name: WideString): WideString; dispid 209;
  end;

// *********************************************************************//
// Interface: IDevServer
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80}
// *********************************************************************//
  IDevServer = interface(IDispatch)
    ['{B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80}']
    function Get_Enabled: WordBool; safecall;
    procedure Set_Enabled(Value: WordBool); safecall;
    function Get_Port: Integer; safecall;
    procedure Set_Port(Value: Integer); safecall;
    function Get_StartBrowser: WordBool; safecall;
    procedure Set_StartBrowser(Value: WordBool); safecall;
    property Enabled: WordBool read Get_Enabled write Set_Enabled;
    property Port: Integer read Get_Port write Set_Port;
    property StartBrowser: WordBool read Get_StartBrowser write Set_StartBrowser;
  end;

// *********************************************************************//
// DispIntf:  IDevServerDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80}
// *********************************************************************//
  IDevServerDisp = dispinterface
    ['{B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80}']
    property Enabled: WordBool dispid 201;
    property Port: Integer dispid 202;
    property StartBrowser: WordBool dispid 203;
  end;

// *********************************************************************//
// Interface: IClientSettings
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {439624CA-ED33-47BE-9211-91290F29584A}
// *********************************************************************//
  IClientSettings = interface(IDispatch)
    ['{439624CA-ED33-47BE-9211-91290F29584A}']
    function Get_MouseMoveGestureStyle: MouseMoveGestureStyle; safecall;
    procedure Set_MouseMoveGestureStyle(Value: MouseMoveGestureStyle); safecall;
    function Get_MouseMoveGestureAction: MouseMoveGestureAction; safecall;
    procedure Set_MouseMoveGestureAction(Value: MouseMoveGestureAction); safecall;
    function Get_CursorVisible: WordBool; safecall;
    procedure Set_CursorVisible(Value: WordBool); safecall;
    function Get_MouseWheelStepValue: Integer; safecall;
    procedure Set_MouseWheelStepValue(Value: Integer); safecall;
    function Get_MouseWheelDirection: Integer; safecall;
    procedure Set_MouseWheelDirection(Value: Integer); safecall;
    function Get_MousePressAsRightButton: WordBool; safecall;
    procedure Set_MousePressAsRightButton(Value: WordBool); safecall;
    property MouseMoveGestureStyle: MouseMoveGestureStyle read Get_MouseMoveGestureStyle write Set_MouseMoveGestureStyle;
    property MouseMoveGestureAction: MouseMoveGestureAction read Get_MouseMoveGestureAction write Set_MouseMoveGestureAction;
    property CursorVisible: WordBool read Get_CursorVisible write Set_CursorVisible;
    property MouseWheelStepValue: Integer read Get_MouseWheelStepValue write Set_MouseWheelStepValue;
    property MouseWheelDirection: Integer read Get_MouseWheelDirection write Set_MouseWheelDirection;
    property MousePressAsRightButton: WordBool read Get_MousePressAsRightButton write Set_MousePressAsRightButton;
  end;

// *********************************************************************//
// DispIntf:  IClientSettingsDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {439624CA-ED33-47BE-9211-91290F29584A}
// *********************************************************************//
  IClientSettingsDisp = dispinterface
    ['{439624CA-ED33-47BE-9211-91290F29584A}']
    property MouseMoveGestureStyle: MouseMoveGestureStyle dispid 201;
    property MouseMoveGestureAction: MouseMoveGestureAction dispid 202;
    property CursorVisible: WordBool dispid 203;
    property MouseWheelStepValue: Integer dispid 204;
    property MouseWheelDirection: Integer dispid 205;
    property MousePressAsRightButton: WordBool dispid 206;
  end;

// *********************************************************************//
// Interface: IRecorder
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {D89DA2B6-B7BF-4065-80F5-6D78B331C7DD}
// *********************************************************************//
  IRecorder = interface(IDispatch)
    ['{D89DA2B6-B7BF-4065-80F5-6D78B331C7DD}']
    function Get_Filename: WideString; safecall;
    procedure Set_Filename(const Value: WideString); safecall;
    procedure Rec(const Label_: WideString); safecall;
    procedure Play(From: Integer; To_: Integer); safecall;
    procedure Stop; safecall;
    function Get_Position: Integer; safecall;
    function Get_Count: Integer; safecall;
    function Get_State: RecorderState; safecall;
    function Get_Options: LongWord; safecall;
    procedure Set_Options(Value: LongWord); safecall;
    function Get_Tracks: IRecTracks; safecall;
    property Filename: WideString read Get_Filename write Set_Filename;
    property Position: Integer read Get_Position;
    property Count: Integer read Get_Count;
    property State: RecorderState read Get_State;
    property Options: LongWord read Get_Options write Set_Options;
    property Tracks: IRecTracks read Get_Tracks;
  end;

// *********************************************************************//
// DispIntf:  IRecorderDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {D89DA2B6-B7BF-4065-80F5-6D78B331C7DD}
// *********************************************************************//
  IRecorderDisp = dispinterface
    ['{D89DA2B6-B7BF-4065-80F5-6D78B331C7DD}']
    property Filename: WideString dispid 202;
    procedure Rec(const Label_: WideString); dispid 203;
    procedure Play(From: Integer; To_: Integer); dispid 204;
    procedure Stop; dispid 205;
    property Position: Integer dispid 207;
    property Count: Integer readonly dispid 208;
    property State: RecorderState readonly dispid 209;
    property Options: LongWord dispid 206;
    property Tracks: IRecTracks readonly dispid 210;
  end;

// *********************************************************************//
// Interface: IRecTrack
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {D4744AE1-70CB-43DD-BEA5-A5310B2E24C6}
// *********************************************************************//
  IRecTrack = interface(IDispatch)
    ['{D4744AE1-70CB-43DD-BEA5-A5310B2E24C6}']
    function Get_Name: WideString; safecall;
    function Get_Position: Integer; safecall;
    property Name: WideString read Get_Name;
    property Position: Integer read Get_Position;
  end;

// *********************************************************************//
// DispIntf:  IRecTrackDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {D4744AE1-70CB-43DD-BEA5-A5310B2E24C6}
// *********************************************************************//
  IRecTrackDisp = dispinterface
    ['{D4744AE1-70CB-43DD-BEA5-A5310B2E24C6}']
    property Name: WideString readonly dispid 201;
    property Position: Integer readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IRecTracks
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {AB45B615-9309-471E-A455-3FE93F88E674}
// *********************************************************************//
  IRecTracks = interface(IDispatch)
    ['{AB45B615-9309-471E-A455-3FE93F88E674}']
    function Get_Item(Index: Integer): IRecTrack; safecall;
    function Get_Count: Integer; safecall;
    property Item[Index: Integer]: IRecTrack read Get_Item;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IRecTracksDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {AB45B615-9309-471E-A455-3FE93F88E674}
// *********************************************************************//
  IRecTracksDisp = dispinterface
    ['{AB45B615-9309-471E-A455-3FE93F88E674}']
    property Item[Index: Integer]: IRecTrack readonly dispid 201;
    property Count: Integer readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IFileSystemFilter
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {3FE99D2F-0CFC-43D1-B762-0C7C15EB872E}
// *********************************************************************//
  IFileSystemFilter = interface(IDispatch)
    ['{3FE99D2F-0CFC-43D1-B762-0C7C15EB872E}']
    function Get_User: WideString; safecall;
    procedure Set_User(const Value: WideString); safecall;
    function Get_CfgFile: WideString; safecall;
    procedure Set_CfgFile(const Value: WideString); safecall;
    function Get_Active: WordBool; safecall;
    procedure Set_Active(Value: WordBool); safecall;
    property User: WideString read Get_User write Set_User;
    property CfgFile: WideString read Get_CfgFile write Set_CfgFile;
    property Active: WordBool read Get_Active write Set_Active;
  end;

// *********************************************************************//
// DispIntf:  IFileSystemFilterDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {3FE99D2F-0CFC-43D1-B762-0C7C15EB872E}
// *********************************************************************//
  IFileSystemFilterDisp = dispinterface
    ['{3FE99D2F-0CFC-43D1-B762-0C7C15EB872E}']
    property User: WideString dispid 201;
    property CfgFile: WideString dispid 202;
    property Active: WordBool dispid 203;
  end;

// *********************************************************************//
// Interface: IRegistryFilter
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4834F840-915B-488B-ADEA-98890A04CEE6}
// *********************************************************************//
  IRegistryFilter = interface(IDispatch)
    ['{4834F840-915B-488B-ADEA-98890A04CEE6}']
    function Get_User: WideString; safecall;
    procedure Set_User(const Value: WideString); safecall;
    function Get_CfgFile: WideString; safecall;
    procedure Set_CfgFile(const Value: WideString); safecall;
    function Get_Active: WordBool; safecall;
    procedure Set_Active(Value: WordBool); safecall;
    property User: WideString read Get_User write Set_User;
    property CfgFile: WideString read Get_CfgFile write Set_CfgFile;
    property Active: WordBool read Get_Active write Set_Active;
  end;

// *********************************************************************//
// DispIntf:  IRegistryFilterDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4834F840-915B-488B-ADEA-98890A04CEE6}
// *********************************************************************//
  IRegistryFilterDisp = dispinterface
    ['{4834F840-915B-488B-ADEA-98890A04CEE6}']
    property User: WideString dispid 201;
    property CfgFile: WideString dispid 202;
    property Active: WordBool dispid 203;
  end;

// *********************************************************************//
// Interface: IJSValue
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {6DE2E6A0-3C3A-47DC-9A93-928135EDAC90}
// *********************************************************************//
  IJSValue = interface(IDispatch)
    ['{6DE2E6A0-3C3A-47DC-9A93-928135EDAC90}']
    function Get_DataType: IJSDataType; safecall;
    procedure Set_DataType(Value: IJSDataType); safecall;
    function Get_RawValue: OleVariant; safecall;
    procedure Set_RawValue(Value: OleVariant); safecall;
    function Get_AsString: WideString; safecall;
    procedure Set_AsString(const Value: WideString); safecall;
    function Get_AsInt: Integer; safecall;
    procedure Set_AsInt(Value: Integer); safecall;
    function Get_AsBool: WordBool; safecall;
    procedure Set_AsBool(Value: WordBool); safecall;
    function Get_AsFloat: Single; safecall;
    procedure Set_AsFloat(Value: Single); safecall;
    function Get_AsJSON: WideString; safecall;
    procedure Set_AsJSON(const Value: WideString); safecall;
    property DataType: IJSDataType read Get_DataType write Set_DataType;
    property RawValue: OleVariant read Get_RawValue write Set_RawValue;
    property AsString: WideString read Get_AsString write Set_AsString;
    property AsInt: Integer read Get_AsInt write Set_AsInt;
    property AsBool: WordBool read Get_AsBool write Set_AsBool;
    property AsFloat: Single read Get_AsFloat write Set_AsFloat;
    property AsJSON: WideString read Get_AsJSON write Set_AsJSON;
  end;

// *********************************************************************//
// DispIntf:  IJSValueDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {6DE2E6A0-3C3A-47DC-9A93-928135EDAC90}
// *********************************************************************//
  IJSValueDisp = dispinterface
    ['{6DE2E6A0-3C3A-47DC-9A93-928135EDAC90}']
    property DataType: IJSDataType dispid 201;
    property RawValue: OleVariant dispid 202;
    property AsString: WideString dispid 203;
    property AsInt: Integer dispid 204;
    property AsBool: WordBool dispid 205;
    property AsFloat: Single dispid 206;
    property AsJSON: WideString dispid 207;
  end;

// *********************************************************************//
// Interface: IJSNamedValue
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {E492419B-00AC-4A91-9AE9-9A82B07E89AE}
// *********************************************************************//
  IJSNamedValue = interface(IJSValue)
    ['{E492419B-00AC-4A91-9AE9-9A82B07E89AE}']
    function Get_Name: WideString; safecall;
    procedure Set_Name(const Value: WideString); safecall;
    property Name: WideString read Get_Name write Set_Name;
  end;

// *********************************************************************//
// DispIntf:  IJSNamedValueDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {E492419B-00AC-4A91-9AE9-9A82B07E89AE}
// *********************************************************************//
  IJSNamedValueDisp = dispinterface
    ['{E492419B-00AC-4A91-9AE9-9A82B07E89AE}']
    property Name: WideString dispid 301;
    property DataType: IJSDataType dispid 201;
    property RawValue: OleVariant dispid 202;
    property AsString: WideString dispid 203;
    property AsInt: Integer dispid 204;
    property AsBool: WordBool dispid 205;
    property AsFloat: Single dispid 206;
    property AsJSON: WideString dispid 207;
  end;

// *********************************************************************//
// Interface: IJSObject
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {59342310-79A7-4B14-8B63-6DF05609AE30}
// *********************************************************************//
  IJSObject = interface(IDispatch)
    ['{59342310-79A7-4B14-8B63-6DF05609AE30}']
    function Get_Id: WideString; safecall;
    procedure Set_Id(const Value: WideString); safecall;
    function Get_Properties: IJSProperties; safecall;
    function Get_Methods: IJSMethods; safecall;
    function Get_Events: IJSEvents; safecall;
    function Get_Objects: IJSObjects; safecall;
    procedure FireEvent(const Name: WideString; const Arguments: IJSArguments); safecall;
    procedure ApplyChanges; safecall;
    procedure ApplyModel; safecall;
    property Id: WideString read Get_Id write Set_Id;
    property Properties: IJSProperties read Get_Properties;
    property Methods: IJSMethods read Get_Methods;
    property Events: IJSEvents read Get_Events;
    property Objects: IJSObjects read Get_Objects;
  end;

// *********************************************************************//
// DispIntf:  IJSObjectDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {59342310-79A7-4B14-8B63-6DF05609AE30}
// *********************************************************************//
  IJSObjectDisp = dispinterface
    ['{59342310-79A7-4B14-8B63-6DF05609AE30}']
    property Id: WideString dispid 201;
    property Properties: IJSProperties readonly dispid 202;
    property Methods: IJSMethods readonly dispid 203;
    property Events: IJSEvents readonly dispid 204;
    property Objects: IJSObjects readonly dispid 205;
    procedure FireEvent(const Name: WideString; const Arguments: IJSArguments); dispid 206;
    procedure ApplyChanges; dispid 207;
    procedure ApplyModel; dispid 208;
  end;

// *********************************************************************//
// DispIntf:  IJSObjectEvents
// Flags:     (0)
// GUID:      {A3D640E8-CD18-4196-A1A2-C87C82B0F88B}
// *********************************************************************//
  IJSObjectEvents = dispinterface
    ['{A3D640E8-CD18-4196-A1A2-C87C82B0F88B}']
    procedure OnExecuteMethod(const Caller: IJSObject; const Method: IJSMethod); dispid 101;
    procedure OnPropertyChange(const Caller: IJSObject; const Prop: IJSProperty); dispid 102;
  end;

// *********************************************************************//
// Interface: IJSObjects
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {C2406011-568E-4EAC-B95C-EF29E4806B86}
// *********************************************************************//
  IJSObjects = interface(IDispatch)
    ['{C2406011-568E-4EAC-B95C-EF29E4806B86}']
    function Get_Count: Integer; safecall;
    function Get_Item(Index: OleVariant): IJSObject; safecall;
    procedure Clear; safecall;
    function Add(const Id: WideString): IJSObject; safecall;
    procedure Remove(const Item: IJSObject); safecall;
    property Count: Integer read Get_Count;
    property Item[Index: OleVariant]: IJSObject read Get_Item; default;
  end;

// *********************************************************************//
// DispIntf:  IJSObjectsDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {C2406011-568E-4EAC-B95C-EF29E4806B86}
// *********************************************************************//
  IJSObjectsDisp = dispinterface
    ['{C2406011-568E-4EAC-B95C-EF29E4806B86}']
    property Count: Integer readonly dispid 201;
    property Item[Index: OleVariant]: IJSObject readonly dispid 0; default;
    procedure Clear; dispid 204;
    function Add(const Id: WideString): IJSObject; dispid 205;
    procedure Remove(const Item: IJSObject); dispid 206;
  end;

// *********************************************************************//
// Interface: IJSProperty
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {1F95C0E9-E7BF-48C9-AA35-88AD0149109B}
// *********************************************************************//
  IJSProperty = interface(IJSNamedValue)
    ['{1F95C0E9-E7BF-48C9-AA35-88AD0149109B}']
    function Get_ReadOnly: WordBool; safecall;
    procedure Set_ReadOnly(Value: WordBool); safecall;
    function OnGet(const Binding: IJSBinding): IJSProperty; safecall;
    function OnSet(const Binding: IJSBinding): IJSProperty; safecall;
    property ReadOnly: WordBool read Get_ReadOnly write Set_ReadOnly;
  end;

// *********************************************************************//
// DispIntf:  IJSPropertyDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {1F95C0E9-E7BF-48C9-AA35-88AD0149109B}
// *********************************************************************//
  IJSPropertyDisp = dispinterface
    ['{1F95C0E9-E7BF-48C9-AA35-88AD0149109B}']
    property ReadOnly: WordBool dispid 401;
    function OnGet(const Binding: IJSBinding): IJSProperty; dispid 402;
    function OnSet(const Binding: IJSBinding): IJSProperty; dispid 403;
    property Name: WideString dispid 301;
    property DataType: IJSDataType dispid 201;
    property RawValue: OleVariant dispid 202;
    property AsString: WideString dispid 203;
    property AsInt: Integer dispid 204;
    property AsBool: WordBool dispid 205;
    property AsFloat: Single dispid 206;
    property AsJSON: WideString dispid 207;
  end;

// *********************************************************************//
// Interface: IJSProperties
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C}
// *********************************************************************//
  IJSProperties = interface(IDispatch)
    ['{FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C}']
    function Get_Count: Integer; safecall;
    function Get_Item(Index: OleVariant): IJSProperty; safecall;
    procedure Clear; safecall;
    function Add(const Name: WideString): IJSProperty; safecall;
    procedure Remove(const Item: IJSProperty); safecall;
    property Count: Integer read Get_Count;
    property Item[Index: OleVariant]: IJSProperty read Get_Item; default;
  end;

// *********************************************************************//
// DispIntf:  IJSPropertiesDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C}
// *********************************************************************//
  IJSPropertiesDisp = dispinterface
    ['{FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C}']
    property Count: Integer readonly dispid 201;
    property Item[Index: OleVariant]: IJSProperty readonly dispid 0; default;
    procedure Clear; dispid 204;
    function Add(const Name: WideString): IJSProperty; dispid 205;
    procedure Remove(const Item: IJSProperty); dispid 206;
  end;

// *********************************************************************//
// Interface: IJSArgument
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {8F8C4462-D7B5-4696-BAD5-16DFAA6E2601}
// *********************************************************************//
  IJSArgument = interface(IJSNamedValue)
    ['{8F8C4462-D7B5-4696-BAD5-16DFAA6E2601}']
  end;

// *********************************************************************//
// DispIntf:  IJSArgumentDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {8F8C4462-D7B5-4696-BAD5-16DFAA6E2601}
// *********************************************************************//
  IJSArgumentDisp = dispinterface
    ['{8F8C4462-D7B5-4696-BAD5-16DFAA6E2601}']
    property Name: WideString dispid 301;
    property DataType: IJSDataType dispid 201;
    property RawValue: OleVariant dispid 202;
    property AsString: WideString dispid 203;
    property AsInt: Integer dispid 204;
    property AsBool: WordBool dispid 205;
    property AsFloat: Single dispid 206;
    property AsJSON: WideString dispid 207;
  end;

// *********************************************************************//
// Interface: IJSArguments
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {FC097EF5-6D8A-4C80-A2AD-382FDC75E901}
// *********************************************************************//
  IJSArguments = interface(IDispatch)
    ['{FC097EF5-6D8A-4C80-A2AD-382FDC75E901}']
    function Get_Count: Integer; safecall;
    function Get_Item(Index: OleVariant): IJSArgument; safecall;
    procedure Clear; safecall;
    function Add(const Name: WideString): IJSArgument; safecall;
    procedure Remove(const Item: IJSArgument); safecall;
    property Count: Integer read Get_Count;
    property Item[Index: OleVariant]: IJSArgument read Get_Item; default;
  end;

// *********************************************************************//
// DispIntf:  IJSArgumentsDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {FC097EF5-6D8A-4C80-A2AD-382FDC75E901}
// *********************************************************************//
  IJSArgumentsDisp = dispinterface
    ['{FC097EF5-6D8A-4C80-A2AD-382FDC75E901}']
    property Count: Integer readonly dispid 201;
    property Item[Index: OleVariant]: IJSArgument readonly dispid 0; default;
    procedure Clear; dispid 204;
    function Add(const Name: WideString): IJSArgument; dispid 205;
    procedure Remove(const Item: IJSArgument); dispid 206;
  end;

// *********************************************************************//
// Interface: IJSMethod
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E}
// *********************************************************************//
  IJSMethod = interface(IDispatch)
    ['{C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E}']
    function Get_Name: WideString; safecall;
    procedure Set_Name(const Value: WideString); safecall;
    function Get_Arguments: IJSArguments; safecall;
    function Get_ReturnValue: IJSValue; safecall;
    function AddArgument(const Name: WideString; DataType: IJSDataType): IJSMethod; safecall;
    function OnCall(const Callback: IJSCallback): IJSMethod; safecall;
    property Name: WideString read Get_Name write Set_Name;
    property Arguments: IJSArguments read Get_Arguments;
    property ReturnValue: IJSValue read Get_ReturnValue;
  end;

// *********************************************************************//
// DispIntf:  IJSMethodDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E}
// *********************************************************************//
  IJSMethodDisp = dispinterface
    ['{C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E}']
    property Name: WideString dispid 201;
    property Arguments: IJSArguments readonly dispid 202;
    property ReturnValue: IJSValue readonly dispid 203;
    function AddArgument(const Name: WideString; DataType: IJSDataType): IJSMethod; dispid 204;
    function OnCall(const Callback: IJSCallback): IJSMethod; dispid 205;
  end;

// *********************************************************************//
// Interface: IJSMethods
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {E4CB461F-586E-4121-ABD7-345B87BC423A}
// *********************************************************************//
  IJSMethods = interface(IDispatch)
    ['{E4CB461F-586E-4121-ABD7-345B87BC423A}']
    function Get_Count: Integer; safecall;
    function Get_Item(Index: OleVariant): IJSMethod; safecall;
    procedure Clear; safecall;
    function Add(const Name: WideString): IJSMethod; safecall;
    procedure Remove(const Item: IJSMethod); safecall;
    property Count: Integer read Get_Count;
    property Item[Index: OleVariant]: IJSMethod read Get_Item; default;
  end;

// *********************************************************************//
// DispIntf:  IJSMethodsDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {E4CB461F-586E-4121-ABD7-345B87BC423A}
// *********************************************************************//
  IJSMethodsDisp = dispinterface
    ['{E4CB461F-586E-4121-ABD7-345B87BC423A}']
    property Count: Integer readonly dispid 201;
    property Item[Index: OleVariant]: IJSMethod readonly dispid 0; default;
    procedure Clear; dispid 204;
    function Add(const Name: WideString): IJSMethod; dispid 205;
    procedure Remove(const Item: IJSMethod); dispid 206;
  end;

// *********************************************************************//
// Interface: IJSEvent
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {8B66EACD-9619-43CF-9196-DCDA17F5500E}
// *********************************************************************//
  IJSEvent = interface(IDispatch)
    ['{8B66EACD-9619-43CF-9196-DCDA17F5500E}']
    function Get_Name: WideString; safecall;
    procedure Set_Name(const Value: WideString); safecall;
    function Get_Arguments: IJSArguments; safecall;
    function AddArgument(const Name: WideString; DataType: IJSDataType): IJSEvent; safecall;
    function ArgumentAsNull(Index: OleVariant): IJSEvent; safecall;
    function ArgumentAsString(Index: OleVariant; const Value: WideString): IJSEvent; safecall;
    function ArgumentAsInt(Index: OleVariant; Value: Integer): IJSEvent; safecall;
    function ArgumentAsBool(Index: OleVariant; Value: WordBool): IJSEvent; safecall;
    function ArgumentAsFloat(Index: OleVariant; Value: Single): IJSEvent; safecall;
    function ArgumentAsJSON(Index: OleVariant; const Value: WideString): IJSEvent; safecall;
    procedure Fire; safecall;
    property Name: WideString read Get_Name write Set_Name;
    property Arguments: IJSArguments read Get_Arguments;
  end;

// *********************************************************************//
// DispIntf:  IJSEventDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {8B66EACD-9619-43CF-9196-DCDA17F5500E}
// *********************************************************************//
  IJSEventDisp = dispinterface
    ['{8B66EACD-9619-43CF-9196-DCDA17F5500E}']
    property Name: WideString dispid 201;
    property Arguments: IJSArguments readonly dispid 202;
    function AddArgument(const Name: WideString; DataType: IJSDataType): IJSEvent; dispid 203;
    function ArgumentAsNull(Index: OleVariant): IJSEvent; dispid 204;
    function ArgumentAsString(Index: OleVariant; const Value: WideString): IJSEvent; dispid 205;
    function ArgumentAsInt(Index: OleVariant; Value: Integer): IJSEvent; dispid 206;
    function ArgumentAsBool(Index: OleVariant; Value: WordBool): IJSEvent; dispid 207;
    function ArgumentAsFloat(Index: OleVariant; Value: Single): IJSEvent; dispid 208;
    function ArgumentAsJSON(Index: OleVariant; const Value: WideString): IJSEvent; dispid 209;
    procedure Fire; dispid 210;
  end;

// *********************************************************************//
// Interface: IJSEvents
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {6AE952B3-B6DA-4C81-80FF-D0A162E11D02}
// *********************************************************************//
  IJSEvents = interface(IDispatch)
    ['{6AE952B3-B6DA-4C81-80FF-D0A162E11D02}']
    function Get_Count: Integer; safecall;
    function Get_Item(Index: OleVariant): IJSEvent; safecall;
    procedure Clear; safecall;
    function Add(const Name: WideString): IJSEvent; safecall;
    procedure Remove(const Item: IJSEvent); safecall;
    property Count: Integer read Get_Count;
    property Item[Index: OleVariant]: IJSEvent read Get_Item; default;
  end;

// *********************************************************************//
// DispIntf:  IJSEventsDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {6AE952B3-B6DA-4C81-80FF-D0A162E11D02}
// *********************************************************************//
  IJSEventsDisp = dispinterface
    ['{6AE952B3-B6DA-4C81-80FF-D0A162E11D02}']
    property Count: Integer readonly dispid 201;
    property Item[Index: OleVariant]: IJSEvent readonly dispid 0; default;
    procedure Clear; dispid 204;
    function Add(const Name: WideString): IJSEvent; dispid 205;
    procedure Remove(const Item: IJSEvent); dispid 206;
  end;

// *********************************************************************//
// Interface: IJSBinding
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {ACFC2953-37F1-479E-B405-D0BB75E156E6}
// *********************************************************************//
  IJSBinding = interface(IDispatch)
    ['{ACFC2953-37F1-479E-B405-D0BB75E156E6}']
    procedure Set_(const Parent: IJSObject; const Prop: IJSProperty); safecall;
  end;

// *********************************************************************//
// DispIntf:  IJSBindingDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {ACFC2953-37F1-479E-B405-D0BB75E156E6}
// *********************************************************************//
  IJSBindingDisp = dispinterface
    ['{ACFC2953-37F1-479E-B405-D0BB75E156E6}']
    procedure Set_(const Parent: IJSObject; const Prop: IJSProperty); dispid 201;
  end;

// *********************************************************************//
// Interface: IJSCallback
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {ADD570A0-491A-4E40-8120-57B4D1245FD3}
// *********************************************************************//
  IJSCallback = interface(IDispatch)
    ['{ADD570A0-491A-4E40-8120-57B4D1245FD3}']
    procedure Callback(const Parent: IJSObject; const Method: IJSMethod); safecall;
  end;

// *********************************************************************//
// DispIntf:  IJSCallbackDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {ADD570A0-491A-4E40-8120-57B4D1245FD3}
// *********************************************************************//
  IJSCallbackDisp = dispinterface
    ['{ADD570A0-491A-4E40-8120-57B4D1245FD3}']
    procedure Callback(const Parent: IJSObject; const Method: IJSMethod); dispid 201;
  end;

  TGetUploadDirEvent = procedure(Sender: TObject; var Directory: string; var Handled: Boolean ) of object;
  TBrowserResizeEvent = procedure(Sender: TObject; var Width, Height: Integer; var ResizeMaximized: Boolean ) of object;
  TReceiveMessageEvent = procedure(Sender: TObject; Data: string) of object;
  TCloseEvent = procedure (Sender: TObject) of object;
  TDownloadEndEvent = procedure (Sender: TObject; const filename: string) of object;
  TUploadEndEvent = procedure (Sender: TObject; const filename: string) of object;
  TRecorderChangedEvent = procedure (Sender: TObject) of object;
  TOnDragFileEvent = procedure (Action: DragAction; X, Y: Integer; const Filenames: string) of object;
  TSaveDialogEvent = procedure (Sender: TObject; const filename: string) of object;

  /// <summary>
  /// Contains properties to manage the VirtualUI Development
  /// Server as well as the access from the developer's web
  /// browser. 
  /// </summary>                                             
  TDevServer = class(TInterfacedObject, IDevServer)
  private
    FVirtualUI: IVirtualUI;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;

    function Get_Enabled: WordBool; safecall;
    procedure Set_Enabled(Value: WordBool); safecall;
    function Get_Port: Integer; safecall;
    procedure Set_Port(Value: Integer); safecall;
    function Get_StartBrowser: WordBool; safecall;
    procedure Set_StartBrowser(Value: WordBool); safecall;
  public
    constructor Create(AVirtualUI: IVirtualUI);
    destructor Destroy; override;

    /// <summary>
    ///   Enables/disables the Development Server.
    /// </summary>
    property Enabled: WordBool read Get_Enabled write Set_Enabled;
    /// <summary>
    ///   Gets/sets the Development Server's TCP/IP listening port.
    /// </summary>
    property Port: Integer read Get_Port write Set_Port;
    /// <summary>
    /// Instructs VirtualUI whether start or not the local web
    /// browser upon VirtualUI activation.  
    /// </summary>                                            
    property StartBrowser: WordBool read Get_StartBrowser write Set_StartBrowser;
  end;

  /// <summary>
  /// Contains information regarding the end-user's screen, web
  /// browser, the window containing VirtualUI Viewer and VirtualUI
  /// Viewer itself. The VirtualUI Viewer tuns inside an HTML DIV
  /// element contained in a frame o browser window on the
  /// end-user's application page.
  /// </summary>
  TBrowserInfo = class(TInterfacedObject, IBrowserInfo)
  private
    FVirtualUI: IVirtualUI;
    function Get_ViewWidth: Integer; safecall;
    procedure Set_ViewWidth(Value: Integer); safecall;
    function Get_ViewHeight: Integer; safecall;
    procedure Set_ViewHeight(Value: Integer); safecall;
    function Get_BrowserWidth: Integer; safecall;
    function Get_BrowserHeight: Integer; safecall;
    function Get_ScreenWidth: Integer; safecall;
    function Get_ScreenHeight: Integer; safecall;
    function Get_Username: WideString; safecall;
    function Get_IPAddress: WideString; safecall;
    function Get_UserAgent: WideString; safecall;
    function Get_ScreenResolution: Integer; safecall;
    function Get_Orientation: Orientation; safecall;
    function Get_UniqueBrowserId: WideString; safecall;
    function GetCookie(const Name: WideString): WideString; safecall;
    procedure SetCookie(const Name, Value, Expires: WideString); safecall;
    function Get_Location: WideString; safecall;
    function Get_CustomData: WideString; safecall;
    procedure Set_CustomData(const Value: WideString); safecall;
    function Get_SelectedRule: WideString; safecall;
    function Get_ExtraData: WideString; safecall;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;
  public
    constructor Create(AVirtualUI: IVirtualUI);
    destructor Destroy; override;

    /// <summary>
    /// \Returns the width of the VirtualUI Viewer. 
    /// </summary>                                  
    property ViewWidth: Integer read Get_ViewWidth;
    /// <summary>
    /// \Returns the height of the VirtualUI Viewer.
    /// </summary>
    property ViewHeight: Integer read Get_ViewHeight;
    /// <summary>
    /// \Returns the width of the HTML element containing the
    /// VirtualUI Viewer. 
    /// </summary>                                           
    property BrowserWidth: Integer read Get_BrowserWidth;
    /// <summary>
    /// \Returns the height of the HTML element containing the
    /// VirtualUI Viewer.
    /// </summary>
    property BrowserHeight: Integer read Get_BrowserHeight;
    /// <summary>
    ///   Returns the width of the end-user's monitor screen.
    /// </summary>
    property ScreenWidth: Integer read Get_ScreenWidth;
    /// <summary>
    ///   Returns the height of the end-user's monitor screen.
    /// </summary>
    property ScreenHeight: Integer read Get_ScreenHeight;
    /// <summary>
    ///   Returns the logged-on Username.
    /// </summary>
    property Username: WideString read Get_Username;
    /// <summary>
    ///   Returns the client's IP address.
    /// </summary>
    property IPAddress: WideString read Get_IPAddress;
    /// <summary>
    ///   Returns the browser's User Agent string.
    /// </summary>
    property UserAgent: WideString read Get_UserAgent;
    /// <summary>
    ///   Returns the application screen resolution defined in the application profile.
    /// </summary>
    property ScreenResolution: Integer read Get_ScreenResolution;
    /// <summary>
    ///   Returns the browser's orientation.
    /// </summary>
    property Orientation: Orientation read Get_Orientation;
    /// <summary>
    /// \UniqueBrowserId identifies an instance of a Web Browser. Each time
    /// an end-user opens the application from a different browser window,
    /// this ID will have a different value.
    /// </summary>
    property UniqueBrowserId: WideString read Get_UniqueBrowserId;
    /// <summary>
    /// \Returns the URL of the current application.
    /// </summary>
    property Location: WideString read Get_Location;
    /// <summary>
    ///  Gets or sets custom user data.
    /// </summary>
    property CustomData: WideString read Get_CustomData write Set_CustomData;
    /// <summary>
    ///  Returns the selected Browser Rule.
    /// </summary>
    property SelectedRule: WideString read Get_SelectedRule;
    /// <summary>
    ///  Returns aditional data from Browser (JSON format).
    /// </summary>
    property ExtraData: WideString read Get_ExtraData;
    /// <summary>
    ///  Returns a specific value from ExtraData by it's name.
    /// </summary>
    /// <param name="Name">Name of value to return.</param>
    function GetExtraDataValue(const Name: WideString): WideString; safecall;
  end;

  /// <summary>
  ///   Allows to set some client settings.
  /// </summary>
  TClientSettings = class(TInterfacedObject, IClientSettings)
  private
    FVirtualUI: IVirtualUI;
    function Get_MouseMoveGestureStyle: MouseMoveGestureStyle; safecall;
    procedure Set_MouseMoveGestureStyle(Value: MouseMoveGestureStyle); safecall;
    function Get_MouseMoveGestureAction: MouseMoveGestureAction; safecall;
    procedure Set_MouseMoveGestureAction(Value: MouseMoveGestureAction); safecall;
    function Get_CursorVisible: WordBool; safecall;
    procedure Set_CursorVisible(Value: WordBool); safecall;
    function Get_MouseWheelStepValue: Integer; safecall;
    procedure Set_MouseWheelStepValue(Value: Integer); safecall;
    function Get_MouseWheelDirection: Integer; safecall;
    procedure Set_MouseWheelDirection(Value: Integer); safecall;
    function Get_MousePressAsRightButton: WordBool; safecall;
    procedure Set_MousePressAsRightButton(Value: WordBool); safecall;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;
  public
    constructor Create(AVirtualUI: IVirtualUI);
    destructor Destroy; override;

    /// <summary>
    /// Valid for touch devices. Specifies whether the mouse pointer
    /// is shown and acts on the exact spot of the finger touch
    /// (absolute) or its position is managed relatively to the
    /// movement of the finger touch (relative). 
    /// </summary>                                                  
    property MouseMoveGestureStyle: MouseMoveGestureStyle read Get_MouseMoveGestureStyle write Set_MouseMoveGestureStyle;
    /// <summary>
    ///   Specifies whether the "mouse move" simulation on a touch device is
    ///   interpreted as a mouse move or as a mouse wheel.
    /// </summary>
    property MouseMoveGestureAction: MouseMoveGestureAction read Get_MouseMoveGestureAction write Set_MouseMoveGestureAction;
    /// <summary>
    ///   Hides/shows the mouse pointer.
    /// </summary>
    property CursorVisible: WordBool read Get_CursorVisible write Set_CursorVisible;
    /// <summary>
    ///   Specifies the scroll speed when the "mouse move" simulation on a
    ///   touch device is interpreted as a mouse wheel. Default value is
    ///   120. Lower values results in a smooth scrolling.
    /// </summary>
    property MouseWheelStepValue: Integer read Get_MouseWheelStepValue write Set_MouseWheelStepValue;
    /// <summary>
    ///   Specifies the scroll direction when the "mouse move" simulation on a
    ///   touch device is interpreted as a mouse wheel. Set this to 1 (default)
    ///   to normal direction, or -1 to invert.
    /// </summary>
    property MouseWheelDirection: Integer read Get_MouseWheelDirection write Set_MouseWheelDirection;
    /// <summary>
    ///   Specifies if the mouse click acts as right button.
    /// </summary>
    property MousePressAsRightButton: WordBool read Get_MousePressAsRightButton write Set_MousePressAsRightButton;
  end;

  /// <summary>
  /// Main class. Has methods, properties and events to allow to
  /// manage some web behavior.
  /// </summary>
  THTMLDoc = class(TInterfacedObject, IHTMLDoc)
  private
    FVirtualUI: IVirtualUI;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;
  public
    /// <summary>
    /// Creates an url pointing to a local filename. This url is valid
    /// during the session lifetime and its private to this session.
    /// </summary>
    /// <param name="url">Arbritary relative url.</param>
    /// <param name="filename">Local filename</param>
    procedure CreateSessionURL(const Url: WideString; const Filename: WideString); safecall;
    /// <summary>
    /// Inserts an HTML. Used to insert regular HTML elements or
    /// WebComponents with custom elements.
    /// </summary>
    /// <param name="Id">ID to assign to the main element of the HTML to be inserted</param>
    /// <param name="Html">HTML snippet</param>
    /// <param name="ReplaceWnd">Wnd to be replaced and tied to</param>
    /// <remarks>
    /// When ReplaceWnd is <> 0 and points to a valid window handle, the positioning of the main element
    /// will follow the Wnd positioning, simulating an embedding.
    /// </remarks>
    procedure CreateComponent(const Id: WideString; const Html: WideString; ReplaceWnd: SYSUINT); safecall;
    /// <summary>
    /// Returns a safe, temporary and unique URL to access any local file.
    /// </summary>
    /// <param name="Filename">Local filename</param>
    /// <param name="Minutes">Expiration in minutes</param>
    function GetSafeURL(const Filename: WideString; Minutes: Integer): WideString; safecall;
    /// <summary>
    ///  Loads a script from URL. If Filename is specified, creates a session
    ///  URL first and then load the script from that Filename.
    /// </summary>
    /// <param name="Url">elative URL</param>
    /// <param name="Filename">Local filename (optional)</param>
    procedure LoadScript(const Url: WideString; const Filename: WideString='');overload; safecall;
    /// <summary>
    ///  Imports an HTML from URL. If Filename is specified, creates a session
    ///  URL first and then imports the html file from that Filename.
    /// </summary>
    /// <param name="Url">elative URL</param>
    /// <param name="Filename">Local filename (optional)</param>
    procedure ImportHTML(const Url: WideString; const Filename: WideString='');overload; safecall;
    constructor Create(AVirtualUI: IVirtualUI);
    destructor Destroy; override;
  end;


  /// <summary>
  /// Main class. Has methods, properties and events to allow the
  /// activation and control the behavior of VirtualUI.
  /// </summary>
  TVirtualUI = class(TInterfacedObject, IVirtualUI)
  private
    FVirtualUI: IVirtualUI;
    FEventSink: IUnknown;
    FCookie: {$IFDEF FPC}DWORD;{$ELSE}Integer;{$ENDIF}
    FDevServer: IDevServer;
    FBrowserInfo: IBrowserInfo;
    FClientSettings: IClientSettings;
    FHTMLDoc : IHTMLDoc;
    FOnGetUploadDir: TGetUploadDirEvent;
    FOnBrowserResize: TBrowserResizeEvent;
    FOnClose: TCloseEvent;
    FOnReceiveMessage: TReceiveMessageEvent;
    FOnDownloadEnd: TDownloadEndEvent;
    FOnUploadEnd: TUploadEndEvent;
    FOnRecorderChanged : TRecorderChangedEvent;
    FOnDragFile: TOnDragFileEvent;
    FOnSaveDialog: TSaveDialogEvent;

    procedure DoBrowserResize(var Width: Integer; var Height: Integer; var ResizeMaximized: Boolean);
    procedure DoGetUploadDir(var Directory: string; var Handled: Boolean);
    procedure DoClose;
    procedure DoReceiveMessage(Data: WideString);
    procedure DoDownloadEnd(const Filename: WideString);
    procedure DoUploadEnd(const Filename: WideString);
    procedure DoRecorderChanged;
    procedure DoDragFile(Action: DragAction; X, Y: Integer; const Filenames: string);
    procedure DoSaveDialog(const Filename: WideString);
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;

    function Get_Active: WordBool; safecall;
    function Get_Enabled: WordBool; safecall;
    procedure Set_Enabled(Value: WordBool); safecall;
    function Get_DevMode: WordBool; safecall;
    procedure Set_DevMode(Value: WordBool); safecall;
    function Get_StdDialogs: WordBool; safecall;
    procedure Set_StdDialogs(Value: WordBool); safecall;
    function Get_BrowserInfo: IBrowserInfo; safecall;
    function Get_DevServer: IDevServer; safecall;
    function Get_ClientSettings: IClientSettings; safecall;
    function Get_Recorder: IRecorder; safecall;
    function Get_FileSystemFilter: IFileSystemFilter; safecall;
    function Get_RegistryFilter: IRegistryFilter; safecall;
    function Get_Options: LongWord; safecall;
    procedure Set_Options(Value: LongWord); safecall;
    function Get_HTMLDoc: IHTMLDoc; safecall;
  public
    constructor Create;
    destructor Destroy; override;

    /// <summary>
    /// Starts the VirtualUI's activation process. Returns true if
    /// VirtualUI was fully activated or false if the passed timeout
    /// expired.
    /// </summary>
    /// <param name="Timeout">Maximum time, in seconds, until the
    ///                       activation process is canceled.
    ///                       Defaults to 60 seconds. </param>
    /// <remarks>
    /// To fully activate VirtualUI, the connection with the
    /// end-user's web browser must established within the time
    /// specified by Timeout parameter. 
    /// </remarks>                                                  
    function Start(Timeout: Integer): WordBool; overload; safecall;
    /// <summary>
    ///   Starts the VirtualUI's activation process. Returns true if VirtualUI
    ///   was fully activated or false if the timeout expired. The timeout is
    ///   60 seconds.
    /// </summary>
    function Start(): WordBool; overload;
    /// <summary>
    ///   Deactivates VirtualUI, closing the connection with the end-user's web
    ///   browser.
    /// </summary>
    procedure Stop; safecall;
    /// <summary>
    ///   Sends the specified file to the end-user's web browser for saving it
    ///   in the remote machine.
    /// </summary>
    /// <param name="LocalFilename">
    ///   Name of the local file to be sent.
    /// </param>
    /// <param name="RemoteFilename">
    ///   Name of the file in the remote machine.
    /// </param>
    /// <param name="MimeType">
    ///   content-type of the file. If specified, the content will be handled by
    ///   browser. Leave blank to force download.
    /// </param>
    procedure DownloadFile(const LocalFilename: WideString; const RemoteFilename: WideString;
                           const MimeType: WideString); overload; safecall;
    /// <summary>
    ///   Sends the specified file to the end-user's web browser for saving it
    ///   in the remote machine.
    /// </summary>
    /// <param name="LocalFilename">
    ///   Name of the local file to be sent.
    /// </param>
    /// <param name="RemoteFilename">
    ///   Name of the file in the remote machine.
    /// </param>
    procedure DownloadFile(const LocalFilename: WideString; const RemoteFilename: WideString); overload; safecall;
    /// <summary>
    ///   Sends the specified file to the end-user's web browser for saving it
    ///   in the remote machine.
    /// </summary>
    /// <param name="LocalFilename">
    ///   Name of both the local and remote file .
    /// </param>
    procedure DownloadFile(const LocalFilename: WideString); overload;
    /// <summary>
    /// Sends the specified PDF file to be shown on the end-user's
    /// web browser.
    /// </summary>
    /// <param name="AFileName">Name of the PDF file. </param>
    /// <remarks>
    /// PrintPDF is similar to DownloadFile, except that it downloads
    /// the file with a content-type: application/pdf.
    /// </remarks>
    procedure PrintPdf(const AFileName: WideString); safecall;
    /// <summary>
    /// Sends the specified PDF file to be shown on the end-user's
    /// web browser. It's similar to PrintPdf, except that disables the
    /// printing options in the browser. Built-in browser printing commands
    /// will be available.
    /// </summary>
    /// <param name="AFileName">Name of the PDF file.</param>
    procedure PreviewPdf(const AFileName: WideString); safecall;
    /// <summary>
    ///   Selects a file from client machine, and it's uploaded to
    ///   ServerDirectory
    /// </summary>
    /// <param name="ServerDirectory">Destination directory in Server.</param>
    procedure UploadFile(const ServerDirectory: WideString); overload; safecall;
    /// <summary>
    ///   Selects a file from client machine, and it's uploaded to VirtualUI
    ///   public path.
    /// </summary>
    procedure UploadFile; overload;
    /// <summary>
    ///   Selects a file from client machine, and it's uploaded to ServerDirectory
    /// </summary>
    /// <param name="ServerDirectory">Destination directory in Server.</param>
    /// <param name="FileName">Returns the full path of uploaded file.</param>
    function UploadFileEx(const ServerDirectory: WideString; out FileName: WideString): WordBool; overload; safecall;
    /// <summary>
    ///   Selects a file from client machine, and it's uploaded to VirtualUI
    ///   public path.
    /// </summary>
    /// <param name="FileName">Returns the full path of uploaded file.</param>
    function UploadFileEx(out FileName: WideString): WordBool; overload;
    /// <summary>
    ///   Pauses sending UI updates to the web browser
    /// </summary>
    procedure Suspend; safecall;
    /// <summary>
    ///   Resume sending UI updates to the web browser
    /// </summary>
    /// <param name="Wnd">The Window to capture.</param>
    /// <param name="FileName">Full path of file to save screenshot.
    ///                        Extensions allowed: jpg, bmp, png.</param>
    procedure Resume; safecall;
    /// <summary>
    ///   Flushes immediately the paintings of a window to the browser.
    ///   This is meant to be used in situations where the window's thread
    ///   is busy doing some heavy work. Splash windows in initialization
    ///   is one of those cases.
    /// </summary>
    /// <param name="Wnd">The Window to be flushed</param>
    /// <returns>
    ///   True if ok, False if error.
    /// </returns>
    function FlushWindow(Wnd: Integer): WordBool; safecall;
    /// <summary>
    ///   Takes a screenshot of a Window.
    /// </summary>
    /// <param name="Wnd">The Window to capture.</param>
    /// <param name="FileName">Full path of file to save screenshot.
    ///                        Extensions allowed: jpg, bmp, png.</param>
    function TakeScreenshot(Wnd: Integer; const FileName: WideString): WordBool; safecall;
    /// <summary>
    ///   Displays a popup with a button to open a web link.
    /// </summary>
    /// <param name="url">Link to open.</param>
    /// <param name="caption">Text to display in popup.</param>
    procedure OpenLinkDlg(const url: WideString; const caption: WideString); safecall;
    /// <summary>
    /// Sends a data string to the web browser.
    /// </summary>
    /// <remarks>
    /// This method is used to send custom data to the browser for
    /// custom purposes.
    /// </remarks>
    procedure SendMessage(const Data: WideString); safecall;
    /// <summary>
    ///   Allows the execution of the passed application.
    /// </summary>
    /// <param name="Filename">
    ///   regular expression specifying the filename(s) of the applications
    ///   allowed to run.
    /// </param>
    /// <remarks>
    ///   Under VirtualUI environment, only applications precompiled with
    ///   VirtualUI SDK should be allowed to run. Applications not under
    ///   VirtualUI control, cannot be controlled.
    /// </remarks>
    procedure AllowExecute(const Filename: WideString); safecall;
    /// <summary>
    ///   Allows to the the image quality for the specified window.
    /// </summary>
    /// <param name="Wnd">
    ///   Window handle.
    /// </param>
    /// <param name="Class">
    ///   Window classname.
    /// </param>
    /// <param name="Quality">
    ///   Quality from 0 to 100.
    /// </param>
    procedure SetImageQualityByWnd(Wnd: Integer; const Class_: WideString; Quality: Integer); safecall;
    /// <summary>
    ///   In mobile, shows the keyboard.
    /// </summary>
    procedure ShowVirtualKeyboard; safecall;
    /// <summary>
    /// \Returns the VirtualUI's state.
    /// </summary>
    property Active: WordBool read Get_Active;
    /// <summary>
    ///   Enables/disables VirtualUI for the container application.
    /// </summary>
    property Enabled: WordBool read Get_Enabled write Set_Enabled;
    /// <summary>
    /// Gets/sets the development mode.
    /// </summary>
    /// <remarks>
    /// When in development mode, applications executed under the
    /// IDE, connect to the Development Server, allowing the access
    /// to the application from the browser while in debugging. 
    /// </remarks>
    property DevMode: WordBool read Get_DevMode write Set_DevMode;
    /// <summary>
    /// Enables/disables the use of standard dialogs.
    /// </summary>
    /// <remarks>
    /// When set to false, the standard save, open and print dialogs
    /// are replaced by native browser ones, enabling you to extend
    /// the operations to the remote computer.
    /// </remarks>
    property StdDialogs: WordBool read Get_StdDialogs write Set_StdDialogs;
    /// <summary>
    /// Contains information regarding the end-user's environment.
    /// </summary>                                                 
    property BrowserInfo: IBrowserInfo read Get_BrowserInfo;
    /// <summary>
    /// Allows for managing the Development Server. 
    /// </summary>                                  
    property DevServer: IDevServer read Get_DevServer;
    /// <summary>
    ///   Controls some working parameters on the client side.
    /// </summary>
    property ClientSettings: IClientSettings read Get_ClientSettings;
    /// <summary>
    /// Session recording and playback.
    /// </summary>
    /// <remarks>
    /// To record a session:
    /// 
    /// \- Set the Recorder.Filename property with the path and name
    /// of the session file to be used. No extension is needed; the
    /// recorder will generate two files, with extensions idx and
    /// dat.
    /// 
    /// \- Call Recorder.Play, passing a track name. This name will
    /// allow to play different recordings in the same session.
    ///
    /// To stop recording:
    /// 
    /// \- Call Recorder.Stop.
    /// 
    /// To play a recorded session:
    /// 
    /// \- Set the Filename property with the path and name of the
    /// session file to be played (the file with idx extension).
    /// 
    /// \- Call Play with the range of entries to play.
    /// 
    /// To play an entire session, pass 0 and the Count property.
    /// 
    /// To play only a specific track, pass the Position of track to
    /// reproduce as From, and the Position of next track as To. For
    /// the last track, the To parameter must be the Count property
    /// of recorder. 
    /// </remarks>                                                  
    property Recorder: IRecorder read Get_Recorder;
    /// <summary>
    /// FileSystem virtualization
    /// </summary>
    /// <remarks>
    /// </remarks>
    property FileSystemFilter: IFileSystemFilter read Get_FileSystemFilter;
    /// <summary>
    /// Registry virtualization
    /// </summary>
    /// <remarks>
    /// </remarks>
    property RegistryFilter: IRegistryFilter read Get_RegistryFilter;
    /// <summary>
    /// Fires during an upload request, allowing you to change the
    /// save folder.
    /// </summary>
    property OnGetUploadDir: TGetUploadDirEvent read FOnGetUploadDir write FOnGetUploadDir;
    /// <summary>
    /// Fires when the VirtualUI Viewer's container window resizes.
    /// Normally, when the browser resizes.
    /// </summary>
    /// <remarks>
    /// Allows you to take action when the  VirtualUI Viewer's
    /// container window resizes. Set Handled to true to disable the
    /// default processing, which resizing all maximized windows. 
    /// </remarks>                                                  
    property OnBrowserResize: TBrowserResizeEvent read FOnBrowserResize write FOnBrowserResize;
    /// <summary>
    ///   Fires when a custom data string is sent from the web browser page.
    /// </summary>
    property OnReceiveMessage: TReceiveMessageEvent read FOnReceiveMessage write FOnReceiveMessage;
    /// <summary>
    ///   Fires when the browser window is about to close.
    /// </summary>
    property OnClose: TCloseEvent read FOnClose write FOnClose;
    /// <summary>
    ///   Fires when the file has been sent.
    /// </summary>
    property OnDownloadEnd: TDownloadEndEvent read FOnDownloadEnd write FOnDownloadEnd;
    /// <summary>
    ///   Fires when the UploadFile method ends, returning the full path
    ///   of uploaded file.
    /// </summary>
    property OnUploadEnd: TUploadEndEvent read FOnUploadEnd write FOnUploadEnd;
    /// <summary>
    ///   Fires when the Save Dialog is Accepted.
    /// </summary>
    property OnSaveDialog: TSaveDialogEvent read FOnSaveDialog write FOnSaveDialog;
    /// <summary>
    ///   Fires when there is a change in the recording or playback status.
    /// </summary>
    property OnRecorderChanged: TRecorderChangedEvent read FOnRecorderChanged write FOnRecorderChanged;
    /// <summary>
    ///   Fires when there is a drag and drop operation with files
    /// </summary>
    property OnDragFile: TOnDragFileEvent read FOnDragFile write FOnDragFile;
    /// <summary>
    ///   Option flags.
    /// </summary>
    property Options: LongWord read Get_Options write Set_Options;
    /// <summary>
    ///   Contains methods to modify the behavior on the HTML page.
    /// </summary>
    property HTMLDoc: IHTMLDoc read Get_HTMLDoc;
  end;

  TEventSink = class(TInterfacedObject, IUnknown, IDispatch)
  private
    FController: TObject;
    FRefCount: Integer;
    // IUnknown
    function _AddRef: Integer; stdcall;
    function _Release: Integer; stdcall;
    function QueryInterface(const IID: TGUID; out Obj): HResult; stdcall;
    // IDispatch
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer; Flag: Word;
      var Params; VarResult, ExceptInfo, ArgErr: Pointer): HResult; stdcall;
  protected
    function GetAsInteger(Arg: TVariantArg): Integer;
    procedure SetInteger(Arg: TVariantArg; Value: Integer);
    function GetAsBoolean(Arg: TVariantArg): Boolean;
    procedure SetBoolean(Arg: TVariantArg; Value: Boolean);
    function GetAsString(Arg: TVariantArg): string;
    procedure SetString(Arg: TVariantArg; Value: string);
    function GetAsInterface(Arg: TVariantArg): IDispatch;
    procedure SetInterface(Arg: TVariantArg; Value: IDispatch);

    function InternalQueryInterface(const IID: TGUID; out Obj): HResult; virtual; abstract;
    function InternalInvoke(DispID: Integer; const IID: TGUID; LocaleID: Integer; Flag: Word;
      var Params; VarResult, ExceptInfo, ArgErr: Pointer): HResult; virtual; abstract;
  public
    constructor Create(Controller: TObject);
    destructor Destroy; override;
  end;

  TVirtualUIEventSink = class(TEventSink)
  protected
    function Controller: TVirtualUI;
    function InternalQueryInterface(const IID: TGUID; out Obj): HResult; override;
    function InternalInvoke(DispID: Integer; const IID: TGUID; LocaleID: Integer; Flag: Word;
      var Params; VarResult, ExceptInfo, ArgErr: Pointer): HResult; override;
  end;

  TExecuteMethodEvent = procedure(const Sender: IJSObject; const Method: IJSMethod) of object;
  TPropertyChangeEvent = procedure(const Sender: IJSObject; const Prop: IJSProperty) of object;

  TJSObject = class;
  TJSObjectEventSink = class(TEventSink)
  protected
    function Controller: TJSObject;
    function InternalQueryInterface(const IID: TGUID; out Obj): HResult; override;
    function InternalInvoke(DispID: Integer; const IID: TGUID; LocaleID: Integer; Flag: Word;
      var Params; VarResult, ExceptInfo, ArgErr: Pointer): HResult; override;
  end;

  /// <summary>
  /// Represents a custom remotable object.
  /// </summary>
  /// <remarks>
  /// TJSObject allows you to define an object model that is
  /// mirrored on the client side, and allows for an easy, powerful
  /// and straight-forward way to connect the web browser client
  /// application and the remoted Windows application.
  /// 
  /// TJSObject can contain properties (IJSProperties), methods
  /// (IJSMethods), events (IJSEvents) and children objects.
  /// Changes to properties values are propagated in from server to
  /// client and viceversa, keeping the data synchronized.
  /// 
  /// TJSObject is defined as a model seen from the client
  /// perspective. A method (IJSMethod) is called on the client
  /// side and executed on the server side. An event (IJSEvent) is
  /// called on the server side and raised on the client side.
  /// 
  /// 
  /// </remarks>                                                   
  TJSObject = class(TInterfacedObject, IJSObject)
  private
    FJSObject: IJSObject;
    FEventSink: IUnknown;
    FCookie: {$IFDEF FPC}DWORD;{$ELSE}Integer;{$ENDIF}
    FOnExecuteMethod: TExecuteMethodEvent;
    FOnPropertyChange: TPropertyChangeEvent;

    procedure DoExecuteMethod(const Sender: IJSObject; const Method: IJSMethod);
    procedure DoPropertyChange(const Sender: IJSObject; const Prop: IJSProperty);
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;

    function Get_Id: WideString; safecall;
    procedure Set_Id(const Value: WideString); safecall;
    function Get_Properties: IJSProperties; safecall;
    function Get_Methods: IJSMethods; safecall;
    function Get_Events: IJSEvents; safecall;
    function Get_Objects: IJSObjects; safecall;
  public
    constructor Create(const Id: WideString);
    destructor Destroy; override;
    /// <summary>
    ///   Fires the event specified in <i>Name</i> on the client-size
    ///   javascript API.
    /// </summary>
    /// <param name="Name">
    ///   Event name
    /// </param>
    /// <param name="Arguments">
    ///   List of arguments
    /// </param>
    procedure FireEvent(const Name: WideString; const Arguments: IJSArguments); safecall;
    /// <summary>
    ///   When this method called, all properties getters are internally called
    ///   looking for changes. Any change to the property value is sent to the
    ///   client.
    /// </summary>
    procedure ApplyChanges; safecall;
    /// <summary>
    ///   Propagates the whole JSObject definition to the javascript client.
    /// </summary>
    procedure ApplyModel; safecall;
    /// <summary>
    ///   Identifier of the object. It must be unique among siblings objects.
    /// </summary>
    property Id: WideString read Get_Id write Set_Id;
    /// <summary>
    ///   List containing all properties of this object.
    /// </summary>
    property Properties: IJSProperties read Get_Properties;
    /// <summary>
    ///   List containing all methods of this object.
    /// </summary>
    property Methods: IJSMethods read Get_Methods;
    /// <summary>
    ///   List containing all events of this object.
    /// </summary>
    property Events: IJSEvents read Get_Events;
    /// <summary>
    ///   List containing all events of this object.
    /// </summary>
    property Objects: IJSObjects read Get_Objects;
    /// <summary>
    ///   Fired when a method is executed on the remote object.
    /// </summary>
    property OnExecuteMethod: TExecuteMethodEvent read FOnExecuteMethod write FOnExecuteMethod;
    /// <summary>
    ///   Fired when a property value has been changed on the remote object.
    /// </summary>
    property OnPropertyChange: TPropertyChangeEvent read FOnPropertyChange write FOnPropertyChange;
  end;

  {$IFDEF DELPHIXE_PLUS}
  TJSPropertyNNProc = reference to procedure (const Parent: IJSObject; const Prop: IJSProperty);
  {$ENDIF}
  TJSPropertyProc = procedure (const Parent: IJSObject; const Prop: IJSProperty) of object;

  TJSBinding = class(TInterfacedObject,IJSBinding)
  private
    {$IFDEF DELPHIXE_PLUS}
    FNNProc : TJSPropertyNNProc;
    {$ENDIF}
    FProc : TJSPropertyProc;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;

    procedure Set_(const Parent: IJSObject; const Prop: IJSProperty); safecall;
  public
    /// <summary>
    ///   Creates an IJSBinding wrapper passing an anonymous procedure
    ///   as a callback.
    /// </summary>
    {$IFDEF DELPHIXE_PLUS}
    constructor Create(ANNProc:TJSPropertyNNProc);overload;
    {$ENDIF}
    /// <summary>
    ///   Creates an IJSBinding wrapper passing an object procedure
    ///   as a callback.
    /// </summary>
    constructor Create(AProc:TJSPropertyProc);overload;
  end;

  {$IFDEF DELPHIXE_PLUS}
  TJSMethodNNProc = reference to procedure (const Parent: IJSObject; const Method: IJSMethod);
  {$ENDIF}
  TJSMethodProc = procedure (const Parent: IJSObject; const Method: IJSMethod) of object;

  TJSCallback = class(TInterfacedObject,IJSCallback)
  private
    {$IFDEF DELPHIXE_PLUS}
    FNNProc : TJSMethodNNProc;
    {$ENDIF}
    FProc : TJSMethodProc;
  protected
    function GetTypeInfoCount(out Count: Integer): HResult; stdcall;
    function GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult; stdcall;
    function GetIDsOfNames(const IID: TGUID; Names: Pointer;
      NameCount, LocaleID: Integer; DispIDs: Pointer): HResult; stdcall;
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
      Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult; stdcall;

    procedure Callback(const Parent: IJSObject; const Method: IJSMethod); safecall;
  public
    /// <summary>
    ///   Creates an IJSCallback wrapper passing an anonymous procedure
    ///   as a callback.
    /// </summary>
    {$IFDEF DELPHIXE_PLUS}
    constructor Create(ANNProc:TJSMethodNNProc);overload;
    {$ENDIF}
    /// <summary>
    ///   Creates an IJSCallback wrapper passing an object procedure
    ///   as a callback.
    /// </summary>
    constructor Create(AProc:TJSMethodProc);overload;
  end;

/// <summary>
///   Returns a global VirtualUI object.
/// </summary>
function VirtualUI: TVirtualUI;
/// <summary>
///   Returns the path where Thinfinity.VirtualUI.dll is located.
/// </summary>
function GetDllDir:string;

implementation

uses IniFiles;

var
  gVirtualUI: TVirtualUI;
  LibHandle: THandle;
  DllGetInstance: function(var Value: IVirtualUI):HResult; stdcall;
  DllCreateJSObject: function (var Value: IJSObject): HRESULT; stdcall;

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
function VirtualUI: TVirtualUI;
begin
  if not Assigned(gVirtualUI) then
    gVirtualUI := TVirtualUI.Create;
  Result := gVirtualUI;
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
  key32 := '\SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\VirtualUI';
  key64 := '\SOFTWARE\Cybele Software\Setups\Thinfinity\VirtualUI';
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
    else Result := ExtractFilePath(ParamStr(0));
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
    Filename := 'Thinfinity.VirtualUI.dll';
    LibHandle := LoadLibrary(PChar(GetDllDir + Filename));
    if LibHandle = 0 then Exit;
    try
      @DllGetInstance := GetProcAddress(LibHandle, 'DllGetInstance');
      if Pointer(@DllGetInstance) = nil then RaiseLastOSError;

      @DllCreateJSObject := GetProcAddress(LibHandle, 'DllCreateJSObject');
      if Pointer(@DllCreateJSObject) = nil then RaiseLastOSError;
    except
      FreeLibrary(LibHandle);
      LibHandle := 0;
      raise;
    end;
  end;
end;

{ TVirtualUI }

procedure TVirtualUI.AllowExecute(const Filename: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.AllowExecute(Filename);
end;

constructor TVirtualUI.Create;
begin
  if Assigned(DllGetInstance) then
  begin
    DllGetInstance(FVirtualUI);
    FEventSink := TVirtualUIEventSink.Create(Self);
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
    InterfaceConnect(FVirtualUI, IEvents, FEventSink, FCookie);
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
  end;
  FBrowserInfo := TBrowserInfo.Create(FVirtualUI);
  FDevServer := TDevServer.Create(FVirtualUI);
  FClientSettings := TClientSettings.Create(FVirtualUI);
  FHTMLDoc := THTMLDoc.Create(FVirtualUI);
end;

destructor TVirtualUI.Destroy;
begin
  if Assigned(FVirtualUI) then
  begin
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
    InterfaceDisconnect(FVirtualUI, IEvents, FCookie);
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
    FEventSink := nil;
    FVirtualUI := nil;
  end;
  FBrowserInfo := nil;
  FDevServer := nil;
  FClientSettings := nil;
  FHTMLDoc := nil;
  if gVirtualUI = Self then
    gVirtualUI := nil;
  inherited;
end;

procedure TVirtualUI.DoRecorderChanged;
begin
  if Assigned(FOnRecorderChanged) then
    FOnRecorderChanged(Self);
end;

procedure TVirtualUI.DoBrowserResize(var Width, Height: Integer;
  var ResizeMaximized: Boolean);
begin
  if Assigned(FOnBrowserResize) then
    FOnBrowserResize(Self, Width, Height, ResizeMaximized);
end;

procedure TVirtualUI.DoClose;
begin
  if Assigned(FOnClose) then
    FOnClose(Self);
end;

procedure TVirtualUI.DoDownloadEnd(const Filename: WideString);
begin
  if Assigned(FOnDownloadEnd) then
    FOnDownloadEnd(Self, Filename);
end;

procedure TVirtualUI.DoDragFile(Action: DragAction; X, Y: Integer; const Filenames: string);
begin
  if Assigned(FOnDragFile) then
    FOnDragFile(Action, X, Y, Filenames);
end;

procedure TVirtualUI.DoUploadEnd(const Filename: WideString);
begin
  if Assigned(FOnUploadEnd) then
    FOnUploadEnd(Self, Filename);
end;

procedure TVirtualUI.DoSaveDialog(const Filename: WideString);
begin
  if Assigned(FOnSaveDialog) then
    FOnSaveDialog(Self, Filename);
end;

procedure TVirtualUI.DoGetUploadDir(var Directory: string;
  var Handled: Boolean);
begin
  if Assigned(FOnGetUploadDir) then
    FOnGetUploadDir(Self, Directory, Handled);
end;

procedure TVirtualUI.DoReceiveMessage(Data: WideString);
begin
  if Assigned(FOnReceiveMessage) then
    FOnReceiveMessage(Self, Data);
end;

procedure TVirtualUI.DownloadFile(const LocalFilename: WideString);
begin
  DownloadFile(LocalFileName, '', '');
end;

procedure TVirtualUI.DownloadFile(const LocalFilename: WideString; const RemoteFilename: WideString);
begin
  DownloadFile(LocalFileName, RemoteFilename, '');
end;

procedure TVirtualUI.DownloadFile(const LocalFilename: WideString;
          const RemoteFilename: WideString; const MimeType: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.DownloadFile(LocalFilename, RemoteFilename, MimeType);
end;

function TVirtualUI.Get_StdDialogs: WordBool;
begin
  Result := True;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.StdDialogs;
end;

function TVirtualUI.Get_HTMLDoc: IHTMLDoc;
begin
  Result := FHTMLDoc;
end;

function TVirtualUI.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.GetTypeInfo(Index, LocaleID, TypeInfo)
  else begin
    Result := E_NOTIMPL;
    Pointer(TypeInfo) := nil;
  end;
end;

function TVirtualUI.GetTypeInfoCount(out Count: Integer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.GetTypeInfoCount(Count)
  else begin
    Result := 0;
    Count := 0;
  end;
end;

function TVirtualUI.Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
  Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr)
  else
    Result := E_NOTIMPL;
end;

procedure TVirtualUI.PrintPdf(const AFileName: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.PrintPdf(AFileName);
end;

procedure TVirtualUI.PreviewPdf(const AFileName: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.PreviewPdf(AFileName);
end;

procedure TVirtualUI.OpenLinkDlg(const url, caption: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.OpenLinkDlg(url, caption);
end;

function TVirtualUI.Get_Active: WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.Active;
end;

function TVirtualUI.Get_BrowserInfo: IBrowserInfo;
begin
  Result := FBrowserInfo;
end;

function TVirtualUI.Get_ClientSettings: IClientSettings;
begin
  Result := FClientSettings;
end;

function TVirtualUI.Get_Recorder;
begin
  Result := nil;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.Recorder;
end;

function TVirtualUI.Get_FileSystemFilter;
begin
  Result := nil;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.FileSystemFilter;
end;

function TVirtualUI.Get_Options: LongWord;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.Options;
end;

function TVirtualUI.Get_RegistryFilter;
begin
  Result := nil;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.RegistryFilter;
end;

function TVirtualUI.Get_DevMode: WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevMode;
end;

function TVirtualUI.Get_DevServer: IDevServer;
begin
  Result := FDevServer;
end;

function TVirtualUI.Get_Enabled: WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.Enabled;
end;

function TVirtualUI.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs)
  else
    Result := E_NOTIMPL;
end;

function TVirtualUI.Start(Timeout: Integer): WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.Start(Timeout);
end;

function TVirtualUI.Start: WordBool;
begin
  Result := Start(60000);
end;

procedure TVirtualUI.Stop;
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Stop;
  if gVirtualUI = Self then
    Free;
end;

function TVirtualUI.TakeScreenshot(Wnd: Integer; const FileName: WideString): WordBool;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.TakeScreenshot(Wnd, FileName)
  else
    Result := false;
end;

procedure TVirtualUI.UploadFile(const ServerDirectory: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.UploadFile(ServerDirectory);
end;

procedure TVirtualUI.UploadFile;
begin
  UploadFile('');
end;

function TVirtualUI.UploadFileEx(const ServerDirectory: WideString;
  out FileName: WideString): WordBool;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.UploadFileEx(ServerDirectory, FileName)
  else
    Result := false;
end;

function TVirtualUI.UploadFileEx(out FileName: WideString): WordBool;
begin
  Result := UploadFileEx('', FileName);
end;

procedure TVirtualUI.Suspend;
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Suspend;
end;

procedure TVirtualUI.Resume;
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Resume;
end;

procedure TVirtualUI.SendMessage(const Data: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.SendMessage(Data);
end;

procedure TVirtualUI.SetImageQualityByWnd(Wnd: Integer; const Class_: WideString; Quality: Integer);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.SetImageQualityByWnd(Wnd,Class_,Quality);
end;

function TVirtualUI.FlushWindow(Wnd: Integer): WordBool;
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.FlushWindow(Wnd);
end;

procedure TVirtualUI.Set_DevMode(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Set_DevMode(Value);
end;

procedure TVirtualUI.Set_Enabled(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Set_Enabled(Value);
end;

procedure TVirtualUI.Set_Options(Value: LongWord);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Set_Options(Value);
end;

procedure TVirtualUI.Set_StdDialogs(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.Set_StdDialogs(Value);
end;

procedure TVirtualUI.ShowVirtualKeyboard;
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ShowVirtualKeyboard;
end;

{ TDevServer }

constructor TDevServer.Create(AVirtualUI: IVirtualUI);
begin
  inherited Create;
  FVirtualUI := AVirtualUI;
end;

destructor TDevServer.Destroy;
begin
  FVirtualUI := nil;
  inherited;
end;

function TDevServer.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs)
  else
    Result := E_NOTIMPL;
end;

function TDevServer.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.GetTypeInfo(Index, LocaleID, TypeInfo)
  else begin
    Result := E_NOTIMPL;
    Pointer(TypeInfo) := nil;
  end;
end;

function TDevServer.GetTypeInfoCount(out Count: Integer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.GetTypeInfoCount(Count)
  else begin
    Count := 0;
    Result := S_OK;
  end;
end;

function TDevServer.Get_Enabled: WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.Enabled;
end;

function TDevServer.Get_Port: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.Port;
end;

function TDevServer.Get_StartBrowser: WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.StartBrowser;
end;

function TDevServer.Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
  Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.DevServer.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr)
  else
    Result := E_NOTIMPL;
end;

procedure TDevServer.Set_Enabled(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.DevServer.Enabled := Value;
end;

procedure TDevServer.Set_Port(Value: Integer);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.DevServer.Port := Value;
end;

procedure TDevServer.Set_StartBrowser(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.DevServer.StartBrowser := Value;
end;

{ TEventSink }

function TEventSink._AddRef: Integer;
begin
  // No need to implement, since lifetime is tied to client
  Result := InterlockedIncrement(FRefCount);
end;

function TEventSink._Release: Integer;
begin
  // No need to implement, since lifetime is tied to client
//  Result := 1;
  Result := InterlockedDecrement(FRefCount);
  if Result = 0 then
    Destroy;
end;

constructor TEventSink.Create(Controller: TObject);
begin
  FController := Controller;
  inherited Create;
end;

function TEventSink.GetAsBoolean(Arg: TVariantArg): Boolean;
var
  Aux : WordBool;
begin
  Aux := False;
  if Arg.vt = varBoolean then
    Aux := Arg.vbool else
  if Arg.vt = varByRef or varBoolean then
    Aux := Arg.pbool^;
  Result := Aux;
end;

function TEventSink.GetAsInteger(Arg: TVariantArg): Integer;
begin
  Result := 0;
  if Arg.vt = varInteger then
    Result := Arg.intVal else
  if Arg.vt = varByRef or varInteger then
    Result := Arg.pintVal^;
end;

function TEventSink.GetAsInterface(Arg: TVariantArg): IDispatch;
begin
  Result := nil;
  if Arg.vt = varDispatch then
    Result := IDispatch(Arg.dispVal) else
  if Arg.vt = varByRef or varDispatch then
    Result := Arg.pdispVal^;
end;

function TEventSink.GetAsString(Arg: TVariantArg): string;
var
  Aux : WideString;
begin
  if Arg.vt = varOleStr then
    Aux := Arg.bstrVal else
  if Arg.vt = varByRef or varOleStr then
    Aux := Arg.pbstrVal^;
  Result := Aux;
end;

function TEventSink.GetIDsOfNames(const IID: TGUID; Names: Pointer;
  NameCount, LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  Result := E_NOTIMPL;
end;

function TEventSink.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  Pointer(TypeInfo) := nil;
  Result := E_NOTIMPL;
end;

function TEventSink.GetTypeInfoCount(out Count: Integer): HResult;
begin
  Count := 0;
  Result := S_OK;
end;

function TEventSink.Invoke(DispID: Integer; const IID: TGUID;
  LocaleID: Integer; Flag: Word; var Params; VarResult, ExceptInfo,
  ArgErr: Pointer): HResult;
begin
  Result := InternalInvoke(DispID, IID, LocaleID, Flag, Params, VarResult,
    ExceptInfo, ArgErr);
end;

function TEventSink.QueryInterface(const IID: TGUID; out Obj): HResult;
// this method returns an instance only when the requested interface is
// IUnknown, IDispatch or IServerWithEventsEvents
begin
  {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
  if GetInterface(IID, Obj) then Result:= S_OK
  else Result := InternalQueryInterface(IID, Obj);
  {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
end;

procedure TEventSink.SetBoolean(Arg: TVariantArg; Value: Boolean);
begin
  if Arg.vt = varByRef or varBoolean then
    Arg.pbool^ := Value;
end;

procedure TEventSink.SetInteger(Arg: TVariantArg; Value: Integer);
begin
  if Arg.vt = varByRef or varInteger then
    Arg.pintVal^ := Value;
end;

procedure TEventSink.SetInterface(Arg: TVariantArg; Value: IDispatch);
begin
  if Arg.vt = varByRef or varDispatch then
    Arg.pdispVal^ := Value;
end;

procedure TEventSink.SetString(Arg: TVariantArg; Value: string);
var
  Aux : WideString;
begin
  Aux := Value;
  if Arg.vt = varByRef or varOleStr then
  begin
    SysFreeString(PWideChar(Arg.pbstrVal^));
    Arg.pbstrVal^ := SysAllocString(PWideChar(Aux));
  end;
end;

destructor TEventSink.Destroy;
begin
  FController := nil;
  inherited;
end;

{ TVirtualUIEventSink }

function TVirtualUIEventSink.Controller: TVirtualUI;
begin
  Result := FController as TVirtualUI;
end;

function TVirtualUIEventSink.InternalInvoke(DispID: Integer; const IID: TGUID;
  LocaleID: Integer; Flag: Word; var Params; VarResult, ExceptInfo,
  ArgErr: Pointer): HResult;
var
  Handled, ResizeMaximized: Boolean;
  Directory, Data, Filenames: string;
  Width, Height, X, Y, Action: Integer;
begin
  Result:= S_OK;
  case DispID of
    101:  begin
      Directory := GetAsString(TDispParams(Params).rgvarg^[1]);
      Handled := GetAsBoolean(TDispParams(Params).rgvarg^[0]);
      Controller.DoGetUploadDir(Directory, Handled);
      SetString(TDispParams(Params).rgvarg^[1], Directory);
      SetBoolean(TDispParams(Params).rgvarg^[0], Handled);
    end;
    102:  begin
      Width := GetAsInteger(TDispParams(Params).rgvarg^[2]);
      Height := GetAsInteger(TDispParams(Params).rgvarg^[1]);
      ResizeMaximized := GetAsBoolean(TDispParams(Params).rgvarg^[0]);
      Controller.DoBrowserResize(Width, Height, ResizeMaximized);
      SetBoolean(TDispParams(Params).rgvarg^[0], ResizeMaximized);
      SetInteger(TDispParams(Params).rgvarg^[1], Height);
      SetInteger(TDispParams(Params).rgvarg^[2], Width);
    end;
    103: begin
      Controller.DoClose;
    end;
    104: begin
      Data := GetAsString(TDispParams(Params).rgvarg^[0]);
      Controller.DoReceiveMessage(Data);
    end;
    105: begin
      Data := GetAsString(TDispParams(Params).rgvarg^[0]);
      Controller.DoDownloadEnd(Data);
    end;
    106: begin
      Controller.DoRecorderChanged;
    end;
    107: begin
      Data := GetAsString(TDispParams(Params).rgvarg^[0]);
      Controller.DoUploadEnd(Data);
    end;
    201: begin
      Action := GetAsInteger(TDispParams(Params).rgvarg^[3]);
      X := GetAsInteger(TDispParams(Params).rgvarg^[2]);
      Y := GetAsInteger(TDispParams(Params).rgvarg^[1]);
      Filenames := GetAsString(TDispParams(Params).rgvarg^[0]);
      Controller.DoDragFile(Action, X, Y, Filenames);
    end;
    202: begin
      Data := GetAsString(TDispParams(Params).rgvarg^[0]);
      Controller.DoSaveDialog(Data);
    end;
  end
end;

function TVirtualUIEventSink.InternalQueryInterface(const IID: TGUID;
  out Obj): HResult;
begin
  {$IFDEF DELPHI6_PLUS} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
  if IsEqualIID(IID, IEvents) then
    Result:= QueryInterface(IDispatch, Obj) else
    Result:= E_NOINTERFACE;
  {$IFDEF DELPHI6_PLUS} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
end;

{ TBrowserInfo }

constructor TBrowserInfo.Create(AVirtualUI: IVirtualUI);
begin
  inherited Create;
  FVirtualUI := AVirtualUI;
end;

destructor TBrowserInfo.Destroy;
begin
  FVirtualUI := nil;
  inherited;
end;

function TBrowserInfo.GetExtraDataValue(const Name: WideString): WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.GetExtraDataValue(Name);
end;

function TBrowserInfo.GetCookie(const Name: WideString): WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.GetCookie(Name);
end;

function TBrowserInfo.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs)
  else
    Result := E_NOTIMPL;
end;

function TBrowserInfo.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.GetTypeInfo(Index, LocaleID, TypeInfo)
  else begin
    Result := E_NOTIMPL;
    Pointer(TypeInfo) := nil;
  end;
end;

function TBrowserInfo.GetTypeInfoCount(out Count: Integer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.GetTypeInfoCount(Count)
  else begin
    Result := 0;
    Count := 0;
  end;
end;

function TBrowserInfo.Get_BrowserHeight: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.BrowserHeight;
end;

function TBrowserInfo.Get_BrowserWidth: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.BrowserWidth;
end;

function TBrowserInfo.Get_CustomData: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.CustomData;
end;

function TBrowserInfo.Get_IPAddress: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.IPAddress;
end;

function TBrowserInfo.Get_Location: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.Location;
end;

function TBrowserInfo.Get_Orientation: Orientation;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.Orientation;
end;

function TBrowserInfo.Get_ScreenHeight: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.ScreenHeight;
end;

function TBrowserInfo.Get_ScreenResolution: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.ScreenResolution;
end;

function TBrowserInfo.Get_ScreenWidth: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.ScreenWidth;
end;

function TBrowserInfo.Get_SelectedRule: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.SelectedRule;
end;

function TBrowserInfo.Get_ExtraData: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.ExtraData;
end;

function TBrowserInfo.Get_UniqueBrowserId: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.UniqueBrowserId;
end;

function TBrowserInfo.Get_UserAgent: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.UserAgent;
end;

function TBrowserInfo.Get_Username: WideString;
begin
  Result := '';
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.Username;
end;

function TBrowserInfo.Get_ViewHeight: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.ViewHeight;
end;

function TBrowserInfo.Get_ViewWidth: Integer;
begin
  Result := 0;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.ViewWidth;
end;

function TBrowserInfo.Invoke(DispID: Integer; const IID: TGUID;
  LocaleID: Integer; Flags: Word; var Params; VarResult, ExcepInfo,
  ArgErr: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.BrowserInfo.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr)
  else
    Result := E_NOTIMPL;
end;

procedure TBrowserInfo.SetCookie(const Name, Value, Expires: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.BrowserInfo.SetCookie(Name, Value, Expires);
end;

procedure TBrowserInfo.Set_CustomData(const Value: WideString);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.BrowserInfo.CustomData := Value;
end;

procedure TBrowserInfo.Set_ViewHeight(Value: Integer);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.BrowserInfo.ViewHeight := Value;
end;

procedure TBrowserInfo.Set_ViewWidth(Value: Integer);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.BrowserInfo.ViewWidth := Value;
end;

{ TClientSettings }

constructor TClientSettings.Create(AVirtualUI: IVirtualUI);
begin
  inherited Create;
  FVirtualUI := AVirtualUI;
end;

destructor TClientSettings.Destroy;
begin
  FVirtualUI := nil;
  inherited;
end;

function TClientSettings.GetIDsOfNames(const IID: TGUID; Names: Pointer;
  NameCount, LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs)
  else
    Result := E_NOTIMPL;
end;

function TClientSettings.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.GetTypeInfo(Index, LocaleID, TypeInfo)
  else begin
    Result := E_NOTIMPL;
    Pointer(TypeInfo) := nil;
  end;
end;

function TClientSettings.GetTypeInfoCount(out Count: Integer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.GetTypeInfoCount(Count)
  else begin
    Result := 0;
    Count := 0;
  end;
end;

function TClientSettings.Get_CursorVisible: WordBool;
begin
  Result := True;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.CursorVisible;
end;

function TClientSettings.Get_MouseMoveGestureAction: MouseMoveGestureAction;
begin
  Result := MM_ACTION_MOVE;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.MouseMoveGestureAction;
end;

function TClientSettings.Get_MouseMoveGestureStyle: MouseMoveGestureStyle;
begin
  Result := MM_STYLE_ABSOLUTE;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.MouseMoveGestureStyle;
end;

function TClientSettings.Get_MousePressAsRightButton: WordBool;
begin
  Result := False;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.MousePressAsRightButton;
end;

function TClientSettings.Get_MouseWheelDirection: Integer;
begin
  Result := 1;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.MouseWheelDirection;
end;

function TClientSettings.Get_MouseWheelStepValue: Integer;
begin
  Result := 120;
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.MouseWheelStepValue;
end;

function TClientSettings.Invoke(DispID: Integer; const IID: TGUID;
  LocaleID: Integer; Flags: Word; var Params; VarResult, ExcepInfo,
  ArgErr: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.ClientSettings.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr)
  else
    Result := E_NOTIMPL;
end;

procedure TClientSettings.Set_CursorVisible(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ClientSettings.CursorVisible := Value;
end;

procedure TClientSettings.Set_MouseMoveGestureAction(
  Value: MouseMoveGestureAction);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ClientSettings.MouseMoveGestureAction := Value;
end;

procedure TClientSettings.Set_MouseMoveGestureStyle(
  Value: MouseMoveGestureStyle);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ClientSettings.MouseMoveGestureStyle := Value;
end;

procedure TClientSettings.Set_MousePressAsRightButton(Value: WordBool);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ClientSettings.MousePressAsRightButton := Value;
end;

procedure TClientSettings.Set_MouseWheelDirection(Value: Integer);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ClientSettings.MouseWheelDirection := Value;
end;

procedure TClientSettings.Set_MouseWheelStepValue(Value: Integer);
begin
  if Assigned(FVirtualUI) then
    FVirtualUI.ClientSettings.MouseWheelStepValue := Value;
end;

{ TJSObject }

procedure TJSObject.ApplyChanges;
begin
  if Assigned(FJSObject) then
    FJSObject.ApplyChanges;
end;

procedure TJSObject.ApplyModel;
begin
  if Assigned(FJSObject) then
    FJSObject.ApplyModel;
end;

constructor TJSObject.Create(const Id: WideString);
begin
  if Assigned(DllGetInstance) then
  begin
    DllCreateJSObject(FJSObject);
    FEventSink := TJSObjectEventSink.Create(Self);
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
    InterfaceConnect(FJSObject, IJSObjectEvents, FEventSink, FCookie);
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
    Self.Id := Id;
  end;
end;

destructor TJSObject.Destroy;
begin
  if Assigned(FJSObject) then
  begin
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
    InterfaceDisconnect(FJSObject, IEvents, FCookie);
    {$IFNDEF VER130} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
    FEventSink := nil;
    FJSObject := nil;
  end;
  inherited;
end;

procedure TJSObject.DoExecuteMethod(const Sender: IJSObject;
  const Method: IJSMethod);
begin
  if Assigned(FOnExecuteMethod) then
    FOnExecuteMethod(Sender, Method);
end;

procedure TJSObject.DoPropertyChange(const Sender: IJSObject;
  const Prop: IJSProperty);
begin
  if Assigned(FOnPropertyChange) then
    FOnPropertyChange(Sender, Prop);
end;

procedure TJSObject.FireEvent(const Name: WideString;
  const Arguments: IJSArguments);
begin
  if Assigned(FJSObject) then
    FJSObject.FireEvent(Name, Arguments);
end;

function TJSObject.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  Result := FJSObject.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs);
end;

function TJSObject.GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult;
begin
  Result := FJSObject.GetTypeInfo(Index, LocaleID, TypeInfo);
end;

function TJSObject.GetTypeInfoCount(out Count: Integer): HResult;
begin
  Result := FJSObject.GetTypeInfoCount(Count);
end;

function TJSObject.Get_Events: IJSEvents;
begin
  if Assigned(FJSObject) then
    Result := FJSObject.Events else
    Result := nil;
end;

function TJSObject.Get_Id: WideString;
begin
  if Assigned(FJSObject) then
    Result := FJSObject.Id else
    Result := '';
end;

function TJSObject.Get_Methods: IJSMethods;
begin
  if Assigned(FJSObject) then
    Result := FJSObject.Methods else
    Result := nil;
end;

function TJSObject.Get_Objects: IJSObjects;
begin
  if Assigned(FJSObject) then
    Result := FJSObject.Objects else
    Result := nil;
end;

function TJSObject.Get_Properties: IJSProperties;
begin
  if Assigned(FJSObject) then
    Result := FJSObject.Properties else
    Result := nil;
end;

function TJSObject.Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
  Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
begin
  Result := FJSObject.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr);
end;

procedure TJSObject.Set_Id(const Value: WideString);
begin
  if Assigned(FJSObject) then
    FJSObject.Id := Value;
end;

{ TJSObjectEventSink }

function TJSObjectEventSink.Controller: TJSObject;
begin
  Result := FController as TJSObject;
end;

function TJSObjectEventSink.InternalInvoke(DispID: Integer; const IID: TGUID;
  LocaleID: Integer; Flag: Word; var Params; VarResult, ExceptInfo,
  ArgErr: Pointer): HResult;
var
  Sender: IJSObject;
  Method: IJSMethod;
  Prop: IJSProperty;
begin
  Result:= S_OK;
  case DispID of
    101:  begin
      Sender := GetAsInterface(TDispParams(Params).rgvarg^[1]) as IJSObject;
      Method := GetAsInterface(TDispParams(Params).rgvarg^[0]) as IJSMethod;
      Controller.DoExecuteMethod(Sender, Method);
    end;
    102:  begin
      Sender := GetAsInterface(TDispParams(Params).rgvarg^[1]) as IJSObject;
      Prop := GetAsInterface(TDispParams(Params).rgvarg^[0]) as IJSProperty;
      Controller.DoPropertyChange(Sender, Prop);
    end;
  end
end;

function TJSObjectEventSink.InternalQueryInterface(const IID: TGUID;
  out Obj): HResult;
begin
  {$IFDEF DELPHI6_PLUS} {$WARN SYMBOL_PLATFORM OFF} {$ENDIF}
  if IsEqualIID(IID, IJSObjectEvents) then
    Result:= QueryInterface(IDispatch, Obj) else
    Result:= E_NOINTERFACE;
  {$IFDEF DELPHI6_PLUS} {$WARN SYMBOL_PLATFORM ON} {$ENDIF}
end;

{ TJSBinding }

{$IFDEF DELPHIXE_PLUS}
constructor TJSBinding.Create( ANNProc: TJSPropertyNNProc);
begin
  FNNProc := ANNProc;
end;
{$ENDIF}
constructor TJSBinding.Create(AProc: TJSPropertyProc);
begin
  FProc := AProc;
end;

function TJSBinding.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  Result := E_NOTIMPL;
end;

function TJSBinding.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  Result := E_NOTIMPL;
  Pointer(TypeInfo) := nil;
end;

function TJSBinding.GetTypeInfoCount(out Count: Integer): HResult;
begin
  Count := 0;
  Result := S_OK;
end;

function TJSBinding.Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
  Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
begin
  Result := E_NOTIMPL;
end;

procedure TJSBinding.Set_(const Parent: IJSObject; const Prop: IJSProperty); safecall;
begin
  {$IFDEF DELPHIXE_PLUS}
  if Assigned(FNNProc) then
    FNNProc(Parent, Prop);
  {$ENDIF}
  if Assigned(FProc) then
    FProc(Parent, Prop);
end;

{ TJSCallback }
{$IFDEF DELPHIXE_PLUS}
constructor TJSCallback.Create(ANNProc: TJSMethodNNProc);
begin
  FNNProc := ANNProc;
end;
{$ENDIF}
procedure TJSCallback.Callback(const Parent: IJSObject; const Method: IJSMethod);
begin
  {$IFDEF DELPHIXE_PLUS}
  if Assigned(FNNProc) then
    FNNProc(Parent, Method);
  {$ENDIF}
  if Assigned(FProc) then
    FProc(Parent, Method);
end;

constructor TJSCallback.Create(AProc: TJSMethodProc);
begin
  FProc := AProc;
end;

function TJSCallback.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  Result := E_NOTIMPL;
end;

function TJSCallback.GetTypeInfo(Index, LocaleID: Integer;
  out TypeInfo): HResult;
begin
  Result := E_NOTIMPL;
  Pointer(TypeInfo) := nil;
end;

function TJSCallback.GetTypeInfoCount(out Count: Integer): HResult;
begin
  Count := 0;
  Result := S_OK;
end;

function TJSCallback.Invoke(DispID: Integer; const IID: TGUID;
  LocaleID: Integer; Flags: Word; var Params; VarResult, ExcepInfo,
  ArgErr: Pointer): HResult;
begin
  Result := E_NOTIMPL;
end;

{ THTMLDoc }

constructor THTMLDoc.Create(AVirtualUI: IVirtualUI);
begin
  FVirtualUI := AVirtualUI;
end;

destructor THTMLDoc.Destroy;
begin
  FVirtualUI := nil;
  inherited;
end;

procedure THTMLDoc.CreateSessionURL(const Url, Filename: WideString);
begin
  FVirtualUI.HTMLDoc.CreateSessionURL(Url,Filename);
end;

procedure THTMLDoc.CreateComponent(const Id, Html: WideString;ReplaceWnd: SYSUINT);
begin
  FVirtualUI.HTMLDoc.CreateComponent(Id,Html,ReplaceWnd);
end;

function THTMLDoc.GetIDsOfNames(const IID: TGUID; Names: Pointer; NameCount,
  LocaleID: Integer; DispIDs: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.HTMLDoc.GetIDsOfNames(IID, Names, NameCount, LocaleID, DispIDs)
  else
    Result := E_NOTIMPL;
end;

function THTMLDoc.GetSafeURL(const Filename: WideString;
  Minutes: Integer): WideString;
begin
  Result := FVirtualUI.HTMLDoc.GetSafeURL(Filename,Minutes);
end;

function THTMLDoc.GetTypeInfo(Index, LocaleID: Integer; out TypeInfo): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.HTMLDoc.GetTypeInfo(Index, LocaleID, TypeInfo)
  else begin
    Result := E_NOTIMPL;
    Pointer(TypeInfo) := nil;
  end;
end;

function THTMLDoc.GetTypeInfoCount(out Count: Integer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.HTMLDoc.GetTypeInfoCount(Count)
  else begin
    Count := 0;
    Result := S_OK;
  end;
end;

function THTMLDoc.Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer;
  Flags: Word; var Params; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
begin
  if Assigned(FVirtualUI) then
    Result := FVirtualUI.HTMLDoc.Invoke(DispID, IID, LocaleID, Flags, Params, VarResult, ExcepInfo, ArgErr)
  else
    Result := E_NOTIMPL;
end;

procedure THTMLDoc.LoadScript(const Url, Filename: WideString);
begin
  FVirtualUI.HTMLDoc.LoadScript(Url,Filename);
end;

procedure THTMLDoc.ImportHTML(const Url, Filename: WideString);
begin
  FVirtualUI.HTMLDoc.ImportHTML(Url,Filename);
end;

initialization
  LoadLib;
finalization
  FreeAndNil(gVirtualUI);
end.

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "Thinfinity.VirtualUI.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
VirtualUI* m_VirtualUI;
JSObject* m_RemoteBrowser;

void loadEndCallback(IJSObject* Parent, IJSMethod* Method) {
  String url = JSROGetArgumentAsString(Method, std::wstring(L"url")).c_str();
  Form1->HistoryIndex = Form1->History->IndexOf(url);
  if (Form1->HistoryIndex == -1) {
	Form1->History->Add(url);
	Form1->HistoryIndex = Form1->History->Count-1;
  }
  Form1->edAddress->Text = Form1->History->Strings[Form1->HistoryIndex];
}

void __fastcall FireGoEvent(std::wstring url) {
  IJSEvent* event = JSROGetEvent(m_RemoteBrowser, std::wstring(L"go"));
  JSROSetEventArgAsString(event, std::wstring(L"url"), url);
  event->Fire();
}

//---------------------------------------------------------------------------
void __fastcall TForm1::Init() {
  String path = ExtractFilePath(Application->ExeName);

  m_VirtualUI->HTMLDoc()->LoadScript(std::wstring(L"/x-tag/x-tag-no-polyfills.min.js"),
									 std::wstring(path.c_str()) + std::wstring(L"..\\x-tag\\x-tag-no-polyfills.min.js"));

  m_VirtualUI->HTMLDoc()->ImportHTML(std::wstring(L"/x-tag/vui-webbrowser.html"),
									 std::wstring(path.c_str()) + std::wstring(L"..\\x-tag\\vui-webbrowser\\vui-webbrowser.html"));

  m_VirtualUI->HTMLDoc()->CreateComponent(std::wstring(L"browser1"), std::wstring(L"vui-webbrowser"), (__int64)(Panel2->Handle));

  m_RemoteBrowser = new JSObject(std::wstring(L"browser1"));

  m_RemoteBrowser->Properties()->Add(std::wstring(L"url"));

  IJSEvent* goEvent = m_RemoteBrowser->Events()->Add(std::wstring(L"go"));
  JSROAddEventArgument(goEvent, std::wstring(L"url"), JSDT_STRING);

  IJSMethod* loadEndMethod = m_RemoteBrowser->Methods()->Add(std::wstring(L"loadEnd"));
  JSROAddMethodParameter(loadEndMethod, std::wstring(L"url"), JSDT_STRING);
  loadEndMethod->OnCall(new JSCallback(loadEndCallback), &loadEndMethod);

  m_RemoteBrowser->ApplyModel();

  History = new TStringList();
  HistoryIndex = -1;
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
  m_VirtualUI = new VirtualUI();
  m_VirtualUI->StdDialogs(true);
  m_VirtualUI->Start();
  Init();
  actGoTo->Execute();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::actPrevExecute(TObject *Sender)
{
  if (HistoryIndex < 1)
	return;
  HistoryIndex--;
  FireGoEvent(History->Strings[HistoryIndex].c_str());
}
//---------------------------------------------------------------------------
void __fastcall TForm1::actNextExecute(TObject *Sender)
{
  if ((HistoryIndex == History->Count-1) || (History->Count == 0))
	return;
  HistoryIndex++;
  FireGoEvent(History->Strings[HistoryIndex].c_str());
}
//---------------------------------------------------------------------------
void __fastcall TForm1::actGoToExecute(TObject *Sender)
{
  FireGoEvent(std::wstring(edAddress->Text.c_str()));
}
//---------------------------------------------------------------------------
void __fastcall TForm1::edAddressKeyDown(TObject *Sender, WORD &Key, TShiftState Shift)

{
  if (Key == 13) {
    actGoTo->Execute();
  }
}
//---------------------------------------------------------------------------


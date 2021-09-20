//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Thinfinity.VirtualUI.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFormMain *FormMain;
VirtualUI* m_VirtualUI;

std::wstring AnsiToWString(AnsiString value) {
  wchar_t res[1024];
  value.WideChar(res, value.WideCharBufSize());
  return std::wstring(res);
}

//---------------------------------------------------------------------------
__fastcall TFormMain::TFormMain(TComponent* Owner)
        : TForm(Owner)
{
	m_VirtualUI = new VirtualUI();
	m_VirtualUI->StdDialogs(true);
  m_VirtualUI->Start();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Open1Click(TObject *Sender)
{
  if (OpenDialog1->Execute()) {
    ShowMessage(OpenDialog1->FileName);
  }
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::Save1Click(TObject *Sender)
{
  if (SaveDialog1->Execute()) {
    ShowMessage(SaveDialog1->FileName);
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Exit1Click(TObject *Sender)
{
  Close();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ButtonAddClick(TObject *Sender)
{
  ListBox1->Items->Add(EditItem->Text);  
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ComboBox1Change(TObject *Sender)
{
  ListView1->ViewStyle = TViewStyle(ComboBox1->ItemIndex);
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Edit1Change(TObject *Sender)
{
  ProgressBar1->Position = UpDownProgress->Position;  
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::TrackBarProgressChange(TObject *Sender)
{
  StatusBar1->Panels->Items[1]->Text = TrackBarProgress->Position;
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Cut1Click(TObject *Sender)
{
  Memo1->CutToClipboard();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Copy1Click(TObject *Sender)
{
  Memo1->CopyToClipboard();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Paste1Click(TObject *Sender)
{
  Memo1->PasteFromClipboard();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ColorBox1Change(TObject *Sender)
{
  Shape1->Brush->Color = ColorBox1->Selected;
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Button1Click(TObject *Sender)
{
  if (OpenDialog1->Execute()) {
    ShowMessage(OpenDialog1->FileName);
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::Button2Click(TObject *Sender)
{
  if (SaveDialog1->Execute()) {
    ShowMessage(SaveDialog1->FileName);
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::CheckStdDialogsClick(TObject *Sender)
{
  m_VirtualUI->StdDialogs(CheckStdDialogs->Checked);
}
//---------------------------------------------------------------------------


void __fastcall TFormMain::Button4Click(TObject *Sender)
{
  m_VirtualUI->TakeScreenshot(this->Handle, L"screenshot.jpg");
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ButStartRecClick(TObject *Sender)
{
  std::wstring trackName = L"VirtualUI_";
  trackName += AnsiToWString(FormatDateTime("yyyymmdd_hhnnss", Now()));

	m_VirtualUI->Recorder()->Filename(L".\\virtualUI_cppbSession");
	m_VirtualUI->Recorder()->Rec(trackName);
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ButStopRecClick(TObject *Sender)
{
  m_VirtualUI->Recorder()->Stop();
  if (m_VirtualUI->Recorder()->State()==Inactive) {
    ShowMessage("Inactive");
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ButBrowseRegistryClick(TObject *Sender)
{
  if (OpenDialogReg->Execute()) {
    EditRegistryCfg->Text = OpenDialogReg->FileName;
    m_VirtualUI->RegistryFilter()->CfgFile(AnsiToWString(EditRegistryCfg->Text));
    Memo1->Lines->Add("Registry Virtualization configuration file:" + AnsiString(m_VirtualUI->RegistryFilter()->CfgFile().c_str()));
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::CheckRegistryVirtClick(TObject *Sender)
{
  m_VirtualUI->RegistryFilter()->Active(CheckRegistryVirt->Checked);
  if (m_VirtualUI->RegistryFilter()->Active()) {
    m_VirtualUI->RegistryFilter()->User(AnsiToWString(EditRegUser->Text));
    Memo1->Lines->Add("Registry Virtualization User Name:" + AnsiString(m_VirtualUI->RegistryFilter()->User().c_str()));
    Memo1->Lines->Add("Registry Virtualization: Enabled");
  }
  else {
    Memo1->Lines->Add("Registry Virtualization: Disabled");
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::ButBrowseFileSystemClick(TObject *Sender)
{
  if (OpenDialogFileSystem->Execute()) {
    EditFileSystemCfg->Text = OpenDialogFileSystem->FileName;
    m_VirtualUI->FileSystemFilter()->CfgFile(AnsiToWString(EditFileSystemCfg->Text));
    Memo1->Lines->Add("File System Virtualization configuration file:" + AnsiString(m_VirtualUI->FileSystemFilter()->CfgFile().c_str()));
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::CheckFileSystemVirtClick(TObject *Sender)
{
  m_VirtualUI->FileSystemFilter()->Active(CheckFileSystemVirt->Checked);
  if (m_VirtualUI->FileSystemFilter()->Active()) {
    m_VirtualUI->FileSystemFilter()->User(AnsiToWString(EditFileSystemUser->Text));
    Memo1->Lines->Add("File System Virtualization User Name:" + AnsiString(m_VirtualUI->FileSystemFilter()->User().c_str()));
    Memo1->Lines->Add("File System Virtualization: Enabled");
  }
  else {
    Memo1->Lines->Add("File System Virtualization: Disabled");
  }
}
//---------------------------------------------------------------------------


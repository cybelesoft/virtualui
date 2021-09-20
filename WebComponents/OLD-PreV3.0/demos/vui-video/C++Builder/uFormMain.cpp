//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "uFormMain.h"
#include "Vui.Video.h"
#include "Thinfinity.VirtualUI.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFormMain *FormMain;
VirtualUI* vui;
VuiVideo* video;
bool playing;

std::wstring AnsiToWString(AnsiString value) {
  //int s = value.WideCharBufSize();
  wchar_t res[1024];
  value.WideChar(res, value.WideCharBufSize());
  return std::wstring(res);
}

void videoOnStateChanged(VuiVideo* sender) {
	FormMain->LabelStatus->Caption = AnsiString(sender->State().c_str());
}

void videoOnLengthChanged(VuiVideo* sender) {
	FormMain->Slider->Max = sender->Length() * 100;
}

void videoOnPositionChanged(VuiVideo* sender) {
  FormMain->Slider->OnChange = NULL;
  FormMain->Slider->Position = sender->Position() * 100;
  FormMain->Slider->OnChange = FormMain->SliderChange;
}

//---------------------------------------------------------------------------
__fastcall TFormMain::TFormMain(TComponent* Owner)
  : TForm(Owner)
{
  AnsiString appPath = ExtractFilePath(Application->ExeName);
  std::wstring Xtagdir = AnsiToWString(appPath) + L"\\..\\x-tag\\";

	vui = new VirtualUI();
	vui->Start();

	video = new VuiVideo();
	video->XTagDir(Xtagdir);
	video->OnLengthChanged = videoOnLengthChanged;
	video->OnPositionChanged = videoOnPositionChanged;
	video->OnStateChanged = videoOnStateChanged;
	video->CreateComponent(L"PanelXVideo", (INT64)(PanelXVideo->Handle));

  std::wstring mediafile = AnsiToWString(appPath) + L"\\vui-video\\media\\big_buck_bunny_480p_2mb.mp4";

  ComboUrl->Items->Add(mediafile.c_str());
  ComboUrl->Items->Add(L"http://www.sample-videos.com/video/mp4/480/big_buck_bunny_480p_2mb.mp4");
  ComboUrl->Items->Add(L"http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4");
  ComboUrl->Items->Add(L"http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K_short.MP4");
  ComboUrl->Items->Add(L"http://download.openbricks.org/sample/H264/h264_Linkin_Park-Leave_Out_All_The_Rest.mp4");
  ComboUrl->Items->Add(L"http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Media/H264_test1_Talkinghead_mp4_480x360.mp4");
  ComboUrl->Items->Add(L"http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Media/H264_test3_Talkingheadclipped_mp4_480x360.mp4");
  ComboUrl->ItemIndex = 0;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::ButGoClick(TObject *Sender)
{
  std::wstring src = AnsiToWString(ComboUrl->Text);
  video->Src(src);
  ButPlay->Caption = "Play";
  playing = false;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::ButPlayClick(TObject *Sender)
{
  if (!playing) {
    video->Play();
    ButPlay->Caption = "Pause";
  }
  else {
    video->Pause();
    ButPlay->Caption = "Play";
  }
  playing = !playing;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::ButStopClick(TObject *Sender)
{
  ButPlay->Caption = "Play";
  playing = false;
  video->Stop();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::SliderChange(TObject *Sender)
{
  video->Move(Slider->Position / 100);
}
//---------------------------------------------------------------------------

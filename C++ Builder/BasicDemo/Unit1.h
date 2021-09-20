//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
#include <ComCtrls.hpp>
#include <ImgList.hpp>
#include <CheckLst.hpp>
#include <ExtCtrls.hpp>
#include <Dialogs.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TFormMain : public TForm
{
__published:	// IDE-managed Components
  TMainMenu *MainMenu1;
  TMenuItem *File1;
  TMenuItem *Open1;
  TMenuItem *N1;
  TMenuItem *Exit1;
  TLabel *Label1;
  TEdit *EditItem;
  TButton *ButtonAdd;
  TListBox *ListBox1;
  TCheckBox *CheckBox1;
  TGroupBox *GroupBox;
  TRadioButton *RadioButton1;
  TRadioButton *RadioButton2;
  TComboBox *ComboBox1;
  TListView *ListView1;
  TLabel *Label2;
  TImageList *ImageList16;
  TImageList *ImageList32;
  TProgressBar *ProgressBar1;
  TEdit *Edit1;
  TUpDown *UpDownProgress;
  TTrackBar *TrackBarProgress;
  TDateTimePicker *DateTimePicker1;
  TMonthCalendar *MonthCalendar1;
  TStatusBar *StatusBar1;
  TPopupMenu *PopupClipboard;
  TMenuItem *Cut1;
  TMenuItem *Copy1;
  TMenuItem *Paste1;
  TLabel *Label3;
  TMemo *Memo1;
  TCheckListBox *CheckListBox1;
  TColorBox *ColorBox1;
  TShape *Shape1;
  TTreeView *TreeView1;
  THotKey *HotKey1;
  TLabel *Label4;
  TOpenDialog *OpenDialog1;
  TSaveDialog *SaveDialog1;
  TButton *Button1;
  TButton *Button2;
  TCheckBox *CheckStdDialogs;
  TButton *Button4;
  TMenuItem *Save1;
  TButton *ButStartRec;
  TButton *ButStopRec;
  TLabel *Label5;
  TEdit *EditRegistryCfg;
  TSpeedButton *ButBrowseRegistry;
  TCheckBox *CheckRegistryVirt;
  TLabel *Label6;
  TEdit *EditFileSystemCfg;
  TSpeedButton *ButBrowseFileSystem;
  TCheckBox *CheckFileSystemVirt;
  TOpenDialog *OpenDialogReg;
  TOpenDialog *OpenDialogFileSystem;
  TLabel *Label7;
  TEdit *EditRegUser;
  TLabel *Label8;
  TEdit *EditFileSystemUser;
  void __fastcall Open1Click(TObject *Sender);
  void __fastcall Exit1Click(TObject *Sender);
  void __fastcall ButtonAddClick(TObject *Sender);
  void __fastcall ComboBox1Change(TObject *Sender);
  void __fastcall Edit1Change(TObject *Sender);
  void __fastcall TrackBarProgressChange(TObject *Sender);
  void __fastcall Cut1Click(TObject *Sender);
  void __fastcall Copy1Click(TObject *Sender);
  void __fastcall Paste1Click(TObject *Sender);
  void __fastcall ColorBox1Change(TObject *Sender);
  void __fastcall Button1Click(TObject *Sender);
  void __fastcall Button2Click(TObject *Sender);
  void __fastcall CheckStdDialogsClick(TObject *Sender);
  void __fastcall Button4Click(TObject *Sender);
  void __fastcall Save1Click(TObject *Sender);
  void __fastcall ButStartRecClick(TObject *Sender);
  void __fastcall ButStopRecClick(TObject *Sender);
  void __fastcall ButBrowseRegistryClick(TObject *Sender);
  void __fastcall CheckRegistryVirtClick(TObject *Sender);
  void __fastcall ButBrowseFileSystemClick(TObject *Sender);
  void __fastcall CheckFileSystemVirtClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormMain *FormMain;
//---------------------------------------------------------------------------
#endif
 
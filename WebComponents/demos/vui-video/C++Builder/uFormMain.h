//---------------------------------------------------------------------------

#ifndef uFormMainH
#define uFormMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TFormMain : public TForm
{
__published:	// IDE-managed Components
  TLabel *Label1;
  TComboBox *ComboUrl;
  TButton *ButGo;
  TButton *ButPlay;
  TButton *ButStop;
  TLabel *Label2;
  TLabel *LabelStatus;
  TTrackBar *Slider;
  TPanel *PanelXVideo;
  void __fastcall ButGoClick(TObject *Sender);
  void __fastcall ButPlayClick(TObject *Sender);
  void __fastcall ButStopClick(TObject *Sender);
  void __fastcall SliderChange(TObject *Sender);
private:	// User declarations
public:		// User declarations
  __fastcall TFormMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormMain *FormMain;
//---------------------------------------------------------------------------
#endif

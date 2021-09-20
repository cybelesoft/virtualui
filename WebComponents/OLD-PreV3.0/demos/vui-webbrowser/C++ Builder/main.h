//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <System.Actions.hpp>
#include <Vcl.ActnList.hpp>
#include <Vcl.Buttons.hpp>
#include <Vcl.ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TActionList *ActionList;
	TAction *actPrev;
	TAction *actNext;
	TAction *actGoTo;
	TPanel *Panel2;
	TPanel *Panel1;
	TSpeedButton *SpeedButton1;
	TSpeedButton *SpeedButton2;
	TSpeedButton *SpeedButton5;
	TEdit *edAddress;
	void __fastcall actPrevExecute(TObject *Sender);
	void __fastcall actNextExecute(TObject *Sender);
	void __fastcall actGoToExecute(TObject *Sender);
	void __fastcall edAddressKeyDown(TObject *Sender, WORD &Key, TShiftState Shift);

private:	// User declarations
	void __fastcall Init();
public:		// User declarations
	int HistoryIndex ;
	TStringList* History;
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

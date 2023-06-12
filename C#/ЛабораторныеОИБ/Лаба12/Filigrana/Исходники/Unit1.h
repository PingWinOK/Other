//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <Grids.hpp>
#include <Menus.hpp>
#include <Dialogs.hpp>
#include <ComCtrls.hpp>
#include <ToolWin.hpp>
#include <ExtCtrls.hpp>
#include <ExtDlgs.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TStringGrid *StringGrid1;
        TStringGrid *StringGrid2;
        TScrollBar *ScrollBar1;
        TMainMenu *MainMenu1;
        TMenuItem *N1;
        TMenuItem *N2;
        TMenuItem *N3;
        TMenuItem *N4;
        TMenuItem *N5;
        TMenuItem *N6;
        TMenuItem *N8;
        TMenuItem *N9;
        TMenuItem *Help1;
        TMenuItem *N10;
        TOpenDialog *OpenDialog1;
        TSaveDialog *SaveDialog1;
        TProgressBar *ProgressBar1;
        TOpenPictureDialog *OpenPictureDialog1;
        TMenuItem *N11;
        TImage *Image1;
        TGroupBox *GroupBox1;
        TLabel *Label1;
        void __fastcall StringGrid1SelectCell(TObject *Sender, int ACol,
          int ARow, bool &CanSelect);
        void __fastcall ScrollBar1Scroll(TObject *Sender,
          TScrollCode ScrollCode, int &ScrollPos);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall N2Click(TObject *Sender);
        void __fastcall N3Click(TObject *Sender);
        void __fastcall N6Click(TObject *Sender);
        void __fastcall N11Click(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall N4Click(TObject *Sender);
        void __fastcall N8Click(TObject *Sender);
        void __fastcall StringGrid1DrawCell(TObject *Sender, int ACol,
          int ARow, TRect &Rect, TGridDrawState State);
        void __fastcall N10Click(TObject *Sender);
        void __fastcall Help1Click(TObject *Sender);
private:	// User declarations
        int i1;
        int j1;
        int i2;
        int j2;
        int shetmax;
        AnsiString pname;
        void __fastcall Insert(TObject *Sender);
        void __fastcall Retrieve(TObject *Sender);
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

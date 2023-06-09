//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#include "Unit2.h"
#include "Unit3.h"
#include <iostream.h>
#include <windows.h>
#include <fstream.h>
#include <Sysutils.hpp>
#include <conio.h>
#include <io.h>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::StringGrid1SelectCell(TObject *Sender, int ACol,
      int ARow, bool &CanSelect)
{
    TForm1::StringGrid2->Row=ARow;
    TForm1::StringGrid2->Col=ACol-1;
    TForm1::ScrollBar1->Position=ARow;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ScrollBar1Scroll(TObject *Sender,
      TScrollCode ScrollCode, int &ScrollPos)
{
    TForm1::StringGrid1->Row=ScrollPos;
    TForm1::StringGrid2->Row=ScrollPos;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
    ScrollBar1->Max=9;
    StringGrid1->ColWidths[0]=52;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::N2Click(TObject *Sender)
{
    AnsiString fname;
    unsigned long fSize;
    int letter;
    char letter2;
    int shet=0;
    int j=0;
    shetmax=0;
    if(!OpenDialog1->Execute()) return;
    Form1->Image1->Picture=NULL;
    Form1->N6->Enabled=False;
    Label1->Caption="���������� "+OpenDialog1->FileName;;
    fname = OpenDialog1->FileName;
    ifstream size_file(fname.c_str(), ios::in|ios::ate);
    ProgressBar1->Max = size_file.tellg();
    size_file.close();
    ifstream input_file(fname.c_str(), ios:: binary);
    while (! input_file.eof())
        {
         TForm1::ScrollBar1->Max=j;
         TForm1::StringGrid1->Cells[0][j] = IntToHex(j*16,8);
         for (int i=1; i<=StringGrid2->ColCount; i++)
             {
              letter2 = letter = input_file.get();
              AnsiString hex = IntToHex(letter,2);
 //������������ ����� �� ������� ����������� ������� �����
              if (hex=="00")
                  {
                   shet++;
                   if (shet>shetmax)
                       {
                        shetmax=shet;//���������� ����� ���������� �������
                        i1=i;//����������� ������� ���������� ����� �������
                        j1=j;
                       }
                  }
              else
              shet=0;
              TForm1::StringGrid1->Cells[i][j] = hex;
              TForm1::StringGrid2->Cells[i-1][j] = letter2;
              ProgressBar1->Position++;
             }
         j++;
        }
    TForm1::StringGrid1->RowCount=j-1;
    TForm1::StringGrid2->RowCount=j-1;
    TForm1::ScrollBar1->Max=j-2;
    ProgressBar1->Position=0;
    Form1->N11->Enabled=True;
    Form1->N8->Enabled=True;
    input_file.close ();
}

//---------------------------------------------------------------------------
// ���������� �����, ����������� ���
void __fastcall TForm1::N3Click(TObject *Sender)
{
    AnsiString name;
    if(!SaveDialog1->Execute()) return;
    name=SaveDialog1->FileName;
    ofstream output_file(name.c_str(), ios:: binary);
    for (int j=0; j<StringGrid2->RowCount; j++)
        {
         for (int i=0; i<StringGrid2->ColCount; i++)
             {
              char *b = TForm1::StringGrid2->Cells[i][j].c_str();
              output_file.put(*b);
             }
        }
    output_file.close ();
}
//---------------------------------------------------------------------------
//����� ����� ����� ������ ��� ����������� ���
void __fastcall TForm1::N6Click(TObject *Sender)
{
    Form2->Caption="����������� ���";
    Form2->Button1->Caption="��������";
    Form2->ShowModal();
    if ( ! Form2->isOK )
        {
         return;
        }
//��������� �������� ��� ��� ����������� � ����������
    ifstream size_file(pname.c_str(), ios::in|ios::ate);
    if (size_file.tellg()>(shetmax-48))
        {
         if ((shetmax-48)>0)
             {
              ShowMessage("������ ������������� ����������� ������ ������� ����������!");
              ShowMessage("������������ ������ ������������� ���: " +IntToStr(shetmax-48)+" ����!");
             }
         else
         ShowMessage("��� �������� ����������, ������������ �����!");
        }
    else
//�������� ���������� ������������ ����������� ���
        {
         Insert(Sender);
         ShowMessage("��� ������� �������!");
         Form1->N3->Enabled=True;
        }
    size_file.close ();
}
//---------------------------------------------------------------------------
//�������� ����������� ��� �����������
void __fastcall TForm1::N11Click(TObject *Sender)
{
     if(!Form1->OpenPictureDialog1->Execute()) return;
     pname = Form1->OpenPictureDialog1->FileName;
     Form1->Image1->Picture->LoadFromFile(pname);
     Form1->N6->Enabled=True;
     StringGrid1->TopRow=j2;
     StringGrid2->TopRow=j2;
     TForm1::ScrollBar1->Position=j2;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormClose(TObject *Sender, TCloseAction &Action)
{
     ShowMessage("���������� ����� �������!");
}
//---------------------------------------------------------------------------

void __fastcall TForm1::N4Click(TObject *Sender)
{
    if ( MessageBox(NULL,"�� ������������� ������ ������� ����������?","��������",MB_YESNO)== mrYes)
    Form1->Close();
}
//---------------------------------------------------------------------------
//����� ����� ������ ��� ���������� ���
void __fastcall TForm1::N8Click(TObject *Sender)
{
    Form2->Caption="���������� ���";
    Form2->Button1->Caption="�������";
    Form2->ShowModal();
    if ( ! Form2->isOK )
       {
        return;
       }
//�������� ���������� ������������ ���������� ���
    Retrieve(Sender);
}
//---------------------------------------------------------------------------
//������������ ��������� ���
void __fastcall TForm1::Insert(TObject *Sender)
{
    ifstream input_file(pname.c_str(), ios:: binary);
    int letter;
    int j=j2; //������������ j ��������� ������ ����������� ���
    int i;
    char letter2;
    char* hashpass;
    j++;
//����������� ���-�������� ������
    for (int i=1; i<=8; i++)
        {
         hashpass=Form2->GetHash();
         letter2 = letter = hashpass[i-1];
         AnsiString hex = IntToHex(letter,2);
         TForm1::StringGrid1->Cells[i][j] = hex;
         TForm1::StringGrid2->Cells[i-1][j] = letter2;
         }
//���������� ���
    while (! input_file.eof())
        {
         j++;
         for (int i=1; i<=StringGrid2->ColCount && !input_file.eof(); i++)
             {
              letter2 = letter = input_file.get();
              if (letter!=-1)
                  {
                   AnsiString hex = IntToHex(letter,2);
                   TForm1::StringGrid1->Cells[i][j] = hex;
                   TForm1::StringGrid2->Cells[i-1][j] = letter2;
                  }
              else
                  {
                   TForm1::StringGrid1->Cells[i][j] = IntToHex('\0',2);
                   TForm1::StringGrid2->Cells[i-1][j] = '\0';
                  }
             }
        }
    input_file.close ();
}

//---------------------------------------------------------------------------
//��������� �������, � ������� ����� ����������� �����������
//���������� ��������� ������ ����������� ���
void __fastcall TForm1::StringGrid1DrawCell(TObject *Sender, int ACol,
      int ARow, TRect &Rect, TGridDrawState State)
{
//��������� ��������������� ������� ���������� ����� ������� �����������
    j2 = j1;
    i2 = i1;
    int prov=shetmax;
    while (prov>0)
        {
         if (i2<1)
             {
              i2=16;
              j2--;
              if(ACol == i2 && ARow == j2) // ���������� ���������� ������
                  {
                   StringGrid1->Canvas->Brush->Color = clHotLight;
                   StringGrid1->Canvas->Font->Color=clWhite;
                   StringGrid1->Canvas->FillRect(Rect);
                  }
             }
         else
             {
              if(ACol == i2 && ARow == j2) // ���������� ���������� ������
                  {
                   StringGrid1->Canvas->Brush->Color = clHotLight;
                   StringGrid1->Canvas->Font->Color=clWhite;
                   StringGrid1->Canvas->FillRect(Rect);
                  }
              i2--;
              prov--;
             }
        }
    AnsiString text=StringGrid1->Cells[ACol][ARow];
    StringGrid1->Canvas->TextRect(Rect,Rect.left,Rect.top, text);
}
//---------------------------------------------------------------------------
//���������� ���
void __fastcall TForm1::Retrieve(TObject *Sender)
{
    int l=0;
    int lmax=0;
    int jj;
    char* hashpass;
//��������� ���-�������� ������, ��������� ������������� � ��������� � ���-�����
    for (int j=0; j<TForm1::StringGrid2->RowCount; j++)
        {
         for (int i=0; i<TForm1::StringGrid2->ColCount; i++)
             {
              char *b = TForm1::StringGrid2->Cells[i][j].c_str();
              hashpass=Form2->GetHash();
              if (hashpass[l]!=*b)
              l=0;
              else
              l++;
              if (l>lmax)
                  {
                   lmax=l;
                   jj=j+1;
                  }
             }
        }
    if(lmax>=strlen(hashpass))
 //���������� ���
        {
         ofstream output_file("���.bmp", ios:: binary);
         for (int j=jj; j<StringGrid2->RowCount; j++)
             {
              for (int i=0; i<StringGrid2->ColCount; i++)
                  {
                   char *b = TForm1::StringGrid2->Cells[i][j].c_str();
                   output_file.put(*b);
                  }
             }
         output_file.close ();
         Form1->Image1->Picture->LoadFromFile("���.bmp");
         DeleteFile("���.bmp");
         ShowMessage("��� ������� ��������!");
        }
    else
    ShowMessage("��� �� �������!");
}
//---------------------------------------------------------------------------
void __fastcall TForm1::N10Click(TObject *Sender)
{
    Form3->ShowModal();
}
//---------------------------------------------------------------------------
//����� Help'�
void __fastcall TForm1::Help1Click(TObject *Sender)
{
    WinExec(".\\Filigrana_�������.chm",SW_SHOW);
    ShellExecute(0, "Open", ".\\Filigrana_�������.chm" , "", "", 1);
}
//---------------------------------------------------------------------------


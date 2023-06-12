//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include "Unit2.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
//Хеширование (результат шифрования магической строки «0123456789»
//многоалфавитной подстановкой на ключе, равном паролю пользователя)
void Hash(const char *key,char *res)
{
    char tmp[8];    // вспомогательный массив символов
    char mag[]="12345678";
    if(strlen(mag)<strlen(key))
         {
          strncpy(tmp,key,strlen(mag));
          tmp[strlen(mag)]='\0';
         }
     else strcpy(tmp,key);
//при необходимости добавление пробелов
     while (strlen(tmp)<strlen(mag))
     strncat(tmp," ",1);
     AnsiString Key(tmp);
     for (int i=0; i<strlen(mag); i++)
     res[i]=(mag[i]+tmp[i])%256;
     res[strlen(mag)]='\0';
}

TForm2 *Form2;
//---------------------------------------------------------------------------
__fastcall TForm2::TForm2(TComponent* Owner)
        : TForm(Owner)
{
    isOK = false;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button1Click(TObject *Sender)
{
    if (Edit1->Text.Length()<4)
    ShowMessage("Пароль должен быть не менее 4 символов!");
    else
    isOK = true;
    Close();
}
//---------------------------------------------------------------------------
void __fastcall TForm2::FormShow(TObject *Sender)
{
    Edit1->Text = "";
}
//Хэширования введённого пароля
char* __fastcall TForm2::GetHash()
{
    char hashkey[8];
    Hash(Edit1->Text.c_str(),hashkey);
    return hashkey;
}
//---------------------------------------------------------------------------
void __fastcall TForm2::Button2Click(TObject *Sender)
{
    Close();
}
//---------------------------------------------------------------------------


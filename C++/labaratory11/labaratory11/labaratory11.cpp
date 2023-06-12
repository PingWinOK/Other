#include "pch.h"
#include <iostream>
#include <cmath>
#include <vector>
#include <string>

using namespace std;

int strlen(char *str) {
	int k;
	for (k = 0; *str++ != '\0'; k++);

	return k;
}

bool srav(char str[], char str2[])
{
	int i = 0;
	for (; str[i] != 0 && str2[i] != 0; i++)
		if (str[i] != str2[i])
			return false;
	if (str[i] != 0 || str2[i] != 0)
		return false;
	return true;
}
void strReverse(char *str) {
	int L = strlen(str);
	int i, j;

	for (i = 0, j = L - 1; i < j; i++, j--) {
		char t = str[i];
		str[i] = str[j];
		str[j] = t;
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 5" << endl;
		cin >> Nomer;

		if (Nomer == 1)
		{


			char str1[100];
			cout << "Введите слово: ";
			cin.getline(str1, 100);
			gets_s(str1);
			strReverse(str1);
			puts(str1);

		}
		if (Nomer == 2)
		{

			string str;
			int key;

			cout << "Введите слово: ";
			cin.ignore();
			getline(cin, str);

			cout << "Введите ключ (цифры): ";
			cin >> key;


			cout << "Зашифрованное сообщение: ";
			for (int i = 0; i < str.size(); i++) {
				str[i] = int(str[i]) + key;
				cout << char(str[i]);
			}

			cout << endl << endl;
			cout << "Расшифрованное сообщение: ";
			for (int i = 0; i < str.size(); i++) {
				str[i] = int(str[i]) - key;
				cout << char(str[i]);
			}
			cout << endl << endl;

		}

		if (Nomer == 3)
		{
			cout << "Введите число: " << endl;
			string s, result;  
			char prev;  
			cin >> s;
			prev = s[0];
			result += s[0];
			for (int i = 1; i < s.size(); i++) {
				if (s[i] != prev) {
					prev = s[i];
					result += s[i];
				}
			}
			cout << result << endl;
		}
		if (Nomer == 4)
		{
			cout << "Введите строку: " << endl;
			int rar = 0;
			cin.ignore();
			char str[100];
			fgets(str, 100, stdin);
			for (int i = 0; i < sizeof(str); i++) {
				if (str[i] == 'D') {
					rar += 1;
					break;
				}
			}
			for (int i = 0; i < sizeof(str); i++) {
				if (str[i] == 'S') {
					rar += 1;
					break;
				}
			}
			for (int i = 0; i < sizeof(str); i++) {
				if (str[i] == 'K') {
					rar += 1;
					break;
				}

			}
			if (rar == 3)
			{
				cout << "Инициалы присудствуют" << endl;
			}
			else
			{
				cout << "Инициалов нет" << endl;
			}
		}

		if (Nomer == 5)
		{

			cout << "Введите слово 1: " << endl;
			cin.ignore();
			char str1[100];
			cin.getline(str1, 100);
			cout << "Введите слово 2: " << endl;
			char str2[100];
			cin.getline(str2, 100);
			bool check = srav(str1, str2);

			if (check == true)
				cout << "Строки равные" << endl;
			else
				cout << "Строки разные" << endl;
			cout << endl << endl;
			cout << endl << endl;
			cout << "Введите слово с точками: " << endl;
			char str[100];
			cin.getline(str, 100);
			for (int i = 0; i < strlen(str); i++)
				if (str[i] != '.')
					printf("%c", str[i]);
				else
					printf("с1%c", str[i]);
			cout << endl << endl;
		}
	}
}


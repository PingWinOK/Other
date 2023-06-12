#include "pch.h"
#include <iostream>
#include <cmath>
#include <vector>
#include <string>
#include <fstream>
#include <iterator>

using namespace std;

void Issort(int *arr, int n) {
	int f;
	for (int i = 0; i < n - 1; i++) {
		f = 0;
		for (int j = i + 1; j < n; j++) {
			f = (arr[j] > arr[i]) ? 1 : 0;
			if (f == 0)
				break;
		}
		if (f == 0)
			break;
	}

	cout << endl << ((f == 1) ? "Массив отсортирован" : "Массив не отсортирован") << endl;
}

int main() {
	setlocale(LC_ALL, "Rus");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 4" << endl;
		cin >> Nomer;

		if (Nomer == 1)
		{

			ifstream in("input.txt");

			if (in.is_open())
			{

				int count_space = 0;
				char symbol;
				while (!in.eof()) {
					in.get(symbol);
					if (symbol == ' ')
						count_space++;
					if (symbol == '\n')
						break;
				}
				//cout << (count_space + 1) << endl;

				in.seekg(0, ios::beg);
				in.clear();

				int n = count_space + 1;
				int* x = new int[n];

				for (int i = 0; i < n; i++) {
					in >> x[i];
				}

				for (int i = 0; i < n; i++)
					cout << x[i] << "\t";

				Issort(x, n);

				delete[] x;

				in.close();
			}
			else
				cout << "Файл не найден.";

		}

		if (Nomer == 2)
		{
		
			char C;

			ifstream in("f.txt");
			fstream fin("g.txt");

			while (in.peek() != EOF)
			{
				in.get(C);
				if (C == 'C')
				{
					fin << "C++";
				}
				else
				{
					fin << C;
				}

				cout << C;
			}
			cout << endl;

			fin.close();
			in.close();


		}
	

		if (Nomer == 3)
		{

			string str;
			ofstream out;
			ifstream infile("inputFile_A.txt");
			out.open("outputFile_A.txt");
			if (!infile) {
				cerr << "Ошибка открытия!" << std::endl;
			}
			else
			{
				while (infile >> str) {
					out << str << ' ';
				}
			}
			infile.close();

		}
		if (Nomer == 4)
		{
			
			vector<double>Fin;
			vector<double>A1;
			vector<double>A2;
			char s = ' ';
			string str = "";
			ifstream in("outputFile_A1.txt");
			copy(istream_iterator<int>(in), istream_iterator<int>(), back_inserter(A1));
			in.close();
			ifstream in1("outputFile_A2.txt");
			copy(istream_iterator<int>(in1), istream_iterator<int>(), back_inserter(A2));
			in.close();
			for (int i = 0; i < A1.size(); i++)
			{
				Fin.push_back((double)A1[i] / (double)A2[i]);
				str += to_string(Fin[i]) + " ";
			}
			ofstream out;
			out.open("inputFile_Fin.txt");
			ifstream infile("inputFile_Fin.txt");	
			out << str;
			infile.close();

		}
	}
}
	


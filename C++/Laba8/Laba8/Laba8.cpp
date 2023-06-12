#include "stdafx.h"
#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 6" << endl;
		cin >> Nomer;

		if (Nomer == 1)
		{
			int A, B;

			cout << "Введите M и N:" << endl;
			cin >> A >> B;
			int **Mass = new int*[A];
			for (int i = 0; i < A; i++)
				Mass[i] = new int[B];
			srand(time(0));
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					Mass[i][j] = 1 + rand() % 99;
					cout << Mass[i][j] << " ";
				}
				cout << endl;
			}
			int max = Mass[0][0];
			int min = Mass[0][0];
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					if (Mass[i][j] > max)
					{
						max = Mass[i][j];
					}
					if (Mass[i][j] < min)
					{
						min = Mass[i][j];
					}
				}
			}
			cout << "Максимальный элемент массива:" << max << endl;
			cout << "Минимальный элемент массива:" << min << endl;
		}
		if (Nomer == 2)
		{
			int A, B;
			cout << "Введите M и N:" << endl;
			cin >> A >> B;
			double **Mass = new double*[A];
			for (int i = 0; i < A; i++)
				Mass[i] = new double[B];
			srand(time(0));
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					Mass[i][j] = (rand() % 100)*0.1;
					cout << Mass[i][j] << " | ";
				}
				cout << endl;
			}
			double S = 0, P = 1;
			for (int i = 0; i < A; i++)
			{
				S = 0;
				for (int j = 0; j < B; j++)
				{
					S += Mass[i][j];
				}
				P *= S;
			}
			cout << "Произведение сумм: " << P << endl;
		}
		if (Nomer == 3)
		{
			int row1, row2, col1, col2;
			double** a, ** b, ** c;

			cout << "Введите количество строк первой матрицы: ";
			cin >> row1;
			cout << "Введите количество столбцов первой матрицы: ";
			cin >> col1;
			cout << "Введите количество строк второй матрицы: ";
			cin >> row2;
			cout << "Введите количество столбцов второй матрицы: ";
			cin >> col2;
			a = new double*[row1];
			srand(time(0));
			cout << "Первая матрица: " << endl;
			for (int i = 0; i < row1; i++)
			{
				a[i] = new double[col1];
				for (int j = 0; j < col1; j++)
				{
					a[i][j] = (rand() % 100)*0.1;
					cout << a[i][j] << " | ";
				}
				cout << endl;
			}

			cout << "Вторая матрица: " << endl;
			b = new double*[row2];
			for (int i = 0; i < row2; i++)
			{
				b[i] = new double[col2];
				for (int j = 0; j < col2; j++)
				{
					b[i][j] = (rand() % 100)*0.1;
					cout << b[i][j] << " | ";
				}
				cout << endl;
			}
			cout << "Умножение: " << endl;

			c = new double*[row1];
			for (int i = 0; i < row1; i++)
			{
				c[i] = new double[col2];
				for (int j = 0; j < col2; j++)
				{
					c[i][j] = 0;
					for (int k = 0; k < col1; k++)
						c[i][j] += a[i][k] * b[k][j];
				}
			}
			for (int i = 0; i < row1; i++)
			{
				for (int j = 0; j < col2; j++)
				{
					cout << c[i][j] << " | ";
				}
				cout << endl;
			}
		}
		if (Nomer == 4)
		{
			int A, B;
			cout << "Введите M и N:" << endl;
			cin >> A >> B;
			double **Mass = new double*[A];
			for (int i = 0; i < A; i++)
				Mass[i] = new double[B];
			srand(time(0));
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					Mass[i][j] = (rand() % 100)*0.1;
					cout << Mass[i][j] << " | ";
				}
				cout << endl;
			}
			double S = 0.0;
			double* Mass1 = new double[A];
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					S += Mass[i][j];
				}
				Mass1[i] = S;
				S = 0.0;
			}
			cout << " Вектор X: " << endl;

			for (int i = 0; i < A; i++)
			{
				cout << Mass1[i] << " | ";
			}
			cout << endl;
		}
		if (Nomer == 5)
		{
			int A, B;
			cout << "Введите M и N:" << endl;
			cin >> A >> B;
			double **Mass = new double*[A];
			for (int i = 0; i < A; i++)
			{
				Mass[i] = new double[B];
			}
			srand(time(0));
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					Mass[i][j] = (rand() % 100)*0.1;
					cout << Mass[i][j] << " | ";
				}
				cout << endl;
			}
			double* Mass1 = new double[A];

			for (int i = 0; i < A; i++)
			{
				double min = Mass[i][0];
				for (int j = 0; j < B; j++)
				{
					if (min > Mass[i][j])
					{
						min = Mass[i][j];
					}
				}
				Mass1[i] = min;
			}
			double max = Mass1[0];
			for (int i = 0; i < B; i++)
			{
				if (max < Mass1[i])
				{
					max = Mass1[i];
				}
			}
			cout << "Максимальный из минимальных элементов строк:" << max << endl;

		}
		if (Nomer == 6)
		{
			int A, B;
			cout << "Введите M и N:" << endl;
			cin >> A >> B;
			int **Mass = new int*[A];
			for (int i = 0; i < A; i++)
			{
				Mass[i] = new int[B];
			}
			srand(time(0));
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					Mass[i][j] = (rand() % 100)*0.1;
					cout << Mass[i][j] << " | ";
				}
				cout << endl;
			}
			int K, Cout = 0;
			cout << "K: " << endl;
			cin >> K;
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					if ((Mass[i][j] % K) == 0)
					{
						Cout++;
					}
				}
			}
			cout << "Количество элементов , которые деляться без остатка на K: " << Cout << endl;
			cout << "Вектор X:" << endl;
			int* Mass2 = new int[A];
			for (int i = 0; i < A; i++)
			{
				Mass2[i] = (rand() % 100);
				cout << Mass2[i] << " | ";
			}
			cout << endl;
			cout << "_________________ "<< endl;
			for (int i = 0; i < A; i++)
			{
				if (i % 2 != 0)
				{
					for (int j = 0; j < B; j++)
					{
						Mass[j][i] = Mass2[j];
					}
				}
			}
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					cout << Mass[i][j] << " | ";
				}
				cout << endl;

			}
		}
	}
}
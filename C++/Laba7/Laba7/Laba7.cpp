

#include "pch.h"
#include <iostream>

using namespace std;

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
			cout << "Введите N:" << endl;
			int N;
			cin >> N;
			int* A = new int[N];
			A[0] = 1;
			A[1] = 1;
			for (int i = 2; i < N; i++)
			{	
				A[i] = A[i - 1] + A[i - 2];
			}
			for (int i = 0; i < N; i++)
			{
				cout << "A[" << i << "]: " << A[i] << endl;
			}

		}
		if (Nomer == 2)
		{
			cout << "Введите N:" << endl;
			int N;
			cin >> N;
			int* A = new int[N];
			for (int i = 0; i < N; i++)
			{
				A[i] = rand() % 99 + 1;
			}
			int max = A[0];
			for (int i = 0; i < N; i++)
			{
				if (A[i] > max)
				{
					max = A[i];
				}
			}
			int min = A[0];
			for (int i = 0; i < N; i++)
			{
				if (A[i] < min)
				{
					min = A[i];
				}
			}
			for (int i = 0; i < N; i++)
			{
				cout << "A[" << i << "]: " << A[i] << endl;
			}
			cout << "Минимальный элемент:" << min << endl;
			cout << "Максимальный элемент:" << max << endl;

		}
		if (Nomer == 3)
		{
			cout << "Введите N:" << endl;
			int N;
			cin >> N;
			int* A = new int[N];
			for (int i = 0; i < N; i++)
			{
				A[i] = rand() % 200 - 100;

			}
			for (int i = 0; i < N; i++)
			{

				cout << "A[" << i << "]: " << A[i] << endl;
			}
			for (int i = 0; i < N; i++)
			{
				if (A[i] >= 1)
				{
					A[i] = 1;
				}
				else
					A[i] = 0;
				cout << "A[" << i << "]: " << A[i] << endl;
			}
		}
		if (Nomer == 4)
		{
			cout << "Введите N:" << endl;
			int N;
			cin >> N;
			int* A = new int[N];
			for (int i = 0; i < N; i++)
			{
				A[i] = rand() % 100 + 1;

			}
			for (int i = 0; i < N; i++)
			{

				cout << "A[" << i << "]: " << A[i] << endl;
			}
			int a, b, Raz = 100;
			for (int i = 0; i < N; i++)
			{

				for (int j = 0; j < N; j++)
				{
					if (i == j)
					{
						continue;
					}
					else
					{
						if (Raz > abs(A[i]- A[j]))
						{
							Raz = abs(A[i] - A[j]);
							a = i;
							b = j;
						}
						

					}
					
				}
			}
			cout << "i " << a << endl;
			cout << "i " << b << endl;

		}
		if(Nomer == 5)
			cout << "Введите N:" << endl;
		int N;
		cin >> N;
		int* A = new int[N];
		for (int i = 0; i < N; i++)
		{
			A[i] = rand() % 100 + 1;

		}
		for (int i = 0; i < N; i++)
		{

			cout << "A[" << i << "]: " << A[i] << endl;
		}
		cout << "____________________________ " << endl;
		for (int i = 0; i < N; i++)
		{
			if (i % 2 != 0)
			{
				A[i] = pow(A[i], 2);
			}
		}
		for (int i = 0; i < N; i++)
		{

			cout << "A[" << i << "]: " << A[i] << endl;
		}
		int max = A[0],h;
		for (int i = 0; i < N; i++)
		{
			if (A[i] > max)
			{
				max = A[i];
				h = i;
			}
		}
		for (int i = 0; i < N; i++)
		{
			if (max == A[i])
			{
			cout << i << endl;
			}
		}




	}
}


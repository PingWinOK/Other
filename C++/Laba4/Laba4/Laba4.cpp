#include "pch.h"
#include <iostream>
#include <string>
#include <math.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 6 или введите 7 для просмотра индивидуального задания: " << endl;
		cin >> Nomer;
		if (Nomer == 1)
		{
			int N,Fib = 1;
			cout << "Введите N" << endl;
			cin >> N;
			int A = 1;
			int B = 1;
			while (true)
			{
					int C = A + B;
					A = B;
					B = C;
					if (B > N)
					{
						Fib = B + A;
						break;
					}
			}
			cout <<Fib<< endl;
			system("pause");
			return 0;
			}
		if (Nomer == 2)
		{
			int N =1;
			long float S = 0,E;
			cout << "Введите точность:" << endl;
			cin >> E;
			while ((1.0 / N) > E)
			{	
				S += (pow(-1, N+1) * 1 / N);
				N++;
			}
			cout << "S = " << S << endl;

		}
		if (Nomer == 3)
		{
			int N;
			float x,h,y;
			cout << "Введите N:" << endl;
			cin >> N;
			h = 2.0 / N;
			x = -2;
			while (1.5 > x)
			{
				y = exp(x) + pow((x - 1), 2);
				cout << "y: " << y<< " При x= " <<x <<endl;
				x += h;
			}
		}
		if (Nomer == 4)
		{
			float y0 , y1,a , x, e;
			cout << "Введите a,x,e:" << endl;
			cin >> a >> x >> e;
			y0 = a;
			while (true)
			{
				y1 = 1.0 / 2 * (y0 + (x / y0));

				if (abs(pow(y1, 2) - pow(y0, 2)) > e)
				{
					cout << "y:" << y1 << endl;
					break;
				}
				y0 = y1;
			}
		}
		if (Nomer == 5)
		{
			int Sum=0, count = 0, N;
			cout << "Введите N:" << endl;
			cin >>N;
			while (N > 0)
			{
				Sum = Sum + N % 10;
				count++;
				N = N / 10;
			}
			cout << "Сумма= "<< Sum <<" Количество= " << count <<endl;

		}
		if (Nomer == 6)
		{
			float i = 0;
			long float p1 = 0,p2 = 1, esp = 0, N;
			cout << "Введите esp:" << endl;
			cin >> esp;
			while (true)
			{
				p1 += 4 * (pow(-1, i)) / ((2 * i) + 1);
				i++;
				N = p2 - p1;
				if(abs(N) < esp)
				{
				cout << "pi:" << p1 << endl;
				break;
				}
				p2 = p1;
			}


		}

		if (Nomer == 7)
		{
			int N,K=2;
			cout << "Введите N:" << endl;
			cin >> N;
			while (pow(2, K) < N)
			{
				K++;
			}
			cout <<K<< endl;

		}
		}
	}




#include <iostream>
#include <cmath>
#include <vector>
#include <string>

using namespace std;


vector<double>VVOD(vector<double>&A)
{
	cout << "Введите елемент массива или + для завершения:" << endl;
	string el;
	cin >> el;
	if (el == "+")
	{
		for (int i = 0; i < A.size(); i++)
		{
			cout << A[i] << ' ';
		}
		cout <<' '<< endl;
	}
	else
	{
		A.push_back(atof(el.c_str()));
		VVOD(A);
	}
	return A;
}

vector<double>VIVOD(vector<double>& A,int cou)
{
		if (cou < A.size())
		{
			cout << " " << A[cou];
			
			VIVOD(A, cou++);
		}
		else
		{
			return A;

		}
}

double Sym(vector<double>&A,int cou)
{
	if (cou < 1)
	{
		return A[0];
		
	}
	else
	{
		//Sy += A[cou];
		//cou--;
		return A[cou] + Sym(A,cou--);
	}
}

int rekurs(int n,int summa)
{
	if (n == 0)
		return summa;
	else
	{
		summa += n % 10;
		return rekurs(n /= 10,summa);
	}

}
double RootK(double x, int k, int n)
{
	if (n == 0)
	{
		return 1;
	}
	return RootK(x, k, n - 1) - (RootK(x, k, n - 1) - x / pow(RootK(x, k, n - 1), k - 1)) / k;
}

void main()
{
   
	setlocale(LC_ALL, "Rus");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 3" << endl;
		cin >> Nomer;

		if (Nomer == 1)
		{
			vector<double>A;

			double Sy = 0.0;
			int cou;
			VVOD(A);
			cout << "Сумма: " << Sym(A,A.size()) << endl;
			VIVOD(A, cou = 0);
		
		}
		if (Nomer == 2)
		{
			int N1, N2, N3,max,summa;
			cout << " Введите число 1: " << endl;
			cin >> N1;
			cout << " Введите число 2: " << endl;
			cin >> N2;
			cout << " Введите число 3: " << endl;
			cin >> N3;
			N1 = rekurs(N1, summa = 0 );
			N2 = rekurs(N2, summa = 0);
			N3 = rekurs(N3, summa = 0);

			if (N1 > N2)
			{
				max = N1;
			}
			else
			{
				max = N2;
			}
			if (max < N3)
			{
				max = N3;
			}
			cout << "Максимальное число : " << max << endl;
		}
		if (Nomer == 3)
		{
			double X;
			int K, N;
			cout << " Введите X " << endl;
			cin >> X;
			cout << " Введите K: " << endl;
			cin >> K;
			cout << " Введите N: " << endl;
			cin >> N;
			double F = RootK(X,K,N);
			cout << "Максимальное число : " << F << endl;
		}
	}
}


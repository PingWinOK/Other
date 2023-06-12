
#include "pch.h"
#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

double g(double a, double b) {
	return (pow(a, 2) + pow(b, 2)) / (pow(a, 2) + 2 * a * b + 3 * pow(b, 2) + 4);
}

double arr(vector<double>A) {
	double average = 0.0;
	for (int i = 0; i < A.size(); i++) {
		average += A[i];
	}
	return average / A.size();
}

double fact(double N) {
	if (N < 0)
		return 0;
	if (N == 0)
		return 1;
	else
		return N * fact(N - 1);
}

double Power1(double x, double a, double E, double n) {
	cout << n << endl;
	double s = a * (a - 1) * (pow(x - n + 1, n) / fact(n));
	cout << n << endl;
	return s;
}

double fun (double x, int n) {
	double t = 1.0;
	for (int k = 0; k < n; k++) 
		t *= (pow(x, 2) / (2 * k + 3) * (2 * k + 2)) / (pow(x, 2) / (2 * k + 2)*(2 * k + 1));
	
	return t;
}

double func1(double x, int n) {
	double A1 = 1.0;
	double A2 = 1.0;
	double s;
	double s1 = 0.0;
	double s2 = 0.0;
	for (int k = 0; k < n; k++) {

	}
	for (int k = 0; k < n; k++) {

		A1 = A1 * (x*x / ((2 * k + 2)*(2 * k + 3)));
		s1 += A1;
	}
	for (int k = 0; k < n; k++) {

		A2 = A2 * (x*x / ((2 * k + 1)*(2 * k + 2)));
		s2 += A2;
	}
	return s = s1 / s2;
}
double DegToRad( double D )
{
   if( 0 > D || D > 360 )
   {
	   cout << "Введите коректное число!" << endl;
   } 
   return D/180*3.14;
}

bool neg(bool x)
{
	return !x;
}
bool con(bool x, bool y)
{
	if (x == 1 && y == 1)
		return 1;
	return 0;
}
bool dis(bool x, bool y)
{
	if (x == 0 && y == 0)
		return 0;
	return 1;
}
bool impl(bool x, bool y)
{
	if (x == 0 && y == 0)
		return 0;
	return 1;
}
bool equiv(bool x, bool y)
{
	if (x == y)
		return 1;
	return 0;
}
bool add(bool x, bool y)
{
	if (x == y)
		return 0;
	return 1;
}
bool nor(bool x, bool y)
{
	if (x == 0 && y == 0)
		return 0;
	return 1;
}

void main() {
	setlocale(LC_ALL, "Rus");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 6" << endl;
		cin >> Nomer; 

 		if (Nomer == 1)
		{
			float c, s, t;
			cout << "Введите s: "; cin >> s;
			cout << "Введите c: "; cin >> c;
			cout << "Введите t: "; cin >> t;

			cout << "Ответ: " << g(1.2, c) + g(t, s) - g(2 * s - t, s*t) << endl; //А как округлить то? 
		}
		if (Nomer == 2)
		{
			int N;
			cout << "Введите n: "; cin >> N;
			vector<double> A;
			for (int i = 0; i < N; ++i) {
				A.push_back((double)(rand() % 100)*0.1);
				cout << A[i] << " " << endl;
			}

			cout << "Среднее арифметическое : " << arr(A)<< endl; //А как округлить то? 
		}
		if (Nomer == 3)
		{
			double x, a, E = 0.00001;

			do {
				cout << "Введитe a: "; 
				cin >> a;
				cout << "Введитe x: "; 
				cin >> x;
			} while (abs(x) > 1 && E < 0);

			double first = pow((1 + x), a);
			double second = 0.0;

			cout << "Формула: " << first << endl;

			for (int n = 2;; n++) {
				if (first - (1 + a * x + second) < E)
				{
					break;
				}
				second += Power1(x, a, E, n);
			}
			cout << "Приближенное: " << (second) << endl;
			cout << "Приближенное: " << (1 + a * x + second) << endl;
		}
		if (Nomer == 4)
		{
			int n;
			double y;
			cout << "Введите y: "; 
			cin >> y;
			cout << "Введите n: "; 
			cin >> n;

			cout << "Ответ: " << (1.7 * fun(0.25, n) + 2 * fun(1 + y, n)) / (6 - fun(pow(y, 2) - 1, n)) << endl;
			cout << "Ответ: " << (1.7 * func1(0.25, n) + 2 * func1(1 + y, n)) / (6 - func1(pow(y, 2) - 1, n)) << endl;
		}

		if (Nomer == 5)
		{
			cout << "Введите число D" << endl;
			double D;
			cin >> D;
			cout << "В радианах: " << DegToRad(D) << endl;
		}
		if (Nomer == 6)
		{
			int n = 0;
			cout << "|#|" << "\t" << "|x1|" << "  " << "|x2|" << "  " << "|x3|" << "  " << "|f|" << "   " << "|g|" << endl;
			for (int x1 = 0; x1 <= 1; x1++)
			for (int x2 = 0; x2 <= 1; x2++)
			for (int x3 = 0; x3 <= 1; x3++)
			{
				bool f = add(neg(equiv(x1, x2)), con(x1, neg(x3)));
				bool g = impl(neg(x1), dis(x2, con(x3, neg(x1))));
				cout<<"|"<< n++ << "|\t|" << x1 << "|   |" << x2 << "|   |" << x3 << "|   |" << f << "|   |" << g <<"|" <<endl;
			}
		}
	}
	}



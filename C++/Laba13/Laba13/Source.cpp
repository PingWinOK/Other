
#include <iostream>
#include <cmath>
#include <vector>
#include <string>
#include <fstream>
#include <iterator>


using namespace std;
//1
double Sum (int N,double x, double (*a)(int N, double x))
{
	double Sum = 0; 
	for (int n = 1; n <= N; n++)
	{
		Sum += (*a)(n,x);
	}
	return Sum;

}

double F1  (int n , double x)
{
	return sin(n*x)/n;
}

double F2  (int n , double x)
{
	return cos(n * x)/(n*n);
}

double F3  (int n , double x)
{
	return pow(-1,n-1)*(pow(x,n)/n);
}
//2
double f(double x) 
{
	return (exp(-pow(x,2)/2));
}

int C(int i)
{
	if (i % 2 == 0)
	{
		return -1;
	}
	else
	{
		return 1;
	}
}
double INTEGRALLEV(double f(double x), double a, double b, int n)
{
	double x, h;
	double sum = 0.0;
	double fx;
	h = (b - a) / n; 

	for (int i = 0; i < n; i++) {
		x = a + i * h;
		fx = f(x);
		sum += fx;
	}
	return (sum * h);
}

double INTEGRALPRAV(double f(double x), double a, double b, int n)
{
	double x, h;
	double sum = 0.0;
	double fx;
	h = (b - a) / n;

	for (int i = 0; i < n; i++) {
		x = a + h * i;
		fx = f(x + h);
		sum += fx;
	}
	return (sum * h);
}
double INTEGRALPRZMOUGOL(double f(double x), double a, double b, int n)
{
	double x, h;
	double sum = 0.0;
	double fx;
	h = (b - a) / n;
	for (int i = 0; i < n; i++) {
		x = a + h * i;
		fx = f(x + h/2);
		sum += fx;
	}
	return (sum * h);
}

double INTEGRALTRAP(double f(double x), double a, double b, int n)
{
	double x, h;
	double sum = 0.0;
	double fx;
	h = (b - a) / n;
	for (int i = 0; i < n; i++) {
		x = a + h * i;
		fx = f(x);
		sum += fx;
	}
	return ((sum + (f(a)/2) + (f(b)/2)) * h);
}


double INTEGRALSIMPSON(double f(double x), int C(int i), double a, double b, int n)
{
	double x, h;
	double sum = 0.0;
	double fx;
	h = (b - a) / n;
	for (int i = 0; i < n; i++) {
		x = a + h * i;
		fx = f(x);
		sum += (fx * (3 + C(i)));
	}
	return (h / 3 * (f(a) + f(b) + sum));
}

double S (int N,int a , int b , double (*A)(int a, int b,  int n))
{
	double S = 0; 
	for (int n = 0; n <= N-1; n++)
	{
		S += (*A)(a,b,n);
	}
	return S;

}


double f1(double x)
{
	return (1/(x * (log(x) + log(2))));
}

double f2(double x)
{
	return (cos(3 * x) * cos(3 * x));
}

int main() {
	setlocale(LC_ALL, "Rus");
	int Nomer;
	while (true)
	{

		cout << " Введите номер задания от 1 до 3" << endl;
		cin >> Nomer;

		if (Nomer == 1)
		{
			double X;
			int N;
			cout << "Введите Х: " << endl;
			cin >> X;
			cout << "Введите N: " << endl;
			cin >> N;
			cout << "S1 = " << Sum(N, X, F1) << endl;
			cout << "S2 = " << Sum(N, X, F2) << endl;
			cout << "S3 = " << Sum(N, X, F3) << endl;
		}
		if (Nomer == 2)
		{

			cout << "Левая граница интегрирования a = -2";
			cout << "\nПравая граница интегрирования b = 2 " << endl;
			cout << "Метод левых прямоугольников:" << endl;
			double a = -2.0, b = 2.0;
			double s, s1;
			double eps = 0.0001;
			int h;
			int n = 1; //начальное число шагов

			s1 = INTEGRALLEV(f, a, b, n);
			do {
				s = s1;
				n = 2 * n;
				s1 = INTEGRALLEV(f, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "\nИнтеграл = " << s1 << endl;


			cout << "Метод правых прямоугольников:";
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALPRAV(f, a, b, n);
			do {
				s = s1;
				n = 2 * n;
				s1 = INTEGRALPRAV(f, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "\nИнтеграл = " << s1 << endl;


			cout << "Метод прямоугольников:";
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALPRZMOUGOL(f, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALPRZMOUGOL(f, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "\nИнтеграл = " << s1 << endl;


			cout << "Метод трапеций:";
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALTRAP(f, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALTRAP(f, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "\nИнтеграл = " << s1 << endl;

			cout << "Метод Симпсона:";
			s = 0.0, s1 = 0.0; 

			s1 = INTEGRALSIMPSON(f, C, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALSIMPSON(f, C, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "\nИнтеграл = " << s1 << endl;

		}
		if (Nomer == 3)
		{
			cout << "Функция 1:" << endl;
			double a = 2.0, b = 3.0;
			double s, s1;
			double eps = 0.0001;
			int n = 1; //начальное число шагов
			cout << "Метод левых прямоугольников:" << endl;
			s1 = INTEGRALLEV(f1, a, b, n);
			do {
				s = s1;
				n = 2 * n;
				s1 = INTEGRALLEV(f1, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "Интеграл = " << s1 << endl;
			cout << "Точное знаение = " << fabs(s1 - s) << endl;
			cout << " " << endl;
			cout << "Метод трапеций:" << endl;
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALTRAP(f1, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALTRAP(f1, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "Интеграл = " << s1 << endl;
			cout << "Точное знаение = " << fabs(s1 - s) << endl;
			cout << " " << endl;
			cout << "Метод Симпсона:" << endl;
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALSIMPSON(f1, C, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALSIMPSON(f1, C, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "Интеграл = " << s1 << endl;
			cout << "Точное знаение = " << fabs(s1 - s) << endl;

			cout << " " << endl;
			cout << "--------------------------------------" << endl;
			cout << "Функция 2:" << endl;
			a = 0.0;
			b = 3.14159265359/2	;
			s = 0.0, s1 = 0.0;
			eps = 0.0001;
			n = 1; //начальное число шагов
			cout << "Метод левых прямоугольников:" << endl;
			s1 = INTEGRALLEV(f2, a, b, n);
			do {
				s = s1;
				n = 2 * n;
				s1 = INTEGRALLEV(f2, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "Интеграл = " << s1 << endl;
			cout << "Точное знаение = " << fabs(s1 - s) << endl;
			cout << " " << endl;
			cout << "Метод трапеций:" << endl;
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALTRAP(f2, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALTRAP(f2, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "Интеграл = " << s1 << endl;
			cout << "Точное знаение = " << fabs(s1 - s) << endl;
			cout << " " << endl;
			cout << "Метод Симпсона:" << endl;
			s = 0.0, s1 = 0.0;

			s1 = INTEGRALSIMPSON(f2, C, a, b, n);
			do {
				s = s1;
				n = 2 * n;

				s1 = INTEGRALSIMPSON(f2, C, a, b, n);
			} while (fabs(s1 - s) > eps);
			cout << "Интеграл = " << s1 << endl;
			cout << "Точное знаение = " << fabs(s1 - s) << endl;

		}

	}
}
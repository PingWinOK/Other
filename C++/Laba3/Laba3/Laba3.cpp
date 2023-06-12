

#include "stdafx.h"
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
				double a, b, c, P, S, max, l1, l2, block = 9.2559631349317831e+61;
				cout << "Введите стороны a , b , c" << endl;
				cin >> a >> b >> c;
				if ((a == -block) || (b == -block) || (c == -block))
				{
					cout << "Введенa строка!" << endl;
					system("pause");
					return 0;

				}
				if ((a < 0) || (b < 0) || (c < 0))
				{
					cout << "Введено отрицательное число!" << endl;
					system("pause");
					return 0;


				}
				if (a >= b &&  a >= c)
				{
					max = a * 2;
					l1 = b * 2;
					l2 = c * 2;
				}
				if (b >= a && b >= c)
				{
					max = b * 2;
					l1 = a * 2;
					l2 = c * 2;
				}
				if (c >= a && c >= b)
				{
					max = c * 2;
					l1 = a * 2;
					l2 = b * 2;
				}

				if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
				{
					P = ((a + b + c) / 2);
					S = sqrt(P * (P - a)*(P - b) * (P - c));
					if (a == b && b == c)
					{
						cout << "Треугольник равносторонний" << endl;
						
					}
					if (((a == b) && a != c) || ((a == c) && c != b) || ((b == c) && b!= a))
					{
						cout << "Треугольник равнобедренный" << endl;
					}
					if ((c*c) == (a*a + b*b) || (a*a) == (c*c + b * b) || (b*b) == (a*a + c * c))
					{
						cout << "Треугольник прямоугольный" << endl;
					}
					cout << "Площадь треугольника: " << S << endl;

				}
				else
				{
					cout << "Треугольник не существует: " << endl;


				}

			}
			if (Nomer == 2)
			{
				double a, b, c, D;
				cout << "Введите коэффициенты a , b , c" << endl;
				cin >> a >> b >> c;
				if ((a == 0) && (b == 0) && (c == 0))
				{
					cout << "Коэффициенты не могут равняться 0" << endl;

				}
				else if ((a == 0) && (b == 0))
				{
					cout << "Коэффициенты a и b не могут равняться 0" << endl;

				}
				else if ((a == 0) && (b != 0))
				{
					cout << "Коэффициент a не может равняться 0" << endl;

				} 
				if (a != 0)
				{
					D = ((b * b) - 4 * a * c);
					if (D >= 0)
					{
						double x1, x2;
						x1 = ((-b + sqrt(D)) / 2 * a);
						x2 = ((-b - sqrt(D)) / 2 * a);
						cout << "Два корня: x1= " << x1 << " и x2= " << x2 << endl;

					}
					if (D < 0)
					{
						cout << "Нет корней" << endl;

					}

				}
			

			}
			if (Nomer == 3)
			{
				double A1, A2, A3, Max, i;
				cout << "Введите числа А1 , А2 , А3" << endl;
				cin >> A1 >> A2 >> A3;
				if (A1 >= A2 &&  A1 >= A3)
				{
					Max = A1;
					i = 1;

				}
				if (A2 >= A1 && A2 >= A3)
				{
					Max = A2;
					i = 2;

				}
				if (A3 >= A1 && A3 >= A2)
				{
					Max = A3;
					i = 3;

				}
				cout << "Максимальное число: " << Max << " Индекс: " << i << endl;

			}
			if (Nomer == 4)
			{
				double y , x;
				cout << "Введите x" << endl;
				cin >> x;
				if (x < 0)
				{
					y = pow((pow(x, 3) + 1), 2);
				}
				if ((0 <= x) && (x < 1))
				{
					y = 0;
				}
				if ((1 <= x) && (x < 2))
				{
					y = x + 2;
				}
				if (x >= 2)
				{
					y = abs(pow(x,2) - 5 * x + 1);
				}
				cout << "Y = "<< y << endl;



			}
			if (Nomer == 5)
			{
				int X, Y, R, r;
				bool Otw;
				cout << "Введите x,y,R,r:";
				cin >> X >> Y >> R >> r;
				Otw = ((pow(X, 2) + pow(Y, 2) >= pow(r, 2)) && (pow(X, 2) + pow(Y, 2) <= pow(R, 2))) ? 1 : 0;
				if (Otw == 1)
				{
					cout << "Точка входит";
				}
				else
				{
					cout << "Точка не входит";
				}

			}
			if (Nomer == 6)
			{
				int a, b = 1, c = 0, d = 1;
				if ((b == 1) && (c == 1) || (d != 0) && (c < 1))
				{
					a = 1;
				}
				else
				{
					a = 0;
				}
				cout << "а равно " << a << endl;
			}
			if (Nomer == 7)
			{
				int Nom;
				cout << " Введите номер задания от 1 до 2: " << endl;
				cin >> Nom;
				if (Nom == 1)
				{
					int A, B;
					cout << "Введите A,B:" << endl;
					cin >> A >> B;
					if (A != B)
					{
						A += B;
						B = A;
					}
					else
					{
						A = 0;
						B = 0;
					}
					cout << "A: "<< A <<" B: " << B << endl;

				}
				if (Nom == 2)
				{
					double Pi = 3.14159, R, D, L, S, N;
					cout << " Введите номер от 1 до 4: " << endl;
					cin >> N;
					if (N == 1)
					{
						cout << " Введите радиус" << endl;
						cin >> R;
						S = Pi * R * R;
						D = R * 2;
						L = 2 * Pi * R;
						cout << " Радиус - " << R << " Диаметр - " << D << " Длинна - " << L << " Площадь - " << S <<endl;
					}
					if (N == 2)
					{
						cout << " Введите диаметр" << endl;
						cin >> D;
						R = D / 2;
						S = Pi * R * R;
						L = 2 * Pi * R;
						cout << " Радиус - " << R << " Диаметр - " << D << " Длинна - " << L << " Площадь - " << S << endl;
					}
					if (N == 3)
					{
						cout << " Введите длинну" << endl;
						cin >> L;
						R = L / (2 * Pi);
						S = Pi * R * R;
						D = R * 2;
						cout << " Радиус - " << R << " Диаметр - " << D << " Длинна - " << L << " Площадь - " << S << endl;
					}
					if (N == 4)
					{
						cout << " Введите площадь" << endl;
						cin >> S;
						R = sqrt(S / Pi);
						D = R * 2;
						L = 2 * Pi * R;
						cout << " Радиус - " << R << " Диаметр - " << D << " Длинна - " << L << " Площадь - " << S << endl;
					}
				}

			}

		}
}


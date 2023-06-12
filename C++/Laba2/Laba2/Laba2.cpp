#include <iostream>
#include <string>


using namespace std;


int main()
{
    setlocale(LC_ALL, "Russian");
	while (true)
	{
		int Nomer;
		cout << " Введите номер задания от 3 до 8 или введите 9 для просмотра индивидуального задания: " << endl;
		cin >> Nomer;
		if (Nomer == 3)
		{
			bool A = true, B = false, C = false, Otw;
			int Nom;
			cout << " Введите цифру от 1 до 9: " << endl;
			cin >> Nom;
			if (Nom == 1)
			{
				Otw = ((-A) && B);
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 2)
			{
				Otw = (A || (-B));
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 3)
			{
				Otw = ((A && B) || C);
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 4)
			{
				Otw = ((A || B) && (-C));
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 5)
			{
				Otw = ((-A) && (-B));
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 6)
			{
				Otw = (-(A && C) || B);
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 7)
			{
				Otw = ((A && (-B)) || C);
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 8)
			{
				Otw = (A && ((-B) || C));
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 9)
			{
				Otw = (A || (-(B && C)));
				cout << " Ответ: " << Otw << endl;
			}
		}
		if (Nomer == 4)
		{
			int Nom;
			cout << " Введите цифру от 1 до 6: " << endl;
			cin >> Nom;
			if (Nom == 1)
			{
				cout << "if((pow(a,k) + 1) > pow((2 + c),r)) " << endl;
			}
			if (Nom == 2)
			{
				cout << "if(abs(1 - b) < E)" << endl;
			}
			if (Nom == 3)
			{
				cout << " if((0 < x) && (x < 1)) " << endl;
			}
			if (Nom == 4)
			{
				cout << "if((x >= 0) && (y >= 0)) " << endl;
			}
			if (Nom == 5)
			{
				cout << " if(((x + 1) <= y) || ((pow(x,2) + pow(y,2)) > 1))" << endl;
			}
			if (Nom == 6)
			{
				cout << "if(((pow(x,2) + pow(y,2)) > 1) && ((x + y) > 1) || ((pow(x,2) + pow(y,2)) > (xy))) " << endl;
			}

		}
		if (Nomer == 5)
		{
			int Nom;
			cout << " Введите цифру от 1 до 4: " << endl;
			cin >> Nom;
			if (Nom == 1)
			{
				cout << "x > 0 ? y = x : y = -x" << endl;

			}
			if (Nom == 2)
			{
				cout << "x > y ? Max = x : Max = y " << endl;
			}
			if (Nom == 3)
			{
				cout << "x > y ? x = 1 : y = 1" << endl;
			}
			if (Nom == 4)
			{
				cout << "x > y ? y = 0 : x = 0" << endl;
			}
		}
		if (Nomer == 6)
		{
			int a = 1, b = 1, c = 1;
			a = true ? ++b : ++c;
			cout << "a =" << a << endl;
			cout << "b =" << b << endl;
			cout << "c =" << c << endl;

		}
		if (Nomer == 7)
		{
			int Nom;
			cout << " Введите цифру от 1 до 8: " << endl;
			cin >> Nom;
			if (Nom == 1)
			{
				int x;
				double y;
				cout << " Введите x: " << endl;
				cin >> x;
				if (x != 0)
				{
					y = sin(x) / x;
				}
				if (x == 0)
				{
					y = 1;
				}
				cout << "y1 = " << y << endl;
			}
			if (Nom == 2)
			{
				int x;
				double y;
				cout << " Введите x: " << endl;
				cin >> x;
				if (x != 0)
				{
					y = pow((1 + x), 1 / x);
				}
				if (x == 0)
				{
					y = exp(1);
				}
				cout << "y2 =  " << y << endl;
			}
			if (Nom == 3)
			{
				int x;
				double y;
				cout << " Введите x: " << endl;
				cin >> x;
				if (x <= 0)
				{
					y = pow(cos(x), 2);
				}
				if (x > 0)
				{
					y = exp(-x) * sin(2 * x) + abs(x);
				}
				cout << "y3 =  " << y << endl;
			}
			if (Nom == 4)
			{
				int x, a;
				double y;
				cout << " Введите x , a: " << endl;
				cin >> x >> a;
				if (x >= 1 && x <= 2)
				{
					y = log(x);
				}
				else
				{
					y = 1 - pow(a, pow(x, 2));
				}
				cout << "y4 =  " << y << endl;
			}
			if (Nom == 5)
			{
				int x, y;
				double z;
				cout << " Введите x , y: " << endl;
				cin >> x >> y;
				if (x >= 0 && x <= 1)
				{
					z = fmin(x, 2 * y);
				}
				else
				{
					z = fmax(2 * x, y);
				}
				cout << "z1 =  " << z << endl;

			}
			if (Nom == 6)
			{
				int x, y;
				double z;
				cout << " Введите x , y: " << endl;
				cin >> x >> y;
				if (x > y)
				{
					z = x - y;
				}
				if (x <= y)
				{
					z = y - x + 1;
				}
				cout << "z2 =  " << z << endl;
			}
			if (Nom == 7)
			{
				int x, y, a, b;
				double z;
				cout << " Введите x , y , a , b: " << endl;
				cin >> x >> y >> a >> b;
				if ((pow(x, 2) + pow(y, 2)) <= 1)
				{
					z = ((a * x) + b) / (pow(x, 2) + pow(y, 2) + 4) + 1;
				}
				if ((pow(x, 2) + pow(y, 2)) >= 1)
				{
					z = ((a * b * x * y) / (pow(x, 2) + pow(y, 2) + 4)) - pow(x, 3);
				}
				cout << "z3 =  " << z << endl;
			}
			if (Nom == 8)
			{
				int x, y, a, b;
				double z;
				cout << " Введите x , y , a , b: " << endl;
				cin >> x >> y >> a >> b;
				if ((a * x) >= 0)
				{
					z = (2 * a * x) / (pow(x, 2) + 3);
				}
				if ((a * x) < 0)
				{
					z = (a + b) / (4 * (pow(x, 2) + 2));
				}
				cout << "z4 =  " << z << endl;
			}
		}
		if (Nomer == 8)
		{
			int Nom;
			cout << " Введите цифру от 1 до 10: " << endl;
			cin >> Nom;
			if (Nom == 1)
			{
				int X, Y, R;
				bool Otw;
				cout << "Введите x,y,R:";
				cin >> X >> Y >> R;
				Otw = (sqrt((pow(X, 2) + pow(Y, 2))) < pow(R, 2)) ? 1 : 0;
				cout << Otw << endl;

			}
			if (Nom == 2)
			{
				int X, Y, R;
				bool Otw;
				cout << "Введите x,y,R:";
				cin >> X >> Y >> R;
				Otw = ((pow(X, 2) + pow(Y, 2)) <= pow(R, 2)) ? 0 : 1;
				cout << Otw << endl;
			}
			if (Nom == 3)
			{
				int X, Y, R, r;
				bool Otw;
				cout << "Введите x,y,R,r:";
				cin >> X >> Y >> R >> r;
				Otw = ((pow(X, 2) + pow(Y, 2) >= pow(r, 2)) && (pow(X, 2) + pow(Y, 2) <= pow(R, 2))) ? 1 : 0;
				cout << Otw << endl;
			}
			if (Nom == 4)
			{
				int X, Y, R, r;
				bool Otw;
				cout << "Введите x,y,R,r:";
				cin >> X >> Y >> R >> r;
				Otw = ((pow(X, 2) + pow(Y, 2) >= pow(r, 2)) && (pow(X, 2) + pow(Y, 2) <= pow(R, 2)) && (X >= 0)) ? 1 : 0;
				cout << Otw << endl;
			}
			if (Nom == 5)
			{
				int X, Y;
				bool Otw;
				cout << "Введите x,y:";
				cin >> X >> Y;
				Otw = ((X >= 0) && (Y >= 0)) ? 1 : 0;
				cout << Otw << endl;
			}
			if (Nom == 6)
			{
				int X, Y;
				bool Otw;
				cout << "Введите x,y:";
				cin >> X >> Y;
				Otw = ((X >= 0) && (Y >= 0) && (Y < X)) ? 1 : 0;
				cout << Otw << endl; cout << "" << endl;
			}
			if (Nom == 7)
			{
				int X, Y, R, r;
				bool Otw;
				cout << "Введите x,y,R,r:";
				cin >> X >> Y >> R >> r;
				Otw = ((pow(X, 2) + pow(Y, 2) >= pow(r, 2)) && (pow(X, 2) + pow(Y, 2) <= pow(R, 2)) && (X >= 0) && (Y >= 0) && (Y <= 2 * X)) ? 1 : 0;
				cout << Otw << endl;
			}
			if (Nom == 8)
			{
				int X, Y, R, r;
				bool Otw;
				cout << "Введите x,y,R,r:";
				cin >> X >> Y >> R >> r;
				Otw = ((pow(X, 2) + pow(Y, 2) >= pow(r, 2)) && (pow(X, 2) + pow(Y, 2) <= pow(R, 2)) && (X >= 0) && (Y >= 0)) ? 1 : 0;
				cout << Otw << endl;
			}
			if (Nom == 9)
			{
				int X, Y, R;
				bool Otw;
				cout << "Введите x,y,R:";
				cin >> X >> Y >> R;
				Otw = ((pow(X, 2) + pow(Y, 2)) <= pow(R, 2)) && (X <= 0) ? 1 : 0;
				cout << Otw << endl;
			}
			if (Nom == 10)
			{
				int X, Y, A;
				bool Otw;
				cout << "Введите x,y,A:";
				cin >> X >> Y >> A;
				Otw = (pow(X, 2) * pow(Y, 2)) >= pow(A, 2) ? 1 : 0;
				cout << Otw << endl;;
			}
		}
		if (Nomer == 9)
		{
			int Nom;
			cout << " Введите цифру от 1 до 2: " << endl;
			cin >> Nom;
			if (Nom == 1)
			{
				int A, B;
				bool Otw;
				cout << " Введите A и B: " << endl;
				cin >> A >> B;

				if (((A % 2) != 0) && ((B % 2) == 0) || ((A % 2) == 0) && ((B % 2) != 0))
				{
					Otw = true;
				}
				else
				{
					Otw = false;
				}
				cout << " Ответ: " << Otw << endl;
			}
			if (Nom == 2)
			{
				int A, B, C;
				bool Otw;
				cout << " Введите A,B и C: " << endl;
				cin >> A >> B >> C;
				if (((A + B) > C) && ((B + C) > A) && ((A + C) > B))
				{
					Otw = true;
				}
				else
				{
					Otw = false;
				}
				cout << " Ответ: " << Otw << endl;

			}
		}
		if (Nomer == 0)
		{
			break;
		}
	}
}


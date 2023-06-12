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

		cout << " ¬ведите номер задани€ от 1 до 5 или введите 6,7,8 дл€ просмотра индивидуального задани€: " << endl;
		cin >> Nomer;
		if (Nomer == 1)
		{
			int n,Q = 0; 
			cout << " ¬ведите n: " << endl;
			cin >> n;
			for (int i = 2; i <= sqrt(n); i++)
			{
				if (n % i == 0)
				{
					cout << " „исло не простое:" << endl;
					Q = 1;
					break;
				}
			}
			if (Q == 0)
			{
				cout << " „исло простое: " << endl;
			}
		}
		if (Nomer == 2)
		{
			int n,Fact = 1;
			cout << " ¬ведите n: " << endl;
			cin >> n;
			for (int i = 1; i < n+1; i++)
			{
				Fact *= i;
			}
			cout << " ‘акториал от n: "<< Fact << endl;

		}
		if (Nomer == 3)
		{
			float n,x;
			float S = 0,A;
			cout << " ¬ведите  x,n: " << endl;
			cin >> x >> n;
			A = x;
			for (int i = 1; i <= n; i++)
			{
				A = sin(A);
				S += A;
			}
			cout << "S = "<< S << endl;

		}
		if (Nomer == 4)
		{
			int x , n = 256;
			float Z,F;
			cout << " ¬ведите  x: " << endl;
			cin >> x;
 			Z = pow(x, 2) + (n / pow(x, 2));
			for (int n = 128; n != 0; n = n / 2)
			{
				if (n == 1)
				{
					Z = x/Z;
				}
				else
				{

					Z = pow(x, 2) + (n / Z);
				}
			}
			cout << "Z: " << Z<< endl;

		}
		if (Nomer == 5)
		{
			int x, n;
			float S = 0.0,A ,B = 1;
			cout << " ¬ведите  x и n : " << endl;
			cin >> x >> n;
			for (int i = 0; i <= n; i++)
			{
				if (i == 0)
				{
					B = 1;
				}
				else
				{
					B *= i;
				}
				if (i == 2)
				{
					A = 1;
				}
				else
				{
					A = 0;
				}
				S += (pow(x, i) / B) * (i + A);
			}
			cout << S << endl;
		}
		if (Nomer == 6)
		{
			int m = 10;
			float a = 3.14/3, b=(3*3.14)/2,h,x,F;
			h = (b - a) / m;
			for (int i = 0; i < 10; i++)
			{
				x = a + i * h;
				F = cos(pow(x, 2) + 1);
				cout << "x" <<i<<" = "<< x << " f(x): "<< F <<endl;
			}

		}
		if (Nomer == 7)
		{
			int N;
			float A,S;
			cout << " ¬ведите A,N: " << endl;
			cin >> A >> N;
			for (int k = 0; k <= N; k++)
			{
				S = pow(A,k);
				cout << "—тепень "<< k <<": "<< S << endl;

			}
		}
		if(Nomer == 8)
		{
			double x,S = 0,a,b,c;
			int N,fac = 1;
			cout << " ¬ведите N и x: " << endl;
			cin >> N >> x;
			a = x;
			for (int k = 0; k <= N; k++)
			{
				S += a;
				a *= ((pow(x,2))/((2*k+3)*(2*k+2)));
			}
			cout << "S: " << S << endl;

		}
	}
}
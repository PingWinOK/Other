#include <iostream>
#include <math.h>

using namespace std;

void main()
{
	setlocale(LC_ALL,"Russian");
	while (true)
	{
		cout << "������� ����� ������� �� 1 �� 4:" << endl;
		int Nomber;
		cin >> Nomber;
		if (Nomber == 1)
		{
			cout << "������� n:" << endl;
			int n, S = 0, Kol = 0;
			cin >> n;
			for (int i = n; i <= 2 * n; i++)
			{
				for (int j = 1; j <= i; j++)
				{
					if (i%j == 0)
					{
						S += j;
						Kol += 1;
					}
				}
			}
			cout << "�����: " << S << " ����������: " << Kol << endl;
		}
		if (Nomber == 2)
		{
			cout << "������� n:" << endl;
			int n,g = 0;
			cin >> n;
			for (int i = 0; i <= 2*n + 5; i++)
			{
				for (int j = 0; j <= 2*n + 5; j++)
				{
					if (pow(i - n, 2) + pow(j - n, 2) <=  pow(n + 5, 2))
					{
						cout << "����� � ������������ [" << i <<" "<< j << "]: ������ �� ����" << endl;
						g += 1;
					}
				}
			}
			cout << g << endl;
		}
		if (Nomber == 3)
		{
			cout << "������� n:" << endl;
			int n;
			cin >> n;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (pow(i, 2) + pow(j, 2) == n)
					{
						cout << "����� ��������� ����� " << i << " � " << j << " ����� " << n << endl;
					}
				}
			}
		}
		if (Nomber == 4)
		{
			cout << "������� ��������:" << endl;
			long double e;
			cin >> e;
			cout << "������� x:" << endl;
			double x, y;
			cin >> x;
			double h = (1 - 0.1) / 10;
			double S = 0;
			for (int i = 1; i <= 10; i++)
			{
				x = 0.1 + i * h;
				y = ((1 + pow(x, 2)) / 2)* (atan(x) - (x / 2));
				cout << "y ��� x =" << x << ": " << y << endl;
				for (int n = 1; n < 20; n++)
				{
					S += pow(-1, n + 1) * (pow(x, 2 * n + 1) / 4 * pow(n, 2) - 1);
					cout << "S =" << S << endl;

				}

			}
		}
	}





}
#include <iostream>
#include <cstdlib>
#include <string>

using namespace std;

int main() 
{ 
	setlocale(LC_ALL, "Russian"); 
	int Nomer;
	cout << " ������� ����� ������� �� 1 �� 12 ��� ������� 13 ��� ��������� ��������������� �������: " << endl;
	cin >> Nomer;
	if(Nomer == 1)
	{
	string F = "�������";
	string I = "�����";
	string O = "���������";
    cout << "FIO: " <<F +" "+ I +" "+ O << endl;
	cout << "FIO: " <<endl<<F << endl <<I << endl << O << endl;
	}
	if(Nomer == 2)
	{
		double N = 9.0,d;
		int x,a,b,c;
		cout << " ������� x: " << endl;
		cin >> x;
		cout << "x: " << x << " N: " << N << endl;
		a = x + N;
		cout << "a = x + N: " << a <<endl;
		b = x - N;
		cout << "b = x - N: " << b <<endl;
		c = x * N;
		cout << "c = x * N: " << c <<endl;
		d = x / N;
		cout << "d = x / N: " << d <<endl;
	}
	if(Nomer == 3)
	{
		int a,b,c,S;
		cout << " ������� a: " << endl;
		cin >> a;
		cout << " ������� b: " << endl;
		cin >> b;
		cout << " ������� c: " << endl;
		cin >> c;
		S = (a + b + c)/3;
		cout << "������� ��������������: " << S << endl;
	}
	if(Nomer == 4)
	{
		double pi = 3.14159265,r,R,S;
		cout << " ������� r: " << endl;
		cin >> r;
		cout << " ������� R: " << endl;
		cin >> R;
		S = pi * ((R * R) - (r * r));
		cout << " ������ ������ �����: " << S << endl;
	}
	if(Nomer == 5)
	{
		int H,M,S, second;
		cout << " ������� ����: " << endl;
		cin >> H;
		cout << " ������� ������: " << endl;
		cin >> M;
		cout << " ������� �������: " << endl;
		cin >> S;
		second = (H * 60 * 60) + (M * 60) + S;
		cout << " ����� � ��������: " << second << endl;
	}
	if(Nomer == 6)
	{
		int a,b,swap;
		cout << " ������� a: " << endl;
		cin >> a;
		cout << " ������� b: " << endl;
		cin >> b;
		swap = a;
		a = b;
		b = swap;
		cout << " a: " << a <<endl;
		cout << " b: " << b <<endl;
	}
	if(Nomer == 7)
	{
		int M;
		cout << " ������� ������: " << endl;
		cin >> M;
		cout << " �����: " << (M / 60) <<" �����: " << (M % 60) << endl;
	}
	if(Nomer == 8)
	{
		int k,m,n;
		float x,y;
		cout << " k: " << endl;
		cin >> k;
		cout << " m: " << endl;
		cin >> m;
		cout << " n: " << endl;
		cin >> n;
		cout << " x: " << endl;
		cin >> x;
		y = (2 * ((k * k)/2))+(x / 3 )+(m % n);
		cout << "y: " << y << endl;
	}
	if(Nomer == 9)
	{
		int x, A;
		cout << " x: " << endl;
		cin >> x;
		A = 1 + x * (-2 + x * (3 - 4 * x));
		cout << " ���������� � ������� ����� �������:" << endl;
		cout << " y = 1 + x * (-2 + x * (3 - 4 * x)) = " << A << endl;
	}
	if (Nomer == 10)
	{
		double x, y;
		cout << " x: " << endl;
		cin >> x;
		y = x / (1 + ((pow(x, 2) / (2 + ((pow(x, 3)) / (3 + ((pow(x, 4)) / 4)))))));
		cout << " y: " << y << endl;
	}
	if (Nomer == 11)
	{
		double x, y1,y2;
		cout << " x: " << endl;
		cin >> x;
		y1 = 1 - x + (pow(x, 2) / (1 * 2)) - (pow(x, 3) / (1 * 2 * 3)) + (pow(x, 4) / (1 * 2 * 3 * 4)) - (pow(x, 5) / (1 * 2 * 3 * 4 * 5));
		cout << " a) y: " << y1 << endl;
		y2 = x - (pow(x, 3) / (1 * 2 * 3)) + (pow(x, 5) / (1 * 2 * 3 * 4  * 5 )) - (pow(x, 7) / (1 * 2 * 3 * 4 * 5 * 6 * 7)) + (pow(x, 9) / (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9));
		cout << " �) y: " << y2 << endl;
	}
	if (Nomer == 12)
	{
		int a1, a2, b1, b2,c1,c2, delta, deltaX, deltaY;
		double x, y;
		cout << " ������� a1,b1,c1 " << endl;
		cin >> a1 >> b1 >> c1;
		cout << " ������� a2,b2,c2" << endl;
		cin >> a2 >> b2 >> c2;
		delta = a1 * b2 - a2 * b1;
		deltaX = c1 * b2 - c2 * b1;
		deltaY = a1 * c2 - a2 * c1;
		x = deltaX / delta;
		y = deltaY / delta;
		cout << " X ="  << x << " Y = " << y <<endl;
	}
	if (Nomer == 13)
	{
		int A, B,x,y;
		double z1, z2, f;
		cout << " ������� A " << endl;
		cin >> A;
		cout << " ������� B" << endl;
		cin >> B;
		z1 = (pow((cos(A) - cos(B)), 2)) - (pow((sin(A) - sin(B)), 2));
		z2 = (-4 * pow(sin((A-B)/2),2)) * (cos(A + B));
		cout << " Z1 =" << z1 << " Z2 = " << z2 << endl;
		cout << " ������� X " << endl;
		cin >> x;
		cout << " ������� Y" << endl;
		cin >> y;
		f = sqrt((pow(sin(x),2)) + (pow(cos(abs(y)), 2)));
		cout << " f = " << f << endl;
	}
    system("pause");
    return 0; 
}
#include <cstddef>
#include <stdio.h>
#include <string.h>
#include <locale.h>
#include <ostream>
#include <iostream>
#include <time.h>
using namespace std;

class Vector
{
private:
    int* vector{};
    int N;
public:
    Vector operator++(void)
    {
        N++;
        return *this;
    }

    Vector operator++(int d)
    {
        N++;
        return *this;
    }

    Vector operator--(void)
    {
        N--;
        return *this;
    }

    Vector operator--(int d)
    {
        N--;
        return *this;
    }

    int GetN(void)
    {
        return N;
    }

    Vector(int n)
    {
        N = n;
        vector = new int[N];
        set();
    }

    double fact(int N)
    {
        if (N < 0)
            return 0;
        if (N == 0)
            return 1;
        else
            return N * fact(N - 1);
    }

    ~Vector()
    {
        //delete[] vector;
    }

    void print()
    {
        for (int i = 0; i < N; i++)
            cout << vector[i] << "  ";
        cout << endl;
    }

    void SetAt(int i, int val)
    {

        vector[i] = val;
        cout << "Значение[" << i << "] изменено на " << vector[i] << endl;
        cout << endl;
    }

    void get(int i) const
    {
        cout << "Индекс[" << i << "]" << endl;
        cout << vector[i - 1];
        cout << endl;
    }

    void set()
    {
        srand(time(0));
        for (int i = 0; i < N; i++)
            vector[i] = fact(i);
    }
};
class Matrix
{
private:
public:
    int N, M;
    int** matrix = NULL;
    ~Matrix()
    {
        //if (matrix)
        //{
        //    for (size_t i = 1; i < N; ++i)
        //        delete[] matrix[i];
        //    delete[] matrix;
        //   
        //}
    }
    Matrix(int n, int m)
    {
        matrix = new int* [N];
        N = n;
        M = m;
        for (size_t i = 0; i < N; i++)
        {

            matrix[i] = new int[M];
        }
        set();
    }

    double fact(int N)
    {
        if (N < 0)
            return 0;
        if (N == 0)
            return 1;
        else
            return N * fact(N - 1);
    }


    int getsize()
    {
        return N, M;
    }

    void print()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                cout << matrix[i][j] << "  ";
            }
            cout << endl;
        }
    }

    void SetAt(int i, int j, int val)
    {

        matrix[i - 1][j - 1] = val;
        cout << "Значение[" << i << "][" << j << "] изменено на " << matrix[i - 1][j - 1] << endl;
        cout << endl;
    }

    int Tat(int i, int j)
    {
        return matrix[i][j];
    }

    void get(int i, int j)
    {

        cout << "Значение[" << i << "][" << j << "]" << endl;
        cout << matrix[i - 1][j - 1];
        cout << endl;
    }
    void set()
    {
        srand(time(0));
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i][j] = fact(i) + fact(j);
            }
            cout << endl;
        }

    }
};


int main()
{
    setlocale(LC_CTYPE, "rus");
    cout << "Война и мир Толстой Л.Н. 2010" << endl;
    cout << "Подросток Достоевский Ф.М. 2004" << endl;
    cout << "Обрыв Гончаров И.А. 2010" << endl;
    cout << endl;

    cout << "Война и мир Толстой Л.Н. 2010" << endl;
    cout << "Обрыв Гончаров И.А. 2010" << endl;
    cout << "Подросток Достоевский Ф.М. 2004" << endl;
    cout << endl;


    cout << "Обрыв Гончаров И.А. 2010" << endl;
    cout << "Война и мир Толстой Л.Н. 2010" << endl;
    cout << endl;
    //setlocale(LC_CTYPE, "rus");
    //int n;
    //cout << "Введите размер вектора: ";
    //cin >> n;
    //Vector vector(n);
    //cout << "Вектор" << endl;
    //vector.print();
    //vector.get(3);
    //cout << "Значение N: " << vector.GetN() << endl;
    //cout << "Используем инкремент" << endl;
    //++vector;
    //cout << "Значение N: " << vector.GetN() << endl;
    //int a;
    //int b;
    //cout << "Введите размер массива (a,b)\n";
    //cout << "n: ";
    //cin >> a;
    //cout << "m: ";
    //cin >> b;
    //Matrix matrix(a, b);
    //cout << "Матрица" << endl;
    //matrix.print();
    //cout << "Получим элемент по индексам" << endl;
    //matrix.get(3, 3);
    //cout << "Заменим элемент по индексам" << endl;
    //matrix.SetAt(3, 3, 15);
    //matrix.print();
    ////задание 2 из лабы 1
    //cout << "Задание 2 из лабораторной работы №1" << endl;
    //Vector vlab1(15);
    //Matrix mlab1(5, 5);
    //mlab1.print();
    //int q = 0;
    //for (size_t i = 0; i < 5; ++i)
    //{
    //    if (i % 2 == 0)
    //    {
    //        for (size_t j = 0; j < 5; ++j)
    //        {
    //            vlab1.SetAt(q, mlab1.Tat(i, j));
    //            q++;
    //        }
    //    }

    //}
    //vlab1.print();
    system("pause");

}

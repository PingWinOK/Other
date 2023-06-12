using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Судоку
{
    public partial class Sudoku : Form
    {
        Label[] labels = new Label[81];
        static public int[,] helpPanel;
        private difficult Dif;
        public Sudoku(difficult dif)
        {
            InitializeComponent();
            this.Dif = dif;
            GenerateBoard();

        }
        private int[,] board;
        // Массив для хранения состояния судоку
        private TextBox[,] cells;
        private void GenerateBoard()
        {
            sudokuPanel.Controls.Clear();

            // Создаем новые массивы для хранения текущего состояния и текстовых полей
            board = new int[9, 9];
            cells = new TextBox[9, 9];

            // Генерация нового поля судоку
            GenerateSudokuSolution(); // Генерируем полное решение судоку


            RemoveRandomValues(); // Удаляем случайные значения для создания игрового поля

            // Создание текстовых полей
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 30,
                        Height = 30,
                        Font = new Font("Segoe Print", 11),
                        TextAlign = HorizontalAlignment.Center,
                        Multiline = true,
                        MaxLength = 1,
                        Tag = new Point(row, col)
                    };

                    if (board[row, col] != 0)
                    {
                        textBox.Text = board[row, col].ToString();
                        textBox.Enabled = false;
                    }
                    textBox.Location = new Point(col * 32, row * 32);
                    // Добавление текстового поля в панель судоку
                    sudokuPanel.Controls.Add(textBox);
                    cells[row, col] = textBox;
                    textBox.KeyPress += TextBox_KeyPress;
                }
            }

            // Создание границ блоков
            Lines A = new Lines();
            A.Line(2,sudokuPanel.Height, 94, 0, sudokuPanel);
            A.CreateLine();
            A.Line(2,sudokuPanel.Height, 190, 0, sudokuPanel);
            A.CreateLine();
            A.Line(sudokuPanel.Width,2, 0, 94, sudokuPanel);
            A.CreateLine();
            A.Line(sudokuPanel.Width,2, 0, 190, sudokuPanel);
            A.CreateLine();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отмена ввода символа, если он не является числом или управляющим символом
            }
        }
        private void GenerateSudokuSolution()
        {
            // Создаем пустое поле судоку
            board = new int[9, 9];

            // Рекурсивно заполняем поле судоку
            FillCell(0, 0);
            helpPanel = (int[,])board.Clone();
        }

        private bool FillCell(int row, int col)
        {
            if (col >= 9) // Если достигнут конец строки, переходим на следующую строку
            {
                col = 0;
                row++;

                if (row >= 9) // Если достигнут конец судоку, значит судоку полностью заполнено
                {
                    return true;
                }
            }

            if (board[row, col] != 0) // Если ячейка уже заполнена, переходим к следующей ячейке
            {
                return FillCell(row, col + 1);
            }

            // Генерируем случайное значение для текущей ячейки
            List<int> values = new List<int>(Enumerable.Range(1, 9));
            Shuffle(values); // Перемешиваем значения, чтобы получить разные комбинации

            foreach (int value in values)
            {
                if (IsValidPlacement(row, col, value))
                {
                    board[row, col] = value;

                    if (FillCell(row, col + 1)) // Рекурсивно заполняем следующую ячейку
                    {
                        return true;
                    }

                    board[row, col] = 0; // Если рекурсивный вызов FillCell() вернул false, сбрасываем значение в 0 и пробуем следующее значение
                }
            }

            return false; // Если ни одно значение не подходит, возвращаем false
        }
        private bool IsValidPlacement(int row, int col, int value)
        {
            // Проверка по горизонтали и вертикали
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == value || board[i, col] == value)
                    return false;
            }

            // Проверка внутри блока 3x3
            int blockRow = row / 3 * 3;
            int blockCol = col / 3 * 3;
            for (int i = blockRow; i < blockRow + 3; i++)
            {
                for (int j = blockCol; j < blockCol + 3; j++)
                {
                    if (board[i, j] == value)
                        return false;
                }
            }

            return true;
        }
        private void RemoveRandomValues()
        {
            RandomNumber random = new RandomNumber();
            int emptyCellsCount = this.Dif.freefield; // Количество ячеек, которые нужно удалить

            while (emptyCellsCount > 0)
            {
                int row = random.Next(0, 9);
                int col = random.Next(0, 9);

                if (board[row, col] != 0)
                {
                    board[row, col] = 0;
                    emptyCellsCount--;
                }
            }
        }
        private void Shuffle<T>(List<T> list)
        {
            RandomNumber random = new RandomNumber();

            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = random.Next(i, list.Count);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private bool IsSudokuSolved()
        {
            int[,] sudokuValues = new int[9, 9];
            int row = 0;
            int col = 0;
            foreach (Control control in sudokuPanel.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (int.TryParse(textBox.Text, out int value))
                    {
                        sudokuValues[row, col] = value;
                    }
                    col++;
                    if (col >= 9)
                    {
                        col = 0;
                        row++;
                    }

                }
            }
            row = 0;
            col = 0;
            int check = 0;
            for (; row < 9; row++)
            {
                for (; col < 9; col++)
                {
                    check += sudokuValues[row, col];
                }
                if(check != 45)
                {
                    return false;
                }
            }
                    return true;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (IsSudokuSolved() == true)
            {
                toolStripLabel1.Text = "Правильно";
                toolStripLabel1.ForeColor = Color.Green;

            }
            else
            {
                toolStripLabel1.Text = "Неправильно";
                toolStripLabel1.ForeColor = Color.Red;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HelpPanel HelpPanel = new HelpPanel();
            // Отображение второй формы
            HelpPanel.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Menu Menu = new Menu();
            Menu.Show();
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


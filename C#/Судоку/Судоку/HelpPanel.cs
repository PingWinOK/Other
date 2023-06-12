using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Судоку
{
    public partial class HelpPanel : Form
    {
        public HelpPanel()
        {
            InitializeComponent();
        }
        int[,] board = Sudoku.helpPanel;
        // Массив для хранения состояния судоку
        private TextBox[,] cells;

        private void Form2_Load(object sender, EventArgs e)
        {
            GenerateBoard();
            Lines A = new Lines();
            A.Line(2, HPanel.Height, 82, 0, HPanel);
            A.CreateLine();
            A.Line(2, HPanel.Height, 166, 0, HPanel);
            A.CreateLine();
            A.Line(HPanel.Width, 2, 0, 82, HPanel);
            A.CreateLine();
            A.Line(HPanel.Width, 2, 0, 166, HPanel);
            A.CreateLine();
            
        }
        private void GenerateBoard()
        {
            HPanel.Controls.Clear();

            // Создаем новые массивы для хранения текущего состояния и текстовых полей
            cells = new TextBox[9, 9];

            // Создание текстовых полей
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 25,
                        Height = 25,
                        Font = new Font("Segoe Print", 9),
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
                    textBox.Location = new Point(col * 28, row * 28);
                    // Добавление текстового поля в панель судоку
                    HPanel.Controls.Add(textBox);
                    cells[row, col] = textBox;
                }
            }
        }
    }
}

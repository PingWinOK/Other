using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Задаем начальные значения компонентов формы
            experienceComboBox.SelectedIndex = 0;
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Получаем значения из компонентов формы
            string fullName = fullNameTextBox.Text;
            string experience = experienceComboBox.SelectedItem.ToString();
            bool hasTeachingExperience = teachingExperienceCheckBox.Checked;
            string passportData = passportDataTextBox.Text;

            // Открываем новое окно с решением о приеме на работу
            HiringDecisionForm decisionForm = new HiringDecisionForm(fullName, experience, hasTeachingExperience, passportData);
            decisionForm.ShowDialog();
        }
    }
}

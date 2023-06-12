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
    public partial class HiringDecisionForm : Form
    {
        public HiringDecisionForm(string fullName, string experience, bool hasTeachingExperience, string passportData)
        {
            InitializeComponent();
            fullNameLabel.Text = fullName;
            ExperienceLabel.Text = experience;
            hasTeachingExperienceLabel.Text = hasTeachingExperience ? "Есть" : "Нет";
            passportDataLabel.Text = passportData;
            if (hasTeachingExperience)
            {
                hiringDecisionLabel.Text = "Принять";
            }
            else
            {
                hiringDecisionLabel.Text = "Отклонить";
            }
        }

    }
}

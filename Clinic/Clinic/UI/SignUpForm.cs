
using Clinic.Database;
using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class SignUpForm : Form
    {
        private Control.ControlCollection defaultControls;

        public SignUpForm(Control.ControlCollection defaultControls)
        {
            this.defaultControls = defaultControls;

            foreach (Control control in this.defaultControls)
                control.Visible = false;

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void singUp_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || usernameTextBox.Text == ""
                || passwTextBox.Text == "" || passwRepeatTextBox.Text == "")
            {
                MessageBox.Show("Некоторые поля пустуют, введите все данные.");
            }
            else
            {
                if (passwTextBox.Text != passwRepeatTextBox.Text)
                {
                    MessageBox.Show("Введённые пароли не совпадают, попробуйте ещё раз.");
                }
                else
                {
                    int type = 0;
                    if (registrarButton.Checked)
                    {
                        type = 1;
                    }
                    User user = new User()
                    {
                        Name = nameTextBox.Text,
                        UserName = usernameTextBox.Text,
                        Password = passwTextBox.Text,
                        TypeOfUser = type
                    };
                   // MessageBox.Show(user.TypeOfUser.ToString());
                    if (DBConnector.ContainsUsername(user) != 0)
                    {
                        MessageBox.Show("Пользователь с таким именем уже существует.");
                    }
                    else
                    {
                        DBConnector.AddUser(user);

                        Close();
                        foreach (Control control in this.defaultControls)
                            control.Visible = true;
                    }
                }
            }

        }

       

        private void doctorButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!doctorButton.Checked && registrarButton.Checked)
            {
                registrarButton.Checked = false;
                doctorButton.Checked = true;
            }
        }

        private void registrarButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!registrarButton.Checked && doctorButton.Checked)
            {
                doctorButton.Checked = false;
                registrarButton.Checked = true;
            }
        }
    }
}

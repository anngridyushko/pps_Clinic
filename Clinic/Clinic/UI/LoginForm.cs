
using Clinic.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Entities;
using Clinic.Database;

namespace Clinic
{
    public partial class LoginForm : Form
    {
        private Panel logPanel;
        private Panel signPanel;
        private SignUpForm signForm;

        private User user;

        public LoginForm(User user, Panel logPanel, Panel signPanel)
        {
            InitializeComponent();

            passwTextBox.PasswordChar = '*';
            passwTextBox.UseSystemPasswordChar = true;
            this.signPanel = signPanel;
            this.logPanel = logPanel;

            this.user = user;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in logPanel.Controls)
                control.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int count = 0;
        string username;

        private void singInButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || passwTextBox.Text == "")
            {
                MessageBox.Show("Имя пользователя или пароль отсутствуют.");
            }
            else
            {
                
                user.UserName = usernameTextBox.Text;
                user.Password = passwTextBox.Text;

                if(username == user.UserName)
                {
                    count++;
                }
                else {
                    username = user.UserName;
                    count = 0;
                }

                if (DBConnector.CheckLogin(user))
                {
                    Close();
                    logPanel.Controls[2].Visible = true;
                    //MessageBox.Show(user.TypeOfUser.ToString());
                    if (user.TypeOfUser == 0)
                    {
                        logPanel.Controls[0].Visible = true;
                    }
                    else
                    {
                        logPanel.Controls[1].Visible = true;
                    }

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    if(count == 1)
                    {
                        button1.Visible = true;
                    }
                    if(count == 2)
                    {
                        MessageBox.Show("Вы ввели неправильный пароль 3 раза");
                        Application.Exit();
                    }
                }
                
               
                
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            signForm = new SignUpForm(signPanel.Controls)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            signPanel.Controls.Add(signForm);
            signForm.Show();
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = "";
        }

        private void passwTextBox_Click(object sender, EventArgs e)
        {
            passwTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

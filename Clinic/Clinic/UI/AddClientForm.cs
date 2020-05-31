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
    public partial class AddClientForm : Form
    {
        private ClientForm clientForm;
        public AddClientForm(ClientForm clientForm)
        {
            InitializeComponent();
            this.clientForm = clientForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameText.Text == "" || surnameText.Text == "" || addressText.Text == ""
                || emailText.Text == "" || phoneText.Text == "" || reliefText.Text == "")
            {
                MessageBox.Show("Please, don't leave empty fields");
            }
            else
            {
                Client cl = new Client()
                {
                    Name = nameText.Text,
                    Surname = surnameText.Text,
                    Address = addressText.Text,
                    Email = emailText.Text,
                    PhoneNumber = phoneText.Text,
                    PersonalRelief = Convert.ToInt32(reliefText.Text)
                };

                cl.id = DBConnector.InsertClient(cl);
               
                Close();

                foreach (Control control in clientForm.Controls)
                    control.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Close();

            foreach (Control control in clientForm.Controls)
                control.Visible = true;
        }
    }
}

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
    public partial class AddDoctorForm : Form
    {
        private DoctorForm doctorForm;
        public AddDoctorForm(DoctorForm doctorForm)
        {
            this.doctorForm = doctorForm;
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameText.Text == "" || surnameText.Text == "" || dateText.Text == ""
               || emailText.Text == "" || phoneText.Text == "" || expText.Text == "" || specText.Text == "")
            {
                MessageBox.Show("Please, don't leave empty fields");
            }
            else
            {
                Doctor cl = new Doctor()
                {
                    Name = nameText.Text,
                    Surname = surnameText.Text,
                    DateOfBirth = Convert.ToDateTime(dateText.Text),
                    Email = emailText.Text,
                    PhoneNumber = phoneText.Text,
                    Specialty = specText.Text,
                    Experience = expText.Text
                  
                };

                cl.id = DBConnector.InsertDoctor(cl);

                Close();

                foreach (Control control in doctorForm.Controls)
                    control.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();

            foreach (Control control in doctorForm.Controls)
                control.Visible = true;
        }
    }
    
    
}

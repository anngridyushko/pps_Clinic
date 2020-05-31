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
    public partial class AddPetForm : Form
    {
        private PetForm pForm;
        private int owner_id;
        public AddPetForm(PetForm pForm, int id)
        {
            owner_id = id;
            InitializeComponent();
            this.pForm = pForm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameText.Text == "" || typeText.Text == "" || genderText.Text == ""
                || dateText.Text == "" )
            {
                MessageBox.Show("Please, don't leave empty fields");
            }
            else
            {
                Pet cl = new Pet()
                {
                    Name = nameText.Text,
                    Type = typeText.Text,
                    Gender = genderText.Text,
                    DateOfBirth = Convert.ToDateTime(dateText.Text),
                    Owner_id = owner_id
                   
                };

                cl.id = DBConnector.InsertPet(cl);

                Close();

                foreach (Control control in pForm.Controls)
                    control.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

            foreach (Control control in pForm.Controls)
                control.Visible = true;
        }
    }
}

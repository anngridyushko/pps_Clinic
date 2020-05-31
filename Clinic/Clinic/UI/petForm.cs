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
    public partial class PetForm : Form
    {
        private Client cl;
        private ClientForm clientForm;
        private AddPetForm addPetForm;
        private List<Pet> pets;
        public PetForm(ClientForm clientForm, Client client)
        {
            this.clientForm = clientForm;
            this.cl = client;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int currRow, currCol;
        string value; 

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currRow = dataGridView.CurrentCell.RowIndex;
            currCol = dataGridView.CurrentCell.ColumnIndex;
            value = dataGridView.CurrentCell.Value.ToString();
        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
            foreach (Control control in clientForm.Controls)
                control.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            addPetForm = new UI.AddPetForm(this, cl.id)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            foreach (Control control in Controls)
                control.Visible = false;

            Controls.Add(addPetForm);
            addPetForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = currRow;
            DBConnector.DeletePet(pets[id]);
            Refresh();
        }
         int fieldID;
         string[] fields = { "Name", "Type", "Gender", "DateOfBirth" };
         int id;
        private void button4_Click(object sender, EventArgs e)
        {
            DBConnector.UpdatePet(pets[id], fields[--fieldID], "\'" + value + "\'");
            Refresh();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currRow = dataGridView.CurrentCell.RowIndex;
            currCol = dataGridView.CurrentCell.ColumnIndex;
            value = dataGridView.CurrentCell.Value.ToString();
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            id = currRow;
            fieldID = currCol;
            value = dataGridView[fieldID, id].Value.ToString();
        }

        private void dataGridView_Paint(object sender, PaintEventArgs e)
        {
            pets = DBConnector.LoadPets(cl.id.ToString());
            dataGridView.DataSource = pets;
            dataGridView.Columns[0].Width = 12;
            dataGridView.Columns[1].Width = 12;

        }
    }
}

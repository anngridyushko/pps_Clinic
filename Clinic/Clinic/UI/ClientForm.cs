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
    public partial class ClientForm : Form
    {
        private UI.AddClientForm addClientForm;
        private UI.PetForm petForm;
        private Panel mainPanel;
        private List<Client> cl;
        private User user;

        public ClientForm(User user, Panel mainPanel)
        {
            InitializeComponent();
            this.user = user;
            this.mainPanel = mainPanel;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control control in mainPanel.Controls)
                control.Visible = true;
        }

        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            cl = DBConnector.LoadClients();
            dataGridView.DataSource = cl;
            dataGridView.Columns[0].Width = 20;
           // dataGridView.Columns[1].Width = 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = currRow;
            DBConnector.DeleteClient(cl[id]);
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addClientForm = new UI.AddClientForm(this)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            foreach (Control control in Controls)
                control.Visible = false;

            Controls.Add(addClientForm);
            addClientForm.Show();
        }

        string[] fields = {"Name", "Surname", "Address", "Email", "PhoneNumber", "PersonalRelief" };
        private void button1_Click(object sender, EventArgs e)
        {
            
            DBConnector.UpdateClient(cl[id], fields[--fieldID], "\'" + value + "\'");
            Refresh();
        }

        int fieldID;
        string value;
        int id;
        

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            id = currRow;
            fieldID = currCol;
            value = dataGridView[fieldID, id].Value.ToString();
            
        }

        int currRow;
        int currCol;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currRow = dataGridView.CurrentCell.RowIndex;
            currCol = dataGridView.CurrentCell.ColumnIndex;
            value = dataGridView.CurrentCell.Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            petForm = new UI.PetForm(this, cl[id])
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            foreach (Control control in Controls)
                control.Visible = false;

            Controls.Add(petForm);
            petForm.Show();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

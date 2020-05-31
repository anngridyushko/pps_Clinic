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
    public partial class DoctorForm : Form
    {
        private UI.AddDoctorForm addDoctorForm;
        private Panel mainPanel;
        private List<Doctor> docs;
        private User user;

        public DoctorForm(User user, Panel mainPanel)
        {
            InitializeComponent();
            this.user = user;
            this.mainPanel = mainPanel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control control in mainPanel.Controls)
                control.Visible = true;
        }

        private void DoctorForm_Paint(object sender, PaintEventArgs e)
        {
            docs = DBConnector.LoadDoctors();
            dataGridView.DataSource = docs;
            dataGridView.Columns[0].Width = 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = currRow;
            DBConnector.DeleteDoctor(docs[id]);
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addDoctorForm = new UI.AddDoctorForm(this)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            foreach (Control control in Controls)
                control.Visible = false;

            Controls.Add(addDoctorForm);
            addDoctorForm.Show();
        }
        string[] fields = { "Name", "Surname", "DateOfBirth", "Experience", "Specialty", "Email", "PhoneNumber" };

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnector.UpdateDoctor(docs[id], fields[--fieldID], "\'" + value + "\'");
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
    }
}

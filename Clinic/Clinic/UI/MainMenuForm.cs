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
    public partial class MainMenuForm : Form
    {
        private LoginForm logForm;
        private ClientForm clientForm;
        private DoctorForm doctorForm;
        private PrintForm printForm;
        private RegisterForm reg;
       
        private User user;

        public MainMenuForm()
        {
            InitializeComponent();

            ToolStripManager.Renderer =
                new ToolStripProfessionalRenderer(new CustomProfessionalColors());

            menuStrip.Visible = false;

            user = new User();
          //user.isAdmin = false;

            logForm = new LoginForm(user, panel1, panel2)
            {
                //Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            panel1.Controls.Add(logForm);
            logForm.Show();
        }


        class CustomProfessionalColors : ProfessionalColorTable
        {
            private Color color = Color.Honeydew;

            public override Color MenuItemSelectedGradientBegin => color;

            public override Color MenuItemSelectedGradientEnd => color;

            public override Color MenuItemBorder => color;

            public override Color ButtonCheckedGradientBegin => color;

            public override Color ButtonCheckedGradientEnd => color;
        }

        private void ModifyForm()
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
                item.ForeColor = Color.Black;

            foreach (Control control in panel2.Controls)
                control.Visible = false;
        }

        private void mainScreenMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyForm();
            
          
        }

        private void viewDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyForm();
            viewDoctorsToolStripMenuItem.ForeColor = Color.SeaGreen;

            doctorForm = new DoctorForm(user, panel2)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            panel2.Controls.Add(doctorForm);
            doctorForm.Show();
        }

        private void viewClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyForm();
            viewClientsToolStripMenuItem.ForeColor = Color.SeaGreen;

            clientForm = new ClientForm(user, panel2)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            panel2.Controls.Add(clientForm);
            clientForm.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyForm();
            printToolStripMenuItem.ForeColor = Color.SeaGreen;

            printForm = new PrintForm(user, panel2)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            panel2.Controls.Add(printForm);
            printForm.Show();
        }

        private void deleteDataFromArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bookAnAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void doc1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyForm();
            viewDoctorsToolStripMenuItem.ForeColor = Color.SeaGreen;

            reg = new RegisterForm(user, panel2)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            panel2.Controls.Add(reg);
            reg.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

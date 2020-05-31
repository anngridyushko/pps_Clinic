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
    
    public partial class RegisterForm : Form
    {
        private User user;
        private Panel mainPanel;
        private List<Client> cl;
        private List<Doctor> doc;

        public RegisterForm(User user, Panel mainPanel)
        {
            this.user = user;
            InitializeComponent();
            this.mainPanel = mainPanel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control control in mainPanel.Controls)
                control.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clientName.Text == "" || clientSurname.Text == "" || docName.Text == "" ||
                docSurname.Text == "" || sName.Text == "" || sType.Text == "" || sCost.Text == "" || sDate.Text == "")
            {
                MessageBox.Show("Please, don't leave empty fields");
            }
            else
            {
                Client curr = null;
                foreach (Client cli in cl)
                {
                    if (cli.Name == clientName.Text && cli.Surname == clientSurname.Text)
                    {
                        curr = cli;
                        cl.Remove(cli);
                        break;
                    }
                }
                if (curr == null)
                {
                    MessageBox.Show("Don't have a client with this name");
                }
                Doctor d = null;
                foreach (Doctor dd in doc)
                {
                    if (dd.Name == docName.Text && dd.Surname == docSurname.Text)
                    {
                        d = dd;
                        break;
                    }
                }
                if (d == null)
                {
                    MessageBox.Show("Don't have a doctor with this name");
                }


                if(d != null && curr != null)
                {
                    Service s = new Service {
                        serviceName = sName.Text,
                        serviceType = sType.Text,
                        payment = Convert.ToInt32(sCost.Text),
                        serviceDate = Convert.ToDateTime(sDate.Text)
                    };
                    curr.setService(s);
                    cl.Add(curr);
                }
            }
        }

        private void RegisterForm_Paint(object sender, PaintEventArgs e)
        {
            cl = DBConnector.LoadClients();
            doc = DBConnector.LoadDoctors();
        }
    }
}

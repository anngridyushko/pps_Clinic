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
    public partial class PrintForm : Form
    {
        Panel mainPanel;
        User user;
        private List<Client> cl;
        List<Service> s;

        public PrintForm(User user, Panel mainPanel)
        {
            this.user = user;
            this.mainPanel = mainPanel;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control control in mainPanel.Controls)
                control.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (clientName.Text == "" || clientSurname.Text == "")
            {
                MessageBox.Show("Please, don't leave ampty fields");
            }
            else
            {
                Client curr = null;
                foreach (Client cli in cl)
                {
                    if (cli.Name == clientName.Text && cli.Surname == clientSurname.Text)
                    {
                        curr = cli;
                        s = curr.GetServices();
                        break;
                    }
                }
                if (curr == null)
                {
                    MessageBox.Show("Don't have a client with this name");
                }
                else
                {
                    dataGridView.DataSource = s;
                    for (int i = 0; i < 4; i++)
                    {
                        dataGridView.Columns[i].Width = 100;
                    }
                }
            }
        }

        private void PrintForm_Paint(object sender, PaintEventArgs e)
        {
            cl = DBConnector.LoadClients();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (clientName.Text == "" || clientSurname.Text == "")
            {
                MessageBox.Show("Please, don't leave ampty fields");
            }
            else
            {
                Client curr = null;
                foreach (Client cli in cl)
                {
                    if (cli.Name == clientName.Text && cli.Surname == clientSurname.Text)
                    {
                        curr = cli;
                        s = curr.GetServices();
                        break;
                    }
                }
                if (curr == null)
                {
                    MessageBox.Show("Don't have a client with this name");
                }
                else
                {
                    int cost = 0;
                   
                    foreach(Service ser in s)
                    {
                        cost += ser.payment;
                    }
                    label4.Text = "Client payment: " + cost.ToString(); ;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Dashboard
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if ((Application.OpenForms["RPC"] as RPC) != null)
            {
                
            }
            else
            {
                RPC RPCForm = new RPC();
                RPCForm.Show();
            }
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
            Form2 optionForm = new Form2();
            optionForm.Show();
            this.Hide();
        }


        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://discord.com/developers/applications/";
            myProcess.Start();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://www.paypal.com/paypalme/joelmatic";
            myProcess.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://discord.gg/qA985Ar";
            myProcess.Start();
        }
    }
}

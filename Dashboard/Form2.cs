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
using DiscordRpcDemo;
using System.IO;

namespace Dashboard
{
    public partial class Form2 : Form
    {
        public string APPID; 
        public string APPstate;
        public string APPdetails;
        public string APPlargeImageKey;
        public string APPsmallImageKey;
        public string APPpartySize;
        public string APPpartyMax;

        bool Statebool;
        bool detailsbool;
        bool Limgbool;
        bool Simgbool;
        bool partySizebool;
        bool partyMaxbool;

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

        public Form2()
        {
            InitializeComponent();
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void SaveSettings()
        {
            string[] lines = { APPID, APPstate, APPdetails, APPlargeImageKey, APPsmallImageKey, APPpartySize, APPpartyMax, Statebool.ToString(), detailsbool.ToString(), Limgbool.ToString(), Simgbool.ToString(), partySizebool.ToString(), partyMaxbool.ToString() };

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RPCSettings.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
        private void applyRpc()
        {
            RPC obj = (RPC)Application.OpenForms["RPC"];
            obj.Close();
            RPC RPCForm = new RPC();
            RPCForm.Show();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            docPath = Path.Combine(docPath, "RPCSettings.txt");

            if (!File.Exists(docPath))
            {
                string[] lines = { "995288160974143538", "Program Maded By Joelmatic", "https://github.com/TheRealJoelmatic", "joelmatic", "discord", "1", "2", "a", "True", "True", "True", "True", "True" };

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath)))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }

            string Token = GetLine(docPath, 1);
            string State = GetLine(docPath, 2);
            string details = GetLine(docPath, 3);
            string Limg = GetLine(docPath, 4);
            string Simg = GetLine(docPath, 5);
            int partySize = int.Parse(GetLine(docPath, 6));
            int partyMax = int.Parse(GetLine(docPath, 7));

            ID.Text = Token;
            textBox1.Text = State;
            textBox2.Text = details;
            textBox3.Text = Limg;
            textBox4.Text = Simg;
            textBox6.Text = partySize.ToString();
            textBox5.Text = partyMax.ToString();


            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
            Form1 optionForm = new Form1();
            optionForm.Show();
            this.Hide();
        }

        string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
        }

        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCalender_Leave(object sender, EventArgs e)
        {

        }

        private void btnContactUs_Leave(object sender, EventArgs e)
        {
        }

        private void btnsettings_Leave(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ID_TextChanged(object sender, EventArgs e)
        {
            APPID = ID.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            APPdetails = textBox2.Text;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            APPstate = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            APPlargeImageKey = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            APPsmallImageKey = textBox4.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings();
            applyRpc();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            APPpartySize = textBox6.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            APPpartyMax = textBox5.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Statebool = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            detailsbool = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Limgbool = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Simgbool = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            partySizebool = checkBox6.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            partyMaxbool = checkBox7.Checked;
        }
    }
}

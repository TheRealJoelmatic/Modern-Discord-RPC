using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRpcDemo;
using System.IO;

namespace Dashboard
{
    public partial class RPC : Form
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public RPC()
        {
            InitializeComponent();

        }

        private void RPC_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

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

            bool Statebool = bool.Parse(GetLine(docPath, 8));
            bool detailsbool = bool.Parse(GetLine(docPath, 9));
            bool Limgbool = bool.Parse(GetLine(docPath, 10));
            bool Simgbool = bool.Parse(GetLine(docPath, 11));
            bool partySizebool = bool.Parse(GetLine(docPath, 12));
            bool partyMaxbool = bool.Parse(GetLine(docPath, 13));

            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize(Token, ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize(Token, ref this.handlers, true, null);
            if(Statebool)
                this.presence.details = State;
            if(detailsbool)
                this.presence.state = details;
            if (Limgbool)
                this.presence.largeImageKey = Limg;
            if (Simgbool)
                this.presence.smallImageKey = Simg;
            if (partySizebool)
                this.presence.partySize = partySize;
            if (partyMaxbool)
                this.presence.partyMax = partyMax;
            DiscordRpc.UpdatePresence(ref this.presence);
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
        public void CloseRpc()
        {
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace consoleLinux
{
    public partial class Console : Form
    {

        SshClient client=new SshClient("192.168.1.76", 22, "humito", "22hum001");
        public Console()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            SshCommand retour=client.RunCommand(input.Text);
            output.Text = retour.Result; ;
        }

        private void connect_Click(object sender, EventArgs e)
        {



            client.Connect();
            connect.Enabled = false;
            Disconnect.Enabled = true;
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            connect.Enabled = true;
            Disconnect.Enabled = false;
        }

        private void su_Click(object sender, EventArgs e)
        {
            client.RunCommand("su");
            System.Threading.Thread.Sleep(5000);
            client.RunCommand("22hum001");
            output.Text = "connecté en tant que superutilisateur";
            
        }

    }
}

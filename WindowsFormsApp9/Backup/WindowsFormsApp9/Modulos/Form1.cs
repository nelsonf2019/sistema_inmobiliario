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

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Este metodo pertenece a la libreria de SystemRuntime para mover el formulario desde la parte superior como
        //todas la ventanas de windows
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint ="SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,int wparam, int lparam);
        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 80;
            }
            else
                MenuVertical.Width = 250;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        private void PctMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PctRestore.Visible = true;
            PctMaximize.Visible = false;
        }

        private void PctRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            PctRestore.Visible = false;
            PctMaximize.Visible = true;
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            //#EBEBEB colores de los iconos
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void AbrirInPanel(Object Formhjo)
        {
            if (this.pnlContainer.Controls.Count > 0)
                this.pnlContainer.Controls.RemoveAt(0);
            Form fh = Formhjo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(fh);
            this.pnlContainer.Tag = fh;
            fh.Show();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            AbrirInPanel(new FrmClients());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirInPanel(new FrmAgenda());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirInPanel(new FrmPropiedades());
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

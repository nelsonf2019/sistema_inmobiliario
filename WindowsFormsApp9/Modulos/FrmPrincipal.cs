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
using WindowsFormsApp9.Modulos;

namespace WindowsFormsApp9
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {

            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

        }



        private void customize()
        {
            pnlSubMenu.Visible = false;
            pnlSubMenu2.Visible = false;

        }
        private void hidenSubmenu()
        {
            if (pnlSubMenu.Visible == true)
                pnlSubMenu.Visible = false;
            if (pnlSubMenu2.Visible == true)
                pnlSubMenu2.Visible = false;
        }

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidenSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region Funcionalidades del formulario
        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.pnlContainer.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        //Este metodo pertenece a la libreria de SystemRuntime para mover el formulario desde la parte superior como
        //todas la ventanas de windows
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Objetos botones etc.
        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 262)
            {
                btnAlquiler.Text = "";
                btnPropiedades.Text = "";
                btnUsuario.Text = "";
                MenuVertical.Width = 50;
            }
            else
               if (MenuVertical.Width == 50)
            {
                btnAlquiler.Text = "Alquiler";
                btnPropiedades.Text = "Propiedades";
                btnUsuario.Text = "Usuario";
                MenuVertical.Width = 262;
            }
                
               
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        //Cpaturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;
        private void PctMaximize_Click(object sender, EventArgs e)
        {
            //Obtenemos las coordenadas para dar con la posicion del r
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            PctRestore.Visible = true;
            PctMaximize.Visible = false;
        }

        private void PctRestore_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
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
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
            AbrirFromulario<FrmClientes>();
            toolTip1.SetToolTip(btnClientes, "Clientes inquilinos");
            btnClientes.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirInPanel(new FrmCaja());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPropiedades1, "Propiedades");
            AbrirFromulario<FrmPropiedades>();
            btnPropiedades1.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customize();
            hidenSubmenu();

        }

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            //AbrirFromulario<FrmAlquileres>();
            //btnAlquileres.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // toolTip1.SetToolTip(btnCaja, "Caja");
            AbrirFromulario<FrmCaja>();
            //btnCaja.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnContratos, "Contratos");
            AbrirFromulario<FrmContratos>();
            btnContratos.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnRegistrosAlquileres_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void btnRegistrosAlquileres_Click_1(object sender, EventArgs e)
        {
            AbrirFromulario<FrmRegistroAlquileres>();
            btnRegistrosAlquileres.BackColor = Color.FromArgb(12, 61, 92);
        }


        private void btnAlquiler_Click(object sender, EventArgs e)

        {
            btnPropiedades.BackColor = Color.FromArgb(0, 122, 204);
            btnAlquiler.BackColor = Color.FromArgb(0, 146, 244);
            showSubmenu(pnlSubMenu);
        }

        private void btnContratos_Click_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnContratos, "Contratos");
            AbrirFromulario<FrmContratos>();
            btnContratos.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            btnPropiedades.BackColor = Color.FromArgb(0, 146, 244);
            btnAlquiler.BackColor = Color.FromArgb(0, 122, 204);
            showSubmenu(pnlSubMenu2);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnContratos, "Clientes");
            AbrirFromulario<FrmClientes>();
            btnClientes.BackColor = Color.FromArgb(12, 61, 92);
          
        }

        private void btnPropiedades1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPropiedades1, "Propiedades para alquilar o vender");
            AbrirFromulario<FrmPropiedades>();
            btnPropiedades1.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        //metodo para abrir un formulario dentro de un panel
        private void AbrirFromulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = pnlContainer.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleeción el formulario
            //Si el formulario instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                pnlContainer.Controls.Add(formulario);
                pnlContainer.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForm); 
            } else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForm( object sender,FormClosedEventArgs e)
        {
            if (Application.OpenForms["FrmClientes"] == null)
                btnClientes.BackColor = Color.FromArgb(0, 139, 136);
            if (Application.OpenForms["FrmContratos"] == null)
                btnContratos.BackColor = Color.FromArgb(0, 139, 136);
            if (Application.OpenForms["FrmRegistroAlquileres"] == null)
                btnRegistrosAlquileres.BackColor = Color.FromArgb(0, 139, 139);
            //if (Application.OpenForms["FrmAlquileres"] == null)
            //    btnContratos.BackColor = Color.FromArgb(0, 139, 136);
            //if (Application.OpenForms["FrmClients"] == null)
            //   btnClientes.BackColor = Color.FromArgb(0, 139, 136);
            //if (Application.OpenForms["FrmCaja"] == null)
            //   // btnCaja.BackColor = Color.FromArgb(0, 139, 139);
            //if (Application.OpenForms["FrmPropiedades"] == null)
            //    btnPropiedades.BackColor = Color.FromArgb(0, 139, 139);
        }

    }
    #endregion
    
}

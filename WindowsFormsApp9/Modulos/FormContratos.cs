using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class FrmContratos : Form
    {
        public FrmContratos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbAlquilerDH_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnGarante2_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnGarante3_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnGarante4_Click(object sender, EventArgs e)
        {
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }
        #region Hablitar_y_Deshabilitar_textYCombos
            private void habilitar()
        {
            lblMensaje.Visible = false;
            btnSave.Visible = false;
            cxbPropiedad.Enabled = true;
            cxbPropietario.Enabled = true;
            cxbNumContrato.Enabled = true;
            cxbInquilino.Enabled = true;
            dtpFechaInicio.Enabled = true;
            dtpFechaFin.Enabled = true;
            txtDiasVto.Enabled = true;
            txtMesesDpto.Enabled = true;
            cbxMeses.Enabled = true;
            txtMontoInicial.Enabled = true;
            txtComision.Enabled = true;
            txtImporteDeDpto.Enabled = true;
            txtPrecioCuota.Enabled = true;
            cxbGarante1.Enabled = true;
            cbxGarante2.Enabled = true;
            cxbGarante3.Enabled = true;
            cxbGarante4.Enabled = true;
            txtIngresoG1.Enabled = true;
            c.Enabled = true;
            txtIngresoG3.Enabled = true;
            txtIngresoG4.Enabled = true;
            txtDiasVto.Text = "";
            txtMesesDpto.Text = "";
            txtMontoInicial.Enabled = true;
            txtComision.Text = "";
            txtImporteDeDpto.Text = "";
            txtPrecioCuota.Text = "";
            txtIngresoG1.Text = "";
            txtIngresoG1.Text = "";
            txtIngresoG3.Text = "";
            txtIngresoG4.Text = "";

        }
        private void Deshabilitar()
        {
            lblMensaje.Visible = false;
            btnSave.Visible = true;
            cxbPropiedad.Enabled = false;
            cxbPropietario.Enabled = false;
            cxbNumContrato.Enabled = false;
            cxbInquilino.Enabled = false;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            txtDiasVto.Enabled = false;
            txtMesesDpto.Enabled = false;
            cbxMeses.Enabled = false;
            txtMontoInicial.Enabled = false;
            txtComision.Enabled = false;
            txtImporteDeDpto.Enabled = false;
            txtPrecioCuota.Enabled = false;
            cxbGarante1.Enabled = false;
            cbxGarante2.Enabled = false;
            cxbGarante3.Enabled = false;
            cxbGarante4.Enabled = false;
            txtIngresoG1.Enabled = false;
            c.Enabled = false;
            txtIngresoG3.Enabled = false;
            txtIngresoG4.Enabled = false;
            txtMontoInicial.Enabled = false;
            txtDiasVto.Text = "";
            txtMesesDpto.Text = "";
            txtComision.Text = "";
            txtImporteDeDpto.Text = "";
            txtPrecioCuota.Text = "";
            txtIngresoG1.Text = "";
            txtIngresoG1.Text = "";
            txtIngresoG3.Text = "";
            txtIngresoG4.Text = "";
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            habilitar();
        }

        private void FrmContratos_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            lblMensaje.Visible = true;
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar();
        }
    }
}

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
    public partial class FrmPropiedades : Form
    {
        public FrmPropiedades()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        #region PropiedadesObjetos
            void DeshabilitarBotones()
        {
            btnNuevoImpuesto.Visible = true;
            cbxListado.Enabled = false;
            txtOtrosDatos.Enabled = false;
            dtpFechaVto.Enabled = false;
           
            dtpFechaPgado.Enabled = false;
            txtImporteServicio.Enabled = false;

        }

        void HabilitarBotones()
        {

            btnNuevoImpuesto.Visible = false;
            cbxServicios.Enabled = true;
            dtpFechaVto.Enabled = true;
            txtOtrosDatos.Enabled = true;
            
            dtpFechaPgado.Enabled = true;
            txtImporteServicio.Enabled = true;
        }

        #endregion
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;
            Modulos.Universal.titulo = "Buscar Propietario";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar Ciudad";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar Provincia";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar País";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar Servicios/impuestos";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
             
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
             
        }

        private void btnNuevoImpuesto_Click(object sender, EventArgs e)
        {
            HabilitarBotones();

        }

        private void FrmPropiedades_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            btnNew.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            btnNuevo.Visible = false;
            txtValor.Enabled = true;
            txtValor.Text = "";
            txtZonaBarrio.Enabled = true;
            txtZonaBarrio.Text = "";
            txtCalle.Enabled = true;
            txtCalle.Text = "";
            txtAltura.Enabled = true;
            txtAltura.Text = "";
            txtLote.Enabled = true;
            txtLote.Text = "";
            txtPiso.Enabled = true;
            txtPiso.Text = "";
            cbxPropietario.Text = "";
            txtCiudad.Enabled = true;
            txtCiudad.Text = "";
            txtCp.Enabled = true;
            txtCp.Text = "";
            cbxPropietario.Enabled = true;
            cbxPropietario.Text = "";
            cbxLocalidad.Enabled = true;
            cbxLocalidad.Text = "";
            cbProvincia.Enabled = true;
            cbProvincia.Text = "";
            cbxPais.Enabled = true;
            cbxPais.Text = "";
            txtAmbiente.Enabled=true;
            txtAmbiente.Text = "";
            txtDormitorio.Enabled = true;
            txtDormitorio.Text = "";
            txtPisos.Enabled = true;
            txtPisos.Text = "";
            txtBaños.Enabled = true;
            txtGarage.Enabled = true;
            txtGarage.Text = "";
            txtSuperficie.Enabled = true;
            txtSuperficie.Text = "";
            txtOtros.Enabled = true;
            txtOtros.Text = "";
            rdbDolares.Enabled = true;
            rdbPesos.Enabled = true;
            habiliatrChek();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = true;
            txtValor.Enabled = false;
            txtValor.Text = "";
            txtZonaBarrio.Enabled = false;
            txtZonaBarrio.Text = "";
            txtCalle.Enabled = false;
            txtCalle.Text = "";
            txtAltura.Enabled = false;
            txtAltura.Text = "";
            txtLote.Enabled = false;
            txtLote.Text = "";
            txtPiso.Enabled = false;
            txtPiso.Text = "";
            cbxPropietario.Text = "";
            txtCiudad.Enabled = false;
            txtCiudad.Text = "";
            txtCp.Enabled = false;
            txtCp.Text = "";
            cbxPropietario.Enabled = false;
            cbxLocalidad.Enabled = false;
            cbxLocalidad.Text = "";
            cbProvincia.Enabled = false;
            cbProvincia.Text = "";
            cbxPais.Enabled = false;
            cbxPais.Text = "";
            txtAmbiente.Enabled = false;
            txtAmbiente.Text = "";
            txtDormitorio.Enabled = false;
            txtDormitorio.Text = "";
            txtPisos.Enabled = false;
            txtPisos.Text = "";
            txtBaños.Enabled = false;
            txtGarage.Enabled = false;
            txtGarage.Text = "";
            txtSuperficie.Enabled = false;
            txtSuperficie.Text = "";
            txtOtros.Enabled = false;
            txtOtros.Text = "";
            chkAlquilerPorDia.Enabled = true;
            chkVenta.Enabled = false;
            DehabilitarChek();

        }
        private void DehabilitarChek()
        {
            chkAlquiler.Enabled = false;
            chkAlquilerPorDia.Enabled = false;
            chkVenta.Enabled = false;
            chkAgua.Enabled = false;
            chkElectricidad.Enabled = false;
            chkGasEnvasado.Enabled = false;
            chkGasNatural.Enabled = false;
            chkInternetCabel.Enabled = false;
            chkCloacas.Enabled = false;
            chkTelefono.Enabled = false;
            if (chkAlquiler.Checked == true)
            {
                chkAlquiler.Checked = false;
            }
            if (chkAlquilerPorDia.Checked == true)
            {

                chkAlquilerPorDia.Checked = false;
            }
            if (chkVenta.Checked == true)
            {
                chkVenta.Checked = false;
            }
            if (chkAgua.Checked == true)
            {
                chkAgua.Checked = false;
            }
            if (chkElectricidad.Checked == true)
            {
                chkElectricidad.Checked = false;
            }
            if (chkGasEnvasado.Checked == true)
            {
                chkGasEnvasado.Checked = false;
            }
            if (chkGasNatural.Checked == true)
            {
                chkGasNatural.Checked = false;
            }
            if (chkInternetCabel.Checked == true)
            {
                chkInternetCabel.Checked = false;
            }
            if (chkCloacas.Enabled == true)
            {
                chkCloacas.Checked = false;
            }
            if (chkTelefono.Checked == true)
            {
                chkTelefono.Checked = false;
            }
        }
         private void habiliatrChek()
        {
            chkAlquiler.Enabled = true;
            chkAlquilerPorDia.Enabled = true;
            chkVenta.Enabled = true;
            chkAgua.Enabled = true;
            chkElectricidad.Enabled = true;
            chkGasEnvasado.Enabled = true;
            chkGasNatural.Enabled = true;
            chkInternetCabel.Enabled = true;
            chkCloacas.Enabled = true;
            chkTelefono.Enabled = true;
            if (chkAlquiler.Checked == true)
            {
                chkAlquiler.Checked = false;
            }
            if (chkAlquilerPorDia.Checked == true)
            {

                chkAlquilerPorDia.Checked = false;
            }
            if (chkVenta.Checked == true)
            {
                chkVenta.Checked = false;
            }
            if (chkAgua.Checked == true)
            {
                chkAgua.Checked = false;
            }
            if (chkElectricidad.Checked == true)
            {
                chkElectricidad.Checked = false;
            }
            if (chkGasEnvasado.Checked == true)
            {
                chkGasEnvasado.Checked = false;
            }
            if (chkGasNatural.Checked == true)
            {
                chkGasNatural.Checked = false;
            }
            if (chkInternetCabel.Checked == true)
            {
                chkInternetCabel.Checked = false;
            }
            if (chkCloacas.Enabled == true)
            {
                chkCloacas.Checked = false;
            }
            if (chkTelefono.Checked == true)
            {
                chkTelefono.Checked = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = false;
            txtValor.Enabled = true;
            txtZonaBarrio.Enabled = true;
            txtCalle.Enabled = true;
            txtAltura.Enabled = true;
            txtLote.Enabled = true;
            txtPiso.Enabled = true;
            txtCiudad.Enabled = true;
            txtCp.Enabled = true;
            cbxPropietario.Enabled = true;
            cbxLocalidad.Enabled = true;
            cbProvincia.Enabled = true;
            cbxPais.Enabled = true;
            txtAmbiente.Enabled = true;
            txtDormitorio.Enabled = true;
            txtPisos.Enabled = true;
            txtBaños.Enabled = true;
            txtGarage.Enabled = true; 
            txtSuperficie.Enabled = true;       
            txtOtros.Enabled = true;
            chkAlquiler.Enabled = true;
            chkAlquilerPorDia.Enabled = true;
            chkVenta.Enabled = true;
            rdbDolares.Enabled = true;
            rdbPesos.Enabled = true;
            chkAgua.Enabled = true;
            chkElectricidad.Enabled = true;
            chkGasEnvasado.Enabled = true;
            chkGasNatural.Enabled = true;
            chkInternetCabel.Enabled = true;
            chkCloacas.Enabled = true;
            chkTelefono.Enabled = true;
        }

        private void btnAgregarDiversion_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar Diversion";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnEditarImpuesto_Click(object sender, EventArgs e)
        {
            HabilitarBotones();
        }

        private void btnCancelarImpuesto_Click(object sender, EventArgs e)
        {
            DeshabilitarBotones();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}

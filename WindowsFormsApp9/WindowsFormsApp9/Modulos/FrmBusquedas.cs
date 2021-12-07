using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9.Modulos
{
    public partial class FrmBusqueda : Form
    {
        public FrmBusqueda()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = false;

            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {   
            //si es País en este caso va sin combo, ya que se selecciona desde la grilla y se modifica desde ahí
            txtPais.Enabled = false;
            txtProvincia.Visible = false;
            txtProvincia.Enabled = false;
            txtLocalidad.Visible = false;
            label2.Visible = false;
            lblAgregarPais.Visible = false;
            //Manejamos la variable visible, justamente para mostrar
            //en este caso la sección de hacer un CRUD con Localidad
            //Provincia y País, cuano la variable visible es true,
            //Eso quiere decir que se puede hacer alta, baja, midificar y eliminar
          if (  Modulos.Universal.visible == true)
            {
                if (Modulos.Universal.titulo == "Agregar Ciudad")
                {
                    grpComboLugar.Visible = true;
                    lblTitulo.Text = Modulos.Universal.titulo;
                    txtLocalidad.Visible=true;
                    txtLocalidad.Enabled = false;
                    txtCP.Enabled = false;
                }
                if (Modulos.Universal.titulo == "Agregar Provincia")
                {
                    lblDato.Visible = true;
                    txtCP.Visible = false;
                    label2.Visible = true;
                    grpComboLugar.Visible = true;
                    cmbPais.Visible = true;
                    lblDato.Text = "Provincia";
                    txtProvincia.Visible = true;
                    lblTitulo.Text = Modulos.Universal.titulo;
                    Modulos.Universal.visible = true;
                    cmbProvincia.Visible = false;
                    lblCiudad.Visible = false;
                    
                }
                if (Modulos.Universal.titulo == "Agregar País")
                {
                    lblTitulo.Text="Agregar País";
                    lblAgregarPais.Visible = true;
                    lblDato.Text = "País";
                    dtgDatos.Top = 122;
                    grpBusqueda.Visible = false;
                    cmbPais.Visible = false;
                    grpComboLugar.Visible = true;
                    txtPais.Visible = true;
                    txtLocalidad.Visible = false;
                    cmbProvincia.Visible = false;
                    lblCiudad.Visible = false;
                    txtCP.Visible = false;
                    lblDato.Visible = false;


                }
                if (Modulos.Universal.titulo == "Agregar Servicios/impuestos")
                {
                    lblAgregarPais.Visible = false;
                    txtCP.Visible = false;
                    label2.Visible = false;
                    grpComboLugar.Visible = true;
                    cmbPais.Visible = false;
                    lblDato.Text = "Servicios/impuestos";
                    txtProvincia.Visible = true;
                    lblTitulo.Text = Modulos.Universal.titulo;
                    Modulos.Universal.visible = true;
                    cmbProvincia.Visible = false;
                    lblCiudad.Visible = false;
                }
                if (Modulos.Universal.titulo == "Agregar Diversion")
                {
                    lblTitulo.Text = "Agregar Servicios de Diversion";
                    lblAgregarPais.Visible = true;
                    lblDato.Text = "Servicios Diervsión";
                    dtgDatos.Top = 122;
                    grpBusqueda.Visible = false;
                    cmbPais.Visible = false;
                    grpComboLugar.Visible = true;
                    txtPais.Visible = true;
                    txtLocalidad.Visible = false;
                    cmbProvincia.Visible = false;
                    lblCiudad.Visible = false;
                    txtCP.Visible = false;
                    lblDato.Visible = false;
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = false;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            txtPais.Enabled = true;
            txtPais.Text = "";
            txtProvincia.Enabled = true;
            txtProvincia.Enabled = true;
            txtProvincia.Text = "";
            txtLocalidad.Focus();
            txtProvincia.Focus();
            txtPais.Focus();
          
        
        
  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = true;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            txtPais.Text = "";
            txtPais.Enabled = false;
            txtProvincia.Enabled = false;
            txtProvincia.Text = "";
            txtLocalidad.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtProvincia.Enabled = true;
            txtLocalidad.Enabled = true;
            btnNuevo.Visible = false;
            txtCP.Enabled = true;
            txtLocalidad.Text = "";
            txtPais.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = true;
            txtProvincia.Enabled = false;
            txtLocalidad.Enabled = false;
            txtPais.Enabled = false;
            txtLocalidad.Text = "";
            txtPais.Text = "";
            txtProvincia.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

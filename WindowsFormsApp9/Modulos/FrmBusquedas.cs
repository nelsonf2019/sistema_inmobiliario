using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using WindowsFormsApp9.Modulos;//Debemos importar modulos
using System.Globalization;//Para poder convertir fecha string a DataTime
using System.Data.SqlTypes;


namespace WindowsFormsApp9.Modulos
{
    public partial class FrmBusqueda : Form
    {
        public FrmBusqueda()
        {
            InitializeComponent();
            
        }

        #region carga_combos
        private void CargaComboProvincia()
        {

            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("mostrar_provincia", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                DataRow fila = dt.NewRow();
                fila["Pro_Provincia"] = "Seleccione una Provincia";
                dt.Rows.InsertAt(fila, 0);

                cbxProvincia.ValueMember = "Pro_IProvincia";
                cbxProvincia.DisplayMember = "Pro_Provincia";
                cbxProvincia.DataSource = dt;


            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion
       
        private void CargaComboPais()
        {

            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("mostrar_pais", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                DataRow fila = dt.NewRow();
                fila["p_Pais"] = "Seleccione un País";
                dt.Rows.InsertAt(fila, 0);

                cmbPais.ValueMember = "Id_Pais";
                cmbPais.DisplayMember = "p_Pais";
                cmbPais.DataSource = dt;


            }
            catch (Exception)
            {

                throw;
            }
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
                switch (Modulos.Universal.titulo)
                {
                    case "Agregar Ciudad":
                        grpComboLugar.Visible = true;
                        lblTitulo.Text = Modulos.Universal.titulo;
                        txtLocalidad.Visible = true;
                        txtLocalidad.Enabled = false;
                        txtCP.Enabled = false;
                        cbxProvincia.Enabled = false;
                        CargaComboProvincia();
                        CargaComboPais();
                        // code block
                        break;
                    case "Agregar Provincia":
                        // code block
                        lblDato.Visible = true;
                        txtCP.Visible = false;
                        label2.Visible = true;
                        grpComboLugar.Visible = true;
                        cbxProvincia.Visible = true;
                        lblDato.Text = "Provincia";
                        txtProvincia.Visible = true;
                        lblTitulo.Text = Modulos.Universal.titulo;
                        Modulos.Universal.visible = true;
                        cbxProvincia.Visible = false;
                        lblCiudad.Visible = false;
                        CargaComboPais();                      
                        break;
                    case "Agregar País":
                        lblTitulo.Text = "Agregar País";
                        lblAgregarPais.Visible = true;
                        lblDato.Text = "País";
                        dtgDatos.Top = 122;
                        grpBusqueda.Visible = false;
                        cmbPais.Visible = false;
                        grpComboLugar.Visible = true;
                        txtPais.Visible = true;
                        txtLocalidad.Visible = false;
                        cbxProvincia.Visible = false;
                        lblCiudad.Visible = false;
                        txtCP.Visible = false;
                        lblDato.Visible = false;
                        
                        break;
                    case "Agregar Servicios/impuestos":
                        lblAgregarPais.Visible = false;
                        txtCP.Visible = false;
                        label2.Visible = false;
                        grpComboLugar.Visible = true;
                        cmbPais.Visible = false;
                        lblDato.Text = "Servicios/impuestos";
                        txtProvincia.Visible = true;
                        lblTitulo.Text = Modulos.Universal.titulo;
                        Modulos.Universal.visible = true;
                        cbxProvincia.Visible = false;
                        lblCiudad.Visible = false;
                        break;
                    case "Agregar Diversion":
                        lblTitulo.Text = "Agregar Servicios de Diversion";
                        lblAgregarPais.Visible = true;
                        lblDato.Text = "Servicios Diervsión";
                        dtgDatos.Top = 122;
                        cbxProvincia.Enabled = false;
                        grpBusqueda.Visible = false;
                        cmbPais.Visible = false;
                        grpComboLugar.Visible = true;
                        txtPais.Visible = true;
                        txtLocalidad.Visible = false;
                        cbxProvincia.Visible = false;
                        lblCiudad.Visible = false;
                        txtCP.Visible = false;
                        lblDato.Visible = false;
                        break;
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

            switch (Modulos.Universal.titulo)
            {
                case "Agregar Ciudad":

                    //Validate date on save

                    if(cbxProvincia.Text == "Seleccione una Provincia" | 
                        cmbPais.Text == "Seleccione un País" | txtLocalidad.Text.Length == 0)
                    {
                        //Search existing city

                    }
                    
                    // code block
                    break;
                case "Agregar Provincia":
                    // code block
                    
                    
                    break;
                case "Agregar País":
                    // code block

                    break;
                case "Agregar Servicios/impuestos":
                    // code block

                    break;

                case "Agregar Diversion":
                    // code block
                    
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void cbxProvincia_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void cmbPais_MouseClick(object sender, MouseEventArgs e)
        {
            cbxProvincia.Enabled = true;
        }
    }
}

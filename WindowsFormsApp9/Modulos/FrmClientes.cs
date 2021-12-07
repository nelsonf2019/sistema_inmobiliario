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


namespace WindowsFormsApp9
{
    public partial class FrmClientes : Form
    {
        //--------------------variables de validación datos clientes----------
       
        string NumCalle;
        string Calle;
        string Profesion;
        string Apell_Nombre;
        int CodPostal;
        string Cuit;
        string NumPiso;
        string NumTelefono;
        string Observacion;
        string Email;
        string Localidad;
        int ValidarInquilino;//Validar datos si es inquilino
        int ValidarPropietario; //Validar si es Propietario
        int Id_Ciudad;
        int Id_Provincia;
        int Id_Pais;
        int IdCliente;
        byte Guardar_Nuevo;
        //--------------------------------FIN------------------------------------
        

        bool ClienteNuevo; //Para saber si es nuevo o para editar el cliente
        bool ClienteModificar; //Para midificar el cliente UPDATE
        public FrmClientes()
        {
            InitializeComponent();
            cargacomboLocalidad();
            CargaComboProvincia();
            CargaComboPais();
            CargaDatosEnGrilla();
            ClienteNuevo = false;
            ClienteModificar = false;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void bttnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar Ciudad";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();

        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            Guardar_Nuevo = 0;
            ClienteModificar = false;
            dtGridClientes.Enabled = false;
            ClienteNuevo = true;
            HabilitaBotones();
            LimpiaTextBox();
        }
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnPais_Click_1(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar País";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnProvincia_Click(object sender, EventArgs e)
        {
            Modulos.Universal.visible = true;
            Modulos.Universal.titulo = "Agregar Provincia";
            Form Formulario = new Modulos.FrmBusqueda();
            Formulario.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClienteModificar = false;
            Guardar_Nuevo = 0;
            dtGridClientes.Enabled = true;
            IdCliente = 0;
            DeshabilitaBotones();
            LimpiaTextBox();
            Borrar_validacion();
            cargacomboLocalidad();
            CargaComboProvincia();
            CargaComboPais();
           
           
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            ClienteNuevo = false;
            //En esta variable verificamos si es guardar o nuevo 0 si para guardar
            //1 si es para modificar
            Guardar_Nuevo = 1;
            dtGridClientes.Enabled = true;
           if (ClienteModificar == true)
            {
                HabilitaBotones();
                txtApellidoNombre.Focus();

            }
            else{

                MessageBox.Show("Seleccione una fila para poder editar por favor!");

            }
        }
        #region CargaCombos y DataGrid
        //Cargamos combos y grilla--
        private void CargaDatosEnGrilla()
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_cliente", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                dtGridClientes.DataSource = dt;               
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
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

                cbxPais.ValueMember = "Id_Pais";
                cbxPais.DisplayMember = "p_Pais";
                cbxPais.DataSource = dt;


            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargacomboLocalidad()
        {
            try
            {
                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("mostrar_localidad",con);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                DataRow fila = dt.NewRow();
                fila["Loc_Localidad"] = "Seleccione una Localidad";
                dt.Rows.InsertAt(fila, 0);

                cbxLoclidad.ValueMember = "Loc_IdLocalidad";
                cbxLoclidad.DisplayMember = "Loc_Localidad";
                cbxLoclidad.DataSource = dt;
                    
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void mostrar_pais()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_pais_id", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", Id_Pais);

                da.Fill(dt);
                cbxPais.ValueMember = "Id_Pais";
                cbxPais.DisplayMember = "p_Pais";
                cbxPais.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    
        private void Mostrar_provincia()
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_provincia_id", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", Id_Provincia);
                
                da.Fill(dt);
                cbxProvincia.ValueMember = "Pro_IProvincia";
                cbxProvincia.DisplayMember = "Pro_Provincia";
                cbxProvincia.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void mostrar_ciudad ()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_ciudad_id", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", Id_Ciudad);

                da.Fill(dt);
                cbxLoclidad.ValueMember = "Loc_IdLocalidad";
                cbxLoclidad.DisplayMember = "Loc_Localidad";
                cbxLoclidad.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        #endregion
        private void Borrar_validacion()
            //Borramos las validamos una vez completos de text.box y combos
        {
            epValidarCampos.SetError(txtApellidoNombre, "");
            epValidarCampos.SetError(txtDni, "");
            epValidarCampos.SetError(txtCuit, "");
            epValidarCampos.SetError(txtCalle, "");
            epValidarCampos.SetError(txtNum, "");
            epValidarCampos.SetError(txtPiso, "");
            epValidarCampos.SetError(txtDtoLocalidad, "");
            epValidarCampos.SetError(txtCP, "");
            epValidarCampos.SetError(cbxLoclidad, "");
            epValidarCampos.SetError(cbxProvincia, "");
            epValidarCampos.SetError(cbxPais, "");
            epValidarCampos.SetError(txtTelefono, "");
            epValidarCampos.SetError(txtEmail, "");
            epValidarCampos.SetError(txtActvidadProfesion, "");
            epValidarCampos.SetError(txtObs, "");
        }
        private void ValidarDatosUpDate ()
        {
            if (txtApellidoNombre.Text.Length == 0 |
                txtDni.Text.Length == 0 |
                cbxLoclidad.Text == "Seleccione una Localidad" |
                cbxProvincia.Text == "Seleccione una Provincia" |
                cbxPais.Text == "Seleccione un País")
            {
                //Una vez verifiacdo de que en algún textbox o combobox vacío y/o falta 
                //selecionar una localidad, provincia o país, etc.se procede a 
                // resaltar ese error con un signo de interrogación de color rojo
                if (txtApellidoNombre.Text.Length == 0)
                {
                    epValidarCampos.SetError(txtApellidoNombre, "Ingrese Apell. y Nombre por favor!");
                }
                if (txtDni.Text.Length == 0)
                {
                    epValidarCampos.SetError(txtDni, "Ingrese Num de DNI por favor!");
                }
                if (cbxLoclidad.Text == "Seleccione una Localidad")
                {
                    epValidarCampos.SetError(cbxLoclidad, "Seleccione un Localidad por favor!");
                }
                if (cbxProvincia.Text == "Seleccione una Provincia")
                {
                    epValidarCampos.SetError(cbxProvincia, "Seleccione un Provincia por favor!");
                }
                if (cbxPais.Text == "Seleccione un País")
                {
                    epValidarCampos.SetError(cbxPais, "Seleccione un País por favor!");
                }

            }
            else
            {

                if (chkInquilino.Checked == true)
                {
                    ValidarInquilino = 1;
                }
                else
                {
                    ValidarInquilino = 0;
                }

                if (chkPropietario.Checked == true)
                {
                    ValidarPropietario = 1;
                }
                else
                {
                    ValidarPropietario = 0;
                }
                if (txtDtoLocalidad.Text.Length == 0)
                {
                    Localidad = "Sin informar";
                }
                if (txtCuit.Text.Length == 0)
                {
                    Cuit = "Sin Datos";
                }
                if (txtCalle.Text.Length == 0)
                {
                    Calle = "Sin informar";
                }
                if (txtNum.Text.Length == 0)
                {
                    NumCalle = "0";

                }
                if (txtPiso.Text.Length == 0)
                {
                    NumPiso = "0";

                }
                if (txtCodigo.Text.Length == 0)
                {
                    CodPostal = 0;
                }
                if (txtTelefono.Text.Length == 0)
                {
                    NumTelefono = "Sin datos";
                }

                if (txtEmail.Text.Length == 0)
                {
                    Email = "datos@email.com";
                }
                else
                {

                    if (EmailIsValid(txtEmail.Text))
                    {

                       
                        ClienteModificar = true;
                    }
                    else
                    {

                        
                        ClienteModificar = false;
                        //ValidarUsuario = true;
                        MessageBox.Show("Debe ingresar un formato de tipo Email");

                    }
                }
                if (txtActvidadProfesion.Text.Length == 0)
                {
                    Profesion = "Sin datos";
                }
                if (txtObs.Text.Length == 0)
                {
                    Observacion = "Sin datos";
                    //epValidarCampos.SetError(txtObs, "Un campo se encuentra vacio, por favor complete!");
                }
            }

        }
        private void ValidarDatosClientes()
            //Validamos datos desde del comienzo de los text vacios y los combos que
            //que no fueron seleccionados
            {
            if (txtApellidoNombre.Text.Length == 0 | 
                txtDni.Text.Length == 0 |
                cbxLoclidad.Text == "Seleccione una Localidad" |
                cbxProvincia.Text == "Seleccione una Provincia" | 
                cbxPais.Text== "Seleccione un País")
            {
                //Una vez verifiacdo de que en algún textbox o combobox vacío y/o falta 
                //selecionar una localidad, provincia o país, etc.se procede a 
                // resaltar ese error con un signo de interrogación de color rojo
                if(txtApellidoNombre.Text.Length == 0)
                {
                   epValidarCampos.SetError(txtApellidoNombre, "Ingrese Apell. y Nombre por favor!");
                }
                if (txtDni.Text.Length == 0)
                {
                    epValidarCampos.SetError(txtDni, "Ingrese Num de DNI por favor!");
                }
                if (cbxLoclidad.Text == "Seleccione una Localidad")
                {
                    epValidarCampos.SetError(cbxLoclidad, "Seleccione un Localidad por favor!");
                }
                if (cbxProvincia.Text == "Seleccione una Provincia")
                {
                    epValidarCampos.SetError(cbxProvincia, "Seleccione un Provincia por favor!");
                }
                if (cbxPais.Text == "Seleccione un País")
                {
                    epValidarCampos.SetError(cbxPais, "Seleccione un País por favor!");
                }
                ClienteNuevo = false;
            }
            else{

                ClienteNuevo = true;

                if (chkInquilino.Checked == true)
                {
                    ValidarInquilino = 1;
                }
                else
                {
                    ValidarInquilino = 0;
                }

                if (chkPropietario.Checked == true)
                {
                    ValidarPropietario = 1;
                }
                else
                {
                    ValidarPropietario = 0;
                }
                if (txtDtoLocalidad.Text.Length == 0)
                {
                    Localidad = "Sin informar";
                }
                if (txtCuit.Text.Length == 0)
                {
                    Cuit = "Sin Datos";
                }
                if (txtCalle.Text.Length == 0)
                {
                    Calle = "Sin informar";
                }
                if (txtNum.Text.Length == 0)
                {
                    NumCalle = "0";

                }
                if (txtPiso.Text.Length == 0)
                {
                    NumPiso = "0";

                }
                if (txtCodigo.Text.Length == 0)
                {
                    CodPostal = 0;
                }
                if (txtTelefono.Text.Length == 0)
                {
                    NumTelefono = "Sin datos";
                }

                if (txtEmail.Text.Length == 0)
                {
                    Email = "datos@email.com";
                }
                else{
                
                    if (EmailIsValid(txtEmail.Text))
                    {

                       
                        ClienteNuevo = true;
                    }
                    else{


                        ClienteNuevo = false;
                        //ValidarUsuario = true;
                        MessageBox.Show("Debe ingresar un formato de tipo Email");

                    }
                }
                if (txtActvidadProfesion.Text.Length == 0)
                {
                    Profesion = "Sin datos";
                }
                if (txtObs.Text.Length == 0)
                {
                    Observacion = "Sin datos";
                    //epValidarCampos.SetError(txtObs, "Un campo se encuentra vacio, por favor complete!");
                }
            }
            
        }
        #region CRUD
        private void NuevoCliente()
        {
            try
            {

                Conexion.CONEXIONSQLSERVER.conectar.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("instertar_cliente", Conexion.CONEXIONSQLSERVER.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@Apell_Nombre", SqlDbType.VarChar, 50).Value =Convert.ToString(txtApellidoNombre.Text);
                    cmd.Parameters.Add("@NumDoc", SqlDbType.VarChar, 40).Value = Convert.ToString(txtDni.Text);
                    
                    if (txtCuit.Text.Length == 0)
                    {
                       cmd.Parameters.Add("@NumCuit", SqlDbType.VarChar, 40).Value = Convert.ToString(Cuit);
                    }
                    else
                    {
                       cmd.Parameters.Add("@NumCuit", SqlDbType.VarChar, 40).Value = Convert.ToString(txtCuit.Text);
                    }
                    if (txtCalle.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Calle", SqlDbType.VarChar, 100).Value = Convert.ToString(Calle);
                    }
                    else
                    {
                       cmd.Parameters.Add("@Calle", SqlDbType.VarChar, 100).Value = Convert.ToString(txtCalle.Text);
                    }
                    if (txtNum.Text.Length == 0)
                    {
                       cmd.Parameters.Add("@NumCalle", SqlDbType.VarChar, 6).Value = Convert.ToString(NumCalle);
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumCalle", SqlDbType.VarChar, 6).Value = Convert.ToString(txtNum.Text);
                    }
                    if (txtPiso.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@NumPiso", SqlDbType.VarChar, 6).Value = Convert.ToString(NumPiso);
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumPiso", SqlDbType.VarChar, 6).Value = Convert.ToString(txtPiso.Text);
                    }
                    if (txtDtoLocalidad.Text.Length == 0)
                    {
                       cmd.Parameters.Add("@localidad", SqlDbType.VarChar, 6).Value = Convert.ToString(Localidad);
                    }
                    else
                    {
                        cmd.Parameters.Add("@localidad", SqlDbType.VarChar, 6).Value = Convert.ToString(txtDtoLocalidad.Text);
                    }
                    if (txtCP.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@CodPostal", SqlDbType.Int).Value = Convert.ToInt32(CodPostal);
                    }
                    else
                    {
                        cmd.Parameters.Add("@CodPostal", SqlDbType.Int).Value = Convert.ToInt32(txtCP.Text);    
                    }
                   //--ID DE LOS COMBOBOX--//
                        cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int).Value = Convert.ToInt32(cbxLoclidad.SelectedValue);
                        cmd.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = Convert.ToInt32(cbxProvincia.SelectedValue);
                        cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = Convert.ToInt32(cbxPais.SelectedValue);
                        cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = dtmFechNac.Value;
                   //--FIN-----------///
                    if (txtTelefono.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 40).Value = NumTelefono;
                    }
                    else
                    {
                        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 40).Value = Convert.ToString(txtTelefono.Text);
                    }
                    if (txtEmail.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = Convert.ToString(Email);
                    }
                    else
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = Convert.ToString(txtEmail.Text);
                    }
                    if (txtActvidadProfesion.Text.Length == 0)
                    {
                    cmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 100).Value = Convert.ToString(Profesion);
                    }
                    else
                    {
                        cmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 100).Value = Convert.ToString(txtActvidadProfesion.Text);
                    }
                
                    cmd.Parameters.Add("@Inquilino", SqlDbType.Int).Value = ValidarInquilino;
                    cmd.Parameters.Add("@Propietario", SqlDbType.Int).Value = ValidarPropietario;
                    cmd.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = dtmFechaAlta.Value;
                    if (txtObs.Text.Length == 0)
                    {
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Convert.ToString(txtObs.Text);
                    }
                    else
                    {
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Convert.ToString(txtObs.Text);
                    }
                
                    cmd.Parameters.Add("@Delete", SqlDbType.Bit).Value = 0;

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONSQLSERVER.conectar.Close();
                dtGridClientes.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ya existe un usuario y un Email registrado");
                throw;
            }
           
        }
        private void UpDate_clientes()
        {
            try
            {
                 
                    Conexion.CONEXIONSQLSERVER.conectar.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("sp_update_clients", Conexion.CONEXIONSQLSERVER.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IDCliente", SqlDbType.Int).Value = IdCliente;  
                    cmd.Parameters.Add("@Apell_Nombre", SqlDbType.VarChar, 50).Value = Convert.ToString(txtApellidoNombre.Text);
                    cmd.Parameters.Add("@NumDoc", SqlDbType.VarChar, 40).Value = Convert.ToString(txtDni.Text);

                    if (txtCuit.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@NumCuit", SqlDbType.VarChar, 40).Value = Convert.ToString(Cuit);
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumCuit", SqlDbType.VarChar, 40).Value = Convert.ToString(txtCuit.Text);
                    }
                    if (txtCalle.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Calle", SqlDbType.VarChar, 100).Value = Convert.ToString(Calle);
                    }
                    else
                    {
                        cmd.Parameters.Add("@Calle", SqlDbType.VarChar, 100).Value = Convert.ToString(txtCalle.Text);
                    }
                    if (txtNum.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@NumCalle", SqlDbType.VarChar, 6).Value = Convert.ToString(NumCalle);
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumCalle", SqlDbType.VarChar, 6).Value = Convert.ToString(txtNum.Text);
                    }
                    if (txtPiso.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@NumPiso", SqlDbType.VarChar, 6).Value = Convert.ToString(NumPiso);
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumPiso", SqlDbType.VarChar, 6).Value = Convert.ToString(txtPiso.Text);
                    }
                    if (txtDtoLocalidad.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@localidad", SqlDbType.VarChar, 6).Value = Convert.ToString(Localidad);
                    }
                    else
                    {
                        cmd.Parameters.Add("@localidad", SqlDbType.VarChar, 6).Value = Convert.ToString(txtDtoLocalidad.Text);
                    }
                    if (txtCP.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@CodPostal", SqlDbType.Int).Value = Convert.ToInt32(CodPostal);
                    }
                    else
                    {
                        cmd.Parameters.Add("@CodPostal", SqlDbType.Int).Value = Convert.ToInt32(txtCP.Text);
                    }
                    //--ID DE LOS COMBOBOX--//
                    cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int).Value = Convert.ToInt32(cbxLoclidad.SelectedValue);
                    cmd.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = Convert.ToInt32(cbxProvincia.SelectedValue);
                    cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = Convert.ToInt32(cbxPais.SelectedValue);
                    cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = dtmFechNac.Value;
                    //--FIN-----------///
                    if (txtTelefono.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 40).Value = NumTelefono;
                    }
                    else
                    {
                        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 40).Value = Convert.ToString(txtTelefono.Text);
                    }
                    if (txtEmail.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = Convert.ToString(Email);
                    }
                    else
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = Convert.ToString(txtEmail.Text);
                    }
                    if (txtActvidadProfesion.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 100).Value = Convert.ToString(Profesion);
                    }
                    else
                    {
                        cmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 100).Value = Convert.ToString(txtActvidadProfesion.Text);
                    }

                    cmd.Parameters.Add("@Inquilino", SqlDbType.Int).Value = ValidarInquilino;
                    cmd.Parameters.Add("@Propietario", SqlDbType.Int).Value = ValidarPropietario;
                    cmd.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = dtmFechaAlta.Value;
                    if (txtObs.Text.Length == 0)
                    {
                        cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Convert.ToString(txtObs.Text);
                    }
                    else
                    {
                        cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Convert.ToString(txtObs.Text);
                    }

                    cmd.Parameters.Add("@Delete", SqlDbType.Bit).Value = 0;

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    cmd.ExecuteNonQuery();
                    Conexion.CONEXIONSQLSERVER.conectar.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ya existe un usuario y un Email registrado");
                throw;
            }
        }
        #endregion
        #region ejemplos_comentados
        //DateTime FechaAlta = Convert.ToDateTime(dtmFechaAlta.Value.Date.ToString("dd-MM-yyyy"));
        //DateTime fecha_Alta = DateTime.Today;
        //string fecha_alta = dtmFechaAlta.Value.ToString("dd/MM/yyyy");
        // Convert.ToDateTime(txtNumeroTarjeta1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        //tmFechaAlta.Text =  DateTime.Now.ToShortDateString();

        //dtmFechaAlta.Text =  DateTime.Now.ToShortDateString();
        //dtmFechaAlta.Format = DateTimePickerFormat.Custom;
        //dtmFechaAlta.CustomFormat = "yyyyMMdd";
        //DateTime miFechaAlta = Convert.ToDateTime(dtmFechNac.Value.DateTime.ToString("yyyy-MM-dd"));
        #endregion

        #region HabilitaDeshabilitaObjetos
        private void HabilitaBotones()
        {
            
            btnSave.Visible = false;
            chkInquilino.Enabled = true;
            chkPropietario.Enabled = true;
            txtApellidoNombre.Enabled = true;
            txtDni.Enabled = true;
            txtCuit.Enabled = true;
            txtCalle.Enabled = true;
            dtmFechNac.Enabled = true;
            txtNum.Enabled = true;
            txtPiso.Enabled = true;
            txtCP.Enabled = true;
            txtDtoLocalidad.Enabled = true;
            cbxLoclidad.Enabled = true;
            cbxProvincia.Enabled = true;
            cbxPais.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtActvidadProfesion.Enabled = true;
            txtObs.Enabled = true;
            txtApellidoNombre.Focus();

        }
            private void DeshabilitaBotones()
            {
                btnSave.Visible = true;
                txtApellidoNombre.Enabled = false;
                txtDni.Enabled = false;
                txtCuit.Enabled = false;
                txtCalle.Enabled = false;
                dtmFechNac.Enabled = false;
                txtNum.Enabled = false;
                txtPiso.Enabled = false;
                txtCP.Enabled = false;
                txtDtoLocalidad.Enabled = false;
                cbxLoclidad.Enabled = false;
                cbxProvincia.Enabled = false;
                cbxPais.Enabled = false;
                txtTelefono.Enabled = false;
                txtEmail.Enabled = false;
                txtActvidadProfesion.Enabled = false;
                txtObs.Enabled = false;
        }
        #endregion

        #region VariablesLimpiaTextBox
        private void LimpiaTextBox()
        {
            if (chkInquilino.Checked == true)
            {
                chkInquilino.Checked = false;
            }
            if (chkPropietario.Checked == true)
            {

                chkPropietario.Checked = false;
            }

            txtApellidoNombre.Text = "";
            txtDni.Text = "";
            txtCuit.Text = "";
            txtCalle.Text = "";
            dtmFechNac.Text = "";
            txtNum.Text = "";
            txtPiso.Text = "";
            txtCP.Text = "";
            txtDtoLocalidad.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtActvidadProfesion.Text = "";
            txtObs.Text = "";
        }
        #endregion



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Borrar_validacion();
            if(Guardar_Nuevo == 0)
            {
                ValidarDatosClientes();
                if (ClienteNuevo == true)
                {
                    DeshabilitaBotones();

                    NuevoCliente();
                    LimpiaTextBox();
                    ClienteNuevo = false;
                    MessageBox.Show("Su Cliente/Inquilino se guardo existosamente", "Mensaje nfomativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CargaDatosEnGrilla();
                }
                else
                {
                    MessageBox.Show("Quizas un dato es incorrecto o algo salio mal!", "Mensaje nfomativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                ValidarDatosUpDate();
                if (ClienteModificar == true)
                {
                    // Una vez guardado los datos 
                    // modificado, busco en la base de datos 
                    // que el documento se repita nuevamente y mostrar una advertencia
                    // mediante una consulta a través de un proc. almacenado
                    // el dni ya existe con ese cliente
                    UpDate_clientes();
                    DeshabilitaBotones();
                    CargaDatosEnGrilla();
                    MessageBox.Show("Su Cliente/Inquilino se modificó con exito", "Mensaje nfomativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            
           
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
           
        }

        private void cbxLoclidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Metodo para que solo acepte números
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtCuit.Focus();
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtApellidoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtDni.Focus();
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtCalle.Focus();
            }
            if (txtCuit.TextLength < 12)
            {

            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtNum.Focus();
            }
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            //METODO QUE SOLO ACEPTA NUMEROS
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtCuit.Focus();
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtDtoLocalidad.Focus();
            }
        }

        private void txtDtoLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                cbxLoclidad.Focus();
            }
        }

        private void cbxLoclidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtCP.Focus();
            }
        }

        private void cbxProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                cbxPais.Focus();
            }
        }

        private void cbxPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //METODO QUE SOLO ACEPTA NUMEROS
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtCuit.Focus();
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtActvidadProfesion.Focus();
            }
        }

        private void txtActvidadProfesion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtObs.Focus();
            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {   
            //METODO QUE SOLO ACEPTA NUMEROS
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtCuit.Focus();
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                dtmFechNac.Focus();
            }
        }

        private void dtmFechNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtPiso.Focus();
            }
        }

        private void txtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void chkPropietario_Click(object sender, EventArgs e)
        {
           
        }

        private void chkPropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtApellidoNombre.Focus();
            }
        }

        private void chkInquilino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtApellidoNombre.Focus();
            }
        }

        private void dtGridClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try

            {


                    ClienteModificar = true;
                    //Instanciamos la clase clientes para poder asignar los datos de la grilla a las
                    //propiedades de las variables
                    Modulos.Clientes Clase_Clientes = new Clientes();

                    IdCliente = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Clase_Clientes.StrApellidoyNombre = dtGridClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Apell_Nombre = dtGridClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Clase_Clientes.StrDni = dtGridClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Clase_Clientes.StrCuit = dtGridClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Clase_Clientes.StrCalle = dtGridClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
                    Clase_Clientes.StrNumCalle = dtGridClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
                    Clase_Clientes.StrNumPiso = dtGridClientes.Rows[e.RowIndex].Cells[6].Value.ToString();
                    Clase_Clientes.StrLocalidadDto = dtGridClientes.Rows[e.RowIndex].Cells[7].Value.ToString();
                    Clase_Clientes.IntCodPostal = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[8].Value.ToString());
                    Clase_Clientes.IntIdCiudad = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[9].Value.ToString());
                    Clase_Clientes.IntIdProvincia = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[10].Value.ToString());
                    Clase_Clientes.IntIdPais = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[11].Value.ToString());
                    Clase_Clientes.DtFechaNac = Convert.ToDateTime(dtGridClientes.Rows[e.RowIndex].Cells[12].Value.ToString());
                    Clase_Clientes.StrTelefono = dtGridClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                    Clase_Clientes.StrEmail = dtGridClientes.Rows[e.RowIndex].Cells["c_email"].Value.ToString();
                    Clase_Clientes.StrActividad = dtGridClientes.Rows[e.RowIndex].Cells["c_actividad"].Value.ToString();
                    Clase_Clientes.IntInquilinoSiNo = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells["c_inqulino"].Value.ToString());
                    Clase_Clientes.IntPropietarioSiNo = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells["c_propietario"].Value.ToString());
                    Clase_Clientes.DtFechaAlta = Convert.ToDateTime(dtGridClientes.Rows[e.RowIndex].Cells["c_fecha_alta"].Value.ToString());
                    Clase_Clientes.StrObservaciones = dtGridClientes.Rows[e.RowIndex].Cells["c_observaciones"].Value.ToString();

                    // Clase_Clientes.BytDelete = (dtGridClientes.Rows[e.RowIndex].Cells["c_delete"].Value.ToString());
                    //DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", null);
                    txtApellidoNombre.Text = Clase_Clientes.StrApellidoyNombre;
                    txtDni.Text = Clase_Clientes.StrDni;
                    txtCuit.Text = Clase_Clientes.StrCuit;
                    txtCalle.Text = Clase_Clientes.StrCalle;
                    txtNum.Text = Clase_Clientes.StrNumCalle;
                    txtPiso.Text = Clase_Clientes.StrNumPiso;
                    txtDtoLocalidad.Text = Clase_Clientes.StrLocalidadDto;
                    txtCP.Text = Convert.ToString(Clase_Clientes.IntCodPostal);
                    dtmFechNac.Text = Convert.ToString(dtGridClientes.Rows[e.RowIndex].Cells["Fecha_Nac"].Value.ToString());
                    //---Reservado para el combobox--//
                    Id_Ciudad = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[9].Value.ToString());
                    cbxLoclidad.SelectedValue = Id_Ciudad;
                    // mostrar_ciudad();
                    Id_Provincia = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[10].Value.ToString());
                    cbxProvincia.SelectedValue = Id_Provincia;
                    //  Mostrar_provincia();
                    Id_Pais = int.Parse(dtGridClientes.Rows[e.RowIndex].Cells[11].Value.ToString());
                    cbxPais.SelectedValue = Id_Pais;
                    // mostrar_pais();

                    /////----FIN-------------/////////////

                    txtTelefono.Text = Clase_Clientes.StrTelefono;
                    txtEmail.Text = Clase_Clientes.StrEmail;
                    txtActvidadProfesion.Text = Clase_Clientes.StrActividad;
                    if (Clase_Clientes.IntInquilinoSiNo == 1)
                    {

                        chkInquilino.Checked = true;
                    }
                    else
                    {
                        chkInquilino.Checked = false;
                    }

                    if (Clase_Clientes.IntPropietarioSiNo == 1)
                    {
                        chkPropietario.Checked = true;
                    }
                    else
                    {
                        chkPropietario.Checked = false;
                    }
                    dtmFechaAlta.Text = Convert.ToString(dtGridClientes.Rows[e.RowIndex].Cells["c_fecha_alta"].Value.ToString());
                    txtObs.Text = Clase_Clientes.StrObservaciones;
                    txtCodigo.Text = Convert.ToString(IdCliente);
              
              



            }
            catch (Exception)
            {
                //Aquí da error 
                ClienteModificar = false;
                return;

               // throw;
            }
        }

        private void txtApellidoNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGridClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow fila = ((DataGridView)sender).Rows[e.RowIndex];
            if (fila.Index % 2 == 0) //Si es par
                fila.DefaultCellStyle.BackColor = Color.FromArgb(26, 177, 136);
            else //Si es impar   
                fila.DefaultCellStyle.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Al momento de Elminar un cliente o registro, preguntamos si existe un Id seleccionado desde la grilla que muestra los dotos
            try
            {
               if (IdCliente > 0)
                {
                    Modulos.Clientes Clase_Clientes = new Clientes();
                    
                    string message = "Usted está por eliminar al cliente "+ Apell_Nombre + "¿Desea eliminarlo?";
                    string caption = "¡Atención!";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    //DISPLAY THE MESSAGEBOX-- MOSTRAMOS EL MENSAJE CAJA

                    result = MessageBox.Show(message, caption, buttons);
                    if ( result == System.Windows.Forms.DialogResult.Yes)
                    {
                        Conexion.CONEXIONSQLSERVER.conectar.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("Pro_Alm_Delete_Clients", Conexion.CONEXIONSQLSERVER.conectar);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IDCliente", SqlDbType.Int).Value = IdCliente;
                        cmd.Parameters.Add("@Delete", SqlDbType.Bit).Value = 1; //Aquí se elimina con 1
                                                                                //Simplemente dejamos de mostrarlo en la grilla y listo
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        cmd.ExecuteNonQuery();
                        Conexion.CONEXIONSQLSERVER.conectar.Close();
                        CargaDatosEnGrilla();
                        MessageBox.Show("¡Cliente eliminado con exito!");
                    }
                    
                }else
                {
                    MessageBox.Show("¡Debe seleccionar al menos un cliente para eliminar!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
 

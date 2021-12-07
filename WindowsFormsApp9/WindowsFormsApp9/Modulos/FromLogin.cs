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
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Xml;
using WindowsFormsApp9.Modulos;
using System.Net.Mail;
using System.Net;


namespace WindowsFormsApp9.Modulos
{
        
    public partial class FromLogin : Form

    {
       
        public int NuevoUsuario = 0;
        public int PasaAlSistema;
        FrmPrincipal logeo;
        public Boolean ValidaDatos;
        public Boolean ValidarUsuario;
        public string RembemberPassword;
        public Boolean UsuarioExiste;
        public FromLogin()
        {
            InitializeComponent();
        }
        //Metodo para validar correo electrónico
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
        #region CRUD
        private void insertarUsuario()
            {
            try
            {
                Conexion.CONEXIONSQLSERVER.conectar.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_usuario", Conexion.CONEXIONSQLSERVER.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", txtApellido.Text);
                cmd.Parameters.AddWithValue("@name", txtNombre.Text);
                cmd.Parameters.AddWithValue("@username", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@delete", 0);
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
        private void BuscarExistenciaDeUsuario()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("select * from usuarios WHERE Us_Delete = '0'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    if (txtEmail.Text == rdr["Us_Email"].ToString())
                    {
                        ValidaDatos = true;
                        MessageBox.Show("Ya existe este Email registrado");
                    }
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BuscarUsuarioExistente()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("select * from usuarios WHERE Us_Delete = '0'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                        if (txtUsuario.Text == rdr["Us_UserName"].ToString())
                        {
                            UsuarioExiste = true;
                            
                            
                        }
                    
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Ingresa_al_sistema()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("select * from usuarios WHERE Us_Delete = '0'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (txtUsuario.Text == rdr["Us_UserName"].ToString()) 
                    {
                        if (txtPassword.Text == rdr["Us_Password"].ToString())
                        {
                            logeo = new FrmPrincipal();
                            logeo.Show();
                            this.Hide();
                        }
                    }
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        private void mostrar_correos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("select Us_Email from usuarios WHERE Us_Delete = '0'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cbxEmails.Items.Add(rdr["Us_Email"].ToString());
                    
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Mostrar_password_correo()
        {
            try
            { 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.CONEXIONSQLSERVER.conexion;
                SqlCommand  da = new SqlCommand("buscar_usuario_por_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Email", cbxEmails.Text);
                con.Open();
                RembemberPassword = Convert.ToString(da.ExecuteScalar());
                con.Close();
                
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }
        private void BorrarValidacion()
        {

            epValidarCampos.SetError(txtApellido,"");
            epValidarCampos.SetError(txtNombre, "");
            epValidarCampos.SetError(txtUsuario, "");
            epValidarCampos.SetError(txtPassword, "");
            epValidarCampos.SetError(txtEmail, "");
        }
       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            ckMostrarPass.Visible = true;
            this.Close();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
      
         }
            
        
        private void FromLogin_Load(object sender, EventArgs e)
        {
            lblApellido.Visible = false;
            lblNombre.Visible = false;
            txtApellido.Visible = false;
            txtNombre.Visible = false;
            btnAceptar.Visible = false;
            lblBienvenido.Text = "Bienvenido al sistema inmobiliario";
            ValidaDatos = false;
            btnCancelar.Visible = false;
            ValidarUsuario = false;
            lblMensajeCaracteres.Visible = false;
            txtEmail.Visible = false;
            lblEmail.Visible = false;
            plRestorePassword.Visible = false;
            mostrar_correos();

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            BorrarValidacion();
            btnRestorePass.Visible = false;
            lblApellido.Visible = true;
            lblNombre.Visible = true;
            txtApellido.Visible = true;
            txtNombre.Visible = true;
            btnAceptar.Visible = true;
            lblBienvenido.Text = "Por favor registrese.";
            btnIniciarSesion.BackColor = Color.FromArgb(36, 50, 61);
            NuevoUsuario = 1;
            ValidaDatos = false;
            ValidarUsuario = false;
            btnCancelar.Visible = true;
            lblMensaje.Text = "";
            ckMostrarPass.Visible = false;

            chbRemeberMe.Visible = false;
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtEmail.Visible =true;
            lblEmail.Visible = true;
            lblMensaje.Text = "";
            pcLogin.Visible = false;
            lblMensajeCaracteres.Text = "";
            
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            BorrarValidacion();
            lblBienvenido.Visible = true;
            lblApellido.Visible = false;
            lblNombre.Visible = false;
            txtApellido.Visible = false;
            txtNombre.Visible = false;
            btnRegistrarse.BackColor = Color.FromArgb(36, 50, 61);
            btnIniciarSesion.BackColor = Color.FromArgb(26, 177, 136);
            NuevoUsuario = 0;

            if (txtUsuario.Text == "")
            {
                ValidarUsuario = true;
                epValidarCampos.SetError(txtUsuario, "Ingrese Usuario por favor!");

            }
            if (txtPassword.Text == "")
            {
                ValidarUsuario = true;
                epValidarCampos.SetError(txtPassword, "Ingrese Password por favor!");
               
            }
            if (txtPassword.TextLength < 8)
            {
                ValidarUsuario = true;
                lblMensajeCaracteres.Visible = true;
                lblMensajeCaracteres.Text = "Falta contraseña o tiene menos de 8 caracteres";
            }
            else
            {
                lblMensajeCaracteres.Visible = false;
            
            }
            if (ValidarUsuario == false)
               // BuscarUsuarioExistente();
            {
                ValidarUsuario = false;
                Ingresa_al_sistema();
                
                
            } 
            if (ValidarUsuario == true)
            {
                lblMensaje.Text = "Usuario y/o contraseña es incorrecto";
                ValidarUsuario = false;
            }
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

            BorrarValidacion();
            if (txtApellido.Text == "")
            {
                ValidaDatos = true;
                epValidarCampos.SetError(txtApellido, "Ingrese Apellido por favor!");
              
            }
            if (txtNombre.Text == "")
            {
                ValidaDatos = true;
                epValidarCampos.SetError(txtNombre, "Ingrese Nombre por favor!");
            }
            if (txtUsuario.Text == "")
            {
                ValidaDatos = true;
                epValidarCampos.SetError(txtUsuario, "Ingrese Usuario por favor!");

            }
            if (txtPassword.Text == "")
            {
                ValidaDatos = true;
                epValidarCampos.SetError(txtPassword, "Ingrese Password por favor!");
            }
            if (txtPassword.TextLength < 8)
            {
                ValidaDatos = true;
                lblMensajeCaracteres.Visible=true;
                lblMensajeCaracteres.Text = "Debe ingresar 8 o más caracteres";
               //messageBox.Show("Ingrese una contraseña de 8 caracteres o más");
            }
            if (EmailIsValid(txtEmail.Text))
            {
                //ValidarUsuario = false;
                ValidaDatos = false;
            }
            else
            {
                ValidaDatos = true;
                //ValidarUsuario = true;
                MessageBox.Show("Debe ingresar un formato de tipo Email");

            }
            BuscarExistenciaDeUsuario();


            if (ValidaDatos == false)
            {
                BorrarValidacion();
                BuscarUsuarioExistente();
                if (UsuarioExiste == true)
                {
                    MessageBox.Show("Ya existe un usuario registrado con ese nombre");
                }
                else
                {
                    insertarUsuario();
                    lblApellido.Visible = false;
                    lblNombre.Visible = false;
                    txtApellido.Visible = false;
                    txtNombre.Visible = false;
                    btnRegistrarse.BackColor = Color.FromArgb(36, 50, 61);
                    btnIniciarSesion.BackColor = Color.FromArgb(26, 177, 136);
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                    txtUsuario.Text = "";
                    txtPassword.Text = "";
                    NuevoUsuario = 0;
                    ValidarUsuario = false;
                    lblMensaje.Text = "";
                    btnCancelar.Visible = false;
                    btnAceptar.Visible = false;
                    chbRemeberMe.Visible = true;
                    lblBienvenido.Text = "Bienvenido al sistema inmobiliario";
                    lblMensajeCaracteres.Visible = false;
                    pcLogin.Visible = true;
                    lblEmail.Visible = false;
                    txtEmail.Visible = false;
                    btnRestorePass.Visible = true;
                    mostrar_correos();
                    MessageBox.Show("¡Usuario Registrado con Exito!");
                }
                
            }
            else if(ValidaDatos == true)
            {
                lblMensaje.Text = "Debe completar todos los campos";
                ValidaDatos = false;
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lblApellido.Visible = false;
            lblNombre.Visible = false;
            txtApellido.Visible = false;
            txtNombre.Visible = false;
            btnRestorePass.Visible = true;
            btnRegistrarse.BackColor = Color.FromArgb(36, 50, 61);
            btnIniciarSesion.BackColor = Color.FromArgb(26, 177, 136);
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            lblMensaje.Text = "";
            txtEmail.Text = "";
            ckMostrarPass.Visible = true;
            ValidarUsuario = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            lblBienvenido.Text= "Bienvenido al sistema inmobiliario";
            lblMensajeCaracteres.Visible = false;
            txtEmail.Visible = false;
            lblEmail.Visible = false;
            chbRemeberMe.Visible = true;
            pcLogin.Visible = true;
            BorrarValidacion();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblCaracteres.Text = "" + txtPassword.TextLength;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //if (EmailIsValid(txtEmail.Text))
            //{
                 
            //    ValidaDatos = false;
            //}
            //else
            //{
            //    ValidaDatos = true;
                 
            //    MessageBox.Show("Debe ingresar un formato de tipo Email");

            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrarValidacion();
            plRestorePassword.Visible = true;
            ckMostrarPass.Visible = false;
           
        }
        internal void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add((destinatario));
                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
               // lblEstado_de_envio.Text = "ENVIADO";
                MessageBox.Show("Contraseña Enviada, revisa tu correo Electronico", "Restauracion de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // PanelRestaurarCuenta.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR, revisa tu correo Electronico", "Restauracion de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //lblEstado_de_envio.Text = "Correo no registrado";
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar_password_correo();
            richTextBox1.Text = richTextBox1.Text.Replace("@pass", RembemberPassword);
            enviarCorreo("nelsonfercher@gmail.com", "nuevaclase", richTextBox1.Text, "Solicitud de Contraseña", cbxEmails.Text, "");
            //plRestorePassword.Visible = false;
            label6.Text = RembemberPassword;
            plRestorePassword.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            plRestorePassword.Visible = false;
            ckMostrarPass.Visible = true;
        }

        private void ckMostrarPass_CheckedChanged(object sender, EventArgs e)
        {
           //Metodo que permite mostrar contraseña en el txtPassword
            txtPassword.Select();
            if (ckMostrarPass.Checked == true)
            {
               if (txtPassword.PasswordChar == '*')
                {
                    txtPassword.PasswordChar = '\0';
                }
            }else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            // {
            //     btnIniciarSesion.Select();
            // }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIniciarSesion.Focus();
                btnIniciarSesion.BackColor = Color.FromArgb(31, 212, 163) ;
            }
            //if ((int)e.KeyChar == (int)Keys.Enter)
            //{
            //    btnIniciarSesion.Select();
            //}
        }
    }
}

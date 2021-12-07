using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp9.Conexion
{
    class CONEXIONSQLSERVER
    {
        public static string conexion = "Data Source=.;Initial Catalog=BASEDDINMOBILIARIA;Integrated Security=True";
        //public static string conexion = Convert.ToString(Conexion.Desencryptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);
        internal void abrir()
        {
             if(conectar .State ==ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
         internal void cerrar()
        {
            if (conectar .State ==ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}

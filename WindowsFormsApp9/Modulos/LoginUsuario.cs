using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9.Modulos
{
    class LoginUsuario
    {
        #region "Variables de la clase"
        public int intValorIdUsuario;
        public string strValorNombreUsuario;
        public string strValorApellidoUsuario;
        public string strValorEmailUsuario;
        public string StrValorUserName;
        public string strValorPasswordUsuario;
        public byte bytValorUsuarioActivo;

        public  string strValorEmail { get; internal set; }
        public  string strValorPaword { get; internal set; }
        #endregion

        #region "Propiedades de la clase"
        public int intId
        {
            get
            {
                return intValorIdUsuario;
            }
            set
            {
                intValorIdUsuario = value;
            }
        }
        public string strNombreUsuario
        {
            get
            {
                return strValorNombreUsuario;
            }
            set
            {
                strValorNombreUsuario = value;
            }
        }
        public string strApellidoUsuario
        {
            get
            {
                return strValorApellidoUsuario;
            }
            set
            {
                strValorApellidoUsuario = value;
            }
        }
        public string strEmailUsuario
        {
            get
            {
                return strValorEmailUsuario;
            }
            set
            {
                strValorEmailUsuario = value;
            }
        }
        public string StrUserName
        {
            get
            {
                return StrValorUserName;
            }
            set
            {
                StrValorUserName = value;
            }
        }
        public string strPasswordUsuario
        {
            get
            {
                return strValorPasswordUsuario;
            }
            set
            {
                strValorPasswordUsuario = value;
            }
        }
        public byte byteUsuarioActivo
        {
            get
            {
                return bytValorUsuarioActivo;
            }
            set
            {
                bytValorUsuarioActivo = value;
            }
        }
        #endregion
    }
}

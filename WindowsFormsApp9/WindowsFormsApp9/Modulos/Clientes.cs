using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9.Modulos
{
    class Clientes
    {
        #region Variable de la clase
        //Variable que almacena el valor de la propiedad
        private int intIdCliente;
        private DateTime dtFechaAlta;
        private int intInquilinoSiNo; //0 no es inquilino, 1 si es inquilino
        private int intPropietarioSiNo; //0 no es propietario, 1 si es propietario
        private string strApellidoyNombre;
        private  string strDni; //Es string, pero el en ingreso solo acepta números
        private string strCuit; //Es string, pero el en ingreso solo acepta números
        private string strCalle;
        private string strNumCalle; //Solo acepta num. desde el txtNum
        private string strNumPiso;//Solo acepta num. desde el txtNumPiso
        private DateTime dtFechaNac;
        private string strLocalidadDto;
        private int intCodPostal;
        private int intIdCiudad;
        private int intIdProvincia;
        private int intIdPais;
        private string strTelefono;
        private string strEmail;
        private string strActividad;
        private string strObservaciones;
        private byte bytDelete;

        #endregion

        #region Propiedad de la clase 
        public int IntiDCliente
        {
            get { return intIdCliente; }
            set { intIdCliente = value; }
        }
        public DateTime DtFechaAlta
        {
            get { return dtFechaAlta; }
            set { dtFechaAlta = value; }
        }
        public int IntInquilinoSiNo
        {
            get { return intInquilinoSiNo; }
            set { intInquilinoSiNo = value; }
        }
        public int IntPropietarioSiNo
        {
            get { return intPropietarioSiNo; }
            set { intPropietarioSiNo = value; }
        }
        public string StrApellidoyNombre
        {
            get { return strApellidoyNombre; }
            set { strApellidoyNombre = value; }
        }

        public string StrDni
        {
            get { return strDni; }
            set { strDni = value; }
        }

        public string StrCuit
        {
            get { return strCuit; }
            set { strCuit = value; }
        }
        public string StrCalle
        {
            get { return strCalle; }
            set { strCalle = value; }
        }
        public string StrNumCalle
        {
            get { return strNumCalle; }
            set { strNumCalle = value; }
        }
        public string StrNumPiso
        {
            get { return strNumPiso; }
            set { strNumPiso = value; }
        }

        public DateTime DtFechaNac
        {
            get { return dtFechaNac; }
            set { dtFechaNac = value; }
        }
        public int IntIdCiudad
        {
            get { return intIdCiudad; }
            set { intIdCiudad = value; }
        }
        public string StrLocalidadDto
        {
            get { return strLocalidadDto; }
            set { strLocalidadDto = value; }
        }
        public int IntCodPostal
        {
            get { return intCodPostal; }
            set { intCodPostal = value; }
        }


        public int IntIdProvincia {
            get { return intIdProvincia; }
            set { intIdProvincia = value; }
        }
        public int IntIdPais
        {
            get { return intIdPais;}
            set { intIdPais = value; }
        }
        public string StrTelefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }
        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public string StrActividad
        {
            get { return strActividad; }
            set { strActividad = value; }
        }

        public string StrObservaciones
        {
            get { return strObservaciones; }
            set { strObservaciones = value; }
        }
        public byte BytDelete
        {
            get { return bytDelete; }
            set { bytDelete = value; }
        }
        #endregion

    }
}

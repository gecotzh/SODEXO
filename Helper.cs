using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sodexo.EPedidos.Servicio.Proxy.SvcCodigoMaestro;
using Sodexo.EPedidos.Entidades.Personalizado;
using Sodexo.EPedidos.Servicio.Proxy.SvcUbigeo;
using Sodexo.EPedidos.Servicio.Proxy.SvcEmpleado;
namespace Sodexo.EPedidos.Utilidades
{
    public static class Helper
    {
        public static List<TipoCodigo> CargarEmpleadoPorTipo(string TipoEmpleado) {
            
            EmployeeServiceContractClient SvcEmpleado = new EmployeeServiceContractClient();
            var empleados = SvcEmpleado.Filtrar( new InputParamEmpleado() { EMPLOYEE_TYPE_CODE = TipoEmpleado } );
            List<TipoCodigo> listaTipoCodigo = new List<TipoCodigo>();

            foreach (var emp in empleados)
            {
                TipoCodigo tipoCodigo = new TipoCodigo();
                tipoCodigo.Code = emp.ID.ToString();
                tipoCodigo.ParentTypeCode = "";
                tipoCodigo.CodeDescription = emp.SHORT_NAME;
                tipoCodigo.EntityDocNumber = emp.DOCUMENT_TYPE_NUMBER;
                listaTipoCodigo.Add(tipoCodigo);
            }
            return listaTipoCodigo;

        }


        public static List<TipoCodigo> CargarCodigoPorParent(string TypeCode)
        {
            CodigoMaestroServiceContractClient SvcCodigoMaestro = new CodigoMaestroServiceContractClient();
            DatosCodigoMaestro objCodigoMaestro = new DatosCodigoMaestro();
            objCodigoMaestro.PARENT_TYPE_CODE = TypeCode;
            objCodigoMaestro.ENABLED = Enumeraciones.TIPO_CODIGO_ENABLED;
            OutputListaCodigosMaestro listaCodigoMaestro = SvcCodigoMaestro.Filtrar(objCodigoMaestro);
            List<TipoCodigo> listaTipoCodigo = new List<TipoCodigo>();

            foreach (DatosCodigoMaestro itemTipoRelacion in listaCodigoMaestro.ListaCodigosMaestro)
            {
                TipoCodigo tipoCodigo = new TipoCodigo();
                tipoCodigo.Code = itemTipoRelacion.CODE;
                tipoCodigo.ParentTypeCode = itemTipoRelacion.PARENT_TYPE_CODE;
                tipoCodigo.CodeDescription = itemTipoRelacion.CODE_DESCRIPTION;
                listaTipoCodigo.Add(tipoCodigo);
            }
            return listaTipoCodigo;
        }

        public static TipoCodigo CargarCodigo(string TypeCode)
        {
            CodigoMaestroServiceContractClient SvcCodigoMaestro = new CodigoMaestroServiceContractClient();
            DatosCodigoMaestro objCodigoMaestro = new DatosCodigoMaestro();
            objCodigoMaestro.CODE = TypeCode;
            SvcCodigoMaestro.Obtener(ref objCodigoMaestro);
            TipoCodigo reTipoCodigo = new TipoCodigo();
            if (objCodigoMaestro != null)
            {
                reTipoCodigo.Code = objCodigoMaestro.CODE;
                reTipoCodigo.CodeDescription = objCodigoMaestro.CODE_DESCRIPTION;
                reTipoCodigo.EntityName = objCodigoMaestro.ENTITY_NAME;
                reTipoCodigo.EntityRelated = objCodigoMaestro.ENTITY_RELATED;
                reTipoCodigo.ParentTypeCode = objCodigoMaestro.PARENT_TYPE_CODE;
            }
            return reTipoCodigo;
        }

        public static List<Ubigeo> CargarUbigeoPorParent(int IdUbigeo)
        {
            UbigeoServiceContractClient SvcUbigeo = new UbigeoServiceContractClient();
            DatosUbigeo objDatosUbigeo = new DatosUbigeo();
            objDatosUbigeo.PARENT_TYPE_ID = IdUbigeo;
            OuputListaUbigeo ouputListaUbigeo = SvcUbigeo.Filtrar(objDatosUbigeo);
            List<Ubigeo> listaUbigeos = new List<Ubigeo>();
            foreach (DatosUbigeo itemUbigeo in ouputListaUbigeo.OutputListaUbigeo)
            {
                Ubigeo objUbigeo = new Ubigeo();
                objUbigeo.Id = itemUbigeo.ID;
                objUbigeo.GeoTypeCode = itemUbigeo.GEO_TYPE_CODE;
                objUbigeo.GeoCode = itemUbigeo.GEO_CODE;
                objUbigeo.GeoName = itemUbigeo.GEO_NAME;
                objUbigeo.Abbreviation = itemUbigeo.ABBREVIATION;
                listaUbigeos.Add(objUbigeo);
            }
            return listaUbigeos;
        }

        public static Ubigeo CargarUbigeo(int ID)
        {
            UbigeoServiceContractClient SvcUbigeo = new UbigeoServiceContractClient();
            DatosUbigeo objDatosUbigeo = new DatosUbigeo();
            objDatosUbigeo.ID = ID;
            SvcUbigeo.Obtener(ref objDatosUbigeo);
            Ubigeo objUbigeo = new Ubigeo();
            if (objDatosUbigeo != null)
            {
                objUbigeo.Id = objDatosUbigeo.ID;
                objUbigeo.GeoTypeCode = objDatosUbigeo.GEO_TYPE_CODE;
                objUbigeo.GeoCode = objDatosUbigeo.GEO_CODE;
                objUbigeo.GeoName = objDatosUbigeo.GEO_NAME;
                objUbigeo.Abbreviation = objDatosUbigeo.ABBREVIATION;
            }

            return objUbigeo;
        }

        public static string GeneraPasswordUID(int length)
        {
            string guidResult = System.Guid.NewGuid().ToString();

            guidResult = guidResult.Replace("-", string.Empty);

            if (length <= 0 || length > guidResult.Length)
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

            return guidResult.Substring(0, length);
        }
    }
}

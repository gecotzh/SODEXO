using Sodexo.EPedidos.Servicio.Proxy.SvcCliente;
using Sodexo.EPedidos.Servicio.Proxy.SvcCodigoMaestro;
using Sodexo.EPedidos.Servicio.Proxy.SvcContacto;
using Sodexo.EPedidos.Servicio.Proxy.SvcPersona;
using Sodexo.EPedidos.Servicio.Proxy.SvcRelacion;
using Sodexo.EPedidos.Servicio.Proxy.SvcUbigeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sodexo.EPedidos.Utilidades
{
    public static class LogHelper
    {
        #region ADD_EDIT_LOG
        //public static Sodexo.EPedidos.Servicio.Proxy.SvcOrganizacion.ParametrosLogueo LogRegisterOrg(string evento, int userSesionId)
        //{
        //    var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcOrganizacion.ParametrosLogueo();
        //    paramLogueo.url = URL;
        //    paramLogueo.module = PATH.Split('/')[2];
        //    paramLogueo.eventType = evento;
        //    paramLogueo.sessionUserId = userSesionId;
        //    return paramLogueo;
        //}

        public static Sodexo.EPedidos.Servicio.Proxy.SvcCliente.ParametrosLogueo LogRegisterCliente(string evento, int userSesionId)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcCliente.ParametrosLogueo();
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            paramLogueo.url = URL;
            paramLogueo.module = "Cliente/Insertar"; 
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcCliente.ParametrosLogueo LogEditCliente(string evento, int userSesionId)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcCliente.ParametrosLogueo();
            paramLogueo.url = URL;
            paramLogueo.module = "Cliente/Editar";
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static CUSTOMER_CUSTOM GetOldCustomerData(int idCliente, int idOrganizacion)
        {
            ClienteServiceContractClient SvcCliente = new ClienteServiceContractClient();
            Servicio.Proxy.SvcCliente.DatosOrganizacion objOrganizacion = new Servicio.Proxy.SvcCliente.DatosOrganizacion();
            UbigeoServiceContractClient SvcUbigeo = new UbigeoServiceContractClient();
            CodigoMaestroServiceContractClient SvcCodigoMaestro = new CodigoMaestroServiceContractClient();
            ContactoParticipanteServiceContractClient SvcContacto = new ContactoParticipanteServiceContractClient();
            RelacionServiceContractClient SvcRelacion = new RelacionServiceContractClient();
            objOrganizacion.ID = idOrganizacion;
            DatosClienteOrganizacion doRespuesta = SvcCliente.Obtener(objOrganizacion);

            var CodigoTipoDocumento = doRespuesta.DatosOrganizacion.DOCUMENT_TYPE_CODE;
            var NumeroTipoDocumento = doRespuesta.DatosOrganizacion.DOCUMENT_TYPE_NUMBER;
            var NombreFantasma = (doRespuesta.DatosOrganizacion.COMERCIAL_NAME ?? "");
            var tamanioCode = (doRespuesta.DatosCliente.EMPLOYEE_NUMBER ?? "");
            var RazonSocial = doRespuesta.DatosOrganizacion.ORGANIZATION_NAME;
            var giroNegocio = doRespuesta.DatosCliente.RUT_HOLDING;
            var grupoEmpresarial = doRespuesta.DatosCliente.BUSSINES_GROUP;
            var recordatorioPedido = (doRespuesta.DatosCliente.ORDER_REMINDER_YESNO ?? "N").ToUpper() == "S" ? true : false;
            var alertaRecarga = (doRespuesta.DatosCliente.RECHARGE_ALERT_YESNO ?? "N").ToUpper() == "S" ? true : false;
            var esInternacional = (doRespuesta.DatosCliente.INTERNATIONAL_YESNO ?? "N").ToUpper() == "S" ? true : false;

            var ejecutivoAPV = (doRespuesta.DatosCliente.ACCOUNT_ADVISOR ?? 0);
            var ejecutivoCOM = (doRespuesta.DatosCliente.ACCOUNT_EXECUTIVE ?? 0);

            InputParamDatosContacto objInputDatosContacto = new InputParamDatosContacto();
            objInputDatosContacto.PARTY_ID = doRespuesta.DatosOrganizacion.ID;

            DatosTelefono objDatosTelefono = SvcContacto.ObtenerTelefono(objInputDatosContacto);

            var Telefono = string.Empty;
            if (objDatosTelefono != null)
                Telefono = objDatosTelefono.CONTACT_NUMBER;


            objInputDatosContacto.CONTACT_MECH_TYPE_CODE = Enumeraciones.CODIGO_CORREO_PEDIDOS;
            DatosEmail objDatosEmail = SvcContacto.ObtenerEmail(objInputDatosContacto);

            var CorreoPedido = string.Empty;
            if (objDatosEmail != null)
                CorreoPedido = objDatosEmail.EMAIL_NAME;

            //Correo Facturación Electrónica
            objInputDatosContacto.CONTACT_MECH_TYPE_CODE = Enumeraciones.CODIGO_CORREO_FACTURA_ELECTRONICA;
            objDatosEmail = SvcContacto.ObtenerEmail(objInputDatosContacto);

            var CorreoFacturaElectronica = string.Empty;
            if (objDatosEmail != null)
                CorreoFacturaElectronica = objDatosEmail.EMAIL_NAME;

            //Correo Facturación Electrónica Altenro
            objInputDatosContacto.CONTACT_MECH_TYPE_CODE = Enumeraciones.CODIGO_CORREO_FACTURA_ELECTRONICA_ALTERNO;
            objDatosEmail = SvcContacto.ObtenerEmail(objInputDatosContacto);

            var CorreoFacturaElectronicaAlterno = string.Empty;
            if (objDatosEmail != null)
                CorreoFacturaElectronicaAlterno = objDatosEmail.EMAIL_NAME;

            //bloque de codigo ha revisar
            objInputDatosContacto.CONTACT_MECH_TYPE_CODE = Enumeraciones.CODIGO_DIRECCION;
            DatosDireccion objDatosDireccion = SvcContacto.ObtenerDireccion(objInputDatosContacto);

            var Direccion = string.Empty;
            var IdDepartamento = 0m;
            var IdProvincia = 0m;
            var IdDistrito = 0m;

            if (objDatosDireccion != null)
            {
                Direccion = objDatosDireccion == null && objDatosDireccion.ADDRESS1 == null ? "" : objDatosDireccion.ADDRESS1;
                IdDepartamento = objDatosDireccion != null && objDatosDireccion.DEPARTMENT_GEO_ID != null ? Decimal.Parse(objDatosDireccion.DEPARTMENT_GEO_ID.ToString()) : 0;
                IdProvincia = objDatosDireccion != null && objDatosDireccion.PROVINCE_GEO_ID != null ? Decimal.Parse(objDatosDireccion.PROVINCE_GEO_ID.ToString()) : 0;
                IdDistrito = objDatosDireccion != null && objDatosDireccion.DISTRICT_GEO_ID != null ? objDatosDireccion.DISTRICT_GEO_ID.Value : 0;
            }

            PersonaServiceContractClient SvcPersona = new PersonaServiceContractClient();
            DatosPersona objDatosPersona = new DatosPersona();
            objDatosPersona.ID = doRespuesta.DatosCliente.PERSON_PARTY_ID.ToString() == "" ? 0 : int.Parse(doRespuesta.DatosCliente.PERSON_PARTY_ID.ToString());
            SvcPersona.Obtener(ref objDatosPersona);

            var idPersona = 0m;
            var Contacto = string.Empty;


            if (objDatosPersona != null)
            {
                idPersona = decimal.Parse(doRespuesta.DatosCliente.PERSON_PARTY_ID.ToString());
                //Contacto = objDatosPersona.FIRST_NAME + " " + objDatosPersona.MIDDLE_NAME + " " + objDatosPersona.FATHER_NAME + " " + objDatosPersona.MOTHER_NAME;
                Contacto = objDatosPersona.SHORT_NAME;
            }
            else
            {
                idPersona = 0;
                Contacto = "";
            }

            //BLOQUE PARA CARGAR LA DATA ANTIGUA ANTES DE SU EDICION
            CUSTOMER_CUSTOM oldCustomer = new CUSTOMER_CUSTOM();
            oldCustomer.DOCUMENT_TYPE_CODE = CodigoTipoDocumento;//BUSCAR
            oldCustomer.DOCUMENT_TYPE_NUMBER = NumeroTipoDocumento;
            oldCustomer.ORGANIZATION_NAME = RazonSocial;
            oldCustomer.PERSON_PARTY_NAME = Contacto.Trim();
            oldCustomer.CONTACT_NUMBER = Telefono;
            oldCustomer.DEPARTMENT_GEO_NAME = IdDepartamento.ToString();//ID
            oldCustomer.PROVINCE_GEO_NAME = IdProvincia.ToString();//ID
            oldCustomer.DISTRICT_GEO_NAME = IdDistrito.ToString();//ID
            oldCustomer.ADDRESS1 = Direccion;
            oldCustomer.EMAIL_NAME = CorreoPedido;
            oldCustomer.EMAIL_NAME_INVOICE = CorreoFacturaElectronica;
            oldCustomer.EMAIL_NAME_INVOICE_ALTERNATIVE = CorreoFacturaElectronicaAlterno;
            oldCustomer.RUT_HOLDING = giroNegocio;//BUSCAR
            oldCustomer.BUSSINES_GROUP = (grupoEmpresarial ?? "");
            oldCustomer.INTERNATIONAL_YESNO = esInternacional == true ? "S" : "N";
            oldCustomer.ORDER_REMINDER_YESNO = recordatorioPedido == true ? "S" : "N";
            oldCustomer.RECHARGE_ALERT_YESNO = alertaRecarga == true ? "S" : "N";
            oldCustomer.COMERCIAL_NAME = NombreFantasma;
            oldCustomer.ACCOUNT_ADVISOR = ejecutivoAPV.ToString();//BUSCAR
            oldCustomer.ACCOUNT_EXECUTIVE = ejecutivoCOM.ToString();//BUSCAR
            oldCustomer.EMPLOYEE_NUMBER = tamanioCode;
            return oldCustomer;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcCliente.CUSTOMER_LOG_CUSTOM LogOldCliente(CUSTOMER_CUSTOM custom)
        {
            var CustomerLogCustom = new Sodexo.EPedidos.Servicio.Proxy.SvcCliente.CUSTOMER_LOG_CUSTOM();
            CustomerLogCustom.DOCUMENT_TYPE_CODE = custom.DOCUMENT_TYPE_CODE;
            CustomerLogCustom.DOCUMENT_TYPE_NUMBER = custom.DOCUMENT_TYPE_NUMBER;
            CustomerLogCustom.ORGANIZATION_NAME = custom.ORGANIZATION_NAME;
            CustomerLogCustom.PERSON_PARTY_NAME = custom.PERSON_PARTY_NAME.Trim();
            CustomerLogCustom.CONTACT_NUMBER = custom.CONTACT_NUMBER;
            CustomerLogCustom.DEPARTMENT_GEO_NAME = custom.DEPARTMENT_GEO_NAME;
            CustomerLogCustom.PROVINCE_GEO_NAME = custom.PROVINCE_GEO_NAME;
            CustomerLogCustom.DISTRICT_GEO_NAME = custom.DISTRICT_GEO_NAME;
            CustomerLogCustom.ADDRESS1 = custom.ADDRESS1;
            CustomerLogCustom.EMAIL_NAME = custom.EMAIL_NAME;
            CustomerLogCustom.EMAIL_NAME_INVOICE = custom.EMAIL_NAME_INVOICE;
            CustomerLogCustom.EMAIL_NAME_INVOICE_ALTERNATIVE = custom.EMAIL_NAME_INVOICE_ALTERNATIVE;
            CustomerLogCustom.RUT_HOLDING = custom.RUT_HOLDING;
            CustomerLogCustom.BUSSINES_GROUP = custom.BUSSINES_GROUP;
            CustomerLogCustom.INTERNATIONAL_YESNO = custom.INTERNATIONAL_YESNO;
            CustomerLogCustom.ORDER_REMINDER_YESNO = custom.ORDER_REMINDER_YESNO;
            CustomerLogCustom.RECHARGE_ALERT_YESNO = custom.RECHARGE_ALERT_YESNO;
            CustomerLogCustom.COMERCIAL_NAME = custom.COMERCIAL_NAME;
            CustomerLogCustom.ACCOUNT_ADVISOR = custom.ACCOUNT_ADVISOR;
            CustomerLogCustom.ACCOUNT_EXECUTIVE = custom.ACCOUNT_EXECUTIVE;
            CustomerLogCustom.EMPLOYEE_NUMBER = custom.EMPLOYEE_NUMBER;
            return CustomerLogCustom;
        }

        //public static Sodexo.EPedidos.Servicio.Proxy.SvcContacto.ParametrosLogueo LogRegisterContacto(string evento, int userSesionId)
        //{
        //    var URL = HttpContext.Current.Request.Url.AbsoluteUri;
        //    var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContacto.ParametrosLogueo();
        //    paramLogueo.url = URL;
        //    paramLogueo.module = PATH.Split('/')[2];
        //    paramLogueo.eventType = evento;
        //    paramLogueo.sessionUserId = userSesionId;
        //    return paramLogueo;
        //}

        //public static Sodexo.EPedidos.Servicio.Proxy.SvcRelacion.ParametrosLogueo LogRegisterRelacion(string evento, int userSesionId)
        //{
        //    var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcRelacion.ParametrosLogueo();
        //    paramLogueo.url = URL;
        //    paramLogueo.module = PATH.Split('/')[2];
        //    paramLogueo.eventType = evento;
        //    paramLogueo.sessionUserId = userSesionId;
        //    return paramLogueo;
        //}


        public static Sodexo.EPedidos.Servicio.Proxy.SvcContrato.ParametrosLogueo LogRegisterContrato(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContrato.ParametrosLogueo();
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcContrato.ParametrosLogueo LogEditContrato(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContrato.ParametrosLogueo();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcContratoProducto.ParametrosLogueo LogRegisterContratoProducto(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContratoProducto.ParametrosLogueo();
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcContratoProducto.ParametrosLogueo LogEditContratoProducto(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContratoProducto.ParametrosLogueo();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }


        public static Sodexo.EPedidos.Servicio.Proxy.SvcContratoAtributo.ParametrosLogueo LogRegisterContratoAtributo(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContratoAtributo.ParametrosLogueo();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcContratoAtributo.ParametrosLogueo LogEditContratoAtributo(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContratoAtributo.ParametrosLogueo();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcContratoDetalle.ParametrosLogueo LogRegisterContratoDetalle(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContratoDetalle.ParametrosLogueo();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        public static Sodexo.EPedidos.Servicio.Proxy.SvcContratoDetalle.ParametrosLogueo LogEditContratoDetalle(string evento, int userSesionId, string tab)
        {
            var URL = HttpContext.Current.Request.Url.AbsoluteUri;
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToUpper();
            var paramLogueo = new Sodexo.EPedidos.Servicio.Proxy.SvcContratoDetalle.ParametrosLogueo();
            var TAB = !string.IsNullOrEmpty(tab) ? tab.ToString() : string.Empty;
            paramLogueo.url = URL;
            paramLogueo.module = TAB.ToString();
            paramLogueo.eventType = evento;
            paramLogueo.sessionUserId = userSesionId;
            paramLogueo.pantalla = controller;
            return paramLogueo;
        }

        #endregion
    }
}

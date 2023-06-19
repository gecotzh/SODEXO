using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo.EPedidos.Utilidades
{
    public static class Enumeraciones
    {
        public const string PARAMETRO_DEFAULT_REPOSICION = "0002";
        public const string PARAMETRO_DEFAULT_TARJETA_ADICIONAL = "0003";
        public const string PARAMETRO_DEFAULT_RENOVACION = "0004";
        public const string PARAMETRO_DEFAULT_ENVIO_LIMA = "0005";
        public const string PARAMETRO_DEFAULT_ENVIO_PROVINCIA = "0006";
        public const string PARAMETRO_DEFAULT_IGV = "0007";
        public const string PARAMETRO_DEFAULT_EMISION = "0009";
        public const string PARAMETRO_DEFAULT_MATERIALIZACION = "0018";

        public const string PARAMETRO_DEFAULT_ENVIO_REPO_LIMA = "0012";
        public const string PARAMETRO_DEFAULT_ENVIO_REPO_PROVINCIA = "0013";


        public const int TIPO_CODIGO_ENABLED = 1;

        public const string TIPO_VALOR_PREFERENCIAL_VALE = "40";
        public const string TIPO_VALORES_PORTADOR = "15";
        public const string TIPO_PEDIDO = "38";
        public const string MOTIVO_BLOQUEO_NO_DEFINITIVO = "97";
        public const string TIPO_CONTRATO = "33";
        public const string TIPO_VIGENCIA = "34";

        public const string TIPO_BANCO_PAGO = "64";
        public const string TIPO_MONEDA = "65";


        public const string EXCLUSIVITY_DEFAULT_VALUE = "NO";
        public const int UBIGEO_DEPARTAMENTOS_PERU = 1;
        public const int UBIGEO_DEPARTAMENTO_LIMA = 16;

        public const string TIPO_DOCUMENTO = "25";
        public const string TIPO_DOCUMENTO_DNI = "2501";
        public const string TIPO_DOCUMENTO_RUC = "2502";
        public const string TIPO_DOCUMENTO_EXTRANGERIA = "2503";
        public const string TIPO_DOCUMENTO_PORTADOR = "2504";
        public const string TIPO_DOCUMENTO_PASAPORTE = "2505";

        public const string TIPO_CONCEPTO_CONTRATO_ACUERDO = "35";
        public const string TIPO_ACUERDO_COSTO_REPOSICION = "3501";
        public const string TIPO_ACUERDO_COSTO_ENVIO = "3502";
        public const string TIPO_ACUERDO_COSTO_ENVIO_REPO = "3508";

        public const string TIPO_ACUERDO_TARJETAS_ADICIONALES = "3503";
        public const string TIPO_ACUERDO_COSTO_RENOVACION = "3504";
        public const string TIPO_ACUERDO_COMISION = "3505";
        public const string TIPO_ACUERDO_COSTO_EMISION = "3506";
        public const string TIPO_ACUERDO_COSTO_TRASLADO_SALDO = "3507";
        public const string TIPO_ACUERDO_COSTO_MATERIALIZACION = "3510";

        public const string TIPO_FACILITADOR = "30";
        public const string TIPO_FACILITADOR_CCO = "3001";
        public const string TIPO_FACILITADOR_SUCURSAL = "3002";

        public const string TIPO_ATRIBUTOS_CONTRATO = "36";

        public const string TIPO_GIRO_NEGOCIO = "56";

        public const string TIPO_CODIGO_CAMPANIA = "20";
        public const string TIPO_MARCA = "21";
        public const string UNIDAD_MEDIDA = "22";

        public const string TIPO_PRODUCTO = "23";
        public const string ID_PRODUCTO_TARJETA = "2301";
        public const string ID_PRODUCTO_VALE = "2302";

        public const string TIPO_MOTIVO_CONTRATO = "16";
        public const string TIPO_MOTIVO_ACUERDO = "17";
        public const string CODIGO_ADENDA_ACUERDO = "1701";

        public const string TIPO_CALCULO = "19";
        public const string TIPO_CALCULO_PORCENTUAL = "1901";
        public const string TIPO_CALCULO_DINERO = "1902";

        public const string TIPO_RELACION = "26";
        public const string CODIGO_BENEFICIARIO = "2601";
        public const string CODIGO_MANCOMUNADO = "2602";
        public const string CODIGO_FACULTADO = "2603";

        public const string CODIGO_TELEFONO = "2801";
        public const string CODIGO_CELULAR = "2803";
        public const string CODIGO_CORREO = "2805";
        public const string CODIGO_CORREO_PEDIDOS = "2809";
        public const string CODIGO_CORREO_FACTURA_ELECTRONICA = "2810";
        public const string CODIGO_CORREO_FACTURA_ELECTRONICA_ALTERNO = "2811";
        public const string CODIGO_DIRECCION = "2807";

        public const string TIPO_SEXO = "32";
        public const string RELACION_CONTACTO_EMPRESA = "2930";
        public const string CODIGO_AREA = "1";
        public const string CODIGO_CONTRY = "1";

        public const string CAMPO_VACIO = " ";
        public const int DOCUMENTO_EXISTENTE = 1;

        public const int ID_ROL_ADMIN = 1;
        public const int ID_ROL_CLIENTE = 4;
        public const int ID_ROL_APV = 5;

        public const int CANT_MAX_NOMBRE_CORTO = 23;

        public const string TIPO_RELACION_BENEFICIARIO = "2601";
        public const string TIPO_RELACION_FACULTADO = "2603";
        public const string TIPO_RELACION_MANCOMUNADO = "2602";

        public const string TIPO_RELACION_COMERCIAL = "2605";
        public const string TIPO_RELACION_ASESOR = "2606";


        public const string ESTADO_PEDIDO_ABIERTO = "4101";
        public const string ESTADO_PEDIDO_PEND_PAGO = "4102";
        public const string ESTADO_PEDIDO_PROCESO = "4103";
        public const string ESTADO_PEDIDO_BOBEDA = "4104";
        public const string ESTADO_PEDIDO_REPARTO = "4105";
        public const string ESTADO_PEDIDO_FINALIZADO = "4106";

        public const string TIPO_PEDIDO_EMISION = "3801";
        public const string TIPO_PEDIDO_CARGA = "3802";
        public const string TIPO_PEDIDO_RENOVACION = "3803";
        public const string TIPO_PEDIDO_MANCOMUNADO = "3804";
        public const string TIPO_PEDIDO_REPOSICION = "3805";
        public const string TIPO_PEDIDO_ESPECIAL = "3806";
        public const string TIPO_PEDIDO_DESCARGA = "3807";

        public const string TIPO_PRODUCTO_AMBOS = "2300";
        public const string TIPO_PRODUCTO_AMBOS_DESCRIPCION = "AMBOS";
        public const string TIPO_PRODUCTO_TARJETA = "2301";
        public const string TIPO_PRODUCTO_VALE = "2302";
        public const string TIPO_PRODUCTO_AFINIDAD_LOGO = "2303";
        public const string TIPO_PRODUCTO_AFINIDAD_FONDO = "2304";
        public const string TIPO_PRODUCTO_ENSOBRADO = "2305";
        public const string TIPO_PRODUCTO_TAPA = "2306";

        public const string TIPO_COMPROBANTE_CONSTANCIA_PEDIDO = "4301";
        public const string TIPO_COMPROBANTE_COMPROMISO_PAGO = "4302";
        public const string TIPO_COMPROBANTE_PRE_FACTURA = "4304";

        public const string ESTADO_COMPROBANTE_EMITIDO = "4401";
        public const string ESTADO_COMPROBANTE_CANJE_FACTURA = "4402";

        public const string GASTOS_ADMINISTRATIVOS = "4501";
        public const string PREFACTURA_COBRO_COMISION = "4502";
        public const string PREFACTURA_COBRO_TARJ_ADICIONALES = "4503";
        public const string PREFACTURA_GASTOS_ENVIO = "4504";
        public const string PREFACTURA_COBRO_RENOVACION = "4506";

        public const string ESTADO_CONTRATO_REGISTRADO = "1801";
        public const string ESTADO_CONTRATO_APROBADO = "1802";

        public const string TIPO_COMPROBANTE_ITEM_GASTO_OPERATIVO = "4501";

        public const string PARAMETRO_ACTIVAR_CAMPANIAS = "0001";

        public const string TIPO_OPERACION_EMISION = "5701";
        public const string TIPO_OPERACION_CARGA = "5702";
        public const string TIPO_OPERACION_REINGRESO = "5703";
        public const string TIPO_OPERACION_RENOVACION = "5705";

        public const string TIPO_OPERACION_BLOQUEO = "5710";
        public const string ORDERS_TYPE_CODE_BLOQUEO = "3810";


        public const string TIPO_EMPLEADO_COMERCIAL = "5901";
        public const string TIPO_EMPLEADO_ASESOR = "5902";


        public static string CONFIG_LLAVE_CRIPTOGRAFICA = "LLAVE_CRIPTOGRAFICA";

        public const string ESTADO_DISTRIBUCION_INGRESADO = "1301";
        public const string ESTADO_DISTRIBUCION_PROCESADO = "1302";
        public const string ESTADO_DISTRIBUCION_ERROR = "1303";

        public const string TIPO_TAREJTA_PREPAGO = "47";

        public const string TIPO_CATEGORIZACION = "58";
        public const string TIPO_TAMANIO_EMPRESA = "70";
        //Alexis AFBV
        public const string PUNTO_ENTREGA = "56";
        public const string RUC_SODEXO = "20507852549";
        public const string COD_DIR_ENV = "2814";
        public const string COD_CEL_ENV = "2815";
        public const string COD_TEL_ENV = "2816";
        public const string COD_EMA_ENV = "2817";
        public const string TIPO_MOTIVO = "67";
        //

        public const string TABLA_ABECEDARIO = "A;B;C;D;E;F;G;H;I;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z";

        //MODIFICACION BITPERFECT
        //VALORES CELDA
        public const string VALOR_CELDA_DNI = "DNI";
        public const string VALOR_CELDA_EXTRANGERIA = "CE";
        public const string VALOR_CELDA_PORTADO = "PORTADO";
        public const string VALOR_CELDA_PORTADOR = "PORTADOR";
        public const string VALOR_CELDA_PASAPORTE = "PASAPORTE";
        //
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo.EPedidos.Utilidades
{
    public  class RespuestaGenerica
    {
        public bool esSatisfactorio { get; set; }
        public string mensaje { get; set; }
        public string codigo { get; set; }
        public decimal idGenerado { get; set; }
        public string titulo { get; set; }
        public dynamic data { get; set; }
        public bool contiene_emisiones { get; set; }

        public void setRespuesta(bool r, string m = "", string t = "", string c = "", dynamic d = null,decimal i = 0)
        {
            this.esSatisfactorio = r;
            this.mensaje = m;
            this.titulo = t;
            this.codigo = c;
            this.data = d;
            this.idGenerado = i;

            if (!r && m == "") this.mensaje = "Ocurrio un error inesperado";

        }

    }
}

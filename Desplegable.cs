using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo.EPedidos.Utilidades
{
    public class Desplegable
    {
        public string CampoValor { get; set; }
        public string CampoTexto { get; set; }
        public string ValorAdicional { get; set; }
        public bool Seleccionar { get; set; }
    }

    public class DesplegableEdit
    {
        public int value { get; set; }
        public string text { get; set; }
    }
}

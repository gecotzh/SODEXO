using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sodexo.EPedidos.Logica
{
    public class PedidoCargaMasiva
    {
        public static List<XElement> ReadXml(string fileName)
        {
            
            XDocument document = XDocument.Load(fileName);
            XNamespace workbookNameSpace = @"urn:schemas-microsoft-com:office:spreadsheet";
            // Get worksheet
            var query = from w in document.Elements(workbookNameSpace + "Workbook").Elements(workbookNameSpace + "Worksheet")
                        where w.Attribute(workbookNameSpace + "Name").Value.Equals("Beneficiarios")
                        select w;
            List<XElement> foundWoksheets = query.ToList<XElement>();
            if (foundWoksheets.Count() <= 0) { throw new ApplicationException("La hoja de trabajo [Beneficiarios] no existe"); }

            XElement worksheet = query.ToList<XElement>()[0];
            // Get the row for "Seat"
            query = from d in worksheet.Elements(workbookNameSpace + "Table").Elements(workbookNameSpace + "Row")
                    select d;

            List<XElement> foundData = query.ToList<XElement>();

            if (foundData.Count() <= 0) { throw new ApplicationException("No se han encontrado filas"); }

            return foundData;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorXMLPowerBI.Models
{
    public class PowerBIXML
    {
        public int ID { get; set; }
        public int ID_TP_XML { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataEvent { get; set; }
        public int CdForm { get; set; }
        public string XmlCompl { get; set; }
    }
}

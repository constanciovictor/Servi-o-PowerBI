using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LeitorXMLPowerBI.Models
{
    [XmlRoot("Form")]
    public class FormXML
    {

        //public string id { get; set; }

        [XmlElement("Code")]
        public string Code { get; set; }

        [XmlElement("Name")]
        public string DS_NAME { get; set; }

        [XmlElement("Version")]
        public string NR_VERSION { get; set; }

        [XmlElement("Category")]
        public string Category { get; set; }

        [XmlElement("Fields")]
        public Fields field { get; set; }
    }

    [XmlRoot("Fields")]
    public class Fields
    {
        [XmlElement("Field")]
        public List<Field> Field { get; set; }
    }

    [XmlRoot("Field")]
    public class Field
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Value")]
        public string Value { get; set; }
    }
}

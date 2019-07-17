using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using LeitorXMLPowerBI.Models;
using LeitorXMLPowerBI.Data;
using System.Configuration;

namespace LeitorXMLPowerBI
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {
            foreach (string file in Directory.EnumerateFiles(ConfigurationManager.AppSettings["DiretorioLeitura"].ToString(), "*.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);

                while (xmlDoc.GetElementsByTagName("Files").Count > 0)
                {
                    var xml_node = xmlDoc.GetElementsByTagName("Files")[0];
                    xml_node.ParentNode.RemoveChild(xml_node);
                }

                while (xmlDoc.GetElementsByTagName("PreviousRelatedEntries").Count > 0)
                {
                    var xml_node = xmlDoc.GetElementsByTagName("PreviousRelatedEntries")[0];
                    xml_node.ParentNode.RemoveChild(xml_node);
                }

                while (xmlDoc.GetElementsByTagName("RelatedEntries").Count > 0)
                {
                    var xml_node = xmlDoc.GetElementsByTagName("RelatedEntries")[0];
                    xml_node.ParentNode.RemoveChild(xml_node);
                }

                PowerBIXML pw = new PowerBIXML()
                {   
                    ID_TP_XML = Convert.ToInt32(xmlDoc.GetElementsByTagName("EntryType")[0].FirstChild.Value),                    
                    DataInclusao = DateTime.Now,
                    DataEvent = DateTime.ParseExact(xmlDoc.GetElementsByTagName("EventDate")[0].FirstChild.Value, "ddMMyyyyHHmmss", null),
                    CdForm = xmlDoc.GetElementsByTagName("Form").Count > 0 ? Convert.ToInt32(xmlDoc.GetElementsByTagName("Form")[0].FirstChild.FirstChild.Value) : 0,
                    XmlCompl = xmlDoc.InnerXml
                };

                var dt = new DatabaseAccess();
                dt.InserirPontoXML(pw);
            }

















            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LeitorXMLPowerBI()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

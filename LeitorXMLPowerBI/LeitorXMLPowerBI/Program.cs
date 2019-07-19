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
using System.Xml.Serialization;

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
                var dt = new DatabaseAccess();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);

                //while (xmlDoc.GetElementsByTagName("Files").Count > 0)
                //{
                //    var xml_node = xmlDoc.GetElementsByTagName("Files")[0];
                //    xml_node.ParentNode.RemoveChild(xml_node);
                //}

                //while (xmlDoc.GetElementsByTagName("PreviousRelatedEntries").Count > 0)
                //{
                //    var xml_node = xmlDoc.GetElementsByTagName("PreviousRelatedEntries")[0];
                //    xml_node.ParentNode.RemoveChild(xml_node);
                //}

                //while (xmlDoc.GetElementsByTagName("RelatedEntries").Count > 0)
                //{
                //    var xml_node = xmlDoc.GetElementsByTagName("RelatedEntries")[0];
                //    xml_node.ParentNode.RemoveChild(xml_node);
                //}

                //#region Header

                //var header = MontarHeaderXML(xmlDoc);

                //#endregion

                if (xmlDoc.GetElementsByTagName("Task").Count > 0)
                {
                    var OrdemServico = MontarHeaderXML(xmlDoc.OuterXml);
                }

                if (xmlDoc.GetElementsByTagName("Form").Count > 0)
                {
                    if (xmlDoc.GetElementsByTagName("Form")[0].FirstChild.FirstChild.Value == "01")
                    {
                        var OrdemServico = MontarOrdemServicoXML(xmlDoc.GetElementsByTagName("Form")[0].OuterXml);
                        dt.InserirOrdemServicoXML(OrdemServico);
                    }
                    else if (xmlDoc.GetElementsByTagName("Form")[0].FirstChild.FirstChild.Value == "02")
                    {
                        var OrdemServico = MontarOrdemServicoImpXML(xmlDoc.GetElementsByTagName("Form")[0].OuterXml);
                        dt.InserirOrdemServicoImpXML(OrdemServico);
                    }
                    else if (xmlDoc.GetElementsByTagName("Form")[0].FirstChild.FirstChild.Value == "03")
                    {
                        var OrdemServico = MontarControleServicoXML(xmlDoc.GetElementsByTagName("Form")[0].OuterXml);
                        dt.InserirControleServicoXML(OrdemServico);
                    }
                    else if (xmlDoc.GetElementsByTagName("Form")[0].FirstChild.FirstChild.Value == "04")
                    {
                        var OrdemServico = MontarControleServicoImpXML(xmlDoc.GetElementsByTagName("Form")[0].OuterXml);
                        dt.InserirControleServicoImpXML(OrdemServico);
                    }

                }
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

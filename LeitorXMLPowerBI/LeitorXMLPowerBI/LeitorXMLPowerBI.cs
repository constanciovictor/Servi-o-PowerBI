using LeitorXMLPowerBI.Data;
using LeitorXMLPowerBI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using System.Xml.Serialization;

namespace LeitorXMLPowerBI
{
    public partial class LeitorXMLPowerBI : ServiceBase
    {        
        System.Timers.Timer timer = new System.Timers.Timer();

        public LeitorXMLPowerBI()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           timer.Elapsed += new ElapsedEventHandler(LerXMLPowweBI);
           timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["tempo"].ToString());            
           timer.Enabled = true;
        }

        private void LerXMLPowweBI(object source, ElapsedEventArgs e)
        {
            string nameXML = string.Empty;

            try
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
            }
            catch (Exception ex)
            {
                File.Copy(nameXML, ConfigurationManager.AppSettings["DiretorioSaidaErro"].ToString() + Path.GetFileName(nameXML) + "_" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".xml");
                EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("In OnStop.", EventLogEntryType.Warning);
        }

        public HeaderXML MontarHeaderXML(string xmlDocForm)
        {
            var headerXML = new HeaderXML();

            XmlSerializer serializer = new XmlSerializer(typeof(HeaderXML));
            using (TextReader reader = new StringReader(xmlDocForm))
            {
                headerXML = (HeaderXML)serializer.Deserialize(reader);
            }

            return headerXML;
        }

        public FormXML MontarOrdemServicoXML(string xmlDocForm)
        {
            var formXML = new FormXML();

            XmlSerializer serializer = new XmlSerializer(typeof(FormXML));
            using (TextReader reader = new StringReader(xmlDocForm))
            {
                formXML = (FormXML)serializer.Deserialize(reader);
                formXML.field.Field[0].Id = "N_CONTRATO";
                formXML.field.Field[1].Id = "N_CHAMADO";
                formXML.field.Field[6].Id = "NUM_ENDERECO";
                formXML.field.Field[30].Id = "NM_COMPLETO_RESP";
            }

            return formXML;
        }

        public FormXML MontarOrdemServicoImpXML(string xmlDocForm)
        {
            var formXML = new FormXML();

            XmlSerializer serializer = new XmlSerializer(typeof(FormXML));
            using (TextReader reader = new StringReader(xmlDocForm))
            {
                formXML = (FormXML)serializer.Deserialize(reader);
                formXML.field.Field[13].Id = "LOCALIZACAO_ATUAL";
            }

            return formXML;
        }

        public FormXML MontarControleServicoXML(string xmlDocForm)
        {
            var formXML = new FormXML();

            XmlSerializer serializer = new XmlSerializer(typeof(FormXML));
            using (TextReader reader = new StringReader(xmlDocForm))
            {
                formXML = (FormXML)serializer.Deserialize(reader);
                formXML.field.Field[4].Id = "NUM_ENDERECO";
                formXML.field.Field[58].Id = "TESTE_MONITOR";
            }

            return formXML;
        }

        public FormXML MontarControleServicoImpXML(string xmlDocForm)
        {
            var formXML = new FormXML();

            XmlSerializer serializer = new XmlSerializer(typeof(FormXML));
            using (TextReader reader = new StringReader(xmlDocForm))
            {
                formXML = (FormXML)serializer.Deserialize(reader);
            }

            return formXML;
        }
    }
}

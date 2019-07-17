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

           timer.Interval = 60000;

           timer.Enabled = true;
        }

        private void LerXMLPowweBI(object source, ElapsedEventArgs e)
        {
            string nameXML = string.Empty;

            try
            {
                foreach (string file in Directory.EnumerateFiles(ConfigurationManager.AppSettings["DiretorioLeitura"], "*.xml"))
                {
                    nameXML = file;

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file);

                    //Retira tags que não serão usadas no XML
                    while (xmlDoc.GetElementsByTagName("Files").Count > 0)
                    {
                        var xml_node = xmlDoc.GetElementsByTagName("Files")[0];
                        xml_node.ParentNode.RemoveChild(xml_node);
                    }

                    //Retira tags que não serão usadas no XML
                    while (xmlDoc.GetElementsByTagName("PreviousRelatedEntries").Count > 0)
                    {
                        var xml_node = xmlDoc.GetElementsByTagName("PreviousRelatedEntries")[0];
                        xml_node.ParentNode.RemoveChild(xml_node);
                    }

                    //Retira tags que não serão usadas no XML
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorXMLPowerBI.Models
{
    public class PontoXML
    {
        public string EventType { get; set; }
        public string EventDate { get; set; }
        public string EventDateAge { get; set; }
        public string EventDateFromEpoch { get; set; }
        public string EntryType { get; set; }
        public string EntryGuid { get; set; }
        public string EntryDate { get; set; }
        public string EntryDateAge { get; set; }
        public string EntryDateFromEpoch { get; set; }
        public string EntrySource { get; set; }        

        public EntryLocation EntryLocation { get; set; }
        public Employee Employee { get; set; }
    }

    public class EntryLocation
    {
        public string Address { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string MSISDN { get; set; }
        public string Date { get; set; }
        public string DateAge { get; set; }
        public string DateFromEpoch { get; set; }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        public string BusyStatus { get; set; }     
    }
}

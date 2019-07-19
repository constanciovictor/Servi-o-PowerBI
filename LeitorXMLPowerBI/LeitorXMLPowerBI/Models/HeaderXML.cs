using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LeitorXMLPowerBI.Models
{
    [XmlRoot("Entry")]
    public class HeaderXML
    {
        //public string id { get; set; }

        [XmlElement("EventType")]
        public string EventType { get; set; }

        [XmlElement("EventDate")]
        public string EventDate { get; set; }

        [XmlElement("EventDateAge")]
        public string EventDateAge { get; set; }

        [XmlElement("EventDateFromEpoch")]
        public string EventDateFromEpoch { get; set; }

        [XmlElement("EntryType")]
        public string EntryType { get; set; }

        [XmlElement("EntryGuid")]
        public string EntryGuid { get; set; }

        [XmlElement("EntryDate")]
        public string EntryDate { get; set; }

        [XmlElement("EntryDateAge")]
        public string EntryDateAge { get; set; }

        [XmlElement("EntryDateFromEpoch")]
        public string EntryDateFromEpoch { get; set; }

        [XmlElement("EntrySource")]
        public string EntrySource { get; set; }

        [XmlElement("EntryLocation")]
        public EntryLocation entryLocation { get; set; }

        [XmlElement("Task")]
        public Task task { get; set; }
    }

    [XmlRoot("EntryLocation")]
    public class EntryLocation
    {
        [XmlElement("Address")]
        public string Address { get; set; }

        [XmlElement("X")]
        public string X { get; set; }

        [XmlElement("Y")]
        public string Y { get; set; }

        [XmlElement("MSISDN")]
        public string MSISDN { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("DateAge")]
        public string DateAge { get; set; }

        [XmlElement("DateFromEpoch")]
        public string DateFromEpoch { get; set; }
    }

    [XmlRoot("Task")]
    public class Task
    {
        [XmlElement("TaskNumber")]
        public string TaskNumber { get; set; }

        [XmlElement("Status")]
        public string Status { get; set; }

        [XmlElement("Priority")]
        public string Priority { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("ContactName")]
        public string ContactName { get; set; }

        [XmlElement("CoordinationPhone")]
        public string CoordinationPhone { get; set; }

        [XmlElement("Phone1")]
        public string Phone1 { get; set; }

        [XmlElement("CoordinationPhone2")]
        public string CoordinationPhone2 { get; set; }

        [XmlElement("Phone2")]
        public string Phone2 { get; set; }

        [XmlElement("CustomerName")]
        public string CustomerName { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("Data1")]
        public string Data1 { get; set; }

        [XmlElement("Data2")]
        public string Data2 { get; set; }

        [XmlElement("Data3")]
        public string Data3 { get; set; }

        [XmlElement("Data4")]
        public string Data4 { get; set; }

        [XmlElement("Data5")]
        public string Data5 { get; set; }

        [XmlElement("Data6")]
        public string Data6 { get; set; }

        [XmlElement("Data7")]
        public string Data7 { get; set; }

        [XmlElement("Data9")]
        public string Data9 { get; set; }

        [XmlElement("Data10")]
        public string Data10 { get; set; }

        [XmlElement("Data11")]
        public string Data11 { get; set; }

        [XmlElement("Data13")]
        public string Data13 { get; set; }

        [XmlElement("Data16")]
        public string Data16 { get; set; }

        [XmlElement("Data12")]
        public string Data12 { get; set; }

        [XmlElement("Data14")]
        public string Data14 { get; set; }

        [XmlElement("Data17")]
        public string Data17 { get; set; }

        [XmlElement("Data28")]
        public string Data28 { get; set; }

        [XmlElement("Data29")]
        public string Data29 { get; set; }

        [XmlElement("Data30")]
        public string Data30 { get; set; }

        [XmlElement("ExternalCreationDate")]
        public string ExternalCreationDate { get; set; }

        [XmlElement("ExternalCreationDateAge")]
        public string ExternalCreationDateAge { get; set; }

        [XmlElement("ExternalCreationDateFromEpoch")]
        public string ExternalCreationDateFromEpoch { get; set; }

        [XmlElement("AdditionalInfo")]
        public string AdditionalInfo { get; set; }

        [XmlElement("StartDate")]
        public string StartDate { get; set; }

        [XmlElement("StartDateAge")]
        public string StartDateAge { get; set; }

        [XmlElement("StartDateFromEpoch")]
        public string StartDateFromEpoch { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("DueDateAge")]
        public string DueDateAge { get; set; }

        [XmlElement("DueDateFromEpoch")]
        public string DueDateFromEpoch { get; set; }

        [XmlElement("CreationDate")]
        public string CreationDate { get; set; }

        [XmlElement("CreationDateAge")]
        public string CreationDateAge { get; set; }

        [XmlElement("CreationDateFromEpoch")]
        public string CreationDateFromEpoch { get; set; }

        [XmlElement("TimeWindows")]
        public string TimeWindows { get; set; }

        [XmlElement("TimeWindowPriority")]
        public string TimeWindowPriority { get; set; }

        [XmlElement("ServiceTime")]
        public string ServiceTime { get; set; }

        [XmlElement("Capacity1")]
        public string Capacity1 { get; set; }

        [XmlElement("Capacity2")]
        public string Capacity2 { get; set; }

        [XmlElement("Capacity3")]
        public string Capacity3 { get; set; }

        [XmlElement("Capacity4")]
        public string Capacity4 { get; set; }

        [XmlElement("Capacity5")]
        public string Capacity5 { get; set; }

        [XmlElement("TaskType")]
        public TaskType taskType { get; set; }

        [XmlElement("TaskCategory")]
        public TaskCategory taskCategory { get; set; }

        [XmlElement("Employee")]
        public Employee employee { get; set; }

        [XmlElement("DistributionArea")]
        public DistributionArea distributionArea { get; set; }

        [XmlElement("EntryDateFromEpoch")]
        public string MaximalRadiusForEntries { get; set; }
    }

    [XmlRoot("TaskType")]
    public class TaskType
    {
        [XmlElement("Code")]
        public string Code { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }        
    }

    [XmlRoot("TaskCategory")]
    public class TaskCategory
    {
        [XmlElement("Code")]
        public string Code { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }
    }

    [XmlRoot("Employee")]
    public class Employee
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("EmployeeNumber")]
        public string EmployeeNumber { get; set; }

        [XmlElement("Group")]
        public Group group { get; set; }

        [XmlElement("CurrentAssociatedMobile")]
        public CurrentAssociatedMobile currentAssociatedMobile { get; set; }

        [XmlElement("BusyStatus")]
        public string BusyStatus { get; set; }        
    }

    [XmlRoot("Group")]
    public class Group
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }

    [XmlRoot("CurrentAssociatedMobile")]
    public class CurrentAssociatedMobile
    {
        [XmlElement("MSISDN")]
        public string MSISDN { get; set; }        
    }

    [XmlRoot("DistributionArea")]
    public class DistributionArea
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Layer")]
        public Layer layer { get; set; }
    }

    [XmlRoot("Layer")]
    public class Layer
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}

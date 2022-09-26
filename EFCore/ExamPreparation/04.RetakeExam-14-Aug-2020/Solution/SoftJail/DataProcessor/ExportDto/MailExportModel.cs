using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class MailExportModel
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}

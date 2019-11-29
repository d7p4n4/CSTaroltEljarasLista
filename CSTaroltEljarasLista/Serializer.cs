using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CSTaroltEljarasLista
{
    public class Serializer
    {
        public string serialize(TaroltEljarasLista taroltEljarasLista)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TaroltEljarasLista));
            var xml = "";

            using (var writer = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(writer))
                {
                    serializer.Serialize(writer, taroltEljarasLista);
                    xml = writer.ToString(); // Your XML
                }
            }

            return xml;
        }
    }
}

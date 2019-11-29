using CSAc4yGetXmls;
using CSAc4yObjectGetGuidCAP;
using d7p4n4Namespace.Final.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CSTaroltEljarasLista
{
    public class Translate
    {
        public string XmlToHtmlTransform(SqlConnection connection)
        {
            Translate translate = new Translate();
            Ac4yGetXml ac4YGetXml = new Ac4yGetXml(connection);
            Ac4yGetGuid ac4YGetGuid = new Ac4yGetGuid(connection);
            Deserializer deserializer = new Deserializer();
            Serializer serializer = new Serializer();
            string finalXml = "";

            List<string> list = ac4YGetGuid.GetGuidByTemplateGuid();
            List<string> xmlList = ac4YGetXml.GetXmlsByGuids(list);
            List<TaroltEljaras> taroltEljarasok = new List<TaroltEljaras>();

            foreach (var l in list)
            {
                Console.WriteLine(l);
            }
            foreach (var xml in xmlList)
            {
                //Console.WriteLine(xml);
                taroltEljarasok.Add(deserializer.deser(xml));
            }

            Console.WriteLine(taroltEljarasok.Count);

            TaroltEljarasLista taroltEljarasLista = new TaroltEljarasLista() { taroltEljarasLista = taroltEljarasok };

            finalXml = serializer.serialize(taroltEljarasLista);
            return finalXml;
        }
    }
}

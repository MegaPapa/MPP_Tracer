using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MPPLAB_1 {
    class Serializator<T> {
        public void serialization(T obj, String filename) {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, obj);
            writer.Close();
            Console.WriteLine("Serialization is complete!");
        }

        
    }
}

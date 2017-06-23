using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace SW1_ISO9126_FUZZY.Archivos {

    class Program {
        static void main(string[] args) {

            JObject o1 = JObject.Parse(File.ReadAllText(@"D:\Documentos\Visual Studio 2017\Projects\SW1_ISO9126_FUZZY\SW1_ISO9126_FUZZY\JSON\FuncionalidadInterna.json"));

            using (StreamReader file = File.OpenText(@"D:\Documentos\Visual Studio 2017\Projects\SW1_ISO9126_FUZZY\SW1_ISO9126_FUZZY\JSON\FuncionalidadInterna.json"))
            using (JsonTextReader reader = new JsonTextReader(file)) {
                JObject o2 = (JObject)JToken.ReadFrom(reader);

                Console.WriteLine(o2);
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var sourcePath = "data.csv";
            var desPath = "result.xml";
            var type = "xml";
            if (args.Length == 3)
            {
                sourcePath = args[0];
                desPath = args[1];
                type = args[2];
            }
            ICollection<string> log = new List<string>();
            if (Uri.IsWellFormedUriString(sourcePath, UriKind.RelativeOrAbsolute) && Uri.IsWellFormedUriString(desPath, UriKind.RelativeOrAbsolute))
            {

                File.WriteAllText(@"log.txt", "Podana sciezka jest nie prawidlowa");
                throw new ArgumentException("Podana sciezka jest nie prawidlowa");
            }

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(@"log.txt", "Podany plik nie istnieje");
                throw new FileNotFoundException("Podany plik nie istnieje");
            }

            var lines = File.ReadLines(sourcePath);
            var hash = new HashSet<Student>(new OwnComparer());
            foreach (var line in lines)
            {
                var word = line.Split(",");
                if (word.Length == 9)
                {
                    Student student = new Student(word[0], word[1], word[2], word[3], word[4], DateTime.Parse(word[5]), word[6], word[7], word[8]);
                    var check = hash.Add(student);
                    if (!check)
                    {
                        log.Add(line);
                    }

                }
                else
                {
                    log.Add(line);
                }
            }
            if (type.Equals("xml"))
            {
                FileStream writer = new FileStream(desPath, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute("uczelnia"));
                serializer.Serialize(writer, hash);
                writer.Close();

            }
            if (type.Equals("json"))
            {
                string jsonString = JsonConvert.SerializeObject(hash);
                File.WriteAllText(desPath, jsonString);
            }
            string alllog = "";
            foreach (var line in log)
            {
                alllog += line;
            }
            File.WriteAllText(@"log.txt", alllog);
        }
    }
}

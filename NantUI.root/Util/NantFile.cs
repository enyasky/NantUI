using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace NantUI.Util
{
    public class NantFile
    {
        public List<Target> Targets { get; set; }

        public NantFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new ArgumentException("Invalid file.");

            Targets = new List<Target>();

            var xml = new XmlDocument();
            xml.Load(fileName);

            var elements = xml.GetElementsByTagName("target");

            foreach (XmlElement e in elements)
            {
                var target = new Target(e);
                // if (!string.IsNullOrEmpty(target.Description))
                Targets.Add(target);
            }
        }
    }
}

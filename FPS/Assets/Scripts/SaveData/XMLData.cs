using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace FPS
{
    public class XMLData : IData
    {
        private string _path;
        public Player Load()
        {
            Player result = new Player();

            if (!File.Exists(_path))
                return result;

            using (XmlTextReader xmlReader = new XmlTextReader(_path))
            {
                string key;

                while (xmlReader.Read())
                {
                    key = "Name";
                    if (xmlReader.IsStartElement(key))
                    {
                        try { result.Name = xmlReader.GetAttribute("value"); }

                        catch { result.Name = "Default Name"; }
                    }

                    key = "Hp";
                    if (xmlReader.IsStartElement(key))
                        float.TryParse(xmlReader.GetAttribute("value"), out result.HP);

                    key = "IsVisible";
                    if (xmlReader.IsStartElement(key))
                        bool.TryParse(xmlReader.GetAttribute("value"), out result.IsVisible);

                }
            }
        }

        public void Save(Player player)
        {
            var xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("HP");
            element.SetAttribute("value", player.HP.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsVisible");
            element.SetAttribute("value", player.IsVisible.ToString());
            rootNode.AppendChild(element);

            XmlNode infoNode = xmlDoc.CreateElement("Info");
            var attributes = xmlDoc.CreateAttribute("Unity");
            attributes.Value = Application.unityVersion;
            infoNode.Attributes.Append(attributes);
            rootNode.AppendChild(infoNode);


            xmlDoc.Save(_path);
        }

        public void SetOption(string path)
        {
            _path = Path.Combine(path, "XMLData.xml");
        }
    }
}


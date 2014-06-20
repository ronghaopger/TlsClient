using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RHClassLibrary
{
    public class MyXmlHelper
    {
        private XmlDocument xmlDoc = new XmlDocument();
        private string xmlPath;
        public MyXmlHelper(string xpath)
        {
            xmlPath = xpath;
            xmlDoc.Load(xmlPath);
        }
        //public void AddGif(website model)
        //{
        //    XmlNode root = xmlDoc.SelectSingleNode("gifs");
        //    XmlElement xeName = xmlDoc.CreateElement("gif");
        //    xeName.SetAttribute("id", Guid.NewGuid().ToString());
        //    xeName.SetAttribute("name", model.GifUrl);
        //    root.PrependChild(xeName);
        //    xmlDoc.Save(xmlPath);
        //}
        public void DeleteGif(string id)
        {
            XmlNode root = xmlDoc.SelectSingleNode("gifs");
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Attributes[0].Value == id)
                {
                    root.RemoveChild(node);
                    xmlDoc.Save(xmlPath);
                    break;
                }
            }
        }
        //public List<website> GetGif()
        //{
        //    List<website> modelList = new List<website>();
        //    XmlNode root = xmlDoc.SelectSingleNode("gifs");
        //    foreach (XmlNode node in root.ChildNodes)
        //    {
        //        website model = new website();
        //        model.ID = node.Attributes[0].Value;
        //        model.GifUrl = "http://ww2.sinaimg.cn/bmiddle/" + node.Attributes[1].Value;
        //        modelList.Add(model);
        //    }
        //    return modelList;
        //}
    }
}

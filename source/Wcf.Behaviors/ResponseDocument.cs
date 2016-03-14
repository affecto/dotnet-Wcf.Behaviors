using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace Affecto.Wcf.Behaviors
{
    internal class ResponseDocument
    {
        private const string BodyElement = "SOAP-ENV:Body";

        public XmlDocument Document { get; }

        private ResponseDocument(XmlDocument document)
        {
            Document = document;
        }

        public static ResponseDocument Load(XmlDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }
            XmlNodeList bodies = document.GetElementsByTagName(BodyElement);
            if (bodies.Count != 1)
            {
                throw new ArgumentException("No or more than one SOAP body element.");
            }
            if (bodies[0].ChildNodes.Count != 1)
            {
                throw new ArgumentException("No or more than one SOAP body method element.");
            }
            return new ResponseDocument(document);
        }

        public void RemoveReturnDataNamespaces()
        {
            XmlNode method = Document.GetElementsByTagName(BodyElement)[0].ChildNodes[0];
            string methodReturnData = method.InnerXml;
            string methodReturnDataWithNoNamespaces = Regex.Replace(Regex.Replace(methodReturnData, @"<\w+:", "<"), @"</\w+:", "</");
            method.InnerXml = methodReturnDataWithNoNamespaces;
        }
    }
}

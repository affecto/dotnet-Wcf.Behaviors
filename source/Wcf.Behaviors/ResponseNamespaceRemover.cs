using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text.RegularExpressions;
using System.Xml;

namespace Affecto.Wcf.Behaviors
{
    public class ResponseNamespaceRemover : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            MemoryStream stream = new MemoryStream();
            XmlDocument document = GetReplyDocument(reply, stream);
            RemoveBodyNodeNamespaces(document);
            WriteNodeToStream(stream, document);
            XmlReader reader = XmlReader.Create(stream);
            reply = Message.CreateMessage(reader, int.MaxValue, reply.Version);            
        }

        private static void RemoveBodyNodeNamespaces(XmlDocument document)
        {
            const string bodyElement = "SOAP-ENV:Body";
            XmlNode responseBodyNode = document.GetElementsByTagName(bodyElement)[0].ChildNodes[0];
            string responseBody = responseBodyNode.InnerXml;
            string responseWithNoNamespaces = Regex.Replace(Regex.Replace(responseBody, @"<\w+:", "<"), @"</\w+:", "</");
            responseBodyNode.InnerXml = responseWithNoNamespaces;
        }

        private static void WriteNodeToStream(Stream stream, XmlNode node)
        {
            stream.SetLength(0);
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                node.WriteTo(writer);
                writer.Flush();
            }
            stream.Position = 0;
        }

        private static XmlDocument GetReplyDocument(Message reply, Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                reply.WriteMessage(writer);
                writer.Flush();
            }
            stream.Position = 0;
            doc.Load(stream);
            return doc;
        }
    }
}

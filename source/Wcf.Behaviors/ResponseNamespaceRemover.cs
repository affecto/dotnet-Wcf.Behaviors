using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
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
            ResponseDocument responseDocument = GetReplyDocument(reply, stream);
            responseDocument.RemoveReturnDataNamespaces();
            WriteNodeToStream(stream, responseDocument.Document);
            XmlReader reader = XmlReader.Create(stream);
            reply = Message.CreateMessage(reader, int.MaxValue, reply.Version);            
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

        private static ResponseDocument GetReplyDocument(Message reply, Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                reply.WriteMessage(writer);
                writer.Flush();
            }
            stream.Position = 0;
            doc.Load(stream);
            return ResponseDocument.Load(doc);
        }
    }
}

using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Affecto.Wcf.Behaviors.Tests
{
    [TestClass]
    public class ResponseDocumentTests
    {
        private ResponseDocument sut;
        private XmlDocument document;

        [TestMethod]
        public void RemoveBodyChildNodeNamespacesWhenAllChildrenHaveNamespace()
        {
            CreateSut("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><ts1:request/><ts1:response><ts1:data>30</ts1:data></ts1:response></ts1:getRandomResponse></SOAP-ENV:Body></SOAP-ENV:Envelope>");

            sut.RemoveReturnDataNamespaces();

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><request /><response><data>30</data></response></ts1:getRandomResponse></SOAP-ENV:Body></SOAP-ENV:Envelope>", sut.Document.OuterXml);
        }

        [TestMethod]
        public void RemoveBodyChildNodeNamespacesWhenSomeChildrenHaveNamespace()
        {
            CreateSut("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><request/><ts1:response><data>30</data></ts1:response></ts1:getRandomResponse></SOAP-ENV:Body></SOAP-ENV:Envelope>");

            sut.RemoveReturnDataNamespaces();

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><request /><response><data>30</data></response></ts1:getRandomResponse></SOAP-ENV:Body></SOAP-ENV:Envelope>", sut.Document.OuterXml);
        }

        [TestMethod]
        public void RemoveBodyChildNodeNamespacesWhenNoChildrenHaveNamespace()
        {
            CreateSut("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><request/><response><data>30</data></response></ts1:getRandomResponse></SOAP-ENV:Body></SOAP-ENV:Envelope>");

            sut.RemoveReturnDataNamespaces();

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><request /><response><data>30</data></response></ts1:getRandomResponse></SOAP-ENV:Body></SOAP-ENV:Envelope>", sut.Document.OuterXml);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThereIsNoBody()
        {
            CreateSut("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header></SOAP-ENV:Envelope>");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThereIsNoMethodInBody()
        {
            CreateSut("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body></SOAP-ENV:Body></SOAP-ENV:Envelope>");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThereAreMultipleMethodsInBody()
        {
            CreateSut("<?xml version=\"1.0\" encoding=\"utf-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:id=\"http://x-road.eu/xsd/identifiers\" xmlns:xrd=\"http://x-road.eu/xsd/xroad.xsd\"><SOAP-ENV:Header><xrd:client id:objectType=\"SUBSYSTEM\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>COM</id:memberClass><id:memberCode>1867931-4</id:memberCode><id:subsystemCode>affecto</id:subsystemCode></xrd:client><xrd:service id:objectType=\"SERVICE\"><id:xRoadInstance>FI-DEV</id:xRoadInstance><id:memberClass>GOV</id:memberClass><id:memberCode>0245437-2</id:memberCode><id:subsystemCode>TestService</id:subsystemCode><id:serviceCode>getRandom</id:serviceCode><id:serviceVersion>v1</id:serviceVersion></xrd:service><xrd:userId>test</xrd:userId><xrd:id>ID11234</xrd:id><xrd:protocolVersion>4.0</xrd:protocolVersion><xrd:requestHash algorithmId=\"http://www.w3.org/2001/04/xmlenc#sha512\">Vjced04fZMrA/f66e5NGdbTGPYe7NnnYC2UV7pou7Ttn4AacAFALF1CGi5cVlliluzu49tAenMvtWoHJW7o2jw==</xrd:requestHash></SOAP-ENV:Header><SOAP-ENV:Body><ts1:getRandomResponse xmlns:ts1=\"http://test.x-road.fi/producer\"><request /><response><data>30</data></response></ts1:getRandomResponse><method2><value>10</value></method2></SOAP-ENV:Body></SOAP-ENV:Envelope>");
        }

        private void CreateSut(string xml)
        {
            document = new XmlDocument();
            document.LoadXml(xml);
            sut = ResponseDocument.Load(document);
        }
    }
}

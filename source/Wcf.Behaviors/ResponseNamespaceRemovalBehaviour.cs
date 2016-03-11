using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Affecto.Wcf.Behaviors
{
    public class ResponseNamespaceRemovalBehaviour : BehaviorExtensionElement, IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ResponseNamespaceRemover());
        }

        protected override object CreateBehavior()
        {
            return new ResponseNamespaceRemovalBehaviour();
        }

        public override Type BehaviorType => GetType();
    }
}

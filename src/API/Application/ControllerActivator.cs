using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace API.Application
{
    public class ControllerActivator : IHttpControllerActivator
    {
        private IContainer _container;

        public ControllerActivator(IContainer container)
        {
            _container = container;
        }
        
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            request.RegisterForDispose(_container);

            var controller = (IHttpController)_container.GetInstance(controllerType);

            return controller;
        }
    }
}
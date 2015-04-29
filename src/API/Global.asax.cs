using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using API.Application;
using ShortBus;
using ShortBus.StructureMap;
using StructureMap;
using ShortBus.StructureMap;
using StructureMap;
using StructureMap.Graph;
using IDependencyResolver = ShortBus.IDependencyResolver;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectFactory.Initialize(init =>
            {
                init.Scan(x =>
                {
                    x.AssemblyContainingType(typeof(IAsyncRequestHandler<,>));
                    x.AssemblyContainingType(typeof(IAsyncRequest<>));

                    x.Assembly("Core");
                    x.LookForRegistries();

                    x.WithDefaultConventions();
                    x.TheCallingAssembly();
                    x.AddAllTypesOf(typeof(IAsyncRequest<>));
                    x.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                    x.AddAllTypesOf(typeof(INotificationHandler<>));
                    x.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
                });
                init.For<IDependencyResolver>().Use<ShortBus.StructureMap.StructureMapDependencyResolver>();
                init.Policies.SetAllProperties(x => x.OfType<API.Application.IMediator>());
            });

            Debug.WriteLine(ObjectFactory.Container.WhatDoIHave());
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

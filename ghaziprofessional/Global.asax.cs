using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ghaziprofessional
{

public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SF = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        SF = WebApplication3.helper.nhgenerator.GetSF();
        }


        public override void Init()
        {
            base.Init();
            this.BeginRequest += entrypoint;
            this.EndRequest += exitpoint;

        }

        private void entrypoint(object sender, EventArgs e)
        {
            /*
             Take NH Session
             Give it to Request

                 */

            CurrentSessionContext.Bind(SF.OpenSession());

        }

        private void exitpoint(object sender, EventArgs e)
        {
            /*
             Take session back from request
             dispose/close that session
               */

            ISession S = CurrentSessionContext.Unbind(SF);
            S.Dispose();
        }
    }} 

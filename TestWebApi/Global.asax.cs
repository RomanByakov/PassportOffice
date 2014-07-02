// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Akvelon">
//    Copyright (c) Akvelon. All rights reserved.
// </copyright>
// <summary>
//   The global.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestWebApi
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Routing;

    /// <summary>
    ///     The global.
    /// </summary>
    public class Global : HttpApplication
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}", 
                defaults: new { id = RouteParameter.Optional });
            routes.MapPageRoute("Default", "WebForm/{id}", "~/WebForm.aspx");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The application_ start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="Akvelon">
//   Copyright (c) Akvelon. All rights reserved.
// </copyright>
// <summary>
//   Controller
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TestWebApi
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Script.Serialization;

    using BusinessLayer;

    /// <summary>
    ///     Controller
    /// </summary>
    public class PassportController : ApiController
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="json">
        /// The json.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Passport> Get(string json, int id)
        {
            Passport passport = new JavaScriptSerializer().Deserialize<Passport>(json);
            List<Passport> pas = new List<Passport>();
            pas = PassportRepository.FindPersons(passport, id);
            return pas;
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Passport> Post(Passport data)
        {
            List<Passport> pass = new List<Passport>();

            // pass = PassportRepository.FindPersons(data);
            return pass;
        }

        #endregion
    }
}
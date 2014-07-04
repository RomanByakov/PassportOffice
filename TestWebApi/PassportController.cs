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
        /// <param name="passportObjectJson">
        /// The passport Object Json.
        /// </param>
        /// <param name="sort">
        /// The sort.
        /// </param>
        /// <param name="direction">
        /// The direction.
        /// </param>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Passport> GetPassports(string passportObjectJson, int sort, bool direction, int skip)
        {
            Passport passport = new JavaScriptSerializer().Deserialize<Passport>(passportObjectJson);
            List<Passport> pas = new List<Passport>();
            pas = PassportRepository.FindPassports(passport, sort, direction, skip);
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
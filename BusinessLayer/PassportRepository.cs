// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassportRepository.cs" company="Akvelon">
//   Copyright (c) Akvelon. All rights reserved.
// </copyright>
// <summary>
//   The passport repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    ///     The passport repository.
    /// </summary>
    public class PassportRepository
    {
        #region Static Fields

        /// <summary>
        ///     The cs.
        /// </summary>
        private static string cs = "data source = O91;database = PassOffice; integrated security = SSPI";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The connect.
        /// </summary>
        public static void Connect()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
        }

        /// <summary>
        /// The find persons.
        /// </summary>
        /// <param name="passport">
        /// The passport.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Passport> FindPersons(Passport passport, int sort)
        {
            List<Passport> list = new List<Passport>();

            using (var db = new PassportContext())
            {
                IQueryable<Passport> query = db.Passports;
                switch (sort)
                {
                    case 1:
                        query = db.Passports.OrderBy(a => a.Name);
                        break;
                    case 2:
                        query = db.Passports.OrderBy(a => a.Surname);
                        break;
                    case 3:
                        query = db.Passports.OrderBy(a => a.Patronymic);
                        break;
                    case 4:
                        query = db.Passports.OrderBy(a => a.PassportNumber);
                        break;
                    case 5:
                        query = db.Passports.OrderBy(a => a.Sex);
                        break;
                    case 6:
                        query = db.Passports.OrderBy(a => a.Birthday);
                        break;
                    case 7:
                        query = db.Passports.OrderBy(a => a.City);
                        break;
                    case 8:
                        query = db.Passports.OrderBy(a => a.Address);
                        break;
                    case 9:
                        query = db.Passports.OrderBy(a => a.IssuedBy);
                        break;
                    case 10:
                        query = db.Passports.OrderBy(a => a.DateOfIssue);
                        break;
                    case 11:
                        query = db.Passports.OrderBy(a => a.Code);
                        break;
                }
                if (passport.Name != string.Empty)
                {
                    query = query.Where(a => a.Name.Contains(passport.Name));
                }

                if (passport.Surname != string.Empty)
                {
                    query = query.Where(a => a.Surname.Contains(passport.Surname));
                }

                if (passport.Patronymic != string.Empty)
                {
                    query = query.Where(a => a.Patronymic.Contains(passport.Patronymic));
                }

                if (passport.PassportNumber != string.Empty)
                {
                    query = query.Where(a => a.PassportNumber.Contains(passport.PassportNumber));
                }

                if (passport.Sex != string.Empty)
                {
                    query = query.Where(a => a.Sex.Contains(passport.Sex));
                }

                if (passport.Birthday != new DateTime())
                {
                    query = query.Where(a => a.Birthday.CompareTo(passport.Birthday) == 0);
                }

                if (passport.City != string.Empty)
                {
                    query = query.Where(a => a.City.Contains(passport.City));
                }

                if (passport.Address != string.Empty)
                {
                    query = query.Where(a => a.Address.Contains(passport.Address));
                }

                if (passport.IssuedBy != string.Empty)
                {
                    query = query.Where(a => a.IssuedBy.Contains(passport.IssuedBy));
                }

                if (passport.DateOfIssue != new DateTime())
                {
                    query = query.Where(a => a.DateOfIssue.CompareTo(passport.DateOfIssue) == 0);
                }

                if (passport.Code != string.Empty)
                {
                    query = query.Where(a => a.Code.Contains(passport.Code));
                }

                foreach (var item in query)
                {
                    list.Add(
                        new Passport
                            {
                                Name = item.Name,
                                Surname = item.Surname,
                                Address = item.Address,
                                Birthday = item.Birthday,
                                Patronymic = item.Patronymic,
                                PassportNumber = item.PassportNumber,
                                Sex = item.Sex,
                                City = item.City,
                                IssuedBy = item.IssuedBy,
                                DateOfIssue = item.DateOfIssue,
                                Code = item.Code
                            });
                }


                return list;
            }

            #endregion
        }
    }
}
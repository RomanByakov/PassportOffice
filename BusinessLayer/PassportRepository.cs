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
    using System.Linq;

    /// <summary>
    ///     The passport repository.
    /// </summary>
    public class PassportRepository
    {
        #region Public Methods and Operators

        /// <summary>
        /// The find persons.
        /// </summary>
        /// <param name="passport">
        /// The passport.
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
        public static List<Passport> FindPassports(Passport passport, int sort, bool direction, int skip)
        {
            List<Passport> list = new List<Passport>();

            using (var db = new PassportContext())
            {
                // IQueryable<Passport> query = db.Passports;
                foreach (var item in GenerateQuery(passport, Sorting(sort, direction)).Skip(skip).Take(20))
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
        }

        #endregion

        #region Methods

        /// <summary>
        /// The generate query.
        /// </summary>
        /// <param name="passport">
        /// The passport.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        private static IQueryable<Passport> GenerateQuery(Passport passport, IQueryable<Passport> query)
        {
            var db = new PassportContext();
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

            return query;
        }

        /// <summary>
        /// The sorting.
        /// </summary>
        /// <param name="sort">
        /// Сolumn that sort
        /// </param>
        /// <param name="direction">
        /// Ascending or Descending direction
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        private static IQueryable<Passport> Sorting(int sort, bool direction)
        {
            var db = new PassportContext();
            IQueryable<Passport> query = db.Passports;
            switch (sort)
            {
                case (int)Cells.Name:
                    query = direction ? db.Passports.OrderBy(a => a.Name) : db.Passports.OrderByDescending(a => a.Name);
                    break;
                case (int)Cells.Surname:
                    query = direction
                                ? db.Passports.OrderBy(a => a.Surname)
                                : db.Passports.OrderByDescending(a => a.Surname);
                    break;
                case (int)Cells.Patronymic:
                    query = direction
                                ? db.Passports.OrderBy(a => a.Patronymic)
                                : db.Passports.OrderByDescending(a => a.Patronymic);
                    break;
                case (int)Cells.PassportNumber:
                    query = direction
                                ? db.Passports.OrderBy(a => a.PassportNumber)
                                : db.Passports.OrderByDescending(a => a.PassportNumber);
                    break;
                case (int)Cells.Sex:
                    query = direction ? db.Passports.OrderBy(a => a.Sex) : db.Passports.OrderByDescending(a => a.Sex);
                    break;
                case (int)Cells.Birthday:
                    query = direction
                                ? db.Passports.OrderBy(a => a.Birthday)
                                : db.Passports.OrderByDescending(a => a.Birthday);
                    break;
                case (int)Cells.City:
                    query = direction ? db.Passports.OrderBy(a => a.City) : db.Passports.OrderByDescending(a => a.City);
                    break;
                case (int)Cells.Address:
                    query = direction
                                ? db.Passports.OrderBy(a => a.Address)
                                : db.Passports.OrderByDescending(a => a.Address);
                    break;
                case (int)Cells.IssuedBy:
                    query = direction
                                ? db.Passports.OrderBy(a => a.IssuedBy)
                                : db.Passports.OrderByDescending(a => a.IssuedBy);
                    break;
                case (int)Cells.DateOfIssue:
                    query = direction
                                ? db.Passports.OrderBy(a => a.DateOfIssue)
                                : db.Passports.OrderByDescending(a => a.DateOfIssue);
                    break;
                case (int)Cells.Code:
                    query = direction ? db.Passports.OrderBy(a => a.Code) : db.Passports.OrderByDescending(a => a.Code);
                    break;
            }

            return query;
        }

        #endregion
    }
}
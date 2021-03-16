﻿using NHibernate;
using System;
using ZadanieRekrutacyjne.Domain;

namespace ZadanieRekrutacyjne
{
    class NHibernatePersonRepository : IPersonRepository
    {
        public void Save(Person person)
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(person);
                    transaction.Commit();
                }
            }
        }

        public Person Get(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Person>(id);
            }
        }

        public void Update(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(person);
                    transaction.Commit();
                }
            }
        }

        public void Delete(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(person);
                    transaction.Commit();
                }
            }
        }

        public long RowCount()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Person>().RowCountInt64();
            }
        }
    }
}
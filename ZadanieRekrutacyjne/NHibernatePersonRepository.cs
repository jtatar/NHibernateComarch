using NHibernate;
using System;
using System.Linq;
using ZadanieRekrutacyjne.Domain;

namespace ZadanieRekrutacyjne
{
    public class NHibernatePersonRepository : IPersonRepository
    {
        public void Save(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
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

        public void Delete(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var person = session.Get<Person>(id);
                    session.Delete(person);
                    transaction.Commit();

                }
            }
        }

        public Person[] GetByAge(int age)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQueryable<Person> people = session.Query<Person>()
                       .Where(c => c.Age == age);
                    return people.ToArray();

                }
            }
        }

        public Person[] GetOldest(int amount)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQueryable<Person> people = session.Query<Person>()
                        .OrderByDescending(c => c.Age)
                        .Take(amount);
                    return people.ToArray();
                }
            }
        }

        public Person[] GetAllWithoutOldest(int amountToSkip)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQueryable<Person> people = session.Query<Person>()
                        .OrderByDescending(c => c.Age)
                        .Skip(amountToSkip);
                    return people.ToArray();

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

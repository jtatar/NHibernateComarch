using NHibernate;
using System;
using System.Linq;
using ZadanieRekrutacyjne.Domain;

namespace ZadanieRekrutacyjne
{
    public class NHibernatePersonRepository : IPersonRepository
    {
        public Guid Save(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return SavePerson(person, session, transaction);
                }
            }
        }

        public Person Get(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return GetPerson(id, session);
            }
        }

        public Person Update(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return UpdatePerson(person, session, transaction);
                }
            }
        }

        public Boolean Delete(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return DeletePerson(id, session, transaction);
                }
            }
        }

        public Person[] GetByAge(int age)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return GetPeopleByAge(age, session, transaction);
                }
            }
        }

        public Person[] GetOldest(int amount)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return GetOldestPeople(amount, session, transaction);
                }
            }
        }

        public Person[] GetAllWithoutOldest(int amountToSkip)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return GetAllPeopleWithoutOldest(amountToSkip, session, transaction);
                }
            }
        }

        private Guid SavePerson(Person person, ISession session, ITransaction transaction)
        {
            try
            {
                Guid id = (Guid)session.Save(person);
                transaction.Commit();
                return id;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        private Person GetPerson(Guid id, ISession session)
        {
            try
            {
                return session.Get<Person>(id);
            }
            catch
            {
                return new Person { Id = Guid.Empty };
            }
        }

        private Person UpdatePerson(Person person, ISession session, ITransaction transaction)
        {
            try
            {
                session.Update(person);
                Person updatedPerson = session.Get<Person>(person.Id);
                if (updatedPerson.Id == person.Id && updatedPerson.FirstName == person.FirstName && updatedPerson.LastName == person.LastName && updatedPerson.Age == person.Age)
                {
                    transaction.Commit();
                    return updatedPerson;
                }
                else
                {
                    transaction.Rollback();
                    return new Person { Id = Guid.Empty };
                }
            }
            catch
            {
                return new Person { Id = Guid.Empty };
            }
        }

        private Boolean DeletePerson(Guid id, ISession session, ITransaction transaction)
        {
            try
            {
                Person person = session.Get<Person>(id);
                session.Delete(person);
                transaction.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Person[] GetPeopleByAge(int age, ISession session, ITransaction transaction)
        {
            try
            {
                IQueryable<Person> people = session.Query<Person>()
                   .Where(c => c.Age == age);
                return people.ToArray();

            }
            catch
            {
                return new Person[0];
            }
        }

        private Person[] GetOldestPeople(int amount, ISession session, ITransaction transaction)
        {
            try
            {
                IQueryable<Person> people = session.Query<Person>()
                    .OrderByDescending(c => c.Age)
                    .Take(amount);
                return people.ToArray();
            }
            catch
            {
                return new Person[0];
            }
        }

        private Person[] GetAllPeopleWithoutOldest(int amountToSkip, ISession session, ITransaction transaction)
        {
            try
            {
                IQueryable<Person> people = session.Query<Person>()
                    .OrderByDescending(c => c.Age)
                    .Skip(amountToSkip);
                return people.ToArray();
            }
            catch
            {
                return new Person[0];
            }
        }
    }
}

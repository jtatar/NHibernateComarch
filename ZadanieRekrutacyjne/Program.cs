using System.Xml.Serialization;
using NHibernate.Mapping.ByCode;
using System;
using ZadanieRekrutacyjne.Domain;
using ZadanieRekrutacyjne.Mappings;

namespace ZadanieRekrutacyjne
{
    public class Program
    {
        private static Program _instance;
        private static IPersonRepository _personRepo;

        public static Program GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Program();
            }
            return _instance;
        }

        public IPersonRepository GetPersonRepo()
        {
            if (_personRepo == null)
            {
                _personRepo = new NHibernatePersonRepository();
            }
            return _personRepo;
        }
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "New",
                LastName = "Kees",
                Age = 25
            };

            IPersonRepository _personRepo;

            _personRepo = new NHibernatePersonRepository();
            _personRepo.Save(person);
            Console.WriteLine(person.Id);
        }
    }
}

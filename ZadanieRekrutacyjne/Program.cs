using System.Xml.Serialization;
using NHibernate.Mapping.ByCode;
using System;
using ZadanieRekrutacyjne.Domain;
using ZadanieRekrutacyjne.Mappings;

namespace ZadanieRekrutacyjne
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var person = new Person
            {
                FirstName = "Test",
                LastName = "Kees",
                Age = 25
            };

            IPersonRepository _personRepo;

            _personRepo = new NHibernatePersonRepository();
            _personRepo.Save(person);
            Console.WriteLine(person.Id);
            Console.WriteLine("Hello World!");
        }
    }
}

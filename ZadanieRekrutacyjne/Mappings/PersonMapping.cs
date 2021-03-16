using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ZadanieRekrutacyjne.Domain;

namespace ZadanieRekrutacyjne.Mappings
{
    public class PersonMapping: ClassMapping<Person>
    {
        public PersonMapping()
        {
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.FirstName);
            Property (x => x.LastName);
            Property(x => x.Age);
        }
    }
}

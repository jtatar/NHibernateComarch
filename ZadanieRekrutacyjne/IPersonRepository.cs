using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieRekrutacyjne.Domain;

namespace ZadanieRekrutacyjne
{
    public interface IPersonRepository
    {
        Person Get(Guid id);
        Guid Save(Person person);
        Person Update(Person person);
        Boolean Delete(Guid id);
        Person[] GetByAge(int age);
        Person[] GetOldest(int amount);
        Person[] GetAllWithoutOldest(int amountToSkip);
    }
}

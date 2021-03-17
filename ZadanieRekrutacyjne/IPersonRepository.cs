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
        void Save(Person person);
        void Update(Person person);
        void Delete(Guid id);
        long RowCount();
        Person[] GetByAge(int age);
        Person[] GetOldest(int amount);
        Person[] GetAllWithoutOldest(int amountToSkip);
    }
}

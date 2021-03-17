namespace ZadanieRekrutacyjne
{
    public class NhibernateMain
    {
        private static NhibernateMain _instance;
        private static IPersonRepository _personRepo;

        public static void Main(string[] args)
        {
        }

        public static NhibernateMain GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NhibernateMain();
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
    }
}

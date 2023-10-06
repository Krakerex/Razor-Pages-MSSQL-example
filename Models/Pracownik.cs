namespace _19705_Zadanie_C_.Models
{
    /// <summary>
    /// Model reprezentujący tabelę Pracownik w bazie danych.
    /// </summary>
    public class Pracownik
    {
        public long? ID { get; set; }
        public string Imie { get; set; }
        public string ImieDrugie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string DataUrodzenia { get; set; }
        public string MiejsceUrodzenia { get; set; }
        public long? User_Id { get; set; }
        public Pracownik(long? iD, string imie, string imieDrugie, string nazwisko, string pesel, string dataUrodzenia, string miejsceUrodzenia, long? user_Id)
        {
            ID = iD;
            Imie = imie;
            ImieDrugie = imieDrugie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            DataUrodzenia = dataUrodzenia;
            MiejsceUrodzenia = miejsceUrodzenia;
            User_Id = user_Id;
        }
        public Pracownik()
        {

        }
    }
}

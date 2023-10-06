namespace _19705_Zadanie_C_.Models
{
    /// <summary>
    /// Model reprezentujący tabelę Adres w bazie danych.
    /// </summary>
    public class Adres
    {
        public long? ID { get; set; }
        public long? Pracownik_Id { get; set; }
        public string KodPocztowy { get; set; }
        public string Gmina { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string NrLokalu { get; set; }
        public Adres(long? iD, long? pracownik_Id, string kodPocztowy, string gmina, string miasto, string ulica, string nrDomu, string nrLokalu)
        {
            ID = iD;
            Pracownik_Id = pracownik_Id;
            KodPocztowy = kodPocztowy;
            Gmina = gmina;
            Miasto = miasto;
            Ulica = ulica;
            NrDomu = nrDomu;
            NrLokalu = nrLokalu;
        }
        public Adres()
        {

        }
    }
}

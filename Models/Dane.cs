namespace _19705_Zadanie_C_.Models
{
    /// <summary>
    /// Model reprezentujący tabelę DaneSluzbowe w bazie danych.
    /// </summary>
    public class Dane
    {
        public int? ID { get; set; }
        public long? Pracownik_Id { get; set; }
        public string Etat { get; set; }
        public string Stanowisko { get; set; }
        public string Stawka { get; set; }
        public string DataZatrudnienia { get; set; }
        public string DataKoncaUmowyTerminowej { get; set; }

        public Dane(int? iD, long? pracownik_Id, string etat, string stanowisko, string stawka, string dataZatrudnienia, string dataKoncaUmowyTerminowej)
        {
            ID = iD;
            Pracownik_Id = pracownik_Id;
            Etat = etat;
            Stanowisko = stanowisko;
            Stawka = stawka;
            DataZatrudnienia = dataZatrudnienia;
            DataKoncaUmowyTerminowej = dataKoncaUmowyTerminowej;
        }
        public Dane() { }
    }
}
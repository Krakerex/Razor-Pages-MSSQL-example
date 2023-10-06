using System.Data;
using System.Data.SqlClient;

namespace _19705_Zadanie_C_
{/// <summary>
///  Zawiera metody odpowiedzialne za komunikację z bazą danych, wykorzystuje: <br/>
///  <see cref="SqlDataReader"/><br/>
///  <see cref="SqlConnection"/> <br/>
///  <see cref="SqlCommand"/><br/>
/// </summary>
    public class Database
    {
        /// <summary>
        /// Zawiera connection string dla używanej bazy danych
        /// </summary>
        public static string connectionString = "Data Source=IP-PRAK02\\SQLEXPRESS;Initial Catalog=PortalPraktykanci;Integrated Security=True";
        /// <summary>
        /// Służy do pobierania danych użytkownika, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <returns>Zwraca <see cref="SqlDataReader"/> zawierający dane z tabeli Pracownik użytkownika o ID <see cref="Użytkownik.userID"/></returns>
        public static SqlDataReader getUser()
        {
            SqlConnection conn = new SqlConnection();
            string query = "select * from Pracownik where Id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Użytkownik.userID);
            SqlDataReader reader;

            return reader = Database.DatabaseRead(cmd, conn);

        }
        /// <summary>
        /// Służy do pobierania danych zalogowanego użytkownika z tabeli Adres, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <returns>Zwraca <see cref="SqlDataReader"/> zawierający dane z tabeli Adres zalogowanego użytkownika</returns>
        public static SqlDataReader getAdres()
        {
            SqlConnection conn = new SqlConnection();
            string query = "select * from Adres where Pracownik_Id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Użytkownik.userID);
            SqlDataReader reader;
            return reader = Database.DatabaseRead(cmd, conn);

        }
        /// <summary>
        /// Służy do pobierania danych użytkowników z tabeli Adres, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <returns>Zwraca <see cref="SqlDataReader"/> zawierający wszystkie dane z tabeli Pracownik</returns>
        public static SqlDataReader getAdresy()
        {
            SqlConnection conn = new SqlConnection();
            string query = "select * from Adres";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            return reader = Database.DatabaseRead(cmd, conn);

        }
        /// <summary>
        /// Służy do pobierania danych użytkowników z tabeli DaneSluzbowe, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <returns>Zwraca <see cref="SqlDataReader"/> zawierający dane z tabeli DaneSluzbowe zalogowanego użytkownika</returns>
        public static SqlDataReader getDane()
        {
            SqlConnection conn = new SqlConnection();
            string query = "select * from DaneSluzbowe where Pracownik_Id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Użytkownik.userID);
            SqlDataReader reader;
            return reader = Database.DatabaseRead(cmd, conn);

        }
        /// <summary>
        /// Wykonuje zapytanie <paramref name="cmd"/> na połączeniu <paramref name="conn"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="cmd">Obiekt <see cref="SqlCommand"/> zawierający zapytanie</param>
        /// <param name="conn">Obiekt <see cref="SqlConnection"/> na którym zostanie wykonane połączenie z bazą</param>
        /// <returns>Zwraca obiekt <see cref="SqlDataReader"/> zawierający dane uzyskane z wykonania zapytania</returns>
        public static SqlDataReader DatabaseRead(SqlCommand cmd, SqlConnection conn)
        {
            SqlDataReader reader;
            conn.ConnectionString = connectionString;
            conn.Open();
            reader = cmd.ExecuteReader();
            return reader;

        }
        /// <summary>
        /// Wykonuje UPDATE na rekodrdzie o ID zalogowanego użykownika w tabeli Pracownik na podstawie obiektu <see cref="Models.Pracownik"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="pracownik">Obiekt <see cref="Models.Pracownik"/> zawierający nowe dane rekordu</param>
        /// <returns>Zwraca ilość zmodyfikowanych wierszy</returns>
        public static int setUser(Models.Pracownik pracownik)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            string query = "Update Pracownik set " +
                " Imie=@imie," +
                " ImieDrugie=@imiedrugie," +
                " Nazwisko=@nazwisko," +
                " Pesel=@pesel," +
                " DataUrodzenia=@dataurodzenia," +
                " MiejsceUrodzenia=@miejsceurodzenia," +
                " User_Id=@userid where id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@imie", pracownik.Imie);
            cmd.Parameters.AddWithValue("@imiedrugie", pracownik.ImieDrugie);
            cmd.Parameters.AddWithValue("@nazwisko", pracownik.Nazwisko);
            cmd.Parameters.AddWithValue("@pesel", pracownik.Pesel);
            cmd.Parameters.AddWithValue("@dataurodzenia", pracownik.DataUrodzenia);
            cmd.Parameters.AddWithValue("@miejsceurodzenia", pracownik.MiejsceUrodzenia);
            cmd.Parameters.AddWithValue("@userid", pracownik.User_Id);
            cmd.Parameters.AddWithValue("@id", Użytkownik.userID);
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Wykonuje UPDATE na rekodrdzie o ID zalogowanego użykownika w tabeli Adres na podstawie obiektu <see cref="Models.Adres"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="adres">Obiekt <see cref="Models.Adres"/> zawierający nowe dane rekordu</param>
        /// <returns>Zwraca ilość zmodyfikowanych wierszy</returns>
        public static int setAdres(Models.Adres adres)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            string query = "Update Adres set " +
                " KodPocztowy=@kodpocztowy," +
                " Gmina=@gmina," +
                " Miasto=@miasto," +
                " Ulica=@ulica," +
                " NrDomu=@nrdomu," +
                " NrLokalu=@nrlokalu where Pracownik_Id=@idd";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@kodpocztowy", adres.KodPocztowy);
            cmd.Parameters.AddWithValue("@gmina", adres.Gmina);
            cmd.Parameters.AddWithValue("@miasto", adres.Miasto);
            cmd.Parameters.AddWithValue("@ulica", adres.Ulica);
            cmd.Parameters.AddWithValue("@nrdomu", adres.NrDomu);
            cmd.Parameters.AddWithValue("@nrlokalu", adres.NrLokalu);
            cmd.Parameters.AddWithValue("@idd", Użytkownik.userID);
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Wykonuje UPDATE na rekodrdzie o dowolnym ID w tabeli Adres na podstawie obiektu <see cref="Models.Adres"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="adres">Obiekt <see cref="Models.Adres"/> zawierający nowe dane rekordu</param>
        /// <param name="id"><see langword="int"/> wskazujący ID edytowanego rekordu</param>
        /// <returns></returns>
        public static int setAdres(Models.Adres adres, int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            string query = "Update Adres set " +
                " KodPocztowy=@kodpocztowy," +
                " Gmina=@gmina," +
                " Miasto=@miasto," +
                " Ulica=@ulica," +
                " NrDomu=@nrdomu," +
                " NrLokalu=@nrlokalu where Pracownik_Id=@idd";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@kodpocztowy", adres.KodPocztowy);
            cmd.Parameters.AddWithValue("@gmina", adres.Gmina);
            cmd.Parameters.AddWithValue("@miasto", adres.Miasto);
            cmd.Parameters.AddWithValue("@ulica", adres.Ulica);
            cmd.Parameters.AddWithValue("@nrdomu", adres.NrDomu);
            cmd.Parameters.AddWithValue("@nrlokalu", adres.NrLokalu);
            cmd.Parameters.AddWithValue("@idd", id);
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Wykonuje INSERT na rekodrdzie o ID zalogowanego użykownika w tabeli Adres na podstawie obiektu <see cref="Models.Adres"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="adres">Obiekt <see cref="Models.Adres"/> zawierający nowe dane rekordu</param>
        /// <returns>Ilość dodanych wierszy</returns>
        public static int addAdres(Models.Adres adres)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            string query = "INSERT INTO Adres(Pracownik_Id,KodPocztowy,Gmina,Miasto,Ulica,NrDomu,NrLokalu) VALUES (@pracid,@kodp,@gmina,@miasto,@ulica,@nrd,@nrl)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pracid", adres.Pracownik_Id);
            cmd.Parameters.AddWithValue("@kodp", adres.KodPocztowy);
            cmd.Parameters.AddWithValue("@gmina", adres.Gmina);
            cmd.Parameters.AddWithValue("@miasto", adres.Miasto);
            cmd.Parameters.AddWithValue("@ulica", adres.Ulica);
            cmd.Parameters.AddWithValue("@nrd", adres.NrDomu);
            cmd.Parameters.AddWithValue("@nrl", adres.NrLokalu);
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Wykonuje UPDATE na rekodrdzie o ID zalogowanego użytkownika w tabeli DaneSluzbowe na podstawie obiektu <see cref="Models.Dane"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="dane">Obiekt <see cref="Models.Dane"/> zawierający nowe dane rekordu</param>
        /// <returns>Ilość dodanych wierszy</returns>
        public static int setDane(Models.Dane dane)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            string query = "Update DaneSluzbowe set " +
                " Etat=@etat," +
                " Stanowisko=@stanowisko," +
                " Stawka=@stawka," +
                " DataZatrudnienia=@dataz," +
                " DataKoncaUmowyTerminowej=@datak where Pracownik_Id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@etat", dane.Etat);
            cmd.Parameters.AddWithValue("@stanowisko", dane.Stanowisko);
            cmd.Parameters.AddWithValue("@stawka", dane.Stawka);
            cmd.Parameters.AddWithValue("@dataz", dane.DataZatrudnienia);
            cmd.Parameters.AddWithValue("@datak", dane.DataKoncaUmowyTerminowej);
            cmd.Parameters.AddWithValue("@id", Użytkownik.userID);
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Wykonuje DELETE na rekodrdzie o dowolnym ID w tabeli Adres na podstawie obiektu parametru <paramref name="id"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="id"><see langword="long?"/>wskazujący ID rekordu do usunięcia</param>
        /// <returns>Ilość usuniętych wierszy</returns>
        public static int deleteAdres(long? id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            string query = "DELETE FROM Adres WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

    }
}

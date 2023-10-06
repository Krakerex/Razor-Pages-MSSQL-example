using System.Data.SqlClient;

namespace _19705_Zadanie_C_
{
    /// <summary>
    /// Reprezentuje zalogowanego użytkownika oraz obsługuje logowanie i wylogowywanie, wykorzystuje: <br/>
    ///  <see cref="SqlDataReader"/><br/>
    ///  <see cref="SqlConnection"/> <br/>
    ///  <see cref="SqlCommand"/><br/>
    /// </summary>
    public class Użytkownik
    {
        /// <summary>
        /// ID zalogowanego użytkownika
        /// </summary>
        public static long? userID;

        /// <summary>
        /// Sprawdza, czy w bazie danych istnieje użytkownik o zadanym <paramref name="username"/> i <paramref name="password"/>, wykorzystuje: <br/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        /// </summary>
        /// <param name="username">Zawiera nazwę użytkownika, porównywaną z polem Login w bazie</param>
        /// <param name="password">Zawiera hasło użytkownika, porównywaną z polem Password w bazie</param>
        /// <returns>Zwraca <see langword="int"/>:<br/>
        ///  0 - parametry nie zgadzają się z żadnym użytkownikiem <br/>
        ///  1 - użytkownik istnieje, ale pole status jest ustawione na 0 (nieaktywny)<br/>
        ///  2 - pomyślnie zalogowano
        /// </returns>
        public static int Login(string username, string password)
        {
            SqlConnection conn = new SqlConnection();
            string query = "select * from [User] where Login=@name and Password=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader rd = Database.DatabaseRead(cmd, conn);
            if (!rd.HasRows)
            {
                return 0;
            }
            else
            {
                rd.Read();
                bool status = rd.GetBoolean(rd.GetOrdinal("Status"));
                if (!status)
                {
                    return 1;

                }
                else
                {
                    Użytkownik.userID = rd.GetInt64(0);
                    return 2;


                }

            }
        }
    }

}

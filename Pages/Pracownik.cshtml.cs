using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace _19705_Zadanie_C_.Pages
{
    /// <summary>
    /// <see cref="PageModel"/> strony Pracownik, na której można wykonać operację Read oraz Update na tabeli Pracownik zalogowanego użytkownika
    /// </summary>
    public class PracownikModel : PageModel
    {
        /// <summary>
        /// przechowuje obiekt reprezentujący <see cref="Models.Pracownik"/>
        /// </summary>
        public Models.Pracownik pracowniks;

        /// <summary>
        /// Wysyła do klienta obiekt zawierający rekord o ID <see cref="Użytkownik.userID"/> z tabeli Pracownik używając <see cref="Database.getUser"/> przy zdarzeniu GET, wykorzystuje: <br/>
        ///  <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        ///  
        /// </summary>
        public void OnGet()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getUser();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                pracowniks = new Models.Pracownik
                    (reader.GetInt64(0),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader.GetInt64(7)
                    );
                ViewData["Pracownik"] = pracowniks;

            }

        }
        /// <summary>
        /// Wysyła do klienta obiekt zawierający rekord o ID <see cref="Użytkownik.userID"/> z tabeli Pracownik używając <see cref="Database.getUser"/> przy zdarzeniu POST, wykorzystuje: <br/>
        ///  <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        ///  
        /// </summary>
        public void OnPost()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getUser();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                pracowniks = new Models.Pracownik
                    (reader.GetInt64(0),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader.GetInt64(7)
                    );
                ViewData["Pracownik"] = pracowniks;

            }

        }
        /// <summary>
        /// Przygotowuje obiekt <see cref="Models.Pracownik"/> i używając <see cref="Database.setUser(Models.Pracownik)"/> aktualizuje tabelę Pracownik, po czym
        /// wysyła do klienta obiekt zawierający wszystkie rekordy z tabeli DaneSluzbowe, wykorzystuje: <br/>
        /// <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        /// </summary>
        public void OnPostEdit()
        {

            pracowniks = new Models.Pracownik();
            pracowniks.ID = Użytkownik.userID;
            pracowniks.Imie = Request.Form["1"];
            pracowniks.ImieDrugie = Request.Form["2"];
            pracowniks.Nazwisko = Request.Form["3"];
            pracowniks.Pesel = Request.Form["4"];
            pracowniks.DataUrodzenia = Request.Form["5"];
            pracowniks.MiejsceUrodzenia = Request.Form["6"];
            pracowniks.User_Id = Użytkownik.userID;
            ViewData["idw"] = Database.setUser(pracowniks);
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getUser();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                pracowniks = new Models.Pracownik
                    (reader.GetInt64(0),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader.GetInt64(7)
                    );
                ViewData["Pracownik"] = pracowniks;

            }

        }

    }
}


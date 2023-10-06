using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace _19705_Zadanie_C_.Pages
{
    /// <summary>
    /// <see cref="PageModel"/> strony DaneSluzbowe, na kt�rej mo�na wykona� operacj� Read oraz Update na tabeli DaneSluzbowe zalogowanego u�ytkownika
    /// </summary>
    public class DaneModel : PageModel
    {
        /// <summary>
        /// przechowuje obiekt reprezentuj�cy <see cref="Models.Dane"/>
        /// </summary>
        public Models.Dane dane;

        /// <summary>
        /// Wysy�a do klienta obiekt zawieraj�cy rekord o ID <see cref="U�ytkownik.userID"/> z tabeli DaneSluzbowe u�ywaj�c <see cref="Database.getDane"/> przy zdarzeniu GET, wykorzystuje: <br/>
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
            SqlDataReader reader = Database.getDane();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                dane = new Models.Dane
                    (reader.GetInt32(0),
                    reader.GetInt64(1),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString()
                    );
                ViewData["Dane"] = dane;

            }

        }
        /// <summary>
        /// Wysy�a do klienta obiekt zawieraj�cy rekord o ID <see cref="U�ytkownik.userID"/> z tabeli DaneSluzbowe u�ywaj�c <see cref="Database.getDane"/> przy zdarzeniu POST, wykorzystuje: <br/>
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
            SqlDataReader reader = Database.getDane();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                dane = new Models.Dane
                    (reader.GetInt32(0),
                    reader.GetInt64(1),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString()
                    );
                ViewData["Dane"] = dane;

            }

        }
        /// <summary>
        /// Przygotowuje obiekt <see cref="Models.Dane"/> i u�ywaj�c <see cref="Database.setDane(Models.Dane)"/> aktualizuje tabel� DaneSluzbowe, po czym
        /// wysy�a do klienta obiekt zawieraj�cy wszystkie rekordy z tabeli DaneSluzbowe, wykorzystuje: <br/>
        /// <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        /// </summary>
        public void OnPostEdit()
        {

            dane = new Models.Dane();
            dane.ID = (int)U�ytkownik.userID;
            dane.Pracownik_Id = U�ytkownik.userID;
            dane.Etat = Request.Form["2"];
            dane.Stanowisko = Request.Form["3"];
            dane.Stawka = Request.Form["4"];
            dane.DataZatrudnienia = Request.Form["5"];
            dane.DataKoncaUmowyTerminowej = Request.Form["6"];
            ViewData["idw"] = "Zmodyfikowano " + Database.setDane(dane) + " warto�ci";
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getDane();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                dane = new Models.Dane
                    (reader.GetInt32(0),
                    reader.GetInt64(1),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString()
                    );
                ViewData["Dane"] = dane;

            }

        }

    }
}


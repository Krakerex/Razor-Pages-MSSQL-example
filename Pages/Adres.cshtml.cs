using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace _19705_Zadanie_C_.Pages
{
    /// <summary>
    /// <see cref="PageModel"/> strony Adres, na której mo¿na wykonaæ operacjê Read oraz Update na tabeli Adres zalogowanego u¿ytkownika
    /// </summary>
    public class AdresModel : PageModel
    {
        /// <summary>
        /// przechowuje obiekt reprezentuj¹cy <see cref="Models.Adres"/>
        /// </summary>
        public Models.Adres adres;

        /// <summary>
        /// Wysy³a do klienta obiekt zawieraj¹cy rekord o ID <see cref="U¿ytkownik.userID"/> z tabeli Adres u¿ywaj¹c <see cref="Database.getAdres"/> przy zdarzeniu GET, wykorzystuje: <br/>
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
            SqlDataReader reader = Database.getAdres();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                adres = new Models.Adres
                    (reader.GetInt64(0),
                    reader.GetInt64(1),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString()
                    );
                ViewData["Adres"] = adres;

            }

        }
        /// <summary>
        /// Wysy³a do klienta obiekt zawieraj¹cy rekord o ID <see cref="U¿ytkownik.userID"/> z tabeli Adres u¿ywaj¹c <see cref="Database.getAdres"/> przy zdarzeniu POST, wykorzystuje: <br/>
        /// <see cref="Database"/>
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
            SqlDataReader reader = Database.getAdres();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                adres = new Models.Adres
                    (reader.GetInt64(0),
                    reader.GetInt64(1),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString()
                    );
                ViewData["Adres"] = adres;

            }

        }
        /// <summary>
        /// Przygotowuje obiekt <see cref="Models.Adres"/> i u¿ywaj¹c <see cref="Database.setAdres(Models.Adres)"/> aktualizuje tabelê Adres, po czym
        /// wysy³a do klienta obiekt zawieraj¹cy wszystkie rekordy z tabeli Adres, wykorzystuje: <br/>
        /// <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        /// </summary>
        public void OnPostEdit()
        {

            adres = new Models.Adres();
            adres.ID = Int64.Parse(Request.Form["0"]);
            adres.Pracownik_Id = U¿ytkownik.userID;
            adres.KodPocztowy = Request.Form["2"];
            adres.Gmina = Request.Form["3"];
            adres.Miasto = Request.Form["4"];
            adres.Ulica = Request.Form["5"];
            adres.NrDomu = Request.Form["6"];
            adres.NrLokalu = Request.Form["7"];
            ViewData["idw"] = "Zmodyfikowano " + Database.setAdres(adres) + " wartoœci";
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getAdres();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                adres = new Models.Adres
                    (reader.GetInt64(0),
                    reader.GetInt64(1),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString()
                    );
                ViewData["Adres"] = adres;

            }

        }

    }
}


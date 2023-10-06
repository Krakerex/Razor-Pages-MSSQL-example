using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace _19705_Zadanie_C_.Pages
{
    /// <summary>
    /// <see cref="PageModel"/> strony Admin, na kt�rej mo�na wykona� operacj� CRUD na tabeli Adres
    /// </summary>
    public class AdminModel : PageModel
    {
        /// <summary>
        /// przechowuje obiekt reprezentuj�cy <see cref="Models.Adres"/>
        /// </summary>
        public Models.Adres adres;
        /// <summary>
        /// Lista obiekt�w <see cref="Models.Adres"/> umo�liwiaj�ca edycj� wielu rekord�w naraz
        /// </summary>
        public List<Models.Adres> adresy = new List<Models.Adres>();

        /// <summary>
        /// Wysy�a do klienta obiekt zawieraj�cy wszystkie rekordy z tabeli Adres u�ywaj�c <see cref="Database.getAdresy"/> przy zdarzeniu GET, wykorzystuje: <br/>
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
            SqlDataReader reader = Database.getAdresy();
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
                adresy.Add(adres);
                ViewData["Adres"] = adres;

            }

        }
        /// <summary>
        /// Wysy�a do klienta obiekt zawieraj�cy wszystkie rekordy z tabeli Adres u�ywaj�c <see cref="Database.getAdresy"/> przy zdarzeniu POST, wykorzystuje: <br/>
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
            SqlDataReader reader = Database.getAdresy();
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
                adresy.Add(adres);
                ViewData["Adres"] = adres;

            }

        }
        /// <summary>
        /// Przygotowuje obiekt <see cref="Models.Adres"/> i u�ywaj�c <see cref="Database.setAdres(Models.Adres, int)"/> aktualizuje tabel� Adres, po czym
        /// wysy�a do klienta obiekt zawieraj�cy wszystkie rekordy z tabeli Adres, wykorzystuje: <br/>
        ///  <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        /// </summary>
        /// <param name="id">Parametr wskazuj�cy ID wiersza z tabeli na stronie, z kt�rej zostanie utworzony obiekt <see cref="Models.Adres"/></param>
        public void OnPostEdit(int id)
        {

            adres = new Models.Adres();
            adres.ID = Int64.Parse(Request.Form[(id + 0).ToString()]);
            adres.Pracownik_Id = Int64.Parse(Request.Form[(id + 1).ToString()]);
            adres.KodPocztowy = Request.Form[(id + 2).ToString()];
            adres.Gmina = Request.Form[(id + 3).ToString()];
            adres.Miasto = Request.Form[(id + 4).ToString()];
            adres.Ulica = Request.Form[(id + 5).ToString()];
            adres.NrDomu = Request.Form[(id + 6).ToString()];
            adres.NrLokalu = Request.Form[(id + 7).ToString()];
            ViewData["idw"] = "Zmodyfikowano " + Database.setAdres(adres, (int)adres.ID) + " warto�ci";
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getAdresy();
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
                adresy.Add(adres);
                ViewData["Adres"] = adres;

            }

        }
        /// <summary>
        /// Usuwa rekord z tabeli Adres u�ywaj�c <see cref="Database.deleteAdres"/>, po czym
        /// wysy�a do klienta obiekt zawieraj�cy wszystkie rekordy z tabeli Adres, wykorzystuje: <br/>
        /// <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        /// </summary>
        /// <param name="id">Parametr wskazuj�cy ID wiersza z tabeli na stronie, z kt�rej zostanie utworzony obiekt <see cref="Models.Adres"/></param>
        public void OnPostDelete(int id)
        {

            adres = new Models.Adres();
            adres.ID = Int64.Parse(Request.Form[(id + 0).ToString()]);
            ViewData["idw"] = "Usuni�to " + Database.deleteAdres(adres.ID) + " warto�ci";
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getAdresy();
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
                adresy.Add(adres);
                ViewData["Adres"] = adres;

            }

        }
        /// <summary>
        /// Dodaje nowy rekord do tabeli Adres u�ywaj�c <see cref="Database.addAdres"/>, po czym
        /// wysy�a do klienta obiekt zawieraj�cy wszystkie rekordy z tabeli Adres, wykorzystuje: <br/>
        /// <see cref="Database"/>
        ///  <see cref="SqlDataReader"/><br/>
        ///  <see cref="SqlConnection"/> <br/>
        ///  <see cref="SqlCommand"/><br/>
        ///  <see cref="List{T}" />
        /// </summary>
        /// <param name="id">Parametr wskazuj�cy ID wiersza z tabeli na stronie, z kt�rej zostanie utworzony obiekt <see cref="Models.Adres"/></param>
        public void OnPostAdd(int id)
        {

            adres = new Models.Adres(); ;
            adres.Pracownik_Id = Int64.Parse(Request.Form[(id + 1).ToString()]);
            adres.KodPocztowy = Request.Form[(id + 2).ToString()];
            adres.Gmina = Request.Form[(id + 3).ToString()];
            adres.Miasto = Request.Form[(id + 4).ToString()];
            adres.Ulica = Request.Form[(id + 5).ToString()];
            adres.NrDomu = Request.Form[(id + 6).ToString()];
            adres.NrLokalu = Request.Form[(id + 7).ToString()];
            ViewData["idw"] = "Dodano " + Database.addAdres(adres) + " rekord�w";
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader = Database.getAdresy();
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
                adresy.Add(adres);
                ViewData["Adres"] = adres;

            }

        }

    }
}


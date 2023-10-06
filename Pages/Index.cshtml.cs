using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _19705_Zadanie_C_.Pages
{
    /// <summary>
    /// <see cref="PageModel"/> strony Login, która obs³uguje logowanie u¿ytkowników u¿ywaj¹c <see cref="U¿ytkownik"/>
    /// </summary>
    public class LoginModel : PageModel
    {
        /// <summary>
        /// W momencie wywo³ania zdarzenia OnGetDelete wyœwietla komunikat i wylogowywuje u¿ytkownika czyszcz¹c dane za pomoc¹ <see cref="ISession.Clear"/>
        /// </summary>
        public void OnGetDelete()
        {
            ViewData["confirmation"] = "U¿ytkownik  wylogowany";
            HttpContext.Session.Clear();
        }

        /// <summary>
        /// Wywo³uje <see cref="U¿ytkownik.Login"/> u¿ywaj¹c danych pobranych z formularza na stronie Login i w zale¿noœci od zwróconej wartoœci:<br/>
        /// 0- Wysy³a komunikat ¿e u¿ytkownik nie istnieje <br/>
        /// 1- Wysy³a komunikat ¿e u¿ytkownik jest nieaktywny<br/>
        /// 2- Ustawia za pomoc¹ <see cref="SessionExtensions.SetString"/>  klucz username i przekierowuje na stronê Pracownik
        /// </summary>
        public void OnPost()
        {
            string name = Request.Form["login"];
            string password = Request.Form["password"];
            int Login = U¿ytkownik.Login(name, password);
            if (Login == 0)
            {
                ViewData["confirmation"] = "U¿ytkownik nie istnieje";
            }
            else if (Login == 1)
            {
                ViewData["confirmation"] = "U¿ytkownik nieaktywny";
            }
            else if (Login == 2)
            {
                HttpContext.Session.SetString("username", name);
                HttpContext.Response.Redirect("Pracownik");
            }

        }
    }
}

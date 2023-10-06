using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _19705_Zadanie_C_.Pages
{
    /// <summary>
    /// <see cref="PageModel"/> strony Login, kt�ra obs�uguje logowanie u�ytkownik�w u�ywaj�c <see cref="U�ytkownik"/>
    /// </summary>
    public class LoginModel : PageModel
    {
        /// <summary>
        /// W momencie wywo�ania zdarzenia OnGetDelete wy�wietla komunikat i wylogowywuje u�ytkownika czyszcz�c dane za pomoc� <see cref="ISession.Clear"/>
        /// </summary>
        public void OnGetDelete()
        {
            ViewData["confirmation"] = "U�ytkownik  wylogowany";
            HttpContext.Session.Clear();
        }

        /// <summary>
        /// Wywo�uje <see cref="U�ytkownik.Login"/> u�ywaj�c danych pobranych z formularza na stronie Login i w zale�no�ci od zwr�conej warto�ci:<br/>
        /// 0- Wysy�a komunikat �e u�ytkownik nie istnieje <br/>
        /// 1- Wysy�a komunikat �e u�ytkownik jest nieaktywny<br/>
        /// 2- Ustawia za pomoc� <see cref="SessionExtensions.SetString"/>  klucz username i przekierowuje na stron� Pracownik
        /// </summary>
        public void OnPost()
        {
            string name = Request.Form["login"];
            string password = Request.Form["password"];
            int Login = U�ytkownik.Login(name, password);
            if (Login == 0)
            {
                ViewData["confirmation"] = "U�ytkownik nie istnieje";
            }
            else if (Login == 1)
            {
                ViewData["confirmation"] = "U�ytkownik nieaktywny";
            }
            else if (Login == 2)
            {
                HttpContext.Session.SetString("username", name);
                HttpContext.Response.Redirect("Pracownik");
            }

        }
    }
}

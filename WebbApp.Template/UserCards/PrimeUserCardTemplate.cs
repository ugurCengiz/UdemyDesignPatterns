using System.Text;

namespace WebbApp.Template.UserCards
{
    public class PrimeUserCardTemplate:UserCardTemplate
    {
        protected override string SetFooter()
        {
            var sb = new StringBuilder();
            sb.Append($" <a href='#' class='card-link'>Mesaj gönder</a>");
            sb.Append($" <a href='#' class='card-link'>Detaylı Profil</a>");
            return sb.ToString();
        }

        protected override string SetPicture()
        {
            return $"<img class='card-img-top' src='{AppUser.PictureUrl}'>";
        }
    }
}

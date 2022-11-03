using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoginSystem.Web.MVC.Models
{
    public class UtilizadorRegisto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está com formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }
        [DisplayName("Confirme a sua password")]
        [Compare("Password", ErrorMessage = "As passwords não coincidem")]
        public string PasswordConfirmacao { get; set; }
    }

    public class UtilizadorLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} tem que ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UtilizadorRespostaLogin
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public Utilizadortoken UtilizadorToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }

    public class Utilizadortoken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public ICollection<Claim> Claims { get; set; }
    }

    public class Claim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}

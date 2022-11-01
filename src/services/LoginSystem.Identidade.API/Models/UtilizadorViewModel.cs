using System.ComponentModel.DataAnnotations;

namespace LoginSystem.Identidade.API.Models
{
    public class UtilizadorRegisto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está num formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} deverá ter entre {2} e {1} caracteres" ,MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As passwords não coincidem")]
        public string PasswordConfirmacao { get; set; }
    }

    public class UtilizadorLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está num formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} deverá ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UtilizadorRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UtilizadorToken UtilizadorToken { get; set; }
    }
    public class UtilizadorToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UtilizadorClaim> Claims { get; set; }
    }

    public class UtilizadorClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}

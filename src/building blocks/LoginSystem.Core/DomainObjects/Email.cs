using System.Net.Mail;

namespace LoginSystem.Core.DomainObjects
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;

        public string Endereco { get; private set; }

        protected Email() { } 

        public Email(string endereco)
        {
            if (!Validar(endereco)) throw new DomainException("E-mail inválido"); 
            Endereco = endereco;
        }

        public static bool Validar(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

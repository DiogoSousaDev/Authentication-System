namespace LoginSystem.Core.DomainObjects
{
    public class Nif
    {
        public const int NifMaxLength = 9;
        public string Numero { get; private set; }

        protected Nif(){}

        public Nif(string numero)
        {
            if (!Validar(numero)) throw new DomainException("O NIF não é válido");
            Numero = numero;
        }

        public static bool Validar(string Numero)
        {
            return true;
        }
    }
}

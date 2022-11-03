namespace LoginSystem.Web.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }


    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public List<string> Mensagens { get; set; }
    }

}
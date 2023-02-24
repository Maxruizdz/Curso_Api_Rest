namespace Curso_Api_Rest.Services
{
    public class HelloWordServices: IHelloWordService
    {
        public string GetHelloWorld() {



            return "Hello Word";
        
        }

    }


    public interface IHelloWordService {


        string GetHelloWorld();
    
    
    }
}

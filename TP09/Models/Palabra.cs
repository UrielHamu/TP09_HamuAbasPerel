using Newtonsoft.Json;
public class Palabra
{
     public string texto;
   public int dificultad;

       public Palabra(string texto, int dificultad)
    {
        this.texto = texto;
        this.dificultad = dificultad;
    }

}
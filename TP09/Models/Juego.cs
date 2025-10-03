using Newtonsoft.Json;
public class Juego
{
    [JsonProperty]
    List<Palabra> listPalabra;

    [JsonProperty]
    List<Usuario> jugadores;

    [JsonProperty]
    Usuario jugadorActual;

    private int dificultad;

    private void LlenarListaPalabras()
    {
        listPalabra = new List<Palabra>
        {
            new Palabra("sol", 1),
            new Palabra("luna", 1),
            new Palabra("gato", 1),
            new Palabra("perro", 1),
            new Palabra("flor", 1),
            new Palabra("agua", 1),
            new Palabra("pan", 1),
            new Palabra("rojo", 1),
            new Palabra("mesa", 1),
            new Palabra("silla", 1),

            new Palabra("zapato", 2),
            new Palabra("nino", 2),
            new Palabra("juego", 2),
            new Palabra("hoja", 2),
            new Palabra("viento", 2),
            new Palabra("cafe", 2),
            new Palabra("raton", 2),
            new Palabra("reina", 2),
            new Palabra("puerta", 2),
            new Palabra("pelota", 2),

            new Palabra("aliento", 3),
            new Palabra("hermano", 3),
            new Palabra("espejo", 3),
            new Palabra("peluche", 3),
            new Palabra("sombra", 3),
            new Palabra("piedra", 3),
            new Palabra("triste", 3),
            new Palabra("reloj", 3),
            new Palabra("guitarra", 3),
            new Palabra("fuego", 3),

            new Palabra("analisis", 4),
            new Palabra("sabiduria", 4),
            new Palabra("quimera", 4),
            new Palabra("inmortal", 4),
            new Palabra("espejismo", 4),
            new Palabra("orquidea", 4),
            new Palabra("melancolia", 4),
            new Palabra("estrategia", 4),
            new Palabra("soliloquio", 4),
            new Palabra("revolucion", 4)
        };
    }
    public string inicializarJuego(string nombreUsuario, int pDificultad)
    {
        Usuario usuario = new Usuario(nombreUsuario, 0);
        jugadores=new List<Usuario>();
        jugadorActual = usuario;
        dificultad = pDificultad;
        return cargarPalabra(pDificultad);
    }
    public Juego(){
        listPalabra = new List<Palabra>();
        LlenarListaPalabras();
    }

    private string cargarPalabra(int dificultad)
    {
        Palabra palabra;

        do
        {
          Random random = new Random();
          palabra = listPalabra[random.Next(1, listPalabra.Count)];

        }while(palabra.dificultad != dificultad);

        return palabra.texto; 
    }
    public void finJuego(int intentos)
    {
        jugadores.Add(jugadorActual);
    }
    public List<Usuario> devolverListaUsuarios()
    {
        /*jugadores.Sort((usuario1, usuario2) => usuario1.cantidadDeIntentos.CompareTo(usuario2.cantidadDeIntentos));*/

        return jugadores;
    }
    public string mostrarNombre(string username)
    {
        return username;
    }
}

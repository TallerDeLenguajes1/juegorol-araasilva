using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRoll.Modelos
{
    public enum TipoPersonaje
    {
        Stark,
        Lannister,
        Baratheon,
        Targaryen,
        Greyjoy
    }
        
     public class Personaje
     {
            //datos
            private TipoPersonaje tipo;
            private string nombre;
            private string apodo;
            private DateTime fechaNacimiento;
            private int edad;
            private int salud;
            private string poder;

            private int velocidad;
            private int destreza;
            private int fuerza;
            private int nivel;
            private int armadura;


            public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public string Apodo { get => apodo; set => apodo = value; }
            public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
            public int Edad { get => edad; set => edad = value; }
            public int Salud { get => salud; set => salud = value; }
            public int Velocidad { get => velocidad; set => velocidad = value; }
            public int Destreza { get => destreza; set => destreza = value; }
            public int Fuerza { get => fuerza; set => fuerza = value; }
            public int Nivel { get => nivel; set => nivel = value; }
            public int Armadura { get => armadura; set => armadura = value; }
            public string Poder { get => poder; set => poder = value; }

        public Personaje(TipoPersonaje tipo, string nombre, string apodo, DateTime fechaNacimiento, int edad)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.apodo = apodo;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = edad;
            this.salud = 100;
            this.nivel = 1;
            this.velocidad = GenerarNumAleatorio(1,10);
            this.destreza = GenerarNumAleatorio(1, 5);
            this.fuerza = GenerarNumAleatorio(1, 10);
            this.armadura = GenerarNumAleatorio(1, 10);
            this.poder =ObtenerPoderAleatorio();
        }

        public static Personaje CrearPersonajeAleatorio()
        {
            Random rand = new Random();
            string[] Nombres = { "Jon", "Sansa", "Arya", "Cersei", "Tyrion", "Jaime", "Daenerys", "Joffrey", "Robb", "Eddard", "Drogo", "Ramsay", "Hoddor", "Melisandre"};
            string[] Apodos = { "Snow", "Bastardo", "Gnomo", "Perro", "Khaleesi", "Matarreyes", "Joven lobo", "Lobo blanco","Cuervo", "Domadora de sombras" };
            DateTime fNac = new DateTime(rand.Next(1700,2021), rand.Next(1, 12), rand.Next(1, 30));

            Personaje nuevoPersonaje = new Personaje((TipoPersonaje)rand.Next(0, 5), Nombres[rand.Next(0, Nombres.Length + 1)], Apodos[rand.Next(0, Apodos.Length + 1)], fNac, rand.Next(10, 100));
            return nuevoPersonaje;
        }

        public string mostrarPersonaje()
        {
            return "Nombre: " + Nombre + ", Casa: " + Tipo + ", Edad: " + Edad;
        }

        public void Ataque(Personaje enemigo)
        {
            int PD = Destreza * Fuerza * Nivel;
            int ED = (GenerarNumAleatorio(1,50));
            int VA = PD * ED;
            int PDF = enemigo.Armadura * enemigo.Velocidad;
            int danioprovocado = ((VA * ED) - PDF) / 500;
            enemigo.Salud -= danioprovocado;
        }

        private string ObtenerPoderAleatorio()
        {
            API_Poderes ListadoPoderes = new API_Poderes();
            List<Result> poderes = ListadoPoderes.ListadoDePoderes;
            return poderes[GenerarNumAleatorio(0,poderes.Count)].Name;
        }

        private int GenerarNumAleatorio(int inicio, int final)
        {
            Random rand = new Random();
            return rand.Next(inicio, final);
        }
     }

    
}

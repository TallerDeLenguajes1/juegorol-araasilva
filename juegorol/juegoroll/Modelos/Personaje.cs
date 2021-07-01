using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juegoroll
{
    public enum TipoPersonaje
    {
        Elfo,
        Orco,
        Hobbit,
        Humano,
        Enano
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


        public Personaje(TipoPersonaje tipo, string nombre, string apodo, DateTime fechaNacimiento, int edad)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.apodo = apodo;
            this.fechaNacimiento = fechaNacimiento;
            this.edad =edad;
            this.salud = 100;
            this.nivel = 1;
            switch (tipo)
            {
                case TipoPersonaje.Humano:
                    {
                        this.velocidad = 5;
                        this.destreza = 3;
                        this.fuerza = 3;
                        this.armadura = 2;
                    }
                    break;
                case TipoPersonaje.Hobbit:
                    {
                        this.velocidad = 5;
                        this.destreza = 2;
                        this.fuerza = 3;
                        this.armadura = 2;
                    }
                    break;
                case TipoPersonaje.Elfo:
                    {
                        this.velocidad = 7;
                        this.destreza = 5;
                        this.fuerza = 6;
                        this.armadura = 5;
                    }
                    break;
                case TipoPersonaje.Orco:
                    {
                        this.velocidad = 6;
                        this.destreza = 4;
                        this.fuerza = 8;
                        this.armadura = 7;
                    }
                    break;
                case TipoPersonaje.Enano:
                    {
                        this.velocidad = 5;
                        this.destreza = 3;
                        this.fuerza = 7;
                        this.armadura = 6;

                    }
                    break;
            }
            
        }
        public void Ataque(Personaje enemigo)
        {
            Random aleatorio = new Random();
            int PD = enemigo.Destreza * enemigo.Fuerza * enemigo.Nivel;
            int ED = aleatorio.Next(1, 100);
            int VA = PD * ED;
            int PDEF = enemigo.Armadura * enemigo.Velocidad;
            int MDP = 50000;
            int DanioProvocado = (((VA*ED) - PDEF)/MDP)*100;

            enemigo.Salud -=  DanioProvocado;
        }

        public string MostrarPersonaje()
        {
            return "Nombre: "+ Nombre+", Tipo: "+Tipo+ ", Nivel: "+Nivel;
        }
    }
}

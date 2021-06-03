using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juegorol
{
    public enum TipoPersonaje
    {
        Elfo,
        Orco,
        Hobbit,
        Humano,
    }
    public class Personaje
    {
        
        private TipoPersonaje tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaNacimiento;
        private int edad;
        private int salud;


        private int velocidad;
        private int destresa;
        private int fuerza;
        private int nivel;
        private int armadura;

        public Personaje(int velocidad, int destresa, int fuerza, int nivel, int armadura)
        {
            this.velocidad = velocidad;
            this.destresa = destresa;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
        }

        public Personaje(TipoPersonaje tipo, string nombre, string apodo, DateTime fechaNacimiento, int edad, int salud)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.apodo = apodo;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = edad;
            this.salud = salud;
        }

        public Personaje()
        {
            salud = 100;   
        }
    }
}

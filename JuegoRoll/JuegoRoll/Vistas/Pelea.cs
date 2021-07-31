using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoRoll.Modelos;


namespace JuegoRoll.Vistas
{

    public partial class Pelea : Form
    {
        private List<Personaje> Peleadores;
        private int conAtaques = 0;
        public Pelea( List<Personaje> Personajes)
        {
            InitializeComponent();
            Peleadores = Personajes;
            CargarDatos(Peleadores[0], Peleadores[1]);
        }

        private void CargarDatos(Personaje Peleador1, Personaje Peleador2)
        {
            label1.Text = "Datos del Jugador 1";
            label2.Text = "Velocidad: " + Peleador1.Velocidad;
            label3.Text = "Destreza: " + Peleador1.Destreza;
            label4.Text = "Fuerza: " + Peleador1.Fuerza;
            label5.Text = "Armadura: " + Peleador1.Armadura;
            label12.Text = Peleador1.Apodo;
            label14.Text = "Salud: " + Peleador1.Salud;
            label16.Text = "Poder especial: " + Peleador1.Poder;

            label10.Text = "Datos del Jugador 2";
            label9.Text = "Velocidad: " + Peleador2.Velocidad;
            label8.Text = "Destreza: " + Peleador2.Destreza;
            label7.Text = "Fuerza: " + Peleador2.Fuerza;
            label6.Text = "Armadura: " + Peleador2.Armadura;
            label13.Text = Peleador2.Apodo;
            label15.Text = "Salud: " + Peleador2.Salud;
            label17.Text = "Poder especial: " + Peleador2.Poder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Peleadores[0].Ataque(Peleadores[1]);
            button1.Enabled = false;
            button2.Enabled = true;
            CargarDatos(Peleadores[0], Peleadores[1]);
            EvaluarJuego();
            conAtaques++;
            NumeroDeRouns();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Peleadores[1].Ataque(Peleadores[0]);
            button1.Enabled = true;
            button2.Enabled = false;
            CargarDatos(Peleadores[0], Peleadores[1]);
            EvaluarJuego();
            conAtaques++;
            NumeroDeRouns();
        }
        private void EvaluarJuego()
        {
            if (EsJuegoTerminado())
            {
                if (Peleadores[0].Salud > Peleadores[1].Salud)
                {
                    MessageBox.Show("Ganador: " + Peleadores[0].Nombre, "GANADOR");
                    MejorarSaludYReiniciarbotones(Peleadores[0]);
                    Peleadores.RemoveAt(1);
                    conAtaques = 0;
                }
                else
                {
                    MessageBox.Show("Ganador: " + Peleadores[1].Nombre, "GANADOR");
                    MejorarSaludYReiniciarbotones(Peleadores[1]);
                    Peleadores.RemoveAt(0);
                    conAtaques = 0;
                }

            }
            if (Peleadores.Count == 1)
            {
                this.Close();
            }
            else
            {
                CargarDatos(Peleadores[0], Peleadores[1]);
            }
                    
        }

        private void NumeroDeRouns()
        {
            if (conAtaques <= 2)
            {
                label11.Text = "Round 1";
            }
            if(2<conAtaques && conAtaques <= 4)
            {
                label11.Text = "Round 2";
            }
            if(4<conAtaques && conAtaques <= 6)
            {
                label11.Text = "Round 3";
            }
        }

        private bool EsJuegoTerminado()
        {
            return (conAtaques == 6 || Peleadores[0].Salud < 0 || Peleadores[1].Salud < 0);
        }
        
        private void MejorarSaludYReiniciarbotones(Personaje ganador)
        {
            ganador.Nivel += 1;
            ganador.Salud = 100;
            button1.Enabled = true;
            button2.Enabled = true;
        }
       
    }
}

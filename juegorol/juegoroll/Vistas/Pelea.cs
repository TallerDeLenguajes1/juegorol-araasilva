using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegoroll.Vistas
{
    public partial class Form_Pelea : Form
    {
        List<Personaje> Peleadores = new List<Personaje>();
        Random aleatorio = new Random();
        int ContPeleas = 0, indice1, indice2;

        public Form_Pelea(List<Personaje> personajes)
        {
            InitializeComponent();
            Peleadores = personajes;
            do
            {
                indice1 = aleatorio.Next(0, Peleadores.Count);
                indice2 = aleatorio.Next(0, Peleadores.Count);
            }
            while (indice1 == indice2);
            CargarDatosDeLosJugadores(Peleadores[indice1], Peleadores[indice2]);
        }

        private void CargarDatosDeLosJugadores(Personaje jugador1, Personaje jugador2)
        {
            NombreJug1.Text = jugador1.Apodo;
            lbl_Datos.Text = "Datos de" + jugador1.Nombre;
            lbl_Velocidad.Text = "Velocidad: " + jugador1.Velocidad;
            lbl_Armadura.Text = "Armadura: " + jugador1.Armadura;
            lbl_Destreza.Text = "Destresa: " + jugador1.Destreza;
            lbl_Fuerza.Text = "Fueza: " + jugador1.Fuerza;
            lbl_Nivel.Text = "Nivel: " + jugador1.Nivel;
            lbl_Salud.Text = "Salud: " + jugador1.Salud;

            NombreJug2.Text = jugador2.Apodo;
            lbl_enemigo_Datos.Text = "Datos de " + jugador2.Nombre;
            lbl_enemigo_Armadura.Text = "Armadura: " + jugador2.Armadura;
            lbl_enemigo_Destreza.Text = "Destreza: " + jugador2.Destreza;
            lbl_enemigo_Fuerza.Text = "Fuerza: " + jugador2.Destreza;
            lbl_enemigo_Nivel.Text = "Nivel: " + jugador2.Nivel;
            lbl_enemigo_Salud.Text = "Salud: " + jugador2.Salud;
            lbl_enemigo_Velocidad.Text = "Velocidad: " + jugador2.Velocidad;

        }


        private void Pelea_Load(object sender, EventArgs e)
        {

        }

        private void Atacar1_Click(object sender, EventArgs e)
        {
            Peleadores[indice1].Ataque(Peleadores[indice2]);
            Atacar1.Enabled = false;
            Atacar2.Enabled = true;
            CargarDatosDeLosJugadores(Peleadores[indice1], Peleadores[indice2]);
            EvaluarGanador(Peleadores);
            ContPeleas++;

        }

        private void Atacar2_Click(object sender, EventArgs e)
        {
            Peleadores[indice2].Ataque(Peleadores[indice1]);
            Atacar1.Enabled = true;
            Atacar2.Enabled = false;
            CargarDatosDeLosJugadores(Peleadores[indice1], Peleadores[indice2]);
            EvaluarGanador(Peleadores);
            ContPeleas++;
        }

        private void EvaluarGanador(List<Personaje> Peleadores)
        {
            if (EsJugoTerminado())
            {
                if (Peleadores[indice1].Salud > Peleadores[indice2].Salud)
                {
                    MessageBox.Show("Ganador: " + Peleadores[indice1].Apodo);
                    Peleadores[indice1].Nivel = 2;
                    Peleadores[indice1].Salud = 110;
                    Atacar1.Enabled = true;
                    Atacar2.Enabled = false;
                    Peleadores.RemoveAt(indice2);
                    ContPeleas = 0;
                }
                else
                {
                    MessageBox.Show("Ganador: " + Peleadores[indice2].Apodo);
                    Peleadores[indice2].Nivel = 2;
                    Peleadores[indice2].Salud = 100;
                    Peleadores.RemoveAt(indice1);
                    ContPeleas = 0;
                }
            }
            if (Peleadores.Count == 1)
            {
                MessageBox.Show("El Ganador del Torneo es: " + Peleadores[0].Apodo);
                this.Close();
            }
            else
            {
                do
                {
                    indice1 = aleatorio.Next(0, Peleadores.Count);
                    indice2 = aleatorio.Next(0, Peleadores.Count);
                }
                while (indice1 == indice2);
                CargarDatosDeLosJugadores(Peleadores[indice1], Peleadores[indice2]);
            }
            
        }
        private bool EsJugoTerminado()
        {
            return ContPeleas == 6 || Peleadores[indice1].Salud <= 0 || Peleadores[indice2].Salud<=0;
        }
      
    }
}

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

        public Form_Pelea(Personaje jugador1, Personaje jugador2)
        {
            InitializeComponent();
            CargarDatosDeLosJugadores(jugador1, jugador2);


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

        private void Pelear()
        {
            int bandera
        }
        private void Pelea_Load(object sender, EventArgs e)
        {

        }
    }
}

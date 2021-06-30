using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using juegoroll.Vistas;

namespace juegoroll
{
    public partial class CrearPj : Form

    {
        List<Personaje> Personajes = new List<Personaje>();
        Random aleatorio = new Random();
       
        public CrearPj()
        {
            InitializeComponent();
            SetearComboBox();
            SetearDatePicker();
        }
        private void SetearComboBox()
        {
            comboBox1.Items.Add("Humano");
            comboBox1.Items.Add("Hobbit");
            comboBox1.Items.Add("Elfo");
            comboBox1.Items.Add("Orco");
            comboBox1.Items.Add("Enano");
        }
        private void SetearDatePicker()
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Faltan datos");

            }
            else
            {
                TipoPersonaje nuevotipo = TipoPersonaje.Humano;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        nuevotipo = TipoPersonaje.Humano;
                        break;
                    case 1:
                        nuevotipo = TipoPersonaje.Hobbit;
                        break;
                    case 2:
                        nuevotipo = TipoPersonaje.Elfo;
                        break;
                    case 3:
                        nuevotipo = TipoPersonaje.Orco;
                        break;
                    case 4:
                        nuevotipo = TipoPersonaje.Enano;
                        break;
                }
                Personaje nuevoPersonaje = new Personaje(nuevotipo, textBox1.Text, textBox2.Text, dateTimePicker1.Value, Convert.ToInt32(textBox3.Text));
                AgregarPersonajeALaLista(nuevoPersonaje);
                limpiar();
            }
            
            
        }
        public void AgregarPersonajeALaLista(Personaje nuevoPersonaje)
        {
            Personajes.Add(nuevoPersonaje);
            listBox1.Items.Add(nuevoPersonaje.MostrarPersonaje());
        }

        public void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Personajes.Count < 2)
            {
                MessageBox.Show("Debe haber como minimo dos jugadores");

            }
            else
            {
                int indice1, indice2;
                do
                {
                    indice1 = aleatorio.Next(0, Personajes.Count);
                    indice2 = aleatorio.Next(0, Personajes.Count);
                } while (indice1 == indice2);
                

                Form_Pelea pelea = new Form_Pelea(Personajes[indice1], Personajes[indice2]);
                pelea.ShowDialog();
            }

        }
    }
}

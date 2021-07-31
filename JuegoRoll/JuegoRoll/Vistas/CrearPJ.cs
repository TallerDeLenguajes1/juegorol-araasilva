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
using JuegoRoll.Vistas;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JuegoRoll
{
    public partial class CrearPj : Form
    {
        List<Personaje> Personajes = new List<Personaje>();
        List<Personaje> Ganadores = new List<Personaje>();
        public CrearPj()
        {
            InitializeComponent();
            inicializarComboBox();
            setearDatePicker();
        }

        private void inicializarComboBox()
        {
            comboBox1.Items.Add("Stark");
            comboBox1.Items.Add("Lannister");
            comboBox1.Items.Add("Baratheon");
            comboBox1.Items.Add("Targaryen");
            comboBox1.Items.Add("Greyjoy");
        }
        private void setearDatePicker()
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
             {
                 MessageBox.Show("Faltan Datos");
             }
             else
             {
                 Personaje nuevoPersonaje = new Personaje((TipoPersonaje)comboBox1.SelectedIndex, textBox1.Text, textBox2.Text, dateTimePicker1.Value, Convert.ToInt32(textBox3.Text));
                 AgregarPersonajeALaLista(nuevoPersonaje);
                 Limpiar();
             }
           
        }

        private void AgregarPersonajeALaLista(Personaje nuevo)
        {
            Personajes.Add(nuevo);
            listBox1.Items.Add(nuevo.mostrarPersonaje());
        }
        
        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personaje nuevo = Personaje.CrearPersonajeAleatorio();
            AgregarPersonajeALaLista(nuevo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Personajes.Count < 2)
            {
                MessageBox.Show("No hay suficientes jugadores");
            }
            else
            {
                Pelea nuevaPelea = new Pelea(Personajes);
                nuevaPelea.ShowDialog();
                actualizarListBox();
                if (IsGanador())
                {
                    MessageBox.Show("El Ganador del Torneo es: " + Personajes[0].Nombre, "CAMPEON");
                    Ganadores.Add(Personajes[0]);
                    GuardarGanadores(Ganadores);
                }
            }
        }

        private void actualizarListBox()
        {
            listBox1.Items.Clear();
            foreach (Personaje jugador in Personajes)
            {
                listBox1.Items.Add(jugador.mostrarPersonaje());
            }

        }
        private bool IsGanador()
        {
            return Personajes.Count == 1;
        }
    
        private void GuardarGanadores(List<Personaje> ganadores)
        {

            string strJson = JsonSerializer.Serialize(ganadores);
            FileStream MiArchivo = new FileStream("Campeones.json", FileMode.Create);
            using (StreamWriter streamWriter = new StreamWriter(MiArchivo))
            {
                streamWriter.WriteLine(strJson);
                streamWriter.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists("Campeones.json")){
                Ranking historial = new Ranking();
                historial.ShowDialog();
            }
            else
            {
                MessageBox.Show("Todavia no existe un ranking, debe jugar una partida.", "ERROR");
            }

        }

    }

}

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


namespace JuegoRoll.Vistas
{
    public partial class Ranking : Form
    {
        List<Personaje> Ganadores;
        public Ranking()
        {
            InitializeComponent();
        }


        private void Ranking_Load(object sender, EventArgs e)
        {
            int cont = 1;
            Ganadores = ObtenerGanadores();
             foreach (Personaje campeon in Ganadores)
            {
                listBox1.Items.Add((cont++) + "- Nombre: " + campeon.Nombre + ", Casa: " + campeon.Tipo.ToString() + ", Nivel: " + campeon.Nivel);
                
            }

        }

        private List<Personaje> ObtenerGanadores()
        {            
            List<Personaje> Campeones = null;
            using (StreamReader strReader = new StreamReader("Campeones.json"))
            {
                string campeonesString = strReader.ReadToEnd();
                Campeones = JsonSerializer.Deserialize<List<Personaje>>(campeonesString);
                strReader.Close();
            }
            return Campeones;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Campeones.json"))
            {
                File.Delete("Campeones.json");
                MessageBox.Show("Historial eliminado con exito");
                this.Close();
            }
        }
    }
}

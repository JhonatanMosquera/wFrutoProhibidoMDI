using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wFrutoProhibidoMDI
{
    /// <summary>
    /// Nombre: Paola Ruiz Osorio, Jhonatan Mosquera
    /// Fecha: 1/15/2023
    /// Descripción: Aplicacción para gestionar el persona de una empresa
    /// </summary>
    

    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
            
        }

        private Stream myStream; // Permite cargar la informacin del archivo plano
        int count = 0; // sumar las lineas que crea el archivo plano
        string line; // datagridview  cargar linea a linea 

      

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //MATRIZ
            // Las matrices las vemos a traves de ARREGLOS [] 
            string[] result;
            //tamaño y cantidad de columnas 
            //DataGridTextBoxColumn col1 = new DataGridTextBoxColumn();
            //col1.HeaderText = "Columna1";
            //col1.Width = 300; //Ancho
            //col1.ReadOnly = true; //No escribir encima 

            //openFileDialog1 ==> OBJETO
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Archivo(*.csv) | *.csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                            while ((line = file.ReadLine()) != null)
                            {
                                result = line.Split(';');//split para datagridview, nos lea las lineas de las matrices 
                                //rows son las CELDAS Add adiciona las celdas 
                                dtgRegistro.Rows.Add(result[0], result[1], result[2], result[3], result[4], result[5], result[6]);
                                count++;
                            }
                         
                            file.Close();
                            
                            
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: Could not read file from disk.Original error" + ex.Message);
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
           

            dtgRegistro.Rows.Clear();
        }

       

        private void horaFecha_Tick(object sender, EventArgs e)
        {

            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}

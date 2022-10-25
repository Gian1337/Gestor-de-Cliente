using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Archivo_con_Corte_de_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientes.txt", true, Encoding.UTF8);

            string reg = String.Format("{0}-{1}-{2}-{3}", txt_cod.Text, txt_nombre.Text, txt_apellido.Text, txt_cat.Text);
            sw.WriteLine(reg);
            sw.Close();
            
        }

        private void txtEliminar_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientes.txt");
            StreamWriter sw = new StreamWriter("C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientesa.txt", true , Encoding.UTF8);

            String linea;

            string[] ArrayRegAux = new String[0];

            while((linea = sr.ReadLine()) != null)
            {
                ArrayRegAux = linea.Split('-');
                if (ArrayRegAux[0] != txt_cod.Text)
                {
                    sw.WriteLine(linea);
                }
            }
            sr.Close();
            sw.Close();
            File.Delete("C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientes.txt");
            File.Move("C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientesa.txt", "C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientes.txt");
        }

        private void txtMostrar_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Gianluca\\Desktop\\Archivo con Corte de Control\\clientes.txt");

            string[] arr = new string[0];

            string codigo = String.Empty;
            string nombre = String.Empty;
            string apellido = String.Empty;
            string categoria = String.Empty;

            int exit = 0;

            arr = sr.ReadLine().Split('-');

            while(exit == 0)
            {
                codigo = arr[0];
                nombre = arr[1];
                apellido = arr[2];
                categoria = arr[3];

                lstMostrar.Items.Add(String.Format("Categoria {0}", categoria));

                while(categoria == arr[3] && exit == 0)
                {
                    lstMostrar.Items.Add(String.Format("Cliente {0} - {1} - {2}", codigo, nombre, apellido));

                    if (sr.EndOfStream)
                    {
                        exit = 1;
                    }
                    else
                    {
                        arr = sr.ReadLine().Split('-');
                        if(categoria == arr[3])
                        {
                            codigo = arr[0];
                            nombre = arr[1];
                            apellido = arr[2];
                        }
                    }

       
                }
            }
            sr.Close();
        }
    }
}

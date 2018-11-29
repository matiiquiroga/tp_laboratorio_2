using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formulario
{
    public partial class Form1 : Form
    {
        Correo _correo;

        public Form1()
        {
            InitializeComponent();
            this._correo = new Correo();

        }

        private void ActualizarEstados()
        {
            this.lstIngresado.Items.Clear();
            this.lstEnViaje.Items.Clear();
            this.lstEgresado.Items.Clear();

            foreach (Paquete p in this._correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstIngresado.Items.Add(p);
                        break;

                    case Paquete.EEstado.EnViaje:
                        this.lstEnViaje.Items.Add(p);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEgresado.Items.Add(p);
                        break;

                    default:
                        break;
                }
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                string aux = elemento.MostrarDatos(elemento);
                this.rTbMostrar.Text = aux;

                aux.Guardar("salida.txt");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.txtTrackingID.Text);
            p.InformarEstado += paq_InformaEstado;
            try
            {
                this._correo += p;

                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ep)
            {
                MessageBox.Show(ep.Message);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)_correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEgresado.SelectedItem);
        }
    }
}

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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        Numero _aux= new Numero();

        public FormCalculadora()
        {
            InitializeComponent();        
            cmbOperador.SelectedItem = "+";
        }

        static double Operar(string numero1, string numero2, string operador)
        {
            Numero num = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            double retorno = Calculadora.Operar(num, num2, operador);
            return retorno;
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = " ";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {       
            this.lblResultado.Text = _aux.DecimalBinario(this.lblResultado.Text);   
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = _aux.BinarioDecimal(this.lblResultado.Text);
        }
    }
}

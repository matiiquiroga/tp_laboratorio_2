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
    public partial class Calculadora : Form
    {
        Numero _numero = new Numero();

        public Calculadora()
        {
            InitializeComponent();
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            cmbOperador.SelectedItem = "+";
        }

        private double Operar(string numero1, string numero2, string operador)
        {
            double result = 0;

            Numero num = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Claculadora calculeitor = new Claculadora();

            result = calculeitor.Operar(num, num2, operador);

            return result;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = this.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConverADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = _numero.BinarioDecimal(lblResultado.Text);
        }

        private void btnConvertirABinario_Click_1(object sender, EventArgs e)
        {
            lblResultado.Text = _numero.DecimalBinario(lblResultado.Text);
        }
    }
}

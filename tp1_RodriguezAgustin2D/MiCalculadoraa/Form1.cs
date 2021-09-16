﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadoraa
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult mensaje;
            mensaje =  MessageBox.Show("Desea salir?", "Salida", MessageBoxButtons.YesNo);
            if(mensaje is DialogResult.Yes)
            {
                this.Close();
            }
        }

        public static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Operando numero1 = new Operando(numeroUno);
            Operando numero2 = new Operando(numeroDos);
            return Calculadora.Operar(numero1, numero2,Char.Parse(operador));
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text } = {lblResultado.Text}");
            if(txtNumero2.Text is "0" && cmbOperador.Text is "/")
            {
                MessageBox.Show("No deberias ingresar un 0 como divisor","Mensaje", MessageBoxButtons.OK);
            }
        }

        private void cmbOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult mensaje;
           mensaje = MessageBox.Show("Desea salir?", "Salida", MessageBoxButtons.YesNo);
           if (mensaje is DialogResult.Yes)
           {
               e.Cancel = false;
           }
           else
           {
               e.Cancel = true;
           }
       }
    }
}
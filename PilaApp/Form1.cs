using PilaApp.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilaApp
{
    public partial class Form1 : Form
    {
        Stack<Datos> pila = new Stack<Datos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            datos.Nombres = tbNombres.Text;
            datos.Apellidos = tbApellidos.Text;
            datos.Cargo = tbCargo.Text;
            datos.Salario = int.Parse(tbSalario.Text);
            pila.Push(datos);
            MostrarDatos();

        }

        public void MostrarDatos()
        {
            lbPila.Items.Clear();
            foreach (Datos datos in pila)
            {
                lbPila.Items.Add($"{datos.Nombres} {datos.Apellidos} | {datos.Cargo} | {datos.Salario}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (pila.Count == 0)
            {
                lblMensajes.Text = "La pila está vacía. No hay elementos para eliminar.";
                return;
            }
            Datos eliminado = pila.Pop();
            MostrarDatos();
            lblMensajes.Text = $"Eliminado: {eliminado.Nombres} {eliminado.Apellidos} ({eliminado.Cargo}, {eliminado.Salario})";
        }

        private void btnTope_Click(object sender, EventArgs e)
        {
            if (pila.Count == 0)
            {
                lblMensajes.Text = "La pila está vacía. No hay tope.";
                return;
            }

            Datos tope = pila.Peek();
            lblMensajes.Text = $"Tope: {tope.Nombres} {tope.Apellidos} | {tope.Cargo} | {tope.Salario}";
            if (lbPila.Items.Count > 0)
            {
                lbPila.ClearSelected();
                lbPila.SelectedIndex = 0;
            }
        }
    }
}

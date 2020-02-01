using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroPersonas.xaml
    /// </summary>
    public partial class RegistroPersonas : Window
    {
        public RegistroPersonas()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IDTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDatePicker.Text = Convert.ToString(DateTime.Now);
            BalanceTextBox.Text = string.Empty;
        }
        //LLenarClase
        private Personas LLenaClase()
        {
            Personas persona = new Personas();
            if (string.IsNullOrWhiteSpace(IDTextBox.Text) && string.IsNullOrWhiteSpace(BalanceTextBox.Text))
            {
                IDTextBox.Text = "0";
                BalanceTextBox.Text = "0";
            }
            else
                persona.PersonaId = Convert.ToInt32(IDTextBox.Text);
            persona.Nombre = NombreTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDatePicker.SelectedDate);
            persona.Balance = Convert.ToDecimal(BalanceTextBox.Text);
            return persona;
        }

        //LLenarCampos
        private void LLenaCampo(Personas persona)
        {
            IDTextBox.Text = Convert.ToString(persona.PersonaId);
            NombreTextBox.Text = persona.Nombre;
            CedulaTextBox.Text = persona.Cedula;
            TelefonoTextBox.Text = persona.Telefono;
            DireccionTextBox.Text = persona.Direccion;
            FechaNacimientoDatePicker.SelectedDate = persona.FechaNacimiento;
            BalanceTextBox.Text = Convert.ToString(persona.Balance);
        }
        //Existe en la Base de Datos
        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonasBLL.Buscar(Convert.ToInt32(IDTextBox.Text));
            return (persona != null);
        }

        //Validar
        private bool Validar()
        {
            bool paso = true;
            if (NombreTextBox.Text == string.Empty)
            {
                MessageBox.Show(NombreTextBox.Text, "El Campo Nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;

            }
            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MessageBox.Show(DireccionTextBox.Text, "El Campo Direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text.Replace("-", "")))
            {
                MessageBox.Show(CedulaTextBox.Text, "El Campo no puede estar vacio");
                paso = false;

            }
            return paso;

        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas persona;
            bool paso = false;
            if (!Validar())
                return;
            persona = LLenaClase();

            //Guardar o Modificar
            if ((string.IsNullOrWhiteSpace(IDTextBox.Text) || IDTextBox.Text == "0") && (string.IsNullOrWhiteSpace(BalanceTextBox.Text) || BalanceTextBox.Text == "0"))
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No Fue Posible Guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Clear");
            int id;
            int.TryParse(IDTextBox.Text, out id);
            Limpiar();
            if (PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(IDTextBox.Text, "No Se Puede Eliminar Una Persona que no Existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(IDTextBox.Text, out id);
            Limpiar();
            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LLenaCampo(persona);

            }
            else
            {
                MessageBox.Show("Persona No Encontrada");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

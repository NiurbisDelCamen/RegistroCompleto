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
    /// Interaction logic for RegistroInscripcion.xaml
    /// </summary>
    public partial class RegistroInscripcion : Window
    {
        public RegistroInscripcion()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            InscripcionIdTextBox.Text = string.Empty;
            FechaDatePicker.Text = Convert.ToString(DateTime.Now);
            PersonaIdTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
            ComentariosTextBox.Text = string.Empty;
            DepositoTextBox.Text = string.Empty;
        }

        private Inscripciones LLenaClase()
        {
            Inscripciones inscripcion = new Inscripciones();
            if (string.IsNullOrWhiteSpace(InscripcionIdTextBox.Text))
            {
                InscripcionIdTextBox.Text = "0";
            }
            else
                inscripcion.InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);
            inscripcion.Fecha = Convert.ToDateTime(FechaDatePicker.SelectedDate);
            inscripcion.PersonaId = Convert.ToInt32 (PersonaIdTextBox.Text);
            inscripcion.Monto = Convert.ToDecimal (MontoTextBox.Text);
            inscripcion.Balance = Convert.ToDecimal(BalanceTextBox.Text);
            inscripcion.Comentarios = ComentariosTextBox.Text;
            inscripcion.Deposito = Convert.ToDecimal (DepositoTextBox.Text);
            return inscripcion;
        }

        private void LLenaCampo(Inscripciones inscripcion)
        {
            InscripcionIdTextBox.Text = Convert.ToString(inscripcion.InscripcionId);
            FechaDatePicker.SelectedDate = inscripcion.Fecha;
            PersonaIdTextBox.Text = Convert.ToString(inscripcion.PersonaId);
            MontoTextBox.Text = Convert.ToString(inscripcion.Monto);
            BalanceTextBox.Text = Convert.ToString(inscripcion.Balance);
            ComentariosTextBox.Text = inscripcion.Comentarios;
            DepositoTextBox.Text = Convert.ToString(inscripcion.Deposito);
        }
        //Base de datos.
        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripciones inscripcion = InscripcionBLL.Buscar(Convert.ToInt32(InscripcionIdTextBox));
            return (inscripcion != null);
        }

        //validar
        private bool Validar()
        {
            bool paso = true;
            if(PersonaIdTextBox.Text == string.Empty)
            {
                MessageBox.Show(PersonaIdTextBox.Text, "El Campo PersonaId no puede estar vacio");
                PersonaIdTextBox.Focus();
                paso = false;
            }
            if(string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MessageBox.Show(MontoTextBox.Text, "El Campo Monto no puede estar vacio");
                MontoTextBox.Focus();
                paso = false;
            }
            if(string.IsNullOrWhiteSpace(BalanceTextBox.Text))
            {
                MessageBox.Show(BalanceTextBox.Text, "El Campo Balance no puede estar vacio");
                BalanceTextBox.Focus();
                paso = false;
            }
            if(string.IsNullOrWhiteSpace(DepositoTextBox.Text))
            {
                MessageBox.Show(DepositoTextBox.Text, "El Campo Deposito no puede estar vacio");
                DepositoTextBox.Focus();
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
            Inscripciones inscripcion;
            bool paso = false;
            if (!Validar())
                return;
            inscripcion = LLenaClase();
            //Guardar o Modificar
            if (string.IsNullOrWhiteSpace(InscripcionIdTextBox.Text) || InscripcionIdTextBox.Text == "0")
                paso = InscripcionBLL.Guardar(inscripcion);
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una inscripcion que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionBLL.Modificar(inscripcion);
                if(paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No Fue Posible Guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clear");
            int id;
            int.TryParse(InscripcionIdTextBox.Text, out id);
            Limpiar();
            if(InscripcionBLL.Eliminar (id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(InscripcionIdTextBox.Text, "No Se Puede Eliminar Una Persona que no Existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(InscripcionIdTextBox.Text, out id);
            Limpiar();
            inscripcion = InscripcionBLL.Buscar(id);

            if(inscripcion!=null)
            {
                MessageBox.Show("Inscripcion Encontrada");
                LLenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion No Encontrada");
            }

        }

    }
}

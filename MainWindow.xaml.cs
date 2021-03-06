﻿using Registro.BLL;
using Registro.Entidades;
using Registro.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }/*
        private void Limpiar()
        {
            IDTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDatePicker.Text = Convert.ToString(DateTime.Now);
        }
        //LLenarClase
        private Persona LLenaClase()
        {
            Persona Persona = new Persona();
            if(string.IsNullOrWhiteSpace (IDTextBox.Text))
            {
                IDTextBox.Text = "0";
            }else
            Persona.PersonaID = Convert.ToInt32(IDTextBox.Text);
            Persona.Nombre = NombreTextBox.Text;
            Persona.Telefono = TelefonoTextBox.Text;
            Persona.Cedula = CedulaTextBox.Text;
            Persona.Direccion = DireccionTextBox.Text;
            Persona.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDatePicker.SelectedDate);
            return Persona;
        }

        //LLenarCampos
        private void LLenaCampo(Persona Persona)
        {
            IDTextBox.Text = Convert.ToString(Persona.PersonaID);
            NombreTextBox.Text = Persona.Nombre;
            CedulaTextBox.Text = Persona.Cedula;
            TelefonoTextBox.Text = Persona.Telefono;
            DireccionTextBox.Text = Persona.Direccion;
            FechaNacimientoDatePicker.SelectedDate = Persona.FechaNacimiento;
        }
        //Existe en la Base de Datos
        private bool ExisteEnLaBaseDeDatos()
        {
            Persona Persona = PersonasBLL.Buscar(Convert.ToInt32(IDTextBox.Text));
            return (Persona != null);
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
            Persona persona;
            bool paso = false;
            if (!Validar())
                return;
            persona = LLenaClase();

            //Guardar o Modificar
            if (string.IsNullOrWhiteSpace(IDTextBox.Text )|| IDTextBox.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(persona); 
            }
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Persona persona = new Persona();
            int.TryParse(IDTextBox.Text, out id);
            Limpiar();
            persona = PersonasBLL.Buscar(id);

            if(persona !=null)
            {
                MessageBox.Show("Persona Encontrada");
                LLenaCampo(persona);

            }
            else
            {
                MessageBox.Show("Persona No Encontrada");
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
                MessageBox.Show(IDTextBox.Text,"No Se Puede Eliminar Una Persona que no Existe");
        }*/
        private void RegistroComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegistroComboBox.SelectedIndex == 0)
            {
                RegistroPersonas form = new RegistroPersonas();
                form.Show();
            }
            else
            {
                RegistroInscripcion form = new RegistroInscripcion();
                form.Show();
            }


        }


        private void ConsultasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegistroComboBox.SelectedIndex == 0)
            {
                RegistroPersonas form = new RegistroPersonas();
                form.Show();
            }
            else
            {
                RegistroPersonas form = new RegistroPersonas();
                form.Show();
            }
        }
    }
        
}

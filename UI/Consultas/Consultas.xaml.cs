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


namespace Registro.UI.Consultas
{
    /// <summary>
    /// Interaction logic for Consultas.xaml
    /// </summary>
    public partial class Consultas : Window
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Inscripciones>();
            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch(FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = InscripcionBLL.GetList(p => true);
                        break;
                    case 1: // InscripcionId
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetList(p => p.InscripcionId == id);
                        break;
                    case 2://PersonaId
                        int d = Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetList(p => p.PersonaId == d);
                        break;
                    case 3: //Monto
                        
                      int m =  Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetList(p => p.Monto == m);
                        break;
                    case 4: //Balance
                        int l = Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetList(p => p.Balance == l);
                        break;
                    case 5:// Deposito
                        int k = Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetList(p => p.Deposito == k);
                        break;
                }
            }
            else
            {
                listado = InscripcionBLL.GetList(p => true);
            }
            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace convtemp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            TempSaisie = Convert.ToString(0);
        }
        private string tempSais;
        public string TempSaisie { get { return tempSais; } set { tempSais = value ; OnPropertyChanged("TempSaisie"); } }

        private string tempKel;
        public string TempKel { get { return tempKel; } set { tempKel = value; } }

        private string tempFar;
        public string TempFar { get { return tempFar; } set { tempFar = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tempS.Focus();
        }
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                double tempTempo = 0;
                PropertyChanged(this, new PropertyChangedEventArgs(v));
                if (TempSaisie != "")
                {
                    try
                    {
                        tempTempo = Convert.ToDouble(TempSaisie);
                    }
                    catch
                    {
                        if (TempSaisie != "-")
                        {
                            MessageBox.Show("Erreur de saisie", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        
                    }
                    
                    TempFar = Convert.ToString(tempTempo + 273.16);
                    TempKel = Convert.ToString((9.0 / 5 * tempTempo) + 32);
                    PropertyChanged(this, new PropertyChangedEventArgs("TempKel"));
                    PropertyChanged(this, new PropertyChangedEventArgs("TempFar"));
                    //TempSaisie = Convert.ToString( 25);
                }
            }
        }
        private void buttonQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

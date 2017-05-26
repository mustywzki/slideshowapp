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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Exif;

namespace Afficheur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string path { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            DataContext = new DataModel(path);
        }

        private List<JPGFileData> stringToList()
        {
            List<JPGFileData> temp = new List<JPGFileData>();
            string[] fichiers = Directory.GetFiles(path);
            fichiers.ToList().Where(c => c.ToLower().EndsWith("jpg"))   //Création de la liste de fichier en jpg
                .ToList().ForEach(c => temp.Add(new JPGFileData(c)));  //Ajout de cette liste dans Fichiers

            return temp;
        }

        private void Diaporama_Click(object sender, RoutedEventArgs e)
        {
            DiapoWindow diapo = new DiapoWindow(this.stringToList());
            diapo.Show();
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

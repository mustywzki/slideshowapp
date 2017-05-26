using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Exif;

namespace Afficheur
{
    class DataModel
    {
        public List<JPGFileData> Fichiers { get; set; }

        public DataModel(string chemin)
        {
            Fichiers = new List<JPGFileData>();
            string[] fichiers = Directory.GetFiles(chemin);
            fichiers.ToList().Where(c => c.ToLower().EndsWith("jpg"))   //Création de la liste de fichier en jpg
                .ToList().ForEach(c => Fichiers.Add(new JPGFileData(c)));  //Ajout de cette liste dans Fichiers
        }

        public DataModel(List<JPGFileData> files)
        {
            Fichiers = new List<JPGFileData>();
            Fichiers = files;
        }

        private List<JPGFileData> getListFileData()
        {
            return Fichiers;
        }
    }
}

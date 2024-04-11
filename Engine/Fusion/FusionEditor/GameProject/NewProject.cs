using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionEditor.GameProject
{
    /// <summary>
    /// Class to handle the creation of a new project.
    /// </summary>
    class NewProject : BaseViewModel
    {
        private string _name = "New Project";
        public string Name { get { return _name; } set { if (_name != value) { _name = value; } OnPropertyChanged(nameof(Name)); } }
        private string _path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\FusionProject\";
        public string Path { get { return _path; } set { if (_path != value) { _path = value; OnPropertyChanged(nameof(Path)); } } }
    }

    //TODO 17:20 VIDEO
}

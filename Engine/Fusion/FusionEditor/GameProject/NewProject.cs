using FusionEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FusionEditor.GameProject
{
    [DataContract]
    public class ProjectTemplate
    {
        [DataMember]
        public required string ProjectType { get; set; }
        [DataMember]
        public required string ProjectFile { get; set; }
        [DataMember]
        public required List<string> ProjectFolders { get; set; }

        public required byte[] Icon { get; set; }
        public required byte[] Screenshot { get; set; }
        public required string IconFilePath { get; set; }
        public required string ScreenshotFilePath { get; set; }
        public required string ProjectFilePath { get; set; }
    }

    /// <summary>
    /// Class to handle the creation of a new project.
    /// </summary>
    class NewProject : BaseViewModel
    {
        //TODO: use relative path
        private readonly string _templatePath = @"..\..\FusionEditor\ProjectTemplates";
        private string _projectName = "New Project";
        public string ProjectName { get { return _projectName; } set { if (_projectName != value) { _projectName = value; } OnPropertyChanged(nameof(ProjectName)); } }
        private string _projectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\FusionProject\";
        public string ProjectPath { get { return _projectPath; } set { if (_projectPath != value) { _projectPath = value; OnPropertyChanged(nameof(ProjectPath)); } } }
        private ObservableCollection<ProjectTemplate> _projectTemplates = new ObservableCollection<ProjectTemplate>();
        public ReadOnlyObservableCollection<ProjectTemplate> ProjectTemplates { get; }

        public NewProject()
        {
            ProjectTemplates = new ReadOnlyObservableCollection<ProjectTemplate>(_projectTemplates);
            try
            {
                var templateFiles = Directory.GetFiles(_templatePath, "template.xml", SearchOption.AllDirectories);
                Debug.Assert(templateFiles.Any());
                foreach (var templateFile in templateFiles)
                {
                    var template = Serializer.FromFile<ProjectTemplate>(templateFile);
                    template.IconFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(templateFile), "Icon.png"));
                    template.Icon = File.ReadAllBytes(template.IconFilePath);
                    template.ScreenshotFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(templateFile), "Screenshot.jpg"));
                    template.Screenshot = File.ReadAllBytes(template.ScreenshotFilePath);
                    template.ProjectFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(templateFile), template.ProjectFile));

                    _projectTemplates.Add(template);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"Error while retrieving project template files: {ex.Message}");
                //TODO: log error
            }
        }
    }
}

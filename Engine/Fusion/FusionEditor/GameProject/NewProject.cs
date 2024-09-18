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
    public class NewProject : BaseViewModel
    {
        //TODO: use relative path
        private readonly string _templatePath = @"..\..\FusionEditor\ProjectTemplates";
        private string _projectName = "New Project";
        public string ProjectName { get { return _projectName; } set { if (_projectName != value) { _projectName = value; ValidateProjectNameAndPath(); OnPropertyChanged(nameof(ProjectName)); } } }
        private string _projectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\FusionProjects\";
        public string ProjectPath { get { return _projectPath; } set { if (_projectPath != value) { _projectPath = value; ValidateProjectNameAndPath(); OnPropertyChanged(nameof(ProjectPath)); } } }
        private readonly ObservableCollection<ProjectTemplate> _projectTemplates = new ObservableCollection<ProjectTemplate>();
        public ReadOnlyObservableCollection<ProjectTemplate> ProjectTemplates { get; }
        private bool _isValid;
        public bool IsValid { get  { return _isValid; }  set { if (_isValid != value) { _isValid = value; OnPropertyChanged(nameof(IsValid)); } } }
        private string _errorMsg = "";
        public string ErrorMsg { get { return _errorMsg; } set { if (_errorMsg != value) { _errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); } } }

        private bool ValidateProjectNameAndPath()
        {
            var path = ProjectPath;
            if (!Path.EndsInDirectorySeparator(path)) path += @"\";
            path += $@"{ProjectName}\";

            IsValid = false;

            //Project name validation
            if (string.IsNullOrWhiteSpace(ProjectName.Trim()))
            {
                ErrorMsg = "Project must have a project name.";
            }
            else if (ProjectName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                ErrorMsg = "Project name can't have invalid characters.";
            }

            //Project path validation
            if (string.IsNullOrWhiteSpace(ProjectPath.Trim()))
            {
                ErrorMsg = "Project must have a project path.";
            }
            else if (ProjectPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                ErrorMsg = "Project path can't have invalid characters.";
            }
            else if (Directory.Exists(path) && Directory.EnumerateFileSystemEntries(path).Any())
            {
                ErrorMsg = "The provided project path already exists and is not empty.";
            }

            else
            {
                ErrorMsg = String.Empty;
                IsValid = true;
            }

            return IsValid;
        }

        public string CreateProject(ProjectTemplate template)
        {
            ValidateProjectNameAndPath();
            if (!IsValid) return string.Empty;

            if (!Path.EndsInDirectorySeparator(ProjectPath)) ProjectPath += @"\";
            var path = $@"{ProjectPath}{ProjectName}\";

            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                foreach (var folder in template.ProjectFolders)
                {
                    Directory.CreateDirectory(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(path), folder)));
                }
                var dirInfo = new DirectoryInfo(path + @".Fusion\");
                dirInfo.Attributes |= FileAttributes.Hidden;
                File.Copy(template.IconFilePath, Path.GetFullPath(Path.Combine(dirInfo.FullName, "Icon.png")));
                File.Copy(template.ScreenshotFilePath, Path.GetFullPath(Path.Combine(dirInfo.FullName, "Screenshot.jpg")));

                var projectXml = File.ReadAllText(template.ProjectFilePath);
                projectXml = string.Format(projectXml, ProjectName, ProjectPath);
                var projectPath = Path.GetFullPath(Path.Combine(path, $"{ProjectName}{Project.Extension}"));
                File.WriteAllText(projectPath, projectXml);
                return path;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"Error when creating the project: {ex.Message}");
                return string.Empty;
            }
        }

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
                ValidateProjectNameAndPath();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"Error while retrieving project template files: {ex.Message}");
                //TODO: log error
            }
        }
    }
}
using System;
using System.IO;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public abstract class Project : IProject
    {
        protected Project(ProjectInformation information)
        {
            if (information == null)
                throw new ArgumentNullException(nameof(information));

            if (!Directory.Exists(information.ProjectPath))
                try
                {
                    Directory.CreateDirectory(information.ProjectPath);
                }
                catch (Exception)
                {
                    throw new IOException("Could not create: " + information.ProjectPath);
                }

            if (!File.Exists(information.ProjectPath))
                try
                {
                    Directory.CreateDirectory(information.ProjectPath);
                }
                catch (Exception)
                {
                    throw new IOException("Could not create: " + information.ProjectPath);
                }
            Name = information.Name;
            FullPath = Path.Combine(information.ProjectPath, information.Name);
        }

        ~Project()
        {
            Dispose(false);
        }

        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string Name { get; set; }

        public string FullPath { get; set; }

        public abstract void Export();

        public abstract void Save();
    }
}
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
            FilePath = Path.Combine(information.ProjectPath, information.Name);

        }

        public abstract void Dispose();

        public string Name { get; set; }

        public string FilePath { get; set; }

        public abstract void Export();

        public abstract void Save();
    }
}
using System;
using System.IO;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public abstract class Project : IProject
    {
        protected Project(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                try
                {
                    File.Create(filePath);
                }
                catch (Exception)
                {
                    throw new IOException("Could not create: " + filePath);
                }
            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);
        }

        public abstract void Dispose();

        public string Name { get; set; }

        public string FilePath { get; set; }

        public abstract void Export();

        public abstract void Save();
    }
}
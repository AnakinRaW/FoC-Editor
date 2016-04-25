using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.Mods;
using System;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace
{
    public class ModProject : Project, IModProject
    {
        private bool _disposed;

        public ModProject(ProjectInformation information) : base(information)
        {
            if (information.Type == ProjectInformationType.Create)
                CreateMod();
            else
                LoadMod();

            //TODO Create and save an project file as ProjectName.modproj TODO
            //This will be done sometime later

            // Do post preparations
            information.Definition.PostPrepareProject(this);
        }

        public override void Export()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public IMod Mod { get; set; }

        public void CreateMod()
        {
            // Build up the FileSystem (TODO)
            ModFactory.BuildUpMod(FullPath);

            // Instantiate the mod.
            Mod = ModFactory.CreateMod(FullPath);
        }

        public void LoadMod()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
                //TODO: At the moment there is nothing to dispose
                _disposed = true;
        }
    }
}
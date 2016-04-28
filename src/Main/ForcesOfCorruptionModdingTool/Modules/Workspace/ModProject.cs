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
            InternalCreatProject(information);

            //TODO Create and save an project file as ProjectName.modproj TODO
            //This will be done sometime later

            // Do post preparations
            information.Definition?.PostPrepareProject(this);
        }

        private void InternalCreatProject(ProjectInformation information)
        {
            switch (information.Type)
            {
                case ProjectInformationType.Create:
                    CreateMod();
                    break;
                case ProjectInformationType.Open:
                    LoadMod();
                    break;
                case ProjectInformationType.Import:
                    ImportMod();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Export()
        {
            var manager = new ExportManager.ExportManager(this);
            manager.StartExportWizard();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public IMod Mod { get; set; }

        public void CreateMod()
        {
            ModFactory.BuildUpMod(FullPath);

            // Instantiate the mod.
            Mod = ModFactory.CreateMod(FullPath);
        }

        public void ImportMod()
        {
            Mod = ModFactory.CreateMod(FullPath);
        }

        public void LoadMod()
        {
            //Maybe Load and Import are the same at the end ...
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
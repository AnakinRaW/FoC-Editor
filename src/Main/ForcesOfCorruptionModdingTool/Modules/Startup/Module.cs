using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.InspectorTool;
using ModernApplicationFramework.MVVM.Modules.OutputTool;

namespace ForcesOfCorruptionModdingTool.Modules.Startup
{
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        private readonly IInspectorTool _inspectorTool;
        private readonly IOutput _output;

        [ImportingConstructor]
        public Module(IOutput output, IInspectorTool inspectorTool)
        {
            _output = output;
            _inspectorTool = inspectorTool;
        }

        public override IEnumerable<Type> DefaultTools
        {
            get { yield return typeof(IInspectorTool); }
        }

        public override void Initialize()
        {
            DockingHostViewModel.ShowFloatingWindowsInTaskbar = true;
            _output.AppendLine("Shell loaded successfully");

            DockingHostViewModel.ActiveDocumentChanged += (sender, e) => RefreshInspector();
            RefreshInspector();
            DockingHostViewModel.ShowTool<IOutput>();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
            _output.AppendLine($"Welcome, {Environment.UserName}");
        }

        private void RefreshInspector()
        {
            if (DockingHostViewModel.ActiveItem != null)
                _inspectorTool.SelectedObject = new InspectableObjectBuilder()
                    .WithObjectProperties(DockingHostViewModel.ActiveItem,
                        pd => pd.ComponentType == DockingHostViewModel.ActiveItem.GetType())
                    .ToInspectableObject();
            else
                _inspectorTool.SelectedObject = null;
        }
    }
}
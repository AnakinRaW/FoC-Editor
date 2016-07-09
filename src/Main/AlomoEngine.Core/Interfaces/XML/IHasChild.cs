using System.Collections;
using System.Collections.Generic;
using AlomoEngine.Core.Interfaces.FileLayout;

namespace AlomoEngine.Core.Interfaces.XML
{
    public interface IHasChild
    {
        List<IAlomoXmlObject> Childs { get; set; }

        void AddChildRange(IEnumerable node);
    }
}

using System.Collections;
using System.Collections.Generic;

namespace AlomoEngine.Core.Interfaces
{
    public interface IHasChild
    {
        List<IAlomoXmlObject> Childs { get; set; }

        void AddChildRange(IEnumerable node);
    }
}

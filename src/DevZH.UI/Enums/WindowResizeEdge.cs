using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.UI
{
    // TODO RTL layouts?
    // TODO reconcile edge and corner naming
    public enum WindowResizeEdge
    {
        Left,
        Top,
        Right,
        Bottom,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
        // TODO have one for keyboard resizes?
        // TODO GDK doesn't seem to have any others, including for keyboards...
        // TODO way to bring up the system menu instead?
    }
}

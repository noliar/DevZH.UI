using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class ContainerControl : Control
    {
        
    }

    public class ContainerControl<TChild, TContainerControl> : ContainerControl, IContainerControl<TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl> where TContainerControl : ContainerControl
    {
        protected override void Destroy()
        {
            Children.Clear();
            base.Destroy();
        }

        private TChild _children;

        public virtual TChild Children
        {
            get
            {
                if (_children == null)
                {
                    _children = (TChild)Activator.CreateInstance(typeof(TChild), this);
                }
                return _children;
            }
        }
    }
}

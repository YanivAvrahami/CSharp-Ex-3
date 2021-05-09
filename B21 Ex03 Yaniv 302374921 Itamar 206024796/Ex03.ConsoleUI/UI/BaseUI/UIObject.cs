using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    public abstract class UIObject : IRenderable
    {
        public virtual void Render()
        {
            throw new NotImplementedException();
        }
    }
}

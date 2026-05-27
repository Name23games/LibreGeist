using AurieSharpInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreGeist.Core
{
    public abstract class GeistMod
    {
        public AurieManagedModule Module { get; }

        public abstract string Name { get; }

        public abstract string Author { get; }

        public abstract string ModVersion { get; }

        protected GeistMod(AurieManagedModule module)
        {
            Module = module;
        }

        public abstract void Initialize();

        public virtual void Update(double dt) { }

        public virtual void DrawGUI() { }

        //TODO: Implement functionality
        public virtual void Draw() {}
    }
}

using YYTKInterop;

namespace LibreGeist.Core
{
    public abstract class InstanceBase
    {
        protected GameVariable index;
        protected GameInstance? instance;
        protected int id;

        public GameVariable Index
        {
            get => index;
            set => index = value;
        }

        public GameInstance? Instance => instance;

        public int Id => id;

        public bool IsActive => GML.InstanceExists(index);

        public InstanceBase(GameVariable index)
        {
            this.index = index;
            id = index.GetInstanceId();
        }

        public abstract void PerformEvent(CodeExecutionContext context);
    }
}

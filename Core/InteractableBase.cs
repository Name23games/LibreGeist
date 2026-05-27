using System.Reflection;
using YYTKInterop;

namespace LibreGeist.Core
{
    public abstract class InteractableBase(GameVariable index) : InstanceBase(index)
    {
        public abstract Sprite Sprite { get; protected set; }

        protected int range = 50;

        protected int depth = 1000;

        public override void PerformEvent(CodeExecutionContext context)
        {
            //If initial create event, fill required variables
            if (context.Name.Contains("_Create_") && context.Self.Members.Count == 0)
            {
                instance = GameInstance.FromObject(context.Self);
                var global = Game.Engine.GetGlobalObject();
                GML.SetInstanceVariable(instance, "depth", depth);
                GML.SetInstanceVariable(Index, "sprite_index", Sprite);
                GML.SetInstanceVariable(Index, "range", range);
                var upgrade_area = Game.Engine.CallFunction("asset_get_index", "o_upgrade_area");
                GML.SetInstanceVariable(Index, "can_be_used", true);
                var methodVariable = Game.Engine.CallFunction(
                    "struct_get",
                    upgrade_area,
                    "can_interact"
                );
                var canInteractFunction = Game.Engine.CallFunction(
                    "method_get_index",
                    methodVariable
                );
                var canInteract = Game.Engine.CallFunction("method", Index, canInteractFunction);

                //Use GML native "get_timer" as dummy method (no inputs, low performance impact)
                var dummyMethod = GML.GetAsset("get_timer");
                var whenInteract = Game.Engine.CallFunction("method", Index, dummyMethod);

                GML.SetInstanceVariable(Index, "can_interact", canInteract);
                GML.SetInstanceVariable(Index, "when_interact", whenInteract);

                var method_index = Game.Engine.CallFunction("method_get_index", canInteract);
                Game.Events.AddPostScriptNotification(Geist.Module, canInteractFunction.ToString().Replace("ref script ", "gml_Script_"), CanInteractInternal);

                Game.Events.AddPostBuiltinNotification(Geist.Module, "get_timer", OnInteractInternal);
            }
        }

        private void CanInteractInternal(ScriptExecutionContext Context)
        {
            if (Context.Self.IsInstance())
            {
                int id = GameInstance.FromObject(Context.Self).ID;
                if (this.id == id)
                {
                    CanInteract(Context);
                }
            }
            return;
        }

        private void OnInteractInternal(BuiltinExecutionContext Context)
        {
            if (Context.Self.IsInstance())
            {
                int id = GameInstance.FromObject(Context.Self).ID;
                if (this.id == id)
                {
                    OnInteract(Context);
                }
            }
            return;
        }

        protected abstract void CanInteract(ScriptExecutionContext Context);

        protected abstract void OnInteract(BuiltinExecutionContext Context);
    }
}

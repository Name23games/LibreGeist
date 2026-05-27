using AurieSharpInterop;
using YYTKInterop;

namespace LibreGeist
{
    internal static class Main
    {
        /// <summary>
        /// The mod entrypoint. Called once when the mod is being loaded.
        /// </summary>
        /// <param name="Module">
        /// A unique opaque structure describing the loaded mod.
        /// </param>
        /// <returns>
        /// A status value representing if the method succeeded or not.<br/>
        /// If a mod fails loading, it is promptly unloaded.
        /// </returns>
        public static AurieStatus InitializeMod(AurieManagedModule module)
        {
            Framework.Print("LibreGeist InitializeMod called");

            Geist.SetModule(module);
            Game.Events.OnFrame += Geist.OnFrame;
            Game.Events.OnGameEvent += Geist.OnGameEvent;

            Framework.Print("LibreGeist is Loaded!");
            return AurieStatus.Success;
        }
        /// <summary>
        /// The mod unload routine. Called when a mod is unloaded or hot-reloaded.
        /// </summary>
        /// <param name="Module">
        /// A unique opaque structure describing the loaded mod.
        /// Is the same as the one passed to InitializeMod.
        /// </param>
        public static void UnloadMod(AurieManagedModule Module)
        {
            Framework.Print($"LibreGeist unloaded");
        }
    }
}

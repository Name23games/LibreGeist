using AurieSharpInterop;
using LibreGeist;
using LibreGeist.Constants;
using LibreGeist.Core;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using YYTKInterop;

namespace LibreGeist
{
    public static class Geist
    {
        // Core state
        public const string Version = "0.0.1";
        public static AurieManagedModule? Module { get; private set; }

        // Frame state
        private static int _frameNumber;
        private static DateTime _lastFrameTime = DateTime.Now;

        // Game state
        public static string CurrentRoom { get; private set; } = "c0TitleScreen";
        public static GameObject? CameraSelf { get; private set; }
        public static GameObject? FrameSelf { get; private set; }

        // Mod state
        private static readonly List<GeistMod> Mods = [];
        private static readonly Dictionary<int, InstanceBase> Instances = [];
        private static bool IsInitialized;
        //public static Menu? MainMenu { get; private set; }
        //public static Menu? PauseMenu { get; private set; }

        public static void RegisterInstance(InstanceBase instance)
        {
            int id = instance.Id;
            if (!Instances.ContainsKey(id))
            {
                Instances.Add(id, instance);
            }
        }

        internal static void SetModule(AurieManagedModule module)
        {
            Module = module;
        }

        /// <summary>
        /// Registers all event-hooks and loads static resources (sprites etc.) 
        /// </summary>
        /// <param name="module"></param>
        private static void Initialize()
        {
            Framework.Print("[LibreGeist] Initialize started");

            //CreateMenus();

            Framework.Print($"GeistLib v{Version} loaded");
            LoadMods();
        }
        private static void LoadMods()
        {
            if (!Directory.Exists("mods\\Geist"))
            {
                Directory.CreateDirectory("mods\\Geist");
            }
            var modFiles = Directory.GetFiles($"mods\\Geist", "*.dll");
            for (int i = 0; i < modFiles.Length; i++)
            {
                string? file = modFiles[i];
                try
                {
                    Framework.Print($"Loading mod from file: {file}");
                    AssemblyLoadContext loadContext = AssemblyLoadContext.GetLoadContext(Assembly.GetAssembly(typeof(Geist))!)!;
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        var assembly = loadContext!.LoadFromStream(fs);
                        var modType = assembly.GetTypes().FirstOrDefault(t => t.BaseType?.FullName == typeof(GeistMod).FullName);
                        if (modType != null)
                        {
                            var mod = (GeistMod?)modType.GetConstructor([typeof(AurieManagedModule)])?.Invoke([Module]);
                            if (mod != null)
                            {
                                Mods.Add(mod);
                                Framework.Print($"Added mod: {mod.Name}");
                            }
                            else
                            {
                                Framework.PrintEx(AurieLogSeverity.Warning, $"Could not create mod instance from type \"{modType.FullName}\" in file \"{file}\"");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Framework.PrintEx(AurieLogSeverity.Error, $"Error while loading mod from file \"{file}\": {ex}");
                }
            }
            foreach (GeistMod mod in Mods)
            {
                Framework.Print($"Initializing mod: {mod.Name}");
                mod.Initialize();
            }
        }

        // Todo add gui
        private static void CreateMenus()
        {
        }


        /// <summary>
        /// Builtin function hook to keep track of current room (bound to room_goto)
        /// </summary>
        private static void CheckRoomChanged()
        {
            string roomName = GML.GetCurrentRoomName();

            if (string.IsNullOrEmpty(roomName))
                return;

            if (roomName == CurrentRoom)
                return;

            CurrentRoom = roomName;
            Framework.Print($"[LibreGeist] Room changed to {roomName}");
        }

        internal static void OnGameEvent(CodeExecutionContext context)
        {
            try
            {
                if (context.Self.Name == "struct oCamera")
                    CameraSelf = context.Self;

                if (context.Name.Contains("gml_Object_oCamera_Draw"))
                {
                    FrameSelf = context.Self;

                    DateTime now = DateTime.Now;
                    double deltaTime = (now - _lastFrameTime).TotalSeconds;
                    _lastFrameTime = now;

                    _frameNumber++;
                    OnFrame(_frameNumber, deltaTime);
                }
            }
            catch (Exception ex)
            {
                Framework.PrintEx(AurieLogSeverity.Error, $"[LibreGeist] OnGameEvent failed: {ex}");
            }


            if (!InputController.IsInitialized && context.Self.Name == "struct oCamera")
            {
                InputController.Initialize(context.Self);
            }

            //// Draw Gui elements
            //if (context.Name.Contains("gml_Object_oCamera_Draw_64"))
            //{
            //    Mouse.Update();
            //    MainMenu?.Draw();
            //    PauseMenu?.Draw();
            //    foreach (GeistMod mod in Mods)
            //    {
            //        mod.DrawGUI();
            //    }
            //}

            if (context.Self.IsInstance())
            {
                GameInstance instance = GameInstance.FromObject(context.Self);
                if (instance != null)
                {
                    //Perform events for modded instances
                    int id = instance.ID;
                    if (Instances.TryGetValue(id, out InstanceBase? value))
                    {
                        value.PerformEvent(context);
                    }
                }
            }
        }

        internal static void OnFrame(int frameNumber, double deltaTime)
        {
            if (!IsInitialized)
            {
                try
                {
                    Framework.Print("[LibreGeist] First frame init...");
                    Initialize();
                    IsInitialized = true;
                    Framework.Print("[LibreGeist] Init finished.");
                }
                catch (Exception ex)
                {
                    IsInitialized = true;
                    Framework.PrintEx(AurieLogSeverity.Error, $"[LibreGeist] Init failed: {ex}");
                }
            }

            CheckRoomChanged();

            //if (Keyboard.CheckPressed(0x26)) // Up Arrow
            //{
            //    MainMenu?.MoveUp();
            //}

            //if (Keyboard.CheckPressed(0x28)) // Down Arrow
            //{
            //    MainMenu?.MoveDown();
            //}

            //if (Keyboard.CheckPressed(0x0D)) // Enter
            //{
            //    MainMenu?.Activate();
            //}

            //MainMenu?.Update((float)deltaTime);
            //PauseMenu?.Update((float)deltaTime);

            foreach (GeistMod mod in Mods)
            {
                mod.Update(deltaTime);
            }
        }

        private static void AppendLibToVersionString(ScriptExecutionContext Context)
        {
            var result = Context.GetResult();
            Context.OverrideResult(new GameVariable($"{result} - GeistLib v{Version}"));
        }

        private static void DrawLibreGeistVersion(CodeExecutionContext context)
        {
            Game.Engine.CallFunction("draw_set_color", 16777215);

            Game.Engine.CallFunction(
                "draw_text",
                20,
                20,
                $"LibreGeist v{Version}"
            );
        }


    }
}
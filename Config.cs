using AurieSharpInterop;
using System.Text.Json;

namespace LibreGeist
{
    public class Config
    {
        private const string path = "mods\\managed\\LibreGeist.json";
        private static Config instance = Load();

        public static Config Instance { get => instance; set => instance = value; }
        public bool EnableDebugOverlay { get; set; } = false;

        private static Config Load()
        {
            if (File.Exists(path))
            {
                try
                {
                    string json = File.ReadAllText(path);
                    return JsonSerializer.Deserialize<Config>(json) ?? new Config();
                }
                catch (Exception ex)
                {
                    Framework.PrintEx(
                        AurieLogSeverity.Info,
                        $"LibreGeist Failed to load config, using defaults. Error: {ex.Message}"
                    );
                    return new Config();
                }
            }
            return new Config();
        }

        public static void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    Instance);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Framework.PrintEx(AurieLogSeverity.Info, $"LibreGeist Failed to save config. Error: {ex.Message}");
            }
        }
    }
}

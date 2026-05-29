using AurieSharpInterop;
using YYTKInterop;

namespace LibreGeist.Core
{
    public class GML
    {
        // -------------------------
        // Core call wrapper
        // -------------------------

        public static GameVariable Call(string functionName, params GameVariable[] args)
        {
            try
            {
                return Game.Engine.CallFunction(functionName, args);
            }
            catch (Exception ex)
            {
                Framework.PrintEx(
                    AurieLogSeverity.Error,
                    $"[LibreGeist] GML call failed: {functionName}: {ex}"
                );

                throw;
            }
        }

        // -------------------------
        // Assets
        // -------------------------

        public static GameVariable GetAsset(string assetName)
        {
            return Call("asset_get_index", assetName);
        }

        public static bool AssetExists(string assetName)
        {
            return GetAsset(assetName).ToString() != "-1";
        }

        // -------------------------
        // Rooms
        // -------------------------

        public static string GetCurrentRoomName()
        {
            try
            {
                if (Geist.FrameSelf == null)
                    return "";

                GameVariable room = Game.Engine.GetBuiltinVariable(
                    "room",
                    Geist.FrameSelf,
                    -1
                );

                return Call("room_get_name", room).ToString();
            }
            catch (Exception ex)
            {
                Framework.PrintEx(
                    AurieLogSeverity.Error,
                    $"[LibreGeist] Failed to get current room: {ex}"
                );

                return "";
            }
        }

        /// <summary>
        /// Adds a new instance to a room based on an object template.
        /// </summary>
        /// <param name="roomName">Use constants from <see cref="Constants.Rooms"/></param>
        /// <param name="objectName">Name of the object template</param>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        /// <returns>REF Index of the new instance</returns>
        public static GameVariable AddObjectToRoom(
            string roomName,
            string objectName,
            int x,
            int y
        )
        {
            GameVariable room = GetAsset(roomName);
            GameVariable obj = GetAsset(objectName);

            return Call("room_instance_add", room, x, y, obj);
        }

        // -------------------------
        // Instances
        // -------------------------

        public static bool InstanceExists(GameVariable instance)
        {
            return Call("instance_exists", instance);
        }

        public static GameVariable? FindInstance(string objectName, int index = 0)
        {
            try
            {
                GameVariable obj = GetAsset(objectName);

                if (obj.ToString() == "-1")
                {
                    Framework.Print($"[LibreGeist] Object not found: {objectName}");
                    return null;
                }

                GameVariable instance = Call(
                    "instance_find",
                    obj,
                    new GameVariable(index)
                );

                return InstanceExists(instance) ? instance : null;
            }
            catch (Exception ex)
            {
                Framework.PrintEx(
                    AurieLogSeverity.Error,
                    $"[LibreGeist] Failed to find instance: {objectName}: {ex}"
                );

                return null;
            }
        }

        // -------------------------
        // Instance variables
        // -------------------------

        public static GameVariable? GetInstanceVariable(
            GameVariable instance,
            string name
        )
        {
            try
            {
                return Call("variable_instance_get", instance, name);
            }
            catch (Exception ex)
            {
                Framework.PrintEx(
                    AurieLogSeverity.Error,
                    $"[LibreGeist] Failed to get instance variable '{name}': {ex}"
                );

                return null;
            }
        }

        public static void SetInstanceVariable(
            GameVariable instance,
            string name,
            GameVariable value
        )
        {
            try
            {
                Call("variable_instance_set", instance, name, value);
            }
            catch (Exception ex)
            {
                Framework.PrintEx(
                    AurieLogSeverity.Error,
                    $"[LibreGeist] Failed to set instance variable '{name}': {ex}"
                );
            }
        }

        public static bool HasInstanceVariable(GameVariable instance, string name)
        {
            try
            {
                return Call("variable_instance_exists", instance, name);
            }
            catch (Exception ex)
            {
                Framework.PrintEx(
                    AurieLogSeverity.Error,
                    $"[LibreGeist] Failed to check instance variable '{name}': {ex}"
                );

                return false;
            }
        }
    }
}


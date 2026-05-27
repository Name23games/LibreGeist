using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYTKInterop;

namespace LibreGeist
{
    public static class Extensions
    {
        // Checks if a GameVariable is any GameMaker reference type.
        public static bool IsRef(this GameVariable variable)
        {
            return variable.Type == "ref";
        }

        // Generic parser for all ref types.
        public static bool TryGetRef(this GameVariable variable, out string refType, out int id)
        {
            refType = "";
            id = -1;

            if (!variable.IsRef())
                return false;

            string text = variable.ToString();

            const string prefix = "ref ";
            if (!text.StartsWith(prefix))
                return false;

            string[] parts = text.Substring(prefix.Length).Split(' ');

            if (parts.Length < 2)
                return false;

            refType = parts[0];

            return int.TryParse(parts[1], out id);
        }

        // Gets numeric ID.
        public static int GetRefId(this GameVariable variable)
        {
            return variable.TryGetRef(out _, out int id) ? id : -1;
        }

        // Gets reference type.
        public static string GetRefType(this GameVariable variable)
        {
            return variable.TryGetRef(out string refType, out _) ? refType : "";
        }

        public static int GetInstanceId(this GameVariable variable)
        {
            if (variable.Type != "ref")
            {
                return -1;
            }
            if (variable.ToString().StartsWith("ref instance "))
            {
                var str = variable.ToString().Replace("ref instance ", "");
                if (int.TryParse(str, out int id))
                {
                    return id;
                }
            }
            return -1;
        }

        public static int GetObjectId(this GameVariable variable)
        {
            if (variable.TryGetRef(out string refType, out int id) && refType == "object")
                return id;

            return -1;
        }

        public static int GetRoomId(this GameVariable variable)
        {
            if (variable.TryGetRef(out string refType, out int id) && refType == "room")
                return id;

            return -1;
        }

        public static int GetScriptId(this GameVariable variable)
        {
            if (variable.TryGetRef(out string refType, out int id) && refType == "script")
                return id;

            return -1;
        }
    }
}

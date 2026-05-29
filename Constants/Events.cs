using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreGeist.Constants
{
    internal class Events
    {
        public const string Create = "create";
        public const string BeginStep = "begin_step";
        public const string Step = "step";
        public const string EndStep = "end_step";
        public const string Draw = "draw";
        public const string DrawGui = "draw_gui";
        public const string Destroy = "destroy";
        public const string RoomStart = "room_start";
        public const string RoomEnd = "room_end";
        public const string Alarm = "alarm";
        public const string Collision = "collision";
    }
}

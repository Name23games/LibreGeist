using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibreGeist.Constants
{
    public static class Inputs
    {
        public const string KeySplit = "key_split";
        public const string KeySplitHold = "key_split_hold";
        public const string KeyRejoin = "key_rejoin";

        public const string KeyLeft = "key_left";
        public const string KeyRight = "key_right";
        public const string KeyUp = "key_up";
        public const string KeyDown = "key_down";

        public const string KeyLeftInitial = "key_left_initial";
        public const string KeyRightInitial = "key_right_initial";
        public const string KeyUpInitial = "key_up_initial";
        public const string KeyDownInitial = "key_down_initial";

        public const string KeyAct = "key_act";
        public const string ActHold = "act_hold";

        public const string KeyJump = "key_jump";
        public const string JumpHold = "jump_hold";

        public const string KeyFire = "key_fire";
        public const string KeyInteract = "key_interact";

        public const string SlopeOn = "slopeOn";

        public const string XAxisDeadzone = "x_axis_deadzone";
        public const string YAxisDeadzone = "y_axis_deadzone";

        public static readonly string[] BoolInputs =
        {
            KeySplit,
            KeySplitHold,
            KeyRejoin,

            KeyLeft,
            KeyRight,
            KeyUp,
            KeyDown,

            KeyLeftInitial,
            KeyRightInitial,
            KeyUpInitial,
            KeyDownInitial,

            KeyAct,
            ActHold,

            KeyJump,
            JumpHold,

            KeyFire,
            KeyInteract,

            SlopeOn,
        };

        public static readonly string[] FloatInputs =
        {
            XAxisDeadzone,
            YAxisDeadzone,
        };
    }
}


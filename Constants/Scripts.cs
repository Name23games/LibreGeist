using YYTKInterop;

namespace LibreGeist.Constants
{
    /// <summary>
    /// Useful TetherGeist functions
    /// </summary>
    public static class TGScripts
    {
        // Azae Scripts
            public const string DepleteAzae = "DepleteAzae";
            public const string AddAzae = "AddAzae";
            public const string AzaeBurst = "azaeBurst";
            public const string AzaeFullClear = "azaeFullClear";

        // Inputs Scripts
        public const string SplitInput = "SplitInput";
        public const string GetPlayerInputs = "GetPlayerInputs";

        // Global Scripts
        public const string ObjectsSetAlpha = "ObjectsSetAlpha";
        public const string UnpauseGame = "UnpauseGame";
        public const string FollowCamera = "FollowCamera";
        public const string GoToFinalRoom = "GoToFinalRoom";
        public const string GoToCredits = "GoToCredits";
        public const string GetHerbCount = "GetHerbCount";

        // Player States;
        public const string PlayerStateFree = "PlayerStateFree";
        public const string PlayerStateSplit = "PlayerStateSplit";
        public const string PlayerStateAngler = "PlayerStateAngler";
        public const string PlayerStateReturning = "PlayerStateReturning";
        public const string PlayerStateWallSlide = "PlayerStateWallSlide";
        public const string PlayerStateWallJump = "PlayerStateWallJump";
        public const string PlayerStateFireball = "PlayerStateFireball";
        public const string PlayerStateHit = "PlayerStateHit";
        public const string PlayerStateTalking = "PlayerStateTalking";
        public const string PlayerStateFreeze = "PlayerStateFreeze";
        public const string PlayerStatePainAttack = "PlayerStatePainAttack";
        public const string PlayerStateWalk = "PlayerStateWalk";
        public const string PlayerStateCramps = "PlayerStateCramps";
        public const string PlayerStateRideBeetle = "PlayerStateRideBeetle";
        public const string PlayerStateRotRedirect = "PlayerStateRotRedirect";
        public const string PlayerStateRotLaunch = "PlayerStateRotLaunch";
        public const string PlayerStateLTube = "PlayerStateLTube";
        public const string PlayerStateSpiritDoor = "PlayerStateSpiritDoor";
        /// <summary>
        /// Runs the player's pain moment movement state.
        /// </summary>
        /// <param name="direction">
        /// Horizontal direction: -1 for left, 0 for neutral/decelerate, 1 for right.
        /// </param>
        public const string PlayerStatePainMoment = "PlayerStatePainMoment";
        public const string PlayerStateWallBumper = "PlayerStateWallBumper";
        public const string PlayerStateBinoculars = "PlayerStateBinoculars";
        public const string RejoinVarReset = "RejoinVarReset";
        public const string BumperCollision = "BumperCollision";

        // Spirit States
        public const string FireSnap = "FireSnap";
        /// <summary>
        /// Runs the active spirit movement state.
        /// Handles free-flight acceleration/deceleration, facing direction,
        /// rejoin/split behavior, tether spawning, and spirit collision logic.
        /// </summary>
        /// <param name="horizontalDirection">
        /// Horizontal input direction:
        /// -1 for left, 0 for neutral/decelerate, 1 for right.
        /// </param>
        /// <param name="verticalDirection">
        /// Vertical input direction:
        /// -1 for up, 0 for neutral/decelerate, 1 for down.
        /// </param>
        public const string SpiritSateActive = "SpiritSateActive";
        /// <summary>
        /// Runs the spirit's returning movement state.
        /// Handles limited horizontal control, slows spirit movement,
        /// resets gravity/vertical speed, updates facing direction,
        /// and resolves collisions with spirit walls.
        /// </summary>
        /// <param name="horizontalDirection">
        /// Horizontal input direction:
        /// -1 for left, 0 for neutral/decelerate, 1 for right.
        /// </param>
        public const string SpiritStateReturning = "SpiritStateReturning";
        public const string SpiritStateCrystalPass = "SpiritStateCrystalPass";
        public const string SpiritStateFireball = "SpiritStateFireball";
        public const string SpiritStateAngler = "SpiritStateAngler";
        public const string SpiritStateBounceCharge = "SpiritStateBounceCharge";
        public const string SpiritStateBouncing = "SpiritStateBouncing";

        // Room Transition
        public const string RoomTransition = "RoomTransition";

        // Save Load
        public const string CreateSaveDoc = "CreateSaveDoc";
        public const string SaveGame = "SaveGame";
        public const string SaveGameSettings = "SaveGameSettings";
        public const string ActivateFile = "ActivateFile";
        public const string MakeNewFile = "MakeNewFile";
        public const string ApplyMasterSettings = "ApplyMasterSettings";
        public const string AdoptMasterSettings = "AdoptMasterSettings";
        public const string ApplySaveFileLanguage = "ApplySaveFileLanguage";

        public static class Camera
        {
            /// <summary>
            /// Applies camera shake.
            /// </summary>
            /// <param name="magnitude">
            /// Shake intensity.
            /// Larger values produce stronger camera movement.
            /// </param>
            /// <param name="duration">
            /// Shake duration in steps/frames.
            /// </param>
            public static void ScreenShake(double magnitude, double duration)
            {
                Game.Engine.CallFunction("ScreenShake", magnitude, duration);
            }

            /// <summary>
            /// Applies contextual pain/cramp camera shake effects.
            /// </summary>
            public static void CrampShakes()
            {
                Game.Engine.CallFunction("CrampShakes");
            }
        }
    }
}

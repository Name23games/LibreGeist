using System.Runtime.InteropServices;
using YYTKInterop;

namespace LibreGeist.Core
{
    public class InputController
    {
        public static bool IsInitialized { get; internal set; } = false;

        private static GameObject? Input;
        private static IReadOnlyDictionary<string, GameVariable>? Inputs;
        private static readonly Dictionary<string, bool> LastFrameInputs = new Dictionary<string, bool>();

        public delegate void InputHandler(string input);
        public static event InputHandler? OnPress;
        public static event InputHandler? OnRelease;

        public static void Initialize(GameObject input)
        {
            Game.Events.OnFrame += OnFrame;
            IsInitialized = true;
            Input = input;
            Inputs = input.Members;
            for (int i = 0; i < Constants.Inputs.BoolInputs.Length; i++)
            {
                LastFrameInputs.Add(Constants.Inputs.BoolInputs[i], false);
            }
            for (int i = 0; i < Constants.Inputs.FloatInputs.Length; i++)
            {
                LastFrameInputs.Add(Constants.Inputs.FloatInputs[i], false);
            }
        }

        public static bool IsPressed(string input)
        {
            if (IsInitialized)
            {
                return LastFrameInputs[input];
            }
            return false;
        }

        private static void OnFrame(int FrameNumber, double DeltaTime)
        {
            if (IsInitialized)
            {
                Inputs = Input!.Members;
                for (int i = 0; i < Constants.Inputs.BoolInputs.Length; i++)
                {
                    string input = Constants.Inputs.BoolInputs[i];
                    bool currentState = Inputs[input].ToBoolean();
                    if (LastFrameInputs[input] != currentState)
                    {
                        LastFrameInputs[input] = currentState;
                        if (currentState)
                        {
                            OnPress?.Invoke(input);
                        }
                        else
                        {
                            OnRelease?.Invoke(input);
                        }
                    }
                }
                for (int i = 0; i < Constants.Inputs.FloatInputs.Length; i++)
                {
                    string input = Constants.Inputs.FloatInputs[i];
                    float currentState = Inputs[input].ToFloat();
                    if (currentState == 0 == LastFrameInputs[input])
                    {
                        LastFrameInputs[input] = currentState != 0;
                        if (LastFrameInputs[input])
                        {
                            OnPress?.Invoke(input);
                        }
                        else
                        {
                            OnRelease?.Invoke(input);
                        }
                    }
                }
            }
        }
    }

    public static class Keyboard
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static bool Check(int key)
        {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }

        public static bool CheckPressed(int key)
        {
            bool current = Check(key);

            if (current && !lastKeys[key])
            {
                lastKeys[key] = true;
                return true;
            }

            if (!current)
            {
                lastKeys[key] = false;
            }

            return false;
        }

        private static readonly bool[] lastKeys = new bool[256];
    }

}

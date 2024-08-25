using System.Runtime.InteropServices;

namespace InsertTextToCursorExample;

public class Win32Api
{
    [DllImport("user32")]
    private static extern void SendInput(uint nInputs, Input[] pInputs, int cbSize);

    public static void SendUnicode(string text)
    {
        var inputs = new Input[text.Length];
        var index = 0;
        foreach (var c in text)
        {
            inputs[index] = new Input
            {
                type = 1,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = c,
                        dwFlags = 0x04
                    }
                }
            };
            index++;
        }

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    private struct Input
    {
        public int type;
        public InputUnion u;
    }

    private struct KeyboardInput
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public nint dwExtraInfo;
    }

    private struct MouseInput
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public nint dwExtraInfo;
    }

    private struct HardwareInput
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct InputUnion
    {
        [FieldOffset(0)] public MouseInput mi;
        [FieldOffset(0)] public KeyboardInput ki;
        [FieldOffset(0)] public HardwareInput hi;
    }
}
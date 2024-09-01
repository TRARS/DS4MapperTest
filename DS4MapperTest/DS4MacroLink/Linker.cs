using CustomMacroBase.GamePadState;
using CustomMacroBase.Helper;
using CustomMacroFactory.MainView;
using DS4MapperTest.DS4Library;
using DS4MapperTest.DualSense;
using DS4MapperTest.MapperUtil;
using System;
using System.Linq;

namespace DS4Windows
{
    public static partial class CustomMacroLink
    {
        private static MainWindow macroWindow = CustomMacroFactory.MainEntry.GetService<MainWindow>();

        public static void Init(dynamic ds4MainWindow, dynamic ds4ControlService) => macroWindow.Init(() => ds4MainWindow, () => ds4ControlService);
        public static void Exit() => macroWindow.Exit();
        public static void HideToTray() => macroWindow.HideToTray();
    }

    public static partial class CustomMacroLink
    {
        // -1~1 -> 0~255
        static byte MapDoubleToByte(double LX)
        {
            int mappedValue = (int)((LX + 1) * 127.5);
            return (byte)Math.Clamp(mappedValue, 0, 255);
        }
        // 0~255 -> -1~1
        static double MapByteToDouble(int mappedValue)
        {
            mappedValue = Math.Clamp(mappedValue, 0, 255);
            return Math.Clamp((mappedValue / 127.5) - 1, -1, 1);
        }

        //Method for DS4StateLite
        private static void ConvertToLiteState(in IntermediateState cState, out DS4StateLite r, out DS4StateLite v)
        {
            r = new();
            v = new();

            r.Square = v.Square = cState.BtnWest;
            r.Triangle = v.Triangle = cState.BtnNorth;
            r.Circle = v.Circle = cState.BtnEast;
            r.Cross = v.Cross = cState.BtnSouth;
            r.DpadUp = v.DpadUp = cState.DpadUp;
            r.DpadDown = v.DpadDown = cState.DpadDown;
            r.DpadLeft = v.DpadLeft = cState.DpadLeft;
            r.DpadRight = v.DpadRight = cState.DpadRight;
            r.Share = v.Share = cState.BtnSelect;
            r.Options = v.Options = cState.BtnStart;
            r.TouchButton = v.TouchButton = cState.DS4TouchpadClick;
            r.PS = v.PS = cState.BtnMode;
            //r.Mute = v.Mute = cState.Mute;
            r.L1 = v.L1 = cState.BtnLShoulder;
            r.L2 = v.L2 = (byte)Math.Clamp(cState.LTrigger * 255, 0, 255);
            r.L3 = v.L3 = cState.BtnThumbL;
            r.R1 = v.R1 = cState.BtnRShoulder;
            r.R2 = v.R2 = (byte)Math.Clamp(cState.RTrigger * 255, 0, 255);
            r.R3 = v.R3 = cState.BtnThumbR;
            r.LX = v.LX = MapDoubleToByte(cState.LX);
            r.RX = v.RX = MapDoubleToByte(cState.RX);
            r.LY = v.LY = MapDoubleToByte(cState.LY);
            r.RY = v.RY = MapDoubleToByte(cState.RY);

            //DS4 Touch
            if (cState.DS4Touch1 is DS4State.TouchInfo ds4Touch1)
            {
                r.Touch0RawTrackingNum = v.Touch0RawTrackingNum = ds4Touch1.RawTrackingNum;
                r.Touch0Id = v.Touch0Id = ds4Touch1.Id;
                r.Touch0IsActive = v.Touch0IsActive = ds4Touch1.IsActive;
                r.Touch0 = v.Touch0 = new short[2] { ds4Touch1.X, ds4Touch1.Y };
            }
            if (cState.DS4Touch2 is DS4State.TouchInfo ds4Touch2)
            {
                r.Touch0RawTrackingNum = v.Touch0RawTrackingNum = ds4Touch2.RawTrackingNum;
                r.Touch0Id = v.Touch0Id = ds4Touch2.Id;
                r.Touch0IsActive = v.Touch0IsActive = ds4Touch2.IsActive;
                r.Touch0 = v.Touch0 = new short[2] { ds4Touch2.X, ds4Touch2.Y };
            }
            //DS Touch
            if (cState.DualSenseTouch1 is DualSenseState.TouchInfo dsTouch1)
            {
                r.Touch0RawTrackingNum = v.Touch0RawTrackingNum = dsTouch1.RawTrackingNum;
                r.Touch0Id = v.Touch0Id = dsTouch1.Id;
                r.Touch0IsActive = v.Touch0IsActive = dsTouch1.IsActive;
                r.Touch0 = v.Touch0 = new short[2] { dsTouch1.X, dsTouch1.Y };
            }
            if (cState.DualSenseTouch2 is DualSenseState.TouchInfo dsTouch2)
            {
                r.Touch0RawTrackingNum = v.Touch0RawTrackingNum = dsTouch2.RawTrackingNum;
                r.Touch0Id = v.Touch0Id = dsTouch2.Id;
                r.Touch0IsActive = v.Touch0IsActive = dsTouch2.IsActive;
                r.Touch0 = v.Touch0 = new short[2] { dsTouch2.X, dsTouch2.Y };
            }
        }
        private static void ConvertToFullState(in DS4StateLite v, ref IntermediateState cState)
        {
            cState.BtnWest = v.Square;
            cState.BtnNorth = v.Triangle;
            cState.BtnEast = v.Circle;
            cState.BtnSouth = v.Cross;
            cState.DpadUp = v.DpadUp;
            cState.DpadDown = v.DpadDown;
            cState.DpadLeft = v.DpadLeft;
            cState.DpadRight = v.DpadRight;
            cState.BtnSelect = v.Share;
            cState.BtnStart = v.Options;
            cState.DS4TouchpadClick = v.TouchButton;
            cState.BtnMode = v.PS;
            //cState.Mute = v.Mute;
            cState.BtnLShoulder = v.L1;
            cState.LTrigger = v.L2 / 255;
            cState.BtnThumbL = v.L3;
            cState.BtnRShoulder = v.R1;
            cState.RTrigger = v.R2 / 255;
            cState.BtnThumbR = v.R3;
            cState.LX = MapByteToDouble(v.LX);
            cState.RX = MapByteToDouble(v.RX);
            cState.LY = MapByteToDouble(v.LY);
            cState.RY = MapByteToDouble(v.RY);

            var touch0 = new DS4State.TouchInfo();
            {
                touch0.RawTrackingNum = v.Touch0RawTrackingNum;
                touch0.Id = v.Touch0Id;
                touch0.IsActive = v.Touch0IsActive;
                touch0.X = v.Touch0[0];
                touch0.Y = v.Touch0[1];
            }
            cState.DS4Touch1 = touch0;

            var touch1 = new DS4State.TouchInfo();
            {
                touch1.RawTrackingNum = v.Touch1RawTrackingNum;
                touch1.Id = v.Touch1Id;
                touch1.IsActive = v.Touch1IsActive;
                touch1.X = v.Touch1[0];
                touch1.Y = v.Touch1[1];
            }
            cState.DS4Touch2 = touch1;

            //
            //cState.L2Btn = v.L2 > 0;
            //cState.R2Btn = v.R2 > 0;
        }

        public static void Entry(in int ind, ref IntermediateState currentState)
        {
            var mix = GamepadInputMixer.Instance.AllowMix();
            if ((mix && ind > 1) || (mix is false && ind != 0)) { return; }

            ConvertToLiteState(in currentState, out DS4StateLite realState, out DS4StateLite virtualState);
            macroWindow.MacroEntry(in ind, in realState, in virtualState);
            ConvertToFullState(in virtualState, ref currentState);
        }
    }

    public static partial class CustomMacroLink
    {
        public static bool AllowOnce(string[] hardwareIds) => SingleDs4Accessor.Instance.AllowOnce(hardwareIds);
        public static void Print(string str) => Mediator.Instance.NotifyColleagues(MessageType.PrintNewMessage, str);
        public static bool HasAnyZero<T>(string msg, T xData, T yData)
        {
            var valuesListX = typeof(T).GetFields().Select(field => Convert.ToUInt16(field.GetValue(xData))).ToList();
            var valuesListY = typeof(T).GetFields().Select(field => Convert.ToUInt16(field.GetValue(yData))).ToList();

            var hasAnyZero = valuesListX.Any(item => item == 0) || valuesListY.Any(item => item == 0);
            var dataInfo = $"xData: {string.Join(",", valuesListX)} --- yData: {string.Join(",", valuesListY)}";

            if (hasAnyZero)
            {
                Print($"{msg}_need_reload -> {dataInfo}");
            }
            else
            {
                Print($"{msg} -> {dataInfo}");
            }
            return hasAnyZero;
        }
    }
}

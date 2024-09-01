using DS4MapperTest.DS4Windows.DS4OutDevices;
using Nefarius.ViGEm.Client.Targets.DualShock4;
using DS4Touch = DS4MapperTest.DS4Library.DS4State.TouchInfo;
using DualSenseTouch = DS4MapperTest.DualSense.DualSenseState.TouchInfo;

namespace DS4MapperTest.DS4Windows
{
    public class IntermediateState2DS4Report
    {
        private byte frameCounter; // 0, 1, 2...62, 63, 0....
        private byte FrameCounter
        {
            get
            {
                byte currentValue = frameCounter;
                frameCounter = (byte)((frameCounter + 1) & 0x3F); // 自增并且限制在 0~63 范围
                return currentValue;
            }
        }

        private byte[] rawOutReportEx = new byte[63];
        private DS4_REPORT_EX outDS4Report;

        public unsafe byte[] Convert2DS4Report(ushort tempButtons, ushort tempSpecial, DualShock4DPadDirection tempDPad,
                                                 byte LX, byte LY, byte RX, byte RY, byte L2, byte R2,
                                                 DS4Touch? ds4Touch1, DS4Touch? ds4Touch2, DualSenseTouch? dsTouch1, DualSenseTouch? dsTouch2)
        {
            unchecked
            {
                outDS4Report.wButtons = tempButtons;
                outDS4Report.bSpecial = (byte)(tempSpecial | (this.FrameCounter << 2));
                outDS4Report.wButtons |= tempDPad.Value;
            }

            // L2 R2
            outDS4Report.bTriggerL = L2;
            outDS4Report.bTriggerR = R2;

            // Stick
            outDS4Report.bThumbLX = LX;
            outDS4Report.bThumbLY = LY;
            outDS4Report.bThumbRX = RX;
            outDS4Report.bThumbRY = RY;

            //Touch
            if (ds4Touch1 is not null || ds4Touch2 is not null || dsTouch1 is not null || dsTouch2 is not null)
            {
                outDS4Report.bTouchPacketsN = 1;
                outDS4Report.sCurrentTouch.bPacketCounter = 1;
            }
            else
            {
                outDS4Report.sCurrentTouch.bPacketCounter = 0;
                outDS4Report.sCurrentTouch.bIsUpTrackingNum1 = 0;
                outDS4Report.sCurrentTouch.bIsUpTrackingNum2 = 0;
            }

            // DS4 TouchInfo
            if (ds4Touch1 is DS4MapperTest.DS4Library.DS4State.TouchInfo t1)
            {
                outDS4Report.sCurrentTouch.bIsUpTrackingNum1 = t1.RawTrackingNum;
                outDS4Report.sCurrentTouch.bTouchData1[0] = (byte)(t1.X & 0xFF);
                outDS4Report.sCurrentTouch.bTouchData1[1] = (byte)((t1.X >> 8) & 0x0F | (t1.Y << 4) & 0xF0);
                outDS4Report.sCurrentTouch.bTouchData1[2] = (byte)(t1.Y >> 4);
            }
            if (ds4Touch2 is DS4MapperTest.DS4Library.DS4State.TouchInfo t2)
            {
                outDS4Report.sCurrentTouch.bIsUpTrackingNum2 = t2.RawTrackingNum;
                outDS4Report.sCurrentTouch.bTouchData2[0] = (byte)(t2.X & 0xFF);
                outDS4Report.sCurrentTouch.bTouchData2[1] = (byte)((t2.X >> 8) & 0x0F | (t2.Y << 4) & 0xF0);
                outDS4Report.sCurrentTouch.bTouchData2[2] = (byte)(t2.Y >> 4);
            }
            // DS TouchInfo
            if (dsTouch1 is DS4MapperTest.DualSense.DualSenseState.TouchInfo dst1)
            {
                outDS4Report.sCurrentTouch.bIsUpTrackingNum1 = dst1.RawTrackingNum;
                outDS4Report.sCurrentTouch.bTouchData1[0] = (byte)(dst1.X & 0xFF);
                outDS4Report.sCurrentTouch.bTouchData1[1] = (byte)((dst1.X >> 8) & 0x0F | (dst1.Y << 4) & 0xF0);
                outDS4Report.sCurrentTouch.bTouchData1[2] = (byte)(dst1.Y >> 4);
            }
            if (dsTouch2 is DS4MapperTest.DualSense.DualSenseState.TouchInfo dst2)
            {
                outDS4Report.sCurrentTouch.bIsUpTrackingNum2 = dst2.RawTrackingNum;
                outDS4Report.sCurrentTouch.bTouchData2[0] = (byte)(dst2.X & 0xFF);
                outDS4Report.sCurrentTouch.bTouchData2[1] = (byte)((dst2.X >> 8) & 0x0F | (dst2.Y << 4) & 0xF0);
                outDS4Report.sCurrentTouch.bTouchData2[2] = (byte)(dst2.Y >> 4);
            }

            DS4OutDeviceExtras.CopyBytes(ref outDS4Report, rawOutReportEx);

            return rawOutReportEx;
        }
    }
}

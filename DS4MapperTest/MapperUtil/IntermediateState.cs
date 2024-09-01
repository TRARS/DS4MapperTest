namespace DS4MapperTest.MapperUtil
{
    public partial struct IntermediateState
    {
        public double LX;
        public double LY;
        public bool LSDirty;
        public double RX;
        public double RY;
        public bool RSDirty;
        public double LTrigger;
        public double RTrigger;

        public bool BtnNorth;
        public bool BtnWest;
        public bool BtnSouth;
        public bool BtnEast;
        public bool BtnLShoulder;
        public bool BtnRShoulder;
        public bool BtnMode;
        public bool BtnStart;
        public bool BtnSelect;
        public bool BtnHome;
        public bool BtnExtra;
        public bool BtnThumbL;
        public bool BtnThumbR;
        public bool BtnTouchClick;

        public bool DpadUp;
        public bool DpadLeft;
        public bool DpadDown;
        public bool DpadRight;

        public bool Dirty;
    }

    public partial struct IntermediateState
    {
        public bool DS4TouchpadClick;
        public DS4MapperTest.DS4Library.DS4State.TouchInfo? DS4Touch1;
        public DS4MapperTest.DS4Library.DS4State.TouchInfo? DS4Touch2;
        public DS4MapperTest.DualSense.DualSenseState.TouchInfo? DualSenseTouch1;
        public DS4MapperTest.DualSense.DualSenseState.TouchInfo? DualSenseTouch2;
    }
}

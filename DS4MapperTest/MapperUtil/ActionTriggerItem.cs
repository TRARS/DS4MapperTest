﻿namespace DS4MapperTest.MapperUtil
{
    public class ActionTriggerItem
    {
        private string displayName;
        public string DisplayName => displayName;

        private JoypadActionCodes code;
        public JoypadActionCodes Code => code;

        public ActionTriggerItem(string displayName, JoypadActionCodes code)
        {
            this.displayName = displayName;
            this.code = code;
        }
    }
}

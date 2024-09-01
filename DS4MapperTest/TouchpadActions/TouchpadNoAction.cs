﻿namespace DS4MapperTest.TouchpadActions
{
    public class TouchpadNoAction : TouchpadMapAction
    {
        public const string ACTION_TYPE_NAME = "TouchNoAction";

        public TouchpadNoAction()
        {
            actionTypeName = ACTION_TYPE_NAME;
        }

        public override void Prepare(Mapper mapper, ref TouchEventFrame touchFrame, bool alterState = true)
        {
        }

        public override void Event(Mapper mapper)
        {
        }

        public override void Release(Mapper mapper, bool resetState = true, bool ignoreReleaseActions = false)
        {
        }

        public override void SoftCopyFromParent(TouchpadMapAction parentAction)
        {
            if (parentAction is TouchpadNoAction tempNoAction)
            {
                base.SoftCopyFromParent(parentAction);

                this.parentAction = parentAction;
                mappingId = tempNoAction.mappingId;
            }
        }
    }
}

using DS4MapperTest.ActionUtil;
using DS4MapperTest.MapperUtil;
using System.Collections.Generic;

namespace DS4MapperTest.ButtonActions
{
    public class AxisDirButtonNoAction : AxisDirButton
    {
        public AxisDirButtonNoAction()
        {
        }

        public AxisDirButtonNoAction(ActionFunc actionFunc) : base(actionFunc)
        {
        }

        public AxisDirButtonNoAction(OutputActionData outputAction) : base(outputAction)
        {
        }

        public AxisDirButtonNoAction(IEnumerable<OutputActionData> outputActions) : base(outputActions)
        {
        }

        public override void Event(Mapper mapper)
        {
        }
    }
}

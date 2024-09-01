using DS4MapperTest.ActionUtil;
using DS4MapperTest.ButtonActions;

namespace DS4MapperTest.ViewModels
{
    public class NormalPressFuncPropViewModel
    {
        private Mapper mapper;
        private ButtonAction action;
        private NormalPressFunc func;

        public string Name
        {
            get => func.Name;
            set
            {
                func.Name = value;
            }
        }

        public string DisplayBind
        {
            get
            {
                string result = "";
                result = func.DescribeOutputActions(mapper);
                return result;
            }
        }

        public bool ToggleEnabled
        {
            get => func.toggleEnabled;
            set
            {
                func.toggleEnabled = value;
            }
        }

        public NormalPressFuncPropViewModel(Mapper mapper, ButtonAction action,
            NormalPressFunc func)
        {
            this.mapper = mapper;
            this.action = action;
            this.func = func;
        }
    }
}

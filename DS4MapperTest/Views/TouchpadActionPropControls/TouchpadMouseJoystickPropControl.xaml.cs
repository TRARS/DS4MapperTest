using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadMouseJoystickPropControl.xaml
    /// </summary>
    public partial class TouchpadMouseJoystickPropControl : UserControl
    {
        private TouchpadMouseJoystickPropViewModel touchMouseJoyPropVM;
        public TouchpadMouseJoystickPropViewModel TouchMouseJoyPropVM => touchMouseJoyPropVM;
        private Mapper mapper;
        private TouchpadMapAction action;

        public TouchpadMouseJoystickPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchMouseJoyPropVM = new TouchpadMouseJoystickPropViewModel(mapper, action);

            DataContext = touchMouseJoyPropVM;
        }
    }
}

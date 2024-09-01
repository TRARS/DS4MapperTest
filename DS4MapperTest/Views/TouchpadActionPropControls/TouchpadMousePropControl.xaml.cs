using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadMousePropControl.xaml
    /// </summary>
    public partial class TouchpadMousePropControl : UserControl
    {
        private TouchpadMousePropViewModel touchMousePropVM;
        public TouchpadMousePropViewModel TouchMousePropVM => touchMousePropVM;

        public TouchpadMousePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchMousePropVM = new TouchpadMousePropViewModel(mapper, action);

            DataContext = touchMousePropVM;
        }
    }
}

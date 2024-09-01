using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadStickActionPropControl.xaml
    /// </summary>
    public partial class TouchpadStickActionPropControl : UserControl
    {
        private TouchpadStickActionPropViewModel touchStickPropVM;
        public TouchpadStickActionPropViewModel TouchStickPropVM => touchStickPropVM;

        public TouchpadStickActionPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchStickPropVM = new TouchpadStickActionPropViewModel(mapper, action);

            DataContext = touchStickPropVM;
        }
    }
}

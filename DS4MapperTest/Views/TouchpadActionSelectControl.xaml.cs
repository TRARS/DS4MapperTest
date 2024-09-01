using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for TouchpadActionSelectControl.xaml
    /// </summary>
    public partial class TouchpadActionSelectControl : UserControl
    {
        private TouchpadActionSelectViewModel touchOutputSelVM;
        public TouchpadActionSelectViewModel TouchOutputSelVM
        {
            get => touchOutputSelVM;
        }

        public TouchpadActionSelectControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchOutputSelVM = new TouchpadActionSelectViewModel(mapper, action);
            touchOutputSelVM.PrepareView();

            DataContext = touchOutputSelVM;
        }
    }
}

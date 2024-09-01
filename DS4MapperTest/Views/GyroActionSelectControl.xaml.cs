using DS4MapperTest.GyroActions;
using DS4MapperTest.ViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for GyroActionSelectControl.xaml
    /// </summary>
    public partial class GyroActionSelectControl : UserControl
    {
        private GyroActionSelectViewModel gyroActSelVM;
        public GyroActionSelectViewModel GyroActSelVM => gyroActSelVM;

        public GyroActionSelectControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, GyroMapAction action)
        {
            gyroActSelVM = new GyroActionSelectViewModel(mapper, action);
            gyroActSelVM.PrepareView();

            DataContext = gyroActSelVM;
        }
    }
}

using DS4MapperTest.GyroActions;
using DS4MapperTest.ViewModels.GyroActionPropViewModels;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.GyroActionPropControls
{
    /// <summary>
    /// Interaction logic for GyroMouseJoystickPropControl.xaml
    /// </summary>
    public partial class GyroMouseJoystickPropControl : UserControl
    {
        private GyroMouseJoystickPropViewModel gyroMouseJoyVM;
        public GyroMouseJoystickPropViewModel GyroMouseJoyVM => gyroMouseJoyVM;


        public event EventHandler<int> ActionTypeIndexChanged;

        public GyroMouseJoystickPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, GyroMapAction action)
        {
            gyroMouseJoyVM = new GyroMouseJoystickPropViewModel(mapper, action);
            DataContext = gyroMouseJoyVM;

            gyroSelectControl.PostInit(mapper, action);
            gyroSelectControl.GyroActSelVM.SelectedIndexChanged += GyroActSelVM_SelectedIndexChanged;
        }

        private void GyroActSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                gyroSelectControl.GyroActSelVM.SelectedIndex);
        }
    }
}

using DS4MapperTest.GyroActions;
using DS4MapperTest.ViewModels.GyroActionPropViewModels;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.GyroActionPropControls
{
    /// <summary>
    /// Interaction logic for GyroMousePropControl.xaml
    /// </summary>
    public partial class GyroMousePropControl : UserControl
    {
        private GyroMouseActionPropViewModel gyroMouseActVM;
        public GyroMouseActionPropViewModel GyroMouseActVM => gyroMouseActVM;

        public event EventHandler<int> ActionTypeIndexChanged;

        public GyroMousePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, GyroMapAction action)
        {
            gyroMouseActVM = new GyroMouseActionPropViewModel(mapper, action);

            DataContext = gyroMouseActVM;

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

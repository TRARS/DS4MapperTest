using DS4MapperTest.DPadActions;
using DS4MapperTest.ViewModels.DPadActionPropViewModels;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.DPadActionPropControls
{
    /// <summary>
    /// Interaction logic for DPadTranslatePropControl.xaml
    /// </summary>
    public partial class DPadTranslatePropControl : UserControl
    {
        private DPadTranslatePropViewModel dpadTransVM;
        public DPadTranslatePropViewModel DPadTransVM => dpadTransVM;

        public event EventHandler<int> ActionTypeIndexChanged;

        public DPadTranslatePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, DPadMapAction action)
        {
            dpadTransVM = new DPadTranslatePropViewModel(mapper, action);
            DataContext = dpadTransVM;

            dpadSelectControl.PostInit(mapper, action);
            dpadSelectControl.DPadActSelVM.SelectedIndexChanged += DPadActSelVM_SelectedIndexChanged;
        }

        private void DPadActSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                dpadSelectControl.DPadActSelVM.SelectedIndex);
        }
    }
}

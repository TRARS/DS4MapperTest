using DS4MapperTest.StickActions;
using DS4MapperTest.ViewModels.StickActionPropViewModels;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.StickActionPropControls
{
    /// <summary>
    /// Interaction logic for StickMousePropControl.xaml
    /// </summary>
    public partial class StickMousePropControl : UserControl
    {
        private StickMousePropViewModel stickMouseActVM;
        public StickMousePropViewModel StickMouseActVM => stickMouseActVM;

        public event EventHandler<int> ActionTypeIndexChanged;

        public StickMousePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, StickMapAction action)
        {
            stickMouseActVM = new StickMousePropViewModel(mapper, action);
            DataContext = stickMouseActVM;

            stickSelectControl.PostInit(mapper, action);
            stickSelectControl.StickActSelVM.SelectedIndexChanged += StickActSelVM_SelectedIndexChanged; ;
        }

        private void StickActSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                stickSelectControl.StickActSelVM.SelectedIndex);
        }
    }
}

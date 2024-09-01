using DS4MapperTest.StickActions;
using DS4MapperTest.ViewModels.StickActionPropViewModels;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.StickActionPropControls
{
    /// <summary>
    /// Interaction logic for StickTranslatePropControl.xaml
    /// </summary>
    public partial class StickTranslatePropControl : UserControl
    {
        private StickTranslatePropViewModel stickTransVM;
        public StickTranslatePropViewModel StickTransVM => stickTransVM;

        public event EventHandler<int> ActionTypeIndexChanged;

        public StickTranslatePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, StickMapAction action)
        {
            stickTransVM = new StickTranslatePropViewModel(mapper, action);
            DataContext = stickTransVM;

            stickSelectControl.PostInit(mapper, action);
            stickSelectControl.StickActSelVM.SelectedIndexChanged += StickActSelVM_SelectedIndexChanged;
        }

        private void StickActSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                stickSelectControl.StickActSelVM.SelectedIndex);
        }
    }
}

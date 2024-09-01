using DS4MapperTest.TriggerActions;
using DS4MapperTest.ViewModels.TriggerActionPropViewModels;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.TriggerActionPropControls
{
    /// <summary>
    /// Interaction logic for TriggerTranslatePropControl.xaml
    /// </summary>
    public partial class TriggerTranslatePropControl : UserControl
    {
        private TriggerTranslatePropViewModel trigTransPropVM;
        public TriggerTranslatePropViewModel TrigTransPropVM => trigTransPropVM;

        public event EventHandler<int> ActionTypeIndexChanged;

        public TriggerTranslatePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TriggerMapAction action)
        {
            trigTransPropVM = new TriggerTranslatePropViewModel(mapper, action);

            DataContext = trigTransPropVM;

            triggerSelectControl.PostInit(mapper, action);
            triggerSelectControl.TrigActionSelVM.SelectedIndexChanged += TrigActionSelVM_SelectedIndexChanged;
        }

        private void TrigActionSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                triggerSelectControl.TrigActionSelVM.SelectedIndex);
        }
    }
}

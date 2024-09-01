using DS4MapperTest.TriggerActions;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.TriggerActionPropControls
{
    /// <summary>
    /// Interaction logic for TriggerNoActPropControl.xaml
    /// </summary>
    public partial class TriggerNoActPropControl : UserControl
    {
        public event EventHandler<int> ActionTypeIndexChanged;

        public TriggerNoActPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TriggerMapAction action)
        {
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

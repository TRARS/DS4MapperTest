using DS4MapperTest.DPadActions;
using System;
using System.Windows.Controls;

namespace DS4MapperTest.Views.DPadActionPropControls
{
    /// <summary>
    /// Interaction logic for DPadNoActPropControl.xaml
    /// </summary>
    public partial class DPadNoActPropControl : UserControl
    {
        public event EventHandler<int> ActionTypeIndexChanged;

        public DPadNoActPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, DPadMapAction action)
        {
            dpadSelectControl.PostInit(mapper, action);
            dpadSelectControl.DPadActSelVM.SelectedIndexChanged += StickActSelVM_SelectedIndexChanged; ;
        }

        private void StickActSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                dpadSelectControl.DPadActSelVM.SelectedIndex);
        }
    }
}

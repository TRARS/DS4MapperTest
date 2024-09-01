using DS4MapperTest.ActionUtil;
using DS4MapperTest.ButtonActions;
using DS4MapperTest.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for OutputBindingEditorControl.xaml
    /// </summary>
    public partial class OutputBindingEditorControl : UserControl
    {
        private ButtonActionEditViewModel buttonActionEditVM;
        public event EventHandler Finished;

        public OutputBindingEditorControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, ButtonAction currentAction, ActionFunc func)
        {
            buttonActionEditVM = new ButtonActionEditViewModel(mapper, currentAction, func);

            DataContext = buttonActionEditVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        private void AddOutputSlot_Click(object sender, RoutedEventArgs e)
        {
            buttonActionEditVM.AddTempOutputSlot();
        }

        private void RemoveOutputSlot_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;

            buttonActionEditVM.RemoveOutputSlot(buttonActionEditVM.SelectedSlotItemIndex);

            DataContext = buttonActionEditVM;
        }

        private void UnboundBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;

            buttonActionEditVM.AssignUnbound();

            DataContext = buttonActionEditVM;
        }
    }
}

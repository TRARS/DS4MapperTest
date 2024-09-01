using DS4MapperTest.ActionUtil;
using DS4MapperTest.ViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for ButtonActionFuncSelectControl.xaml
    /// </summary>
    public partial class ButtonActionFuncSelectControl : UserControl
    {
        private ButtonActionFuncSelectViewModel funcTypeSelectVM;
        public ButtonActionFuncSelectViewModel FuncTypeSelectVM => funcTypeSelectVM;

        public ButtonActionFuncSelectControl()
        {
            InitializeComponent();
        }

        public void PostInit(ActionFunc func)
        {
            funcTypeSelectVM = new ButtonActionFuncSelectViewModel(func);

            DataContext = funcTypeSelectVM;
        }
    }
}

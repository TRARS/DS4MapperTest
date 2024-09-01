using DS4MapperTest.DPadActions;
using DS4MapperTest.ViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for DPadActionSelectControl.xaml
    /// </summary>
    public partial class DPadActionSelectControl : UserControl
    {
        private DPadActionSelectViewModel dpadActSelVM;
        public DPadActionSelectViewModel DPadActSelVM => dpadActSelVM;

        public DPadActionSelectControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, DPadMapAction action)
        {
            dpadActSelVM = new DPadActionSelectViewModel(mapper, action);
            dpadActSelVM.PrepareView();

            DataContext = dpadActSelVM;
        }
    }
}

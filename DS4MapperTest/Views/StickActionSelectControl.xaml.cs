using DS4MapperTest.StickActions;
using DS4MapperTest.ViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for StickActionSelectControl.xaml
    /// </summary>
    public partial class StickActionSelectControl : UserControl
    {
        private StickActionSelectViewModel stickActSelVM;
        public StickActionSelectViewModel StickActSelVM => stickActSelVM;

        public StickActionSelectControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, StickMapAction action)
        {
            stickActSelVM = new StickActionSelectViewModel(mapper, action);
            stickActSelVM.PrepareView();

            DataContext = stickActSelVM;
        }
    }
}

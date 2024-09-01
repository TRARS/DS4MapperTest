using DS4MapperTest.TriggerActions;
using DS4MapperTest.ViewModels;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for TriggerActionSelectControl.xaml
    /// </summary>
    public partial class TriggerActionSelectControl : UserControl
    {
        private TriggerActionSelectViewModel trigActionSelVM;
        public TriggerActionSelectViewModel TrigActionSelVM => trigActionSelVM;

        public TriggerActionSelectControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TriggerMapAction action)
        {
            trigActionSelVM = new TriggerActionSelectViewModel(mapper, action);
            trigActionSelVM.PrepareView();

            DataContext = trigActionSelVM;
        }
    }
}

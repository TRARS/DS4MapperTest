using DS4MapperTest.ActionUtil;
using DS4MapperTest.ButtonActions;
using DS4MapperTest.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for StartPressFuncPropControl.xaml
    /// </summary>
    public partial class StartPressFuncPropControl : UserControl
    {
        private StartPressFuncPropViewModel startPressFuncVM;
        public StartPressFuncPropViewModel StartPressFuncVM => startPressFuncVM;

        public event EventHandler RequestBindingEditor;
        public event EventHandler<int> RequestChangeFuncType;

        public StartPressFuncPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, ButtonAction action, StartPressFunc func)
        {
            startPressFuncVM = new StartPressFuncPropViewModel(mapper, action, func);
            DataContext = startPressFuncVM;

            funcTypeControl.PostInit(func);
            funcTypeControl.FuncTypeSelectVM.SelectedIndexChanged += FuncTypeSelectVM_SelectedIndexChanged;
        }

        private void FuncTypeSelectVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = funcTypeControl.FuncTypeSelectVM.SelectedIndex;
            RequestChangeFuncType?.Invoke(this, selectedIndex);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RequestBindingEditor?.Invoke(this, EventArgs.Empty);
        }
    }
}

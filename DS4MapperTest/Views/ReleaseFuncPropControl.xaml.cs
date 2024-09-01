using DS4MapperTest.ActionUtil;
using DS4MapperTest.ButtonActions;
using DS4MapperTest.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for ReleaseFuncFuncPropControl.xaml
    /// </summary>
    public partial class ReleaseFuncPropControl : UserControl
    {
        private ReleaseFuncPropViewModel propViewModel;
        public event EventHandler RequestBindingEditor;
        public event EventHandler<int> RequestChangeFuncType;

        public ReleaseFuncPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, ButtonAction action, ReleaseFunc func)
        {
            propViewModel = new ReleaseFuncPropViewModel(mapper, action, func);

            DataContext = propViewModel;

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

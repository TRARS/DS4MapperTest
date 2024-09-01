using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using static DS4MapperTest.Views.TouchpadActionPropControls.TouchpadActionPadPropControl;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadSingleButtonPropControl.xaml
    /// </summary>
    public partial class TouchpadSingleButtonPropControl : UserControl
    {
        private TouchpadSingleButtonPropViewModel touchSingleBtnVM;
        public TouchpadSingleButtonPropViewModel TouchSingleBtnVM => touchSingleBtnVM;

        public event EventHandler<DirButtonBindingArgs> RequestFuncEditor;

        public TouchpadSingleButtonPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchSingleBtnVM = new TouchpadSingleButtonPropViewModel(mapper, action);
            DataContext = touchSingleBtnVM;
        }

        public void RefreshView()
        {
            // Force re-eval of bindings
            DataContext = null;
            DataContext = touchSingleBtnVM;
        }

        private void BtnEditBinding_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchSingleBtnVM.Action.EventButton,
                !touchSingleBtnVM.Action.UseParentActions,
                touchSingleBtnVM.UpdateEventButton));
        }
    }
}

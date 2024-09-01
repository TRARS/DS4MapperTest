using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using static DS4MapperTest.Views.TouchpadActionPropControls.TouchpadActionPadPropControl;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadCircularPropControl.xaml
    /// </summary>
    public partial class TouchpadCircularPropControl : UserControl
    {
        private TouchpadCircularPropViewModel touchCircVM;
        public TouchpadCircularPropViewModel TouchCircVM => touchCircVM;

        public event EventHandler<DirButtonBindingArgs> RequestFuncEditor;

        public TouchpadCircularPropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchCircVM = new TouchpadCircularPropViewModel(mapper, action);
            DataContext = touchCircVM;
        }

        public void RefreshView()
        {
            // Force re-eval of bindings
            DataContext = null;
            DataContext = touchCircVM;
        }

        private void BtnEditForward_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchCircVM.Action.ClockWiseBtn,
                !touchCircVM.Action.UseParentCircButtons[0],
                touchCircVM.UpdateClockWiseBtn));
        }

        private void BtnEditBackward_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchCircVM.Action.CounterClockwiseBtn,
                !touchCircVM.Action.UseParentCircButtons[1],
                touchCircVM.UpdateCounterClockWiseBtn));
        }
    }
}

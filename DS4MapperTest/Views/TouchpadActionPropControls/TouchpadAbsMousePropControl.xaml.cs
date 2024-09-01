using DS4MapperTest.ButtonActions;
using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadAbsMousePropControl.xaml
    /// </summary>
    public partial class TouchpadAbsMousePropControl : UserControl
    {
        public class ButtonBindingArgs : EventArgs
        {
            private AxisDirButton actionBtn;
            public AxisDirButton ActionBtn => actionBtn;

            private bool realAction;
            public bool RealAction => realAction;

            public delegate void UpdateActionHandler(ButtonAction oldAction, ButtonAction newAction);
            private UpdateActionHandler updateActHandler;
            public UpdateActionHandler UpdateActHandler => updateActHandler;

            public ButtonBindingArgs(AxisDirButton pullBtn, bool realAction, UpdateActionHandler updateActDel)
            {
                this.actionBtn = pullBtn;
                this.realAction = realAction;
                this.updateActHandler = updateActDel;
            }
        }

        private TouchpadAbsMousePropViewModel touchAbsMousePropVM;
        public TouchpadAbsMousePropViewModel TouchAbsMousePropVM => touchAbsMousePropVM;

        public event EventHandler<ButtonBindingArgs> RequestFuncEditor;

        public TouchpadAbsMousePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchAbsMousePropVM = new TouchpadAbsMousePropViewModel(mapper, action);

            DataContext = touchAbsMousePropVM;
        }

        private void btnEditTest_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new ButtonBindingArgs(touchAbsMousePropVM.Action.RingButton,
                !touchAbsMousePropVM.Action.UseParentRingButton,
                touchAbsMousePropVM.UpdateRingButton));
        }
    }
}

using DS4MapperTest.TouchpadActions;
using DS4MapperTest.ViewModels.TouchpadActionPropViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using static DS4MapperTest.Views.TouchpadActionPropControls.TouchpadActionPadPropControl;

namespace DS4MapperTest.Views.TouchpadActionPropControls
{
    /// <summary>
    /// Interaction logic for TouchpadDirSwipePropControl.xaml
    /// </summary>
    public partial class TouchpadDirSwipePropControl : UserControl
    {
        private TouchpadDirSwipePropViewModel touchDirSwipeVM;
        public TouchpadDirSwipePropViewModel TouchDirSwipeVM => touchDirSwipeVM;

        public event EventHandler<DirButtonBindingArgs> RequestFuncEditor;

        public TouchpadDirSwipePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, TouchpadMapAction action)
        {
            touchDirSwipeVM = new TouchpadDirSwipePropViewModel(mapper, action);
            DataContext = touchDirSwipeVM;
        }

        public void RefreshView()
        {
            // Force re-eval of bindings
            DataContext = null;
            DataContext = touchDirSwipeVM;
        }

        private void BtnUpEdit_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchDirSwipeVM.Action.UsedEventsButtonsY[(int)TouchpadDirectionalSwipe.SwipeAxisYDir.Up],
                !touchDirSwipeVM.Action.UseParentDataY[(int)TouchpadDirectionalSwipe.SwipeAxisYDir.Up],
                touchDirSwipeVM.UpdateUpDirButton));
        }

        private void BtnDownEdit_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchDirSwipeVM.Action.UsedEventsButtonsY[(int)TouchpadDirectionalSwipe.SwipeAxisYDir.Down],
                !touchDirSwipeVM.Action.UseParentDataY[(int)TouchpadDirectionalSwipe.SwipeAxisYDir.Down],
                touchDirSwipeVM.UpdateDownDirButton));
        }

        private void BtnLeftEdit_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchDirSwipeVM.Action.UsedEventsButtonsX[(int)TouchpadDirectionalSwipe.SwipeAxisXDir.Left],
                !touchDirSwipeVM.Action.UseParentDataX[(int)TouchpadDirectionalSwipe.SwipeAxisXDir.Left],
                touchDirSwipeVM.UpdateLeftDirButton));
        }

        private void BtnRightEdit_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(touchDirSwipeVM.Action.UsedEventsButtonsX[(int)TouchpadDirectionalSwipe.SwipeAxisXDir.Right],
                !touchDirSwipeVM.Action.UseParentDataX[(int)TouchpadDirectionalSwipe.SwipeAxisXDir.Right],
                touchDirSwipeVM.UpdateRightDirButton));
        }
    }
}

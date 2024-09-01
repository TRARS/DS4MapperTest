﻿using DS4MapperTest.StickActions;
using DS4MapperTest.ViewModels.StickActionPropViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using static DS4MapperTest.Views.StickActionPropControls.StickPadActionControl;

namespace DS4MapperTest.Views.StickActionPropControls
{
    /// <summary>
    /// Interaction logic for StickAbsMousePropControl.xaml
    /// </summary>
    public partial class StickAbsMousePropControl : UserControl
    {
        private StickAbsMousePropViewModel stickAbsMouseVM;
        public StickAbsMousePropViewModel StickAbsMouseVM => stickAbsMouseVM;

        public event EventHandler<int> ActionTypeIndexChanged;
        public event EventHandler<DirButtonBindingArgs> RequestFuncEditor;

        public StickAbsMousePropControl()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, StickMapAction action)
        {
            stickAbsMouseVM = new StickAbsMousePropViewModel(mapper, action);
            DataContext = stickAbsMouseVM;

            stickSelectControl.PostInit(mapper, action);
            stickSelectControl.StickActSelVM.SelectedIndexChanged += StickActSelVM_SelectedIndexChanged;
        }

        public void RefreshView()
        {
            // Force re-eval of bindings
            DataContext = null;
            DataContext = stickAbsMouseVM;
        }

        private void StickActSelVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionTypeIndexChanged?.Invoke(this,
                stickSelectControl.StickActSelVM.SelectedIndex);
        }

        private void btnEditTest_Click(object sender, RoutedEventArgs e)
        {
            RequestFuncEditor?.Invoke(this,
                new DirButtonBindingArgs(stickAbsMouseVM.Action.RingButton,
                !stickAbsMouseVM.Action.UseParentRingButton,
                stickAbsMouseVM.UpdateRingButton));
        }
    }
}

﻿using DS4MapperTest.ActionUtil;
using DS4MapperTest.ButtonActions;
using DS4MapperTest.ViewModels;
using DS4MapperTest.Views.ButtonActionPropControls;
using System;
using System.Windows;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for AlwaysOnEditWindow.xaml
    /// </summary>
    public partial class AlwaysOnEditWindow : Window
    {
        private AlwaysOnButtonFuncEditViewModel btnFuncEditVM;
        public AlwaysOnButtonFuncEditViewModel BtnFuncEditVM => btnFuncEditVM;

        private ButtonActionViewModel btnActionEditVM;
        private ButtonNoActionViewModel btnNoActVM;
        private FuncBindingControl bindControl;
        private ButtonNoActionPropControl noActionControl = new ButtonNoActionPropControl();

        public AlwaysOnEditWindow()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, ButtonMapAction action)
        {
            btnFuncEditVM = new AlwaysOnButtonFuncEditViewModel(mapper, action);

            if (action.GetType() == typeof(ButtonAction))
            {
                btnFuncEditVM.SelectedTransformIndex = 1;
                //FuncBindingControl tempControl = new FuncBindingControl();
                //DataContext = btnActionEditVM;
            }
            else if (action.GetType() == typeof(ButtonNoAction))
            {
                btnFuncEditVM.IsTransformOutputVisible = true;
                //DataContext = btnNoActVM;
            }

            SetupDisplayControl();

            btnFuncEditVM.SelectedTransformIndexChanged += BtnFuncEditVM_SelectedTransformIndexChanged;

            DataContext = btnFuncEditVM;
        }

        public void SetupDisplayControl()
        {
            switch (btnFuncEditVM.Action)
            {
                case ButtonAction:
                    innerViewControl.DataContext = null;

                    btnActionEditVM = new ButtonActionViewModel(btnFuncEditVM.Mapper, btnFuncEditVM.Action);
                    //if (btnActionEditVM.Action != btnFuncEditVM.Action)
                    //{
                    //    btnFuncEditVM.UpdateAction(btnActionEditVM.Action);
                    //}
                    btnFuncEditVM.UsingRealAction = btnActionEditVM.UsingRealAction;
                    btnFuncEditVM.TempAction = btnActionEditVM.Action;

                    bindControl = null;
                    bindControl = new FuncBindingControl();
                    bindControl.PostInit(btnFuncEditVM.Mapper, btnFuncEditVM.Action);
                    bindControl.RequestBindingEditor += TempControl_RequestBindingEditor;
                    bindControl.PreActionSwitch += BindControl_PreActionSwitch;
                    bindControl.ActionChanged += BindControl_ActionChanged;
                    bindControl.RequestClose += BindControl_RequestClose;
                    bindControl.FuncBindVM.IsRealAction = btnActionEditVM.Action.ParentAction == null;
                    btnActionEditVM.DisplayControl = bindControl;

                    innerViewControl.DataContext = btnActionEditVM;
                    break;
                case ButtonNoAction:
                    innerViewControl.DataContext = null;

                    btnNoActVM = new ButtonNoActionViewModel(btnFuncEditVM.Mapper, btnFuncEditVM.Action);
                    btnFuncEditVM.TempAction = btnNoActVM.Action;
                    btnFuncEditVM.UsingRealAction = btnNoActVM.UsingRealAction;

                    btnNoActVM.DisplayControl = noActionControl;
                    innerViewControl.DataContext = btnNoActVM;
                    break;
                default:
                    break;
            }
        }

        private void BindControl_PreActionSwitch(ButtonAction oldAction, ButtonAction newAction)
        {
            btnFuncEditVM.SwitchLayerAction(oldAction, newAction, false);
            btnFuncEditVM.MigrationActionId(newAction);
            btnFuncEditVM.UpdateAction(newAction);
        }

        private void BindControl_RequestClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindControl_ActionChanged(object sender, ButtonAction action)
        {
            btnFuncEditVM.MigrationActionId(action);
            btnFuncEditVM.UpdateAction(action);
        }

        private void BtnFuncEditVM_SelectedTransformIndexChanged(object sender, EventArgs e)
        {
            int ind = btnFuncEditVM.SelectedTransformIndex;
            if (ind >= 0)
            {
                ButtonMapAction tempAct = btnFuncEditVM.PrepareNewAction(ind);
                if (tempAct != null)
                {
                    ButtonMapAction oldAction = btnFuncEditVM.Action;

                    if (btnFuncEditVM.TempAction.Id != MapAction.DEFAULT_UNBOUND_ID)
                    {
                        tempAct.Id = btnFuncEditVM.TempAction.Id;
                    }
                    else
                    {
                        btnFuncEditVM.MigrationActionId(tempAct);
                    }

                    btnFuncEditVM.UpdateAction(tempAct);
                    //tempAct.MappingId = oldAction.MappingId;
                    btnFuncEditVM.SwitchLayerAction(oldAction, tempAct);
                    SetupDisplayControl();
                }
            }
        }

        private void TempControl_RequestBindingEditor(object sender, ActionFunc func)
        {
            OutputBindingEditorControl tempControl = new OutputBindingEditorControl();
            tempControl.PostInit(btnActionEditVM.Mapper, btnActionEditVM.Action, func);
            tempControl.Finished += (sender, args) =>
            {
                bindControl.RefreshView();
                btnActionEditVM.DisplayControl = bindControl;
                btnFuncEditVM.TopTransformPanelVisible = true;
                //FuncBindingControl tempControl = new FuncBindingControl();
                //tempControl.PostInit(btnFuncEditVM.Mapper, btnFuncEditVM.Action);
                //tempControl.RequestBindingEditor += TempControl_RequestBindingEditor;
                //btnFuncEditVM.DisplayControl = tempControl;
            };

            btnFuncEditVM.TopTransformPanelVisible = false;
            btnActionEditVM.DisplayControl = tempControl;
        }

        private void PrepareDefaultView(Mapper mapper, ButtonAction action)
        {
            //FuncBindingControl tempControl = new FuncBindingControl();
            //tempControl.PostInit(mapper, action);
            //tempControl.RequestBindingEditor += TempControl_RequestBindingEditor;
            //btnFuncEditVM.DisplayControl = tempControl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool oldValue = btnFuncEditVM.IsTransformOutputVisible;
            btnFuncEditVM.IsTransformOutputVisible = !oldValue;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DataContext = null;
            innerViewControl.DataContext = null;
        }
    }
}

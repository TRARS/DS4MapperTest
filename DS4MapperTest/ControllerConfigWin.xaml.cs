using DS4MapperTest.SteamControllerLibrary;
using DS4MapperTest.ViewModels;
using System;
using System.Windows;

namespace DS4MapperTest
{
    /// <summary>
    /// Interaction logic for ControllerConfigWin.xaml
    /// </summary>
    public partial class ControllerConfigWin : Window
    {
        private bool dirty;
        private ControllerConfigViewModel controlConfigVM;

        public ControllerConfigWin()
        {
            InitializeComponent();
        }

        public void PostInit(SteamControllerDevice device)
        {
            controlConfigVM = new ControllerConfigViewModel(device);

            steamControllerTabItem.DataContext = controlConfigVM;
            controlConfigVM.ControlOptions.LeftTouchpadRotationChanged += ControlOptions_OptionChanged;
            controlConfigVM.ControlOptions.RightTouchpadRotationChanged += ControlOptions_OptionChanged;
        }

        private void ControlOptions_OptionChanged(object sender, EventArgs e)
        {
            dirty = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (dirty)
            {
                AppGlobalDataSingleton.Instance.SaveControllerDeviceSettings(controlConfigVM.Device,
                    controlConfigVM.Device.DeviceOptions);
            }

            controlConfigVM.ControlOptions.LeftTouchpadRotationChanged -= ControlOptions_OptionChanged;
            controlConfigVM.ControlOptions.RightTouchpadRotationChanged -= ControlOptions_OptionChanged;

            steamControllerTabItem.DataContext = null;
        }
    }
}

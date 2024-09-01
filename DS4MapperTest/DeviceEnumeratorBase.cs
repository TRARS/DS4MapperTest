using System.Collections.Generic;

namespace DS4MapperTest
{
    public abstract class DeviceEnumeratorBase
    {
        public abstract void FindControllers();
        public abstract IEnumerable<InputDeviceBase> GetFoundDevices();
        public abstract void StopControllers();
    }
}

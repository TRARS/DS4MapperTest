namespace DS4MapperTest
{
    public abstract class DeviceReaderBase
    {
        public abstract void StartUpdate();
        public abstract void StopUpdate();
        public abstract void WriteRumbleReport();
    }
}

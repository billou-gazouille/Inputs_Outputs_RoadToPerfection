
public class IOXorMB : MultiInputOutputDeviceMB
{
    IOXor ioXor = new IOXor();
	public override MultiInputOutputDevice multiIODevice => ioXor;
}

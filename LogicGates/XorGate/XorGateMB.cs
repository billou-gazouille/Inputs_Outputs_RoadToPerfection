
public class XorGateMB : MultiInputOutputDeviceMB
{
    XorGate xorGate = new XorGate();
	public override MultiInputOutputDevice multiIODevice => xorGate;
}

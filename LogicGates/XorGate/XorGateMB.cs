
public class XorGateMB : TwoInputOutputDeviceMB
{
    XorGate xorGate = new XorGate();
	public override TwoInputOutputDevice twoIODevice => xorGate;
}

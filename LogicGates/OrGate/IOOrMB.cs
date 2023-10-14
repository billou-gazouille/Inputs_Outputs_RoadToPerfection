
using UnityEngine;

public class IOOrMB : MultiInputOutputDeviceMB
{
    IOOr ioOr = new IOOr();
	public override MultiInputOutputDevice multiIODevice => ioOr;
}

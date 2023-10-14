using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XorGate
{
	public class XorGateInput : InputDevice { }
	public class XorGateOutput : OutputDevice { }

	public List<InputDevice> SourceInputs { get; private set; }
	// each output will get a sourceInput:
	public List<XorGateOutput> outputs { get; private set; } = new List<XorGateOutput>();     // intermediate

	public InputDevice input { get; private set; } = new XorGateInput();

	public void SetSourceInputs(List<InputDevice> srcInputs)
	{
		SourceInputs = srcInputs;
	}

	public void Init()
	{
		foreach (InputDevice srcInp in SourceInputs)
		{
			srcInp.onTriggered += () =>
			{
				if (TestXor() && !input.IsTriggered)
					input.Trigger();
				else if (!TestXor() && input.IsTriggered)
					input.Untrigger();
			};

			srcInp.onUntriggered += () =>
			{
				if (TestXor() && !input.IsTriggered)
					input.Trigger();
				else if (!TestXor() && input.IsTriggered)
					input.Untrigger();
			};
		}
	}

	public bool TestXor()
	{
		int n_inputsTriggered = 0;
		foreach (InputDevice inp in SourceInputs)
		{
			if (inp.IsTriggered)
				n_inputsTriggered++;
		}
		bool isOdd = n_inputsTriggered % 2 == 1;
		return isOdd;
	}
}


using System.Collections.Generic;
using UnityEngine;

public class AndGate
{
	public class AndGateInput : InputDevice { }
	public class AndGateOutput : OutputDevice { }

    public List<InputDevice> SourceInputs { get; private set; }
	// each output will get a sourceInput:
	public List<AndGateOutput> outputs { get; private set; } = new List<AndGateOutput>();	  // intermediate

	public InputDevice input { get; private set; } = new AndGateInput();
	
	public void SetSourceInputs(List<InputDevice> srcInputs)
    {
		SourceInputs = srcInputs;

		/*
		foreach (InputDevice inp in SourceInputs)
		{
			AndGateOutput andGateOutput = new AndGateOutput();  // intermediate
			andGateOutput.WorldPosition = Vector3.one;
			outputs.Add(andGateOutput);
			Debug.Log(andGateOutput);
			Debug.Log(inp);
			Debug.Log("------------------");
			andGateOutput.SetInputDevice(inp);
		}
		Debug.Log("****************************************");
		foreach (OutputDevice ou in outputs)
		{
			Debug.Log(ou.connectedInputDevice);
		}
		*/
	}

	public void Init()
	{
		foreach (InputDevice srcInp in SourceInputs)
		{
			srcInp.onTriggered += () =>
			{
				//Debug.Log("An input from an AND Gate was triggered!");
				if (TestAnd())
				{
					//Debug.Log("AND satisfied!");
					input.Trigger();
				}
			};

			srcInp.onUntriggered += () =>
			{
				//Debug.Log("An input from an AND Gate was untriggered!");
				if (input.IsTriggered)
					input.Untrigger();
			};
		}
	}

	public bool TestAnd()
	{
		foreach (var inp in SourceInputs)
		{
			if (!inp.IsTriggered)
				return false;
		}
		return true;
	}
}

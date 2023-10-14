
using UnityEngine;

public class StateInputMB : InputDeviceMB
{
	StateInput stateInput = new StateInput();
	public override InputDevice inputDevice => stateInput;

	[SerializeField] Texture2D tex0;
	[SerializeField] Texture2D tex1;

	[SerializeField] bool state;

	Renderer _rend = null;
	Renderer Rend
	{
		get
		{
			if (_rend == null)
				_rend = GetComponent<Renderer>();
			return _rend;
		}
	}

	void OnValidate()
	{
		if (state && !stateInput.IsTriggered)
		{
			Rend.material.mainTexture = tex1;
			stateInput.Trigger();
		}
		else if (!state && stateInput.IsTriggered)
		{
			Rend.material.mainTexture = tex0;
			stateInput.Untrigger();
		}
	}
}

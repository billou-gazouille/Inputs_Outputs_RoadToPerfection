using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneInput_POOP : InputDevice
{
    public TriggerZoneInput_POOP(ITriggerZone triggerZone)
    {
        TriggerZone = triggerZone;
        TriggerZone.onEntered += Trigger;
        TriggerZone.onLeft += Untrigger;
    }

	public ITriggerZone TriggerZone { get; private set; }
}

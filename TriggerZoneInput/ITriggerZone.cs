using System;

public interface ITriggerZone
{
	public event Action onEntered;
    public event Action onLeft;
}

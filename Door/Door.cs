using System;
using UnityEngine;

public class Door : OutputDevice
{
	public Quaternion ClosedRotation { get; private set; }
	public Quaternion OpenedRotation { get; private set; }
	public Quaternion CurrentRotation { get; private set; }

	public event Action<Quaternion> onChangeState;

	public void SetClosedRotation(Quaternion closedRot)
	{
		ClosedRotation = closedRot;
		CurrentRotation = closedRot;
		OpenedRotation = closedRot * Quaternion.Euler(0f, -90f, 0f);
	}

	protected override void OnActivate() => Open();
	protected override void OnDeactivate() => Close();

	void Open()
	{
		CurrentRotation = OpenedRotation;
		onChangeState?.Invoke(CurrentRotation);
	}

	void Close()
	{
		CurrentRotation = ClosedRotation;
		onChangeState?.Invoke(CurrentRotation);
	}
}

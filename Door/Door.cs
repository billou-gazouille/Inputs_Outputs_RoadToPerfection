using System;
using UnityEngine;

public class Door : OutputDevice
{
	public Quaternion ClosedRotation { get; private set; }
	public Quaternion OpenedRotation { get; private set; }
	public Quaternion CurrentRotation { get; private set; }

	public bool IsOpen { get; private set; } = false;
	public event Action<Quaternion> onChangeState;

	public void SetClosedRotation(Quaternion closedRot)
	{
		ClosedRotation = closedRot;
		CurrentRotation = closedRot;
		OpenedRotation = closedRot * Quaternion.Euler(0f, -90f, 0f);
	}

	protected override void Activate() => Open();
	protected override void Deactivate() => Close();

	void Open()
	{
		IsOpen = true;
		CurrentRotation = OpenedRotation;
		onChangeState?.Invoke(CurrentRotation);
	}

	void Close()
	{
		IsOpen = false;
		CurrentRotation = ClosedRotation;
		onChangeState?.Invoke(CurrentRotation);
	}
}

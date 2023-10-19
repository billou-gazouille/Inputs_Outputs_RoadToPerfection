
using UnityEngine;

public class Elevator : OutputDevice
{
    public Vector3 StartPosition {  get; private set; }
    public Vector3 EndPosition { get; private set; }

    public Vector3 CurrentPosition { get; private set; }
    public Vector3 StartEndDir => (EndPosition - StartPosition).normalized;

	public Vector3 MoveDirection => StartEndDir * (IsActive ? 1f : -1f);
	public float Speed { get; set; }

	//protected override void BehaviourIfNullInput() => Deactivate();

	public void Init(Vector3 startPosition, Vector3 endPosition, float speed)
	{
		StartPosition = startPosition;
		EndPosition = endPosition;
		CurrentPosition = startPosition;
		Speed = speed;
	}


	public void UpdatePosition()
    {
		//if (connectedInputDevice == null)
			//return;
        Vector3 translateStep = MoveDirection * Time.deltaTime * Speed;
		CurrentPosition += translateStep;
        CheckOutOfBounds();
	}

	void CheckOutOfBounds()
	{
		if (Vector3.Dot(CurrentPosition-StartPosition, StartEndDir) < 0f)
			CurrentPosition = StartPosition;
		else if (Vector3.Dot(CurrentPosition-EndPosition, -StartEndDir) < 0f)
			CurrentPosition = EndPosition;
	}
}

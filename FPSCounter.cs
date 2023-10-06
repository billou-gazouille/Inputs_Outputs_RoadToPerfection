
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FPSCounter : MonoBehaviour
{
    public int fps { get; private set; }
	public int fpsAvg { get; private set; }   // average over the last n frames
	public int n_framesToTrack { get; private set; } = 100;
    
    Queue<float> frameRates = new Queue<float>();
    float fpsFloat;

    void Update()
    {
		fpsFloat = 1f / Time.deltaTime;
		fps = (int) fpsFloat;
        frameRates.Enqueue(fpsFloat);
        if (frameRates.Count > n_framesToTrack)
            frameRates.Dequeue();
        fpsAvg = (int) frameRates.Average();
	}
}

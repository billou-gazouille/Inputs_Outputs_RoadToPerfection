
using UnityEngine;
using TMPro;

public class FPS_UI : MonoBehaviour
{
    [SerializeField] FPSCounter fps_counter;
    [SerializeField] TMP_Text text;

    int frames_counter = 0;

    void Update()
    {
        if (frames_counter > fps_counter.n_framesToTrack)
        {
            text.text = $"{fps_counter.fpsAvg} fps";
			frames_counter = 0;
		}
		frames_counter++;
	}
}

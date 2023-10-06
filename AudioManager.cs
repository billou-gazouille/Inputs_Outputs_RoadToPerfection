
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; } = null;

	AudioSource audioSource;
	Transform _transform;

	[SerializeField] List<AudioClip> audioClips;
	Dictionary<string, AudioClip> clipNames = new Dictionary<string, AudioClip>();


	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		audioSource = GetComponent<AudioSource>();
		_transform = transform;

		foreach (var clip in audioClips)
			clipNames.Add(clip.name, clip);
	}

	public void Play3DSound(string soundName, Vector3 position)
	{
		audioSource.spatialBlend = 1f;
		_transform.position = position;
		PlayClip(soundName);
	}

	public void Play2DSound(string soundName)
	{
		audioSource.spatialBlend = 0f;
		PlayClip(soundName);
	}

	void PlayClip(string soundName)
	{
		if (!clipNames.ContainsKey(soundName))
		{
			Debug.LogError($"No AudioClip named '{soundName}' was included on the AudioManager !", this);
			return;
		}
		audioSource.clip = clipNames[soundName];
		audioSource.Play();
	}
}

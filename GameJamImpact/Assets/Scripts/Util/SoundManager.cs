using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip laughing, apploases, buzzer;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
		
	}

	public void playSound(int type) {
		audioSource.Stop ();
		switch (type) {
		case 0:
			audioSource.PlayOneShot (laughing, 0.1f);
			break;
		case 1:
			audioSource.PlayOneShot (apploases, 0.1f);
		break;
		case 2:
			//audioSource.PlayOneShot (apploases, 0.1f);
			break;
		case 3:
			//audioSource.PlayOneShot (apploases, 0.1f);
			break;
		case 10:
			audioSource.PlayOneShot (buzzer, 0.1f);
			break;
		}
	}

	public void stop() {
		audioSource.Stop ();
	}
}

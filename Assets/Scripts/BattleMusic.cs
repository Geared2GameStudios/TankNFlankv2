using UnityEngine;
using System.Collections;

public class BattleMusic : MonoBehaviour {

	public static BattleMusic Instance;

	// Sound Variables
	public AudioClip battleTrack;
	public float audio1Volume = 1.0f;
	public float audio2Volume = 0.0f;
	public bool trackPlaying = false;

	public GameObject enemy;
	public GameObject player;

	public float fDistance;

	void PlaySound()
	{
		audio.clip = battleTrack;
		audio.Play();
	}

	void fadeIn()
	{
		if (audio2Volume < 1.0f) 
		{
			audio2Volume += 0.1f * Time.deltaTime;
			audio.volume = audio2Volume;
		}
	}

	void fadeOut()
	{
		if (audio1Volume > 0.1f) 
		{
			audio1Volume -= 0.1f * Time.deltaTime;
			audio.volume = audio1Volume;
		}
	}

	// Distance Player to Enemy AI
	void Distance()
	{
		fDistance = Vector3.Distance (player.transform.position, enemy.transform.position);
	}

	void Update()
	{
		if (enemy != null)
		{
			Distance ();
			if (fDistance < 100) 
			{
				if (!trackPlaying)
				{
					PlaySound ();
					trackPlaying = true;
				}

				fadeIn ();
			}
			else
				fadeOut ();
		}

	}

}

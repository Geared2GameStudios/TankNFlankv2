using UnityEngine;
using System.Collections;

public class destroyObject : MonoBehaviour 
{
	private GameObject firstDrop;

	public bool hit;
	public GameObject currentLightPillar;
	public GameObject nextLightPillar;
	public GameObject xPlode;
	public bool deactivate;

	//Sound Variables
	public AudioClip objectHit;
	public bool playExplosion = false;
	public bool soundPlaying = false;

	
	// Use this for initialization
	void Awake () 
	{
		hit = false;
		deactivate =  false;
		firstDrop = GameObject.Find ("powerUpSmokescreen");
	}

	void PlaySound()
	{		
		if (!soundPlaying && !playExplosion) 
		{
			this.gameObject.audio.PlayOneShot (objectHit);
			playExplosion = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nextLightPillar == null) 
		{
			deactivate = true;
		}
		if (hit) 
		{				
			currentLightPillar.SetActive (false);
			nextLightPillar.SetActive (true);
			this.gameObject.GetComponent<TSD5Fate>().enabled = true;
		    TurboSlice.instance.shatter (gameObject, 3);
			xPlode.SetActive(true);
		
			if (this.gameObject.name == "lastObjective")
			{
				this.gameObject.GetComponent<TSD5Fate>().enabled = true;
				TurboSlice.instance.shatter (gameObject, 3);
				xPlode.SetActive(true);
				firstDrop.gameObject.GetComponent<smokeScreen>().isActive = true;
			}
					
			
		}

		if (!audio.clip == null) 
		{
			
			soundPlaying = false;
			
		}
	}
}

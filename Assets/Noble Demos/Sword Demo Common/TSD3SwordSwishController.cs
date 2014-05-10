using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TSD3SwordVelocityFilter))]
[RequireComponent(typeof(AudioSource))]
public class TSD3SwordSwishController : MonoBehaviour
{
	private TSD3SwordVelocityFilter velocityFilter;
	private new AudioSource audio;
	
	public AudioClip[] swishes;
	
	// Use this for initialization
	void Start () {
		velocityFilter = GetComponent<TSD3SwordVelocityFilter>();
		audio = GetComponent<AudioSource>();
	}
	
	bool wasFastEnoughToCut = false;
	
	// Update is called once per frame
	void Update ()
	{
		bool isFastEnoughToCut = velocityFilter.IsFastEnoughToCut;
		
		if(isFastEnoughToCut && !wasFastEnoughToCut)
		{
			AudioClip clip = swishes[Random.Range(0, swishes.Length)];
			
			audio.PlayOneShot(clip);
		}
		
		wasFastEnoughToCut = isFastEnoughToCut;
	}
}

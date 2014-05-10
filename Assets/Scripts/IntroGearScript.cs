﻿using UnityEngine;
using System.Collections;

public class IntroGearScript : MonoBehaviour {

	public float speed = 10.0f;
	public Transform parent;
	public AudioClip nextClip;
	
	private bool playOnce = false;
	void Awake()
	{
		 parent.position = new Vector3(parent.position.x, 22.0f, parent.position.z);
	
	}
	void Update () 
	{
		this.transform.Rotate(Vector3.up * speed);
		
		if(parent.position.y > 1.0f)
		{
			parent.position = new Vector3(parent.position.x, parent.position.y - 4.0f  * Time.deltaTime, parent.position.z);
		}
		else
		{
		 	speed = 0;
		 	this.audio.loop = false;
		 	if(!playOnce)
		 	{
		 		this.audio.clip = nextClip;
				this.audio.PlayOneShot(nextClip);
				playOnce  = true;
				StartCoroutine(WaittoExit(5.0f));
			}					
		}
	}
	private IEnumerator WaittoExit(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(1);
	}
}
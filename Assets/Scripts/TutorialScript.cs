using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour
 {

	public static TutorialScript Instance;

	private PlayerMove playermove;
	private bool check1 = false;
	private bool check2 = false;
	private bool check3 = false;
	
	public AudioClip[] tutorialClips;
	public string [] tutorialText;
	public Transform player;
	public GameObject[] checkpoints;
	public float[] distances;
	public int index =0;
	public float seconds = 0f;
	public  bool check4 = false;
	public  bool check5 = false;
	
	// Use this for initialization
	void Awake ()
	{
		playermove = player.GetComponent<PlayerMove>();
		playermove.stopMove =true;
		distances = new float[5]; 
	}
	private void GetDistances()
	{
		for (int i = 0; i < 5; i++) 
		{
			if(distances[i] != null)
			{
				distances[i] = Vector3.Distance(player.transform.position, checkpoints[i].transform.position);
			}
		}
		if(distances[0] < 150.0f && distances[0] > 50.0f && !check1)
		{	
			check1 = true;
			playermove.stopMove = true;
			index = 2;
		}
		else if(distances[0] < 50.0f && !check2)
		{
			playermove.stopMove = true;
			check2 = true;
			index = 3;
		}
		
		if(distances[1] < 50.0f && !check3)
		{
		
			playermove.stopMove = true;
			check3 = true;
			index = 4;
		}
		if(distances[3] < 50.0f && !check4)
		{	
			playermove.stopMove = true;
			check4 = true;
			index = 5;
		}
		if(distances[4] < 10.0f && !check5)
		{
			playermove.stopMove = true;
			check5 = true;
			index = 8;
		}
	}
	private void SwitchSounds()
	{
		switch(index)
		{
			case 0:
			{					
				StartCoroutine("AudioWait1");
				index = -1;
				break;
			}
			case 1:
			{
				StartCoroutine("AudioWait2");
				index = -1;
				break;
			}
			case 2:
			{
				player.audio.clip = null;
				seconds = 12f;
				StartCoroutine("AudioWait3", seconds);
				index = -1;
				break;
			}
			case 3:
			{
				player.audio.clip = null;
				seconds = 11f;
				StartCoroutine("AudioWait3", seconds);
				index = -1;
				break;
			}
			case 4:
			{
				player.audio.clip = null;
				seconds = 11f;
				StartCoroutine("AudioWait3", seconds);
				index = -1;
				break;
			}
			case 5:
			{
				player.audio.clip = null;
				seconds = 15f;
				StartCoroutine("AudioWait3", seconds);
				index = -1;
				break;
			}
			case 6:
			{
				playermove.stopMove = true;
				player.audio.clip = null;
				seconds = 20f;
				StartCoroutine("AudioWait3", seconds);
				index = -1;
				break;
			}
			case 7:
			{
				playermove.stopMove = true;
				player.audio.clip = null;
				seconds = 7f;
				StartCoroutine("AudioWait5", seconds);
				index = -1;
				break;
			}
			case 8:
			{
				player.audio.clip = null;
				seconds = 14f;
				StartCoroutine("AudioWait4", seconds);
				index = -1;
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		GetDistances();
		if(index != -1)
			SwitchSounds();
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}

	}
	 IEnumerator AudioWait1()
	{
		player.audio.volume = 1.0f;
		player.audio.PlayOneShot(tutorialClips[index]);
		yield return new WaitForSeconds(11.0f);
		index = 1;
	}
	IEnumerator AudioWait2()
	{
		player.audio.volume = 1.0f;
		player.audio.PlayOneShot(tutorialClips[index]);
		yield return new WaitForSeconds(10.0f);
		playermove.stopMove = false;
		index = -1;
	}
	IEnumerator AudioWait3(float secs)
	{
		player.audio.volume = 1.0f;
		player.audio.PlayOneShot(tutorialClips[index]);
		yield return new WaitForSeconds(secs);
		playermove.stopMove = false;
		index = -1;
	}
	
	IEnumerator AudioWait4(float secs)
	{
		player.audio.volume = 1.0f;
		player.audio.PlayOneShot(tutorialClips[index]);
		yield return new WaitForSeconds(secs);
	
	}
	IEnumerator AudioWait5(float secs)
	{
		player.audio.volume = 1.0f;
		player.audio.PlayOneShot(tutorialClips[index]);
		yield return new WaitForSeconds(secs);
		playermove.stopMove = false;
		index = -1;
	}
	
}

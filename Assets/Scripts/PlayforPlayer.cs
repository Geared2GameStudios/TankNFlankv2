using UnityEngine;
using System.Collections;

public class PlayforPlayer : MonoBehaviour 
{
	public static PlayforPlayer Instance;
	public GameObject[] soundobjects;
	public GameObject 	player;
	public float[] distance;



	// Use this for initialization
	void Awake () 
	{
		Instance = this;
		player = GameObject.FindGameObjectWithTag("Player");
		distance = new float[4];
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < 4; i++) 
		{
			distance[i] = Vector3.Distance(soundobjects[i].transform.position, player.transform.position);

			if(distance[i] < 200.0f)
			{
				soundobjects[i].gameObject.audio.enabled = true;
			}
			else
			{
				soundobjects[i].gameObject.audio.enabled = false;
			}
		}
	}
}

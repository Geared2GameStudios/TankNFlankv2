using UnityEngine;
using System.Collections;

public class alarm : MonoBehaviour {
	public bool bAlarm;
	public GameObject[] tanks;


	// Use this for initialization
	void Awake () {
		bAlarm = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (bAlarm == true) 
		{
			for(int i = 0;i < 3; i++)
			{
				tanks[i].gameObject.GetComponent<AI_Navigation>().enabled = true;
			}
		}

	}
}

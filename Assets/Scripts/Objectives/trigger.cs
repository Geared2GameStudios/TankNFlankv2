using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {
	public GameObject player;
	public GameObject other;

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Vector3.Distance (player.transform.position, this.transform.position) < 100)
		{
			other.GetComponent<AI_Navigation>().enabled = true;
		}
	}


}

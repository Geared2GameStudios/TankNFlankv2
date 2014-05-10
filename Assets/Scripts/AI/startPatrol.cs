using UnityEngine;
using System.Collections;

public class startPatrol : MonoBehaviour 
{
	public GameObject jeep;
	private supportJeep spjeep;

	// Use this for initialization
	void Awake () 
	{
		spjeep = jeep.GetComponent<supportJeep>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(spjeep.pickedUp == true)
				gameObject.GetComponent<AI_Navigation> ().enabled = true;

	}
}

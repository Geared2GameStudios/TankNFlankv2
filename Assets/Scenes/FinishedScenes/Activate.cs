using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {

	public GameObject thisTank;
	public GameObject thisHouse;
	public bool 	  isActive = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!isActive)
		{
			if(thisHouse == null)
			{
				thisTank.SetActive(true);
				isActive = true;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine(WaittoExit(5.0f));
	}

	private IEnumerator WaittoExit(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(1);
	}
}

using UnityEngine;
using System.Collections;

public class Base_Alarm : MonoBehaviour {


	public bool hit;
	public GameObject[] enemy;
	GameObject player;

	// Use this for initialization
	void Awake ()
	{
		hit = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hit) 
		{
			enemy[0].GetComponent<AI_Navigation>().enabled = true;
			enemy[1].GetComponent<AI_Navigation>().enabled = true;
			enemy[2].GetComponent<AI_Navigation>().enabled = true;

			enemy[0].GetComponent<AI_Navigation>().alarm = true;
			enemy[1].GetComponent<AI_Navigation>().alarm = true;
			enemy[2].GetComponent<AI_Navigation>().alarm = true;
		}
	}
}

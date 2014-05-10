using UnityEngine;
using System.Collections;

public class smokeScreen : MonoBehaviour {

	public GameObject 	smokeScreenPickUp;
	public GameObject 	jeep;
	public GameObject   chckpoint;
	public GameObject 	player;
	private playerStats	stats;
	private TutorialScript tut;
	private supportJeep support;

	// Use this for initialization
	void Awake()
	{
	  tut = chckpoint.GetComponent<TutorialScript>();
	 
	  stats = player.GetComponent<playerStats>();
	  support = jeep.GetComponent<supportJeep>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (support.pickedUp == true ) 
		{
			smokeScreenPickUp.transform.position = jeep.transform.position;
		}
		

	}
	void OnTriggerEnter(Collider other)
	{

		if (other.transform.tag == "Player")
		{
			stats.bsmokeScreen = true;
			jeep.SetActive(false);
			Destroy(smokeScreenPickUp);
			tut.index = 6;
		}
		else if (other.transform.tag == "jeep") 
		{
			smokeScreenPickUp.transform.position = other.transform.position;
			support.pickedUp = true;
		}
	}
}

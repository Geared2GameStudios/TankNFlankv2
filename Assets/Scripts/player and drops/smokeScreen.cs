using UnityEngine;
using System.Collections;

public class smokeScreen : MonoBehaviour {
	
	public GameObject 	smokeScreenPickUp;
	public GameObject 	jeep;
	public GameObject   chckpoint;
	public GameObject 	player;
	public GameObject house2;
	public GameObject smoke2Pillar;
	public GameObject truckMesh;
	private playerStats	stats;
	private TutorialScript tut;
	private supportJeep support;
	public bool pickedUp;
	public bool isActive;
	// Use this for initialization
	void Awake()
	{
		tut = chckpoint.GetComponent<TutorialScript>();
		pickedUp = false;
		stats = player.GetComponent<playerStats>();
		support = jeep.GetComponent<supportJeep>();
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 truckDirection = jeep.transform.position - this.transform.position;
		if (truckDirection.magnitude < 8) {
						support.pickedUp = true;
						support.workDammit = false;
			            pickedUp = true;
				}
		
		if (pickedUp == true ) 
		{
			this.transform.position = jeep.transform.position;
		}
		if (this.gameObject.name == "powerUpSmokescreen2") {
			if(house2){
						if (house2.GetComponent<DestroyNonMissionObjects> ().hit == true) {
								smoke2Pillar.SetActive (true);
				                isActive = true;
						}
			}
				}

		
	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "Player")
		{
			stats.bsmokeScreen = true;
			truckMesh.SetActive(false);
			Destroy(smokeScreenPickUp);
			if (this.name == "powerUpSmokescreen")
				tut.index = 6;
		}
		else if (other.transform.tag == "jeep") 
		{
			this.transform.position = other.transform.position;
			support.pickedUp = true;
			pickedUp = true;
		}
	}
}

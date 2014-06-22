using UnityEngine;
using System.Collections;

public class DamagePowerUp : MonoBehaviour {
	
	public GameObject 	DamagePickUp;
	public GameObject 	jeep;
	public GameObject 	player;
	public GameObject Church;
	public GameObject Pillar;
	private playerStats	stats;
	private supportJeep support;
	
	// Use this for initialization
	void Awake()
	{
		
		stats = player.GetComponent<playerStats>();
		support = jeep.GetComponent<supportJeep>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 truckDirection = jeep.transform.position - this.transform.position;
		if (truckDirection.magnitude < 8)
			support.pickedUp = true;
		
		if (support.pickedUp == true ) 
		{
			DamagePickUp.transform.position = jeep.transform.position;
		}

		if (Church.GetComponent<DestroyNonMissionObjects> ().hit == true) {
			Pillar.SetActive (true);
				}
		
	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "Player")
		{
			stats.playerDamage = 2;
			jeep.SetActive(false);
			Destroy(DamagePickUp);
		}
		else if (other.transform.tag == "jeep") 
		{
			DamagePickUp.transform.position = other.transform.position;
			support.pickedUp = true;
		}
	}
}

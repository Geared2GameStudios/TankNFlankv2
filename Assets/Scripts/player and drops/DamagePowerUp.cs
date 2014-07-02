using UnityEngine;
using System.Collections;

public class DamagePowerUp : MonoBehaviour {
	
	public GameObject 	DamagePickUp;
	public GameObject 	player;
	public GameObject Church;
	public GameObject Pillar;
	public GameObject 	jeep;
	public GameObject truckMesh;
	private playerStats	stats;
	private supportJeep support;
	public bool pickedUp;
	public bool isActive;
	
	// Use this for initialization
	void Awake()
	{
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
		if (Church){
						if (Church.GetComponent<DestroyNonMissionObjects> ().hit == true) {
								Pillar.SetActive (true);
								isActive = true;
						}
		}
		
						if (pickedUp == true) {
								this.transform.position = jeep.transform.position;
						}
				
	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "Player")
		{
			stats.playerDamage = 2;
			truckMesh.SetActive(false);
			Destroy(DamagePickUp);
		}
		else if (other.transform.tag == "jeep") 
		{
			DamagePickUp.transform.position = other.transform.position;
			support.pickedUp = true;
			pickedUp = true;
		}
	}
}

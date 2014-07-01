using UnityEngine;
using System.Collections;

public class DamagePowerUp : MonoBehaviour
{
	
	public GameObject 	DamagePickUp;
	public GameObject 	player;
	public GameObject Church;
	public GameObject Pillar;
	private playerStats	stats;
	public bool OneTime = false;
	
	// Use this for initialization
	void Awake()
	{
		
		stats = player.GetComponent<playerStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(!OneTime)
		{

			if (Church.GetComponent<DestroyNonMissionObjects> ().hit == true ) 
			{
				Pillar.SetActive (true);
				OneTime = true;
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "Player")
		{
			stats.playerDamage = 2;
			//jeep.SetActive(false);
			Destroy(DamagePickUp);
		}
		//else if (other.transform.tag == "jeep") 
		//{
			//DamagePickUp.transform.position = other.transform.position;
			//support.pickedUp = true;
		//}
	}
}

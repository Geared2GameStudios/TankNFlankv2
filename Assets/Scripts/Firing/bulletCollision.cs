using UnityEngine;
using System.Collections;

public class bulletCollision : MonoBehaviour {
	private Transform clone;
	private enemyHealth eHealth;
	private playerStats pStats;
	public GameObject clonePrefab;
	public GameObject chckpoint;
	private TutorialScript tut;
	// Use this for initialization
	void Awake () {
	
		eHealth = GameObject.FindGameObjectWithTag ("enemy").GetComponent<enemyHealth> ();
		pStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerStats> ();
		chckpoint = GameObject.Find("CheckPoints");
		tut = chckpoint.GetComponent<TutorialScript>();
	 
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "objectiveObject")
		{
			other.gameObject.GetComponent<destroyObject> ().hit = true;
		}
	
	  if (other.transform.tag == "enemy") 
		{
			eHealth.health -= pStats.playerDamage;
			if (eHealth.health <= 0)
			{
			clone = Instantiate(clonePrefab, other.transform.position, other.transform.localRotation) as Transform;
			Destroy(other.gameObject);
			tut.index = 7;
			
			}
		
				
		}
	 if(other.gameObject.transform.tag == "barrier" || other.gameObject.transform.name == "Barrier")
		{
			DestroyObject(this.gameObject);
		}
	}
}

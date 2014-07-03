using UnityEngine;
using System.Collections;

public class supportJeep : MonoBehaviour {
	public static supportJeep Instance;
	public GameObject[] drop;
	public GameObject truckMesh;
	public GameObject misselPiller;
	public bool pickedUp;
	public bool follow;
	public bool workDammit;
	public Transform player;
	
	NavMeshAgent npc;
	
	
	
	// Use this for initialization
	void Start () {
		Instance = this;
		npc = GetComponent<NavMeshAgent>();
		follow = true;
		pickedUp = false;
		workDammit = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (follow && workDammit == false && pickedUp == false) 
		{
			npc.destination = player.localPosition;
			truckMesh.SetActive(false);
			
		}
		
		
		if (follow) 
		{
			npc.destination = player.localPosition;
		}
		
		if (workDammit == true)
		{
			if (pickedUp)
				pickedUp = false;

			follow = false;
			dropPickUp ();
		}
		
		if (pickedUp == true) 
		{
			workDammit = false;
			follow = true;
			misselPiller.SetActive(true);
		}
	}
	
	void dropPickUp()
	{
		truckMesh.SetActive (true);
		if (drop[0].gameObject.GetComponent<smokeScreen>().isActive == true && drop[0])
			npc.destination = drop[0].transform.position;
		if (drop[1].gameObject.GetComponent<smokeScreen>().isActive == true && drop[1])
			npc.destination = drop[1].transform.position;
		if (drop[2].gameObject.GetComponent<DamagePowerUp>().isActive == true && drop[2])
			npc.destination = drop[2].transform.position;
		
		
	}
}

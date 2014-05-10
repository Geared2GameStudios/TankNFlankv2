using UnityEngine;
using System.Collections;

public class AI_Navigation : MonoBehaviour {

	public static AI_Navigation Instance;
	private int currentNode = 0;
	private float attackTime;
	public bool deactivate;
	public Transform[] waypoints;
	public GameObject player;
	private TestScript test;
	private playerStats stats;
	public Transform turret;
	public float attackCD;
	private enemyHealth enemy;

	bool waypointLoop = true;
	bool isNear;
	float attackRange = 700f;
	float pointBlank = 100f;
	NavMeshAgent npc;
	
	int layerMask = 1 << 8;
	RaycastHit hit;


	// Use this for initialization
	void Awake () 
	{
		Instance = this;
		attackTime = Time.time;
		npc = GetComponent<NavMeshAgent>();
		stats = player.GetComponent<playerStats>();
		layerMask = ~layerMask;
		enemy = this.GetComponent<enemyHealth>();
		test = player.GetComponent<TestScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!deactivate && !test.stopMove)
		{
			Debug.DrawRay (turret.position, turret.forward*50, Color.magenta);
			if (currentNode < waypoints.Length) 
			{
				TransverseWaypoints();
			}
			else
				if(waypointLoop)
				{
				currentNode = 0;
				
				}

		}

	}
	
	void TransverseWaypoints() //causes npc's to transverse waypoint objects
	{
		Vector3 npcDirection = waypoints [currentNode].position - this.transform.position;
		Vector3 playerDirection = player.transform.position - this.transform.position;
		
		if (playerDirection.sqrMagnitude < attackRange)
		{
			if (isNear){
				lookAt();
				attack ();
			}
								
			else if (Vector3.Dot (playerDirection.normalized, turret.forward) > 0 
			         && Physics.Raycast(turret.position,turret.forward,out hit,Mathf.Infinity,layerMask)){
								lookAt();
								attack ();
								isNear = true;
						} 
				}

		else if (npcDirection.magnitude < 8) {
								currentNode++; // advanced the waypoint array
								isNear = false;
								turretSweep();
				} else {
								npc.destination = waypoints [currentNode].position; // moves npc to waypoint
								isNear = false;
								turretSweep();
						}
				
	}
	
	void attack()
	{
		if ((player.transform.position - transform.position).sqrMagnitude > pointBlank && Time.time > attackTime) 
		{
			npc.destination = player.transform.position;
			stats.playerHealth -= enemy.damage;
			attackTime = Time.time + attackCD;
		}

	}

	void lookAt()
	{
		Vector3 lookAtPlayer = player.transform.position - turret.position;
		turret.rotation = Quaternion.LookRotation (lookAtPlayer);

	}

	void turretSweep()
	{
		turret.rotation = Quaternion.Euler(0,Mathf.Sin(Time.realtimeSinceStartup/2)* 180, 0);
	}



}

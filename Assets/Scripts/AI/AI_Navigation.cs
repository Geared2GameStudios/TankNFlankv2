using UnityEngine;
using System.Collections;

public class AI_Navigation : MonoBehaviour {
	
	public static AI_Navigation Instance;
	
	private int currentNode = 0;
	private float attackTime;
	private PlayerMove test;
	private playerStats stats;
	private enemyHealth enemy;
	private Vector3 LastPlayerSighting;
	
	public bool deactivate;
	public bool isDetected;
	public bool isNear;
	public Transform[] waypoints;
	public GameObject player;
	public GameObject Alarm;
	public Transform turret;
	public float attackCD;
	
	bool waypointLoop = true;
	
	
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
		test = player.GetComponent<PlayerMove>();
		isNear = false;
		isDetected = false;		

	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(!deactivate && !test.stopMove)
		{
			Debug.DrawRay (turret.position, turret.forward*100, Color.magenta);
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

		if (Alarm.gameObject.GetComponent<alarm> ().bAlarm == true) 
		{
			npc.destination = player.transform.position;
		}

		
		if (playerDirection.sqrMagnitude < attackRange)
		{
			if (isNear && isDetected){
				lookAt();
				attack ();
				LastPlayerSighting = player.transform.position;
			}
			
			else if (Physics.Raycast(turret.position,turret.forward*100,out hit)|| Vector3.Distance(player.transform.position,this.transform.position) < 100 )
			{
				if (hit.collider.tag == "Player")
				{
					lookAt();
					attack ();
					isNear = true; 
					isDetected = true;
				}
				else
				{
					turretSweep();
					isDetected = false;
				}
			} 
			
		}
		
		else if (npcDirection.magnitude < 8 || Alarm.gameObject.GetComponent<alarm> ().bAlarm == false) {
			currentNode++; // advanced the waypoint array
			turretSweep();
		} else if(!isNear&& Alarm.gameObject.GetComponent<alarm> ().bAlarm == false) {
			npc.destination = waypoints [currentNode].position; // moves npc to waypoint
			turretSweep();
		}
		if (isNear && !isDetected) {
			
			npc.destination = LastPlayerSighting;
			turretSweep ();
		}
		
	}
	
	void attack()
	{
		Vector3 offSet = player.transform.position - turret.transform.position;
		float sqrLen = offSet.sqrMagnitude;
		lookAt ();
		
		if (sqrLen < 500)
			npc.Stop ();
		else
			npc.destination = player.transform.position;
		
		if (Time.time > attackTime) 
		{
			
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
using UnityEngine;
using System.Collections;

public class JeepController : MonoBehaviour {

	public Transform 	jeep;
	public Transform 	spawner;
	public Transform 	player;
	public bool 		activated = false;
	public bool 		oneTimeOn = false;
	public bool 		oneTimeOff = false;
	private supportJeep spjeep;
	private TutorialScript tut;
	private PlayerMove	test;
	public float 		coolDown = 5.0f;
	public float 		currentTime = 0.0f;
	
	// Use this for initialization
	void Awake () 
	{
		spjeep = jeep.GetComponent<supportJeep>();
		tut = this.GetComponent<TutorialScript>();
		test = player.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
			if(Input.GetButtonDown("Support") && tut.check4  && !test.stopMove)
			{
				if(!activated)
				{
					if(currentTime <= 0.0f)
					{
					
						activated  = true;
						oneTimeOn = true;
						oneTimeOff = true;
						spjeep.workDammit = true;
						currentTime = 0.0f;
					}
				
			
					
				}
				else
				{
					activated = false;
					spjeep.follow = false;
				}
			}
			
		
		
		
		if(activated)
		{
			if(oneTimeOn)
			{
				
				jeep.transform.localPosition  = spawner.transform.position;
				
				oneTimeOn  = false;
			}
		
		}
		else
		{
			if(oneTimeOff)
			{
				currentTime = 0.0f;
				currentTime += coolDown;
				oneTimeOff = false;
			}
			
			currentTime -= Time.deltaTime;
			
					
		}

	}
}

using UnityEngine;
using System.Collections;

public class OculusTurret : MonoBehaviour {
	public static OculusTurret Instance;
	private TestScript pMove;
	public GameObject player;
	// Controls whether the player should or shouldn't be moving

	// private members
	
	private float m_fmoveSpeed = 20.0f;					// Controls the players moving speed
	private float m_fturnSpeed = 50.0f;					// Controls the players rotating speed
	// Use this for initialization
	void Awake ()
	{
		Instance = this;
		pMove = player.GetComponent<TestScript>();  
	}
	
	// Update is called once per frame
	void Update () 
	{
		float tempHorz = Input.GetAxis("THorz");
		float tempVert = Input.GetAxis("TVert");

		if(!pMove.stopMove)
		{

			this.transform.Rotate(Vector3.down * tempVert * m_fturnSpeed * Time.deltaTime);

			this.transform.Rotate(Vector3.right * tempHorz * m_fturnSpeed * Time.deltaTime);

			//Limits range
			Vector3 temp = this.transform.eulerAngles;

			//If you want it higher increase the 15's
			//if you want lower reduce the 360/0
			if(temp.x < 360 && temp.x > 180)
				temp.x = 0;
			if(temp.x > 15 && temp.x <= 180)
				temp.x = 15;
				
			temp.z = 0;	
			this.transform.eulerAngles = temp;


		}
	}

}
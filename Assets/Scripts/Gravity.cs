using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public float fGravity;
	private Vector3 racast;
	public LayerMask lWater;
	public float distancetohitground;

	RaycastHit rFront;
	RaycastHit rLeft;
	RaycastHit rRight;
	RaycastHit rMiddle;
	RaycastHit rBack;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		#region Racast stuff
		//Raycasts


		//Raycasts actually launching
		Vector3 TempPosition = transform.position + Vector3.up * 1f;
		Physics.Raycast (TempPosition + (transform.forward *  3), Vector3.down,out rFront, 500, lWater);
		Physics.Raycast (TempPosition , Vector3.down,out rMiddle, 500,lWater);
		Physics.Raycast (TempPosition - (transform.right * 2)+ (transform.forward *  3), Vector3.down,out rLeft, 500, lWater);
		Physics.Raycast (TempPosition + (transform.right * 2)+ (transform.forward *  3), Vector3.down,out rRight,500, lWater);
		Physics.Raycast (TempPosition - (transform.forward *  3), Vector3.down,out rBack, 500,lWater);
		//Debug Drawing the raycasts
		Debug.DrawRay (TempPosition + (transform.forward *  3), Vector3.down, Color.blue);
		Debug.DrawRay (TempPosition , Vector3.down, Color.blue);
		Debug.DrawRay (TempPosition - (transform.forward *  3), Vector3.down, Color.blue);
		Debug.DrawRay (TempPosition - (transform.right * 2)+ (transform.forward *  3), Vector3.down, Color.green);
		Debug.DrawRay (TempPosition + (transform.right * 2)+ (transform.forward *  3), Vector3.down, Color.green);
		#endregion



		if(rFront.distance > distancetohitground && rBack.distance > distancetohitground && rLeft.distance > distancetohitground && rRight.distance > distancetohitground && rMiddle.distance > distancetohitground)
		{
			//timeProj-= Time.deltaTime;
		
			Vector3 temp;
			temp = transform.position;
			//temp.y += 0.01f;
			transform.position = temp;
			
		}
		//Checks closeness to the gound, stops falling if close enough
		if(rFront.distance > distancetohitground && rBack.distance > distancetohitground && rLeft.distance > distancetohitground && rRight.distance > distancetohitground && rMiddle.distance > distancetohitground)
		{
			//timeProj-= Time.deltaTime;

			Vector3 temp;
			temp = transform.position;
			temp.y -= (fGravity * Time.deltaTime);
			transform.position = temp;

		}
		else{

			#region Angling the object
			Vector3 vAngle = transform.eulerAngles;
			//Angles stuff, I'll probably be fixing this up more later on
			//it's a bit janky
			if( rFront.distance < rBack.distance)
			{
				float temp = (rBack.distance - rFront.distance);
				vAngle.x -= temp* fGravity;
			}

			if(rBack.distance < rFront.distance)
			{
				float temp = (rFront.distance - rBack.distance);
				vAngle.x += temp* fGravity;
			}

			if(rLeft.distance < rRight.distance)
			{
				float temp = (rRight.distance - rLeft.distance);
				vAngle.z -= temp* fGravity;
			}
			if(rRight.distance < rLeft.distance)
			{
				float temp = (rLeft.distance - rRight.distance);
				vAngle.z += temp* fGravity;
			}

			//Makes sure the object doesn't get angled too far
			if(vAngle.x < 340 && vAngle.x > 300)
			{
				Debug.Log ("x+"+vAngle.x);
				vAngle.x = 340;
			}
			else if (vAngle.x > 30 && vAngle.x < 90 )
			{
				vAngle.x = 30;
				Debug.Log (vAngle.x);
			}
			if(vAngle.x < 345 && vAngle.x > 300)
			{
				Debug.Log ("x+"+vAngle.x);
				vAngle.x = 345;				
			}
			
			else if (vAngle.x > 25 && vAngle.x < 90 )
			{
				vAngle.x = 25;
				Debug.Log (vAngle.x);
			}

			transform.eulerAngles = vAngle;
			#endregion
		}

	}
}




#region Notes for myself of things I was trying before that didn't work
/*
			Debug.Log ("else");

			float f = collider.bounds.size.x;

			RaycastHit rhit;
			Vector3 vPosition = transform.position;


			//vPosition.x += (collider.bounds.size.x / 2);
			vPosition += (transform.forward *(collider.bounds.size.x / 2));
			Physics.Raycast (vPosition, Vector3.down,out rhit, 2);
			Debug.DrawRay (vPosition, Vector3.down, Color.blue);
			float fFront = rhit.distance;

			vPosition = transform.position;
			//vPosition += (-transform.forward * 7);
			vPosition += (-transform.forward *  3);
			Physics.Raycast (vPosition, Vector3.down,out rhit, 2);
			Debug.DrawRay (vPosition, Vector3.down, Color.blue);
			float fBack = rhit.distance;

			vPosition = transform.position;
			//vPosition.z -= (collider.bounds.size.z / 2);
			//vPosition += (-transform.right * 2);
			vPosition += (-transform.right * (collider.bounds.size.z / 2));
			//vPosition += (-transform.forward * 3);
			Physics.Raycast (vPosition, Vector3.down,out rhit, 2);
			Debug.DrawRay (vPosition, Vector3.down, Color.blue);
			float fLeft = rhit.distance;

			vPosition = transform.position;
			//vPosition.z += (collider.bounds.size.z / 2);
			//vPosition += (transform.right * 2);
			vPosition += (transform.right * (collider.bounds.size.z / 2));
			//vPosition += (-transform.forward * 3);
			Physics.Raycast (vPosition, Vector3.down,out rhit, 2);
			Debug.DrawRay (vPosition, Vector3.down, Color.blue);
			float fRight = rhit.distance;


			//Debug.Log (fFront);
			//Debug.Log (fBack);
			//Debug.Log (fLeft);
			//Debug.Log (fRight);
			//Debug.Log (f);
			//Debug.Log ("x+"+vAngle.x);

				*/
#endregion

using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public float fGravity;
	private Vector3 racast;
	public LayerMask lWater;
	public float distancetohitground;

	RaycastHit rFront;
	RaycastHit rMiddle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		#region Racast stuff

		//Raycasts actually launching
		Vector3 TempPosition = transform.position + Vector3.up * 1f;
		Physics.Raycast (TempPosition + (transform.forward *  3), Vector3.down,out rFront, 500, lWater);
		Physics.Raycast (TempPosition , Vector3.down,out rMiddle, 500,lWater);
	
		#endregion



		//Checks closeness to the gound, stops falling if close enough
		if(rFront.distance > 500.0f || rMiddle.distance > 500.0f)
		{
			Vector3 temp = transform.position;
			temp.y += fGravity + 1;
			transform.position = temp;
		}
		if(rFront.distance > distancetohitground)
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

			//forward backward
			/*
			if( rFront.distance < rMiddle.distance)
			{
				Debug.Log ("Adding");
				vAngle.x +=(rFront.distance - rMiddle.distance)*8;
			}

			if( rFront.distance > rMiddle.distance)
			{
				Debug.Log ("Subbing");
				vAngle.x += (rFront.distance - rMiddle.distance)*8;
			}*/
			transform.forward = Vector3.Slerp (transform.forward,rFront.point - rMiddle.point, Time.deltaTime*20);

			//Left and right
			Quaternion setrotation = new Quaternion();
			setrotation = Quaternion.LookRotation (transform.forward, rMiddle.normal);

			//Makes sure the object doesn't get angled too far
			if(vAngle.x < 330 && vAngle.x > 300)
			{
			
				vAngle.x = 330;
			}
			else if (vAngle.x > 40 && vAngle.x < 90 )
			{
				vAngle.x = 40;
			
			}
		
			

			transform.eulerAngles = vAngle;
			transform.rotation = Quaternion.RotateTowards( transform.rotation, setrotation, Time.deltaTime * 20f);

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
/*(Vector3.Cross (rRight.point-Vector3.up, rMiddle.point-Vector3.up  )+ Vector3.Cross( rMiddle.point-Vector3.up  , rFront.point-Vector3.up)
			               + Vector3.Cross (rFront.point-Vector3.up  , rLeft.point-Vector3.up  )+ Vector3.Cross( rLeft.point-Vector3.up , rRight.point-Vector3.up  )).normalized;
			Debug.Log ("Up Direction"+UpDirection);

		Physics.Raycast (TempPosition - (transform.right * 2)+ (transform.forward *  2), Vector3.down,out rLeft, 500, lWater);
		Physics.Raycast (TempPosition + (transform.right * 2)+ (transform.forward *  2), Vector3.down,out rRight,500, lWater);
		//Physics.Raycast (TempPosition - (transform.right * 2), Vector3.down,out rFront, 500, lWater);
		//Physics.Raycast (TempPosition + (transform.right * 2), Vector3.down,out rMiddle,500, lWater);
		//Physics.Raycast (TempPosition - (transform.forward *  3), Vector3.down,out rBack, 500,lWater);
			#region Drawing Raycasta
		//Debug Drawing the raycasts
		/*
		Debug.DrawRay (TempPosition + (transform.forward *  3), Vector3.down, Color.blue);
		Debug.DrawRay (TempPosition , Vector3.down, Color.blue);
		//Debug.DrawRay (TempPosition - (transform.forward *  3), Vector3.down, Color.blue);
		Debug.DrawRay (TempPosition - (transform.right * 2)+ (transform.forward *  2), Vector3.down, Color.green);
		Debug.DrawRay (TempPosition + (transform.right * 2)+ (transform.forward *  2), Vector3.down, Color.green);
#endregion
*/
	
#endregion

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public ParticleSystem leftTreadSystem;
	public ParticleSystem rightTreadSystem;
	public Transform 		skybox;
	public GameObject		laterLevel;
	public GameObject 		currentLevel;
	private  CharacterController controller;
	private float MovementSpeed = 0.5f;
	private float Acceleration = 1.02f;
	private float MaxSpeed =  20;
	private float TurnSpeed = 50.0f;
	private Vector3 Direction;
	public bool stopMove = false;
	private float Distance2Terrain = 0f;
	public AudioClip[] tankMovement;
	private int iSound;
	// Use this for initialization
	void Awake () {
		controller = GetComponent<CharacterController>();
	}

	void PlaySound(int clip)
	{
		audio.volume = 0.5f;
		//audio.volume = PlayerSettingsScript.Instance.effectsVolume;
		audio.clip = tankMovement[clip];
		audio.Play();
	}
	// Update is called once per frame
	void Update () {
		skybox.position = this.transform.position;
		float tempDistance = Vector3.Distance(this.transform.position, laterLevel.transform.position);
		if(tempDistance <= 100f)
		{
			currentLevel.SetActive(false);
		}
		else if(tempDistance <= 1000)
		{
			laterLevel.SetActive(true);
		}


		

		if(!stopMove)
		{
		if(Input.GetAxis ("Vertical") > 0)
		{
			MovementSpeed *= Acceleration;
			transform.Rotate(0,Input.GetAxis ("Horizontal")*TurnSpeed*Time.deltaTime*0.5f, 0);
			//Debug.Log ("slow turn");
		}
		else if(Input.GetAxis ("Vertical") < 0)
		{
			MovementSpeed *= Acceleration;
			transform.Rotate(0,Input.GetAxis ("Horizontal")*TurnSpeed*Time.deltaTime, 0);
			//Debug.Log("fast turn");
		}
		else if(Input.GetAxis ("Vertical") == 0)
		{
			MovementSpeed = 2.0f;
			//Debug.Log ("MovmentSpeed"+MovementSpeed);
			transform.Rotate(0,Input.GetAxis ("Horizontal")*TurnSpeed*Time.deltaTime, 0);
			
		}
		if(MovementSpeed > MaxSpeed)
		{
			//Debug.Log ("Too Much Speed");
			MovementSpeed = MaxSpeed;
		}

		Direction = new Vector3(0,0,Input.GetAxis ("Vertical"));
		Direction = transform.TransformDirection (Direction);

		controller.Move (Direction* MovementSpeed* Time.deltaTime);

		if(Direction.x != 0.0f || Direction.z != 0.0f)
		{
			
			if(iSound == 0)
			{
				audio.Stop ();
			}
			
			if(!audio.isPlaying)
			{
				iSound = 1;
				PlaySound(1);
			}
			leftTreadSystem.gameObject.SetActive(true);
			rightTreadSystem.gameObject.SetActive(true);
		}
		else
		{
			if(iSound == 1)
			{
				audio.Stop();
			}
			
			if(!audio.isPlaying)
			{
				iSound = 0;
				PlaySound (0);
			}

			if(Input.GetAxis ("Horizontal")>0)
					leftTreadSystem.gameObject.SetActive(true);
			else
					leftTreadSystem.gameObject.SetActive(false);
			if(Input.GetAxis ("Horizontal") < 0)
					rightTreadSystem.gameObject.SetActive(true);
				else
					rightTreadSystem.gameObject.SetActive(false);
		}


		}
	}
}

using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour 
{
	public TestScript Instance;
	public ParticleSystem leftTreadSystem;
	public ParticleSystem rightTreadSystem;



	private  CharacterController controller;
	private float speed = 16.0f;
	private float turnSpeed = 90.0f;
	public bool stopMove = false;

	public AudioClip[] tankMovement;
	private int iSound;

	private void Awake()
	{
		Instance = this;
		controller = GetComponent<CharacterController>();
		
	}
	void PlaySound(int clip)
	{
		audio.volume = 0.5f;
		audio.clip = tankMovement[clip];
		audio.Play();
	}
	
		
	private void Update()
	{
		

			if(!stopMove)
			{
			transform.Rotate(0,Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime,0);

			Vector3 movDir = new Vector3( 0, 0, Input.GetAxis("Vertical"));

			movDir = transform.TransformDirection (movDir);
			movDir*= speed;

			controller.Move (movDir * Time.deltaTime);
			if(movDir.x != 0.0f || movDir.z != 0.0f)
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
				
				
				leftTreadSystem.gameObject.SetActive(false);
				rightTreadSystem.gameObject.SetActive(false);
			}
		}
	}
}

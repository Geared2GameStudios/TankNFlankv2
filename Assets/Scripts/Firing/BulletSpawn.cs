using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour 
{


	public GameObject muzzleFlash;
	public ParticleSystem smoke;
	//Debug
	private TestScript test;
	//Rate of fire
	public float ShellFireRate;
	//Firing mechanisms
	private float NextShell = 0;
	private bool TankFire = false;
	public GameObject player;
	//The prefab used for the bullets
	public GameObject ShellPrefab;

	public AudioClip tankFire;	

	GameObject Shell;
	// Use this for initialization
	void Awake () {
		test = player.GetComponent<TestScript>();
//		Debug.Log("Accessed");

	}

	public void PlaySound()
	{
		this.gameObject.audio.PlayOneShot (tankFire);
	}

	void Fire ()
	{
		//sanity check
		if(!TankFire) return;
	
		//Creates the shell
		Shell = Instantiate( ShellPrefab, transform.position, transform.rotation) as GameObject;	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Fires stuff
		TankFire = false;
		if(!test.stopMove)
		{
			if(Input.GetAxis("Fire") > 0.05f && Time.time > NextShell)
			{
				muzzleFlash.particleEmitter.Emit ();
				smoke.Play ();
				//Debug
				//Debug.Log("Left Click");
				NextShell = Time.time + ShellFireRate;
				TankFire = true;

				Fire();
				PlaySound ();
			
			}
		}
	}
}

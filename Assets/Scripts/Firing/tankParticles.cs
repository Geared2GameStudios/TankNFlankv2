using UnityEngine;
using System.Collections;

public class tankParticles : MonoBehaviour {
	public GameObject muzzleFlash;
	public ParticleSystem smoke;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			
						muzzleFlash.particleEmitter.Emit ();
						smoke.Play ();
				}
	}
}

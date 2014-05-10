using UnityEngine;
using System.Collections;

public class raycastTest : MonoBehaviour {
	RaycastHit hit;
	int layerMask = 1 << 8;
	Transform transform;
	public GameObject muzzleFlash;
	public ParticleSystem smoke;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {

			muzzleFlash.particleEmitter.Emit();
			smoke.Play();
			Debug.DrawRay (transform.position, transform.forward*100, Color.magenta);

			if (Physics.Raycast(transform.position,transform.forward,out hit,150,layerMask))
			{
				hit.collider.gameObject.GetComponent<destroyObject>().hit = true;
			}

		}
	}
}

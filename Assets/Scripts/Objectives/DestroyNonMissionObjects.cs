using UnityEngine;
using System.Collections;

public class DestroyNonMissionObjects : MonoBehaviour {

	public bool hit;
	public GameObject xPlode;
	public bool deactivate;
	
	// Use this for initialization
	void Awake ()
	{
		hit = false;
		deactivate =  false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hit) {
			this.gameObject.rigidbody.useGravity = false;
			this.gameObject.rigidbody.isKinematic = true;
				}

		if (hit) 
		{
			this.gameObject.rigidbody.useGravity = true;
			this.gameObject.rigidbody2D.isKinematic = false;
			this.gameObject.GetComponent<TSD5Fate>().enabled = true;
			TurboSlice.instance.shatter (gameObject, 3);
			xPlode.SetActive(true);
		}
	}
}
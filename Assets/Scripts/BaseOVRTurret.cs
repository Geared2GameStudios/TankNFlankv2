using UnityEngine;
using System.Collections;

public class BaseOVRTurret : MonoBehaviour {
 	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localRotation = Quaternion.Euler(0,0, target.transform.rotation.eulerAngles.y - 180f);
	}
}

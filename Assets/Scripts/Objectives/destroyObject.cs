using UnityEngine;
using System.Collections;

public class destroyObject : MonoBehaviour {

	public bool hit;
	public GameObject currentLightPillar;
	public GameObject nextLightPillar;
	public ParticleSystem smoke;
	public bool deactivate;
	
	// Use this for initialization
	void Start () {
		hit = false;
		deactivate =  false;
		
	}
	
	// Update is called once per frame
	void Update () {
				if (nextLightPillar == null) {
						deactivate = true;
				}
				if (hit) {
			
						//smoke.Play ();
						if (!deactivate) {
								currentLightPillar.SetActive (false);
								nextLightPillar.SetActive (true);
								this.gameObject.GetComponent<TSD5Fate>().enabled = true;
								TurboSlice.instance.shatter (gameObject, 3);
								
						}
							if (this.gameObject.name == "lastObjective"){
								this.gameObject.GetComponent<TSD5Fate>().enabled = true;
								TurboSlice.instance.shatter (gameObject, 3);
								
								}
				}
		}
}

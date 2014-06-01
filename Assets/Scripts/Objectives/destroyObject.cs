using UnityEngine;
using System.Collections;

public class destroyObject : MonoBehaviour {

	public bool hit;
	public GameObject currentLightPillar;
	public GameObject nextLightPillar;
	public ParticleSystem smoke;
	//public bool deactivate;
	
	// Use this for initialization
	void Awake () {
		hit = false;
		//deactivate =  false;
		
	}
	
	// Update is called once per frame
	void Update () {
				//if (nextLightPillar == null) {
				//		deactivate = true;
				//}
				if (hit) {

						
								currentLightPillar.SetActive (false);
								nextLightPillar.SetActive (true);
								this.gameObject.GetComponent<TSD5Fate>().enabled = true;
								TurboSlice.instance.shatter (gameObject, 3);
								
						
							if (this.gameObject.name == "lastObjective"){
								this.gameObject.GetComponent<TSD5Fate>().enabled = true;
								TurboSlice.instance.shatter (gameObject, 3);
								
								}
							
							if (this.gameObject.tag == "Base")
							{
								this.gameObject.GetComponent<Base_Alarm>().hit = true;
								this.gameObject.GetComponent<TSD5Fate>().enabled = true;
								TurboSlice.instance.shatter (gameObject, 3);
							}
				}
		}
}

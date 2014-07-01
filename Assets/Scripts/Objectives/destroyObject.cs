using UnityEngine;
using System.Collections;

public class destroyObject : MonoBehaviour 
{

	public bool hit;
	public GameObject currentLightPillar;
	public GameObject nextLightPillar;
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
		if (nextLightPillar == null) 
		{
			deactivate = true;
		}
		if (hit) 
		{				
			currentLightPillar.SetActive (false);
			nextLightPillar.SetActive (true);
			this.gameObject.GetComponent<TSD5Fate>().enabled = true;
		    TurboSlice.instance.shatter (gameObject, 3);
			xPlode.SetActive(true);
		
			if (this.gameObject.name == "lastObjective")
			{
				this.gameObject.GetComponent<TSD5Fate>().enabled = true;
				TurboSlice.instance.shatter (gameObject, 3);
				xPlode.SetActive(true);
			}
					
			
		}
	}
}

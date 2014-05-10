using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

	public static SliderScript Instance;
	public GameObject HUD;
	public GameObject Slider;
	public GameObject reticule;
	private bool showHUD;
	private bool slideOut;
	private bool showReticule = false;
	private float closed = 1.46f;
	private float open = -2.0f;

	// Use this for initialization
	void Awake () 
	{
		Instance = this;
		slideOut = false;
		showHUD = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("HUD"))
		{
			if(showHUD)
				showHUD = false;
			else
				showHUD = true;
				
		}

		if(Input.GetButtonDown("Target") )
		{
			if(!showReticule)
				showReticule = true;
	
		}
		else if(Input.GetButtonUp("Target"))
		{
			showReticule = false;
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			if(showHUD)
			{
				if(slideOut)
					slideOut = false;
				else
					slideOut = true;
			}	
		}
		
		if(showHUD)
			HUD.gameObject.SetActive(true);
		else
			HUD.gameObject.SetActive(false);
		
		if(showReticule)
		{
			reticule.gameObject.SetActive(true);
		}
		else
		{
			reticule.gameObject.SetActive(false);
		}
		
		if(slideOut)
		{
			Slider.transform.localPosition = new Vector3(Mathf.MoveTowards(Slider.transform.localPosition.x, open, 
			   10.0f * Time.deltaTime), Slider.transform.localPosition.y, Slider.transform.localPosition.z);
		}
		else
		{
			Slider.transform.localPosition = new Vector3(Mathf.MoveTowards(Slider.transform.localPosition.x, closed, 
			   10.0f * Time.deltaTime), Slider.transform.localPosition.y, Slider.transform.localPosition.z);
		}
	}
}

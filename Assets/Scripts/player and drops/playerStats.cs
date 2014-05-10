using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
	public static playerStats Instance;

	public int playerDamage;
	public bool bsmokeScreen;
	public ParticleSystem smokeScreen;
	public int playerHealth;
	public Transform spawn;
	// Use this for initialization
	void Awake () {
		bsmokeScreen = false;
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bsmokeScreen == true && Input.GetButtonDown ("Power"))
		{
				smokeScreen.Emit(2000);
				bsmokeScreen = false;
		}

		if (playerHealth <= 0) 
		{
			this.transform.position = spawn.position;
			playerHealth = 20;
		}
	}

}
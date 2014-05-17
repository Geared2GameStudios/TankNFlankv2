using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
	private int i;
	public static playerStats Instance;
	public GameObject player;
	public int playerDamage;
	public int playerHealth;
	public bool bsmokeScreen;
	public ParticleSystem[] smokeScreen;
	public Transform spawn;
	// Use this for initialization
	void Awake () {
		bsmokeScreen = false;
		i = 0;
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bsmokeScreen == true && Input.GetButtonDown ("Power"))
		{
			StartCoroutine(smokescreen());
			bsmokeScreen = false;
			i = 0;
		}

		if (playerHealth <= 0) 
		{
			this.transform.position = spawn.position;
			playerHealth = 20;
		}
	}

	IEnumerator  smokescreen()
	{
		for (i=0; i < 5; i++)
		{
	
			smokeScreen [i].transform.position = player.transform.position;
			smokeScreen [i].particleSystem.Play ();
			yield return new WaitForSeconds(0.5f);
	
		}


	}

}
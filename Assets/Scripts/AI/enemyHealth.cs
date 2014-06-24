using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	
	public static enemyHealth Instance;
	
	
	private TutorialScript tut;
	
	public GameObject smoke;
	public GameObject Xplode;
	public GameObject chckPoints;
	public int health;
	public int damage;
	public bool isDead;

	//Sound Variables
	public AudioClip enemyHit;
	public bool playOuch = false;
	public bool soundPlaying = false;
	
	
	// Use this for initialization
	void Awake () {
		isDead = false;
		Instance = this;
		tut = chckPoints.GetComponent<TutorialScript>();
	}

	void PlaySound()
	{
		this.gameObject.audio.volume = PlayerSettingsScript.Instance.effectsVolume;

		if (!soundPlaying && !playOuch) 
		{
			this.gameObject.audio.PlayOneShot (enemyHit);
			playOuch = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health == 1)
		{
			PlaySound ();
			StartCoroutine(turnOffAI ());
			smoke.SetActive(true);
		}
		else if (health <= 0)
		{
			PlaySound ();

			if(isDead == false)
			{
				isDead = true;
				this.gameObject.GetComponent<AI_Navigation>().enabled = false;
				Xplode.SetActive(true);
				//tut.index = 7;
			}	
			else 
			{
				this.gameObject.GetComponent<AI_Navigation>().enabled = false;
			}
		}

		if (!audio.clip == null) 
		{
			
			soundPlaying = false;
			
		}
	}
	
	IEnumerator turnOffAI()
	{
		this.gameObject.GetComponent<NavMeshAgent> ().Stop ();
		this.gameObject.GetComponent<AI_Navigation>().enabled = false;
		yield return new WaitForSeconds(12F);
		this.gameObject.GetComponent<AI_Navigation>().enabled = true;
	}
	
}

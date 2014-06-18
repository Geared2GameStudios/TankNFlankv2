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
	
	
	// Use this for initialization
	void Awake () {
		isDead = false;
		Instance = this;
		tut = chckPoints.GetComponent<TutorialScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health == 1)
		{
			StartCoroutine(turnOffAI ());
			smoke.SetActive(true);
		}
		else if (health <= 0)
		{

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
	}
	
	IEnumerator turnOffAI()
	{
		this.gameObject.GetComponent<NavMeshAgent> ().Stop ();
		this.gameObject.GetComponent<AI_Navigation>().enabled = false;
		yield return new WaitForSeconds(12F);
		this.gameObject.GetComponent<AI_Navigation>().enabled = true;
	}
	
}

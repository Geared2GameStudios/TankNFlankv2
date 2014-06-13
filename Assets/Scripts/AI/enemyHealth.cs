using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	
	public static enemyHealth Instance;
	
	
	private TutorialScript tut;
	private AI_Navigation AI;
	
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
		AI = GameObject.FindGameObjectWithTag ("enemy").gameObject.GetComponent<AI_Navigation> ();
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
				AI.enabled = false;
				Xplode.SetActive(true);
				tut.index = 7;
			}	
			else 
			{
				AI.enabled = false;
			}
		}
	}
	
	IEnumerator turnOffAI()
	{
		AI.GetComponent<NavMeshAgent> ().Stop ();
		AI.enabled = false;
		yield return new WaitForSeconds(12F);
		AI.enabled = true;
	}
	
}

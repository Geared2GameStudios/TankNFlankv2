using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	
	public static enemyHealth Instance;
	public GameObject chckPoints;
	private TutorialScript tut;
	private AI_Navigation AI;
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
			turnOffAI ();
		else if (health <= 0)
		{
			if(!isDead)
			{
				isDead = true;
				tut.index = 7;
			}	
		}
	}
	
	IEnumerator turnOffAI()
	{
		AI.enabled = false;
		yield return new WaitForSeconds(12F);
		AI.enabled = true;
	}
	
}

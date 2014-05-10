using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	public static enemyHealth Instance;
	public GameObject chckPoints;
	private TutorialScript tut;
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
		if (health <= 0)
		{
		 if(!isDead)
		 {
			isDead = true;
			tut.index = 7;
		  }	
		}
	}
}

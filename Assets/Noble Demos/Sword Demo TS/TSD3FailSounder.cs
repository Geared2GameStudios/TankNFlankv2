using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TSD3FailSounder : MonoBehaviour
{
	private int lastObservedMissCount = 0;
	
	void Update ()
	{		
		int observedMissCount = TSD3ScoreModel.instance.missed;
		
		if(observedMissCount > lastObservedMissCount)
		{
			audio.Play();
		}
		
		lastObservedMissCount = observedMissCount;
	}
}

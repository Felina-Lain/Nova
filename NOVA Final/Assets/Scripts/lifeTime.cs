using UnityEngine;
using System.Collections;

public class lifeTime : MonoBehaviour {


	private float currentTimer = 0.0f;
	public float timerMax = 3.0f;

	void Update () {
	
		if(currentTimer > timerMax){
			Destroy(gameObject);
		}else{
			currentTimer += Time.deltaTime;
		}

	}
}

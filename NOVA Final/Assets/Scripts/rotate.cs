using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	
	public float speed = 90.0f;
	
	void Update () {
		
		transform.Rotate(transform.up, speed * Time.deltaTime);
		
	}
}
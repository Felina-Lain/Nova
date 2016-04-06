using UnityEngine;
using System.Collections;

public class rotateAroundTransform : MonoBehaviour {
	
	public Transform target;
	public float speed = 180.0f;
	
	void Update () {
		
		transform.RotateAround(target.position, target.up, speed * Time.deltaTime);
		
	}
}
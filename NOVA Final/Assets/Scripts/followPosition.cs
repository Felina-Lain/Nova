using UnityEngine;
using System.Collections;

public class followPosition : MonoBehaviour {

	public Transform target;
	public bool useSmooth = false;
	public float smoothPosTime = 1.0f;
	public float smoothRotTime = 1.0f;


	void Update () {
		if(Time.timeScale > 0f){
			if(!useSmooth){
			transform.position = target.position;
			transform.rotation = target.rotation;
		}else{

			transform.position = Vector3.Lerp(transform.position, target.position, smoothPosTime * 1/Time.timeScale * Time.deltaTime);//	target.position;
			transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothRotTime * 1/Time.timeScale * Time.deltaTime);//	target.rotation;

			}
		}
	}
}

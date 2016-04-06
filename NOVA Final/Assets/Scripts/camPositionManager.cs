using UnityEngine;
using System.Collections;

public class camPositionManager : MonoBehaviour {
	
	public attractionFeature attractionScript;
	public moveCharaV3 moveScript;

	public Transform cameraPivot;
	public Transform defaultPos;
	public Transform middlePos;
	public Transform farPos;
	public Transform nearPos;

	public float lerpSpeed = 5.0f;
	public float rotAroundSpeed = 50.0f;

	void Awake () {

		cameraPivot = GameObject.Find("Pivot").transform;

		if(attractionScript == null)
			print ("il manque reference ici");
		if(moveScript == null)
			print ("il manque reference ici");

	}

	void LateUpdate () {
	
		if(attractionScript.curState == attractionFeature.attractionState.Placement){

			transform.position = Vector3.Lerp(transform.position, farPos.position, lerpSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, farPos.rotation, lerpSpeed * Time.deltaTime);
//			float rotSpeedBySecond = rotAroundSpeed * moveScript.reverseByTime * Time.deltaTime;
//			cameraPivot.Rotate(transform.InverseTransformDirection(0.0f, Input.GetAxis("Horizontal"), 0.0f) * rotSpeedBySecond);

		}else if(attractionScript.curState == attractionFeature.attractionState.Permanent){

			transform.position = Vector3.Lerp(transform.position, middlePos.position, lerpSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, middlePos.rotation, lerpSpeed * Time.deltaTime);
			
		}else if(moveScript.destructionMode){

			transform.position = Vector3.Lerp(transform.position, nearPos.position, lerpSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, nearPos.rotation, lerpSpeed * Time.deltaTime);

		}else if(!moveScript.destructionMode){
			transform.position = Vector3.Lerp(transform.position, middlePos.position, lerpSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, defaultPos.rotation, lerpSpeed * Time.deltaTime);
		}else{
			transform.position = Vector3.Lerp(transform.position, middlePos.position, lerpSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, defaultPos.rotation, lerpSpeed * Time.deltaTime);
		}

	}
}

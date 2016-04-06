using UnityEngine;
using System.Collections;

public class moveCharaV3 : MonoBehaviour {
	
	
	//Depl
	//
	// Stick gauche et droit comme version actuelle ...
	//
	// void Walk(){
	//  
	//  Vector3 _DirectionR;
	//  
	//  _DirectionR = (transform.position - Camera.main.transform.position) * Input.GetAxisRaw("Vertical");
	//  transform.position += _DirectionR  walkSpeed  Time.deltaTime;
	//  transform.position += Input.GetAxis("Horizontal") * transform.right;
	//  
	//  //print (Vector3.Distance(Vector3.zero, GetComponent<Rigidbody>().velocity));
	// }
	//
	//... Dont le multiplicateur de vitesse est inversement proportionnel au Time.timeScale
	//
	//L2 et R2 = rotation ace combat (si dans attractionFeature.cs le mode attraction est inactif)
	
	public float speed = 20.0f;
	public float boostMultiplier = 2.0f;
	public float rotSpeed = 50.0f;
	public bool REVERT_Y_ROTAXIS = false;
	public float bounceMultiplier = 5.0f;
	public float bounceMax = 25.0f;
	public float bounceReverseSpeed = 1.0f;
	public float bounceScaleDivision = 4.0f; //la force de bounce est egale a la taille de la planete divisee par x
	public attractionFeature attractionScript;
	
	float bounceDefaultForce = 70.0f;
//	Camera cam;
	float currentSpeed = 0.0f;
	bool _CanSplit = true;
	[HideInInspector]
	public bool destructionMode = false;
	Vector3 bounceDir = Vector3.zero;
	[HideInInspector]
	public float reverseByTime;
	LineRenderer lineComp;
	bool _bouncing = false;
	Vector3 lastKnownDirection = Vector3.zero;
	public float curRotYSpeed = 0.0f;
	public float curRotXSpeed = 0.0f;
	float axisValue;

	void Start(){
//		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		attractionScript = GetComponent<attractionFeature>();
		lineComp = GetComponent<LineRenderer>();
	}
	
	void Update () {
		
		//maj multiplicateur de temps
		REVERT_Y_ROTAXIS = optionsParameters.revertYAxis;
		
		if(Time.timeScale > 0f){
			reverseByTime = 1/Time.timeScale;
		
		
		//PRESSION STICK
		
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis("Vertical");
		float zAxis = 0.0f;
		if(Input.GetButton("StickG") || Input.GetButton("StickD"))
			zAxis = 1;
		
		//Si en placement de zone d'attraction
		if(attractionScript.curState == attractionFeature.attractionState.Placement){
			//VITESSE
			
			//vitesse = pression stick
			axisValue = Vector3.Distance(Vector3.zero, new Vector3(xAxis, yAxis, zAxis));

//			if(Input.GetAxis("LT-RT-Axis") < -0.5f){
//				//currentSpeed = speed * boostMultiplier;
//				currentSpeed = Mathf.Lerp(currentSpeed, (speed * boostMultiplier) * axisValue, reverseByTime * Time.deltaTime);
//			}else if(Input.GetAxis("LT-RT-Axis") > 0.5f){
//				//currentSpeed = speed / boostMultiplier;
//				currentSpeed = Mathf.Lerp(currentSpeed, (speed / boostMultiplier) * axisValue, reverseByTime * Time.deltaTime);
			//}else{
				currentSpeed = Mathf.Lerp(currentSpeed, speed * axisValue, reverseByTime * Time.deltaTime);
			//}
		}else{
			
			//VITESSE
			
			//vitesse = pression stick
			axisValue = Vector3.Distance(Vector3.zero, new Vector3(xAxis, yAxis, zAxis));
			//currentSpeed = Mathf.Lerp(currentSpeed, speed * axisValue, reverseByTime * Time.deltaTime);//		speed * axisValue;
			//if destructionMode
//			if(destructionMode)
//				currentSpeed *= boostMultiplier;
			if(Input.GetAxis("LT-RT-Axis") < -0.5f){
				//currentSpeed = speed * boostMultiplier;
				currentSpeed = Mathf.Lerp(currentSpeed, (speed * boostMultiplier) * axisValue, reverseByTime * Time.deltaTime);
			}else if(Input.GetAxis("LT-RT-Axis") > 0.5f){
				//currentSpeed = speed / boostMultiplier;
				currentSpeed = Mathf.Lerp(currentSpeed, (speed / boostMultiplier) * axisValue, reverseByTime * Time.deltaTime);
			}else{
				currentSpeed = Mathf.Lerp(currentSpeed, speed * axisValue, reverseByTime * Time.deltaTime);
			}
			//vitesse = inversement proportionnel au timescale
			//currentSpeed *= 1/Time.timeScale;
		} //else placement

//			print (currentSpeed);
			
			//DIRECTION
			
			Vector3 _DirectionR;
			//_DirectionR = (transform.position - cam.transform.position).normalized * Input.GetAxisRaw("Vertical");
			_DirectionR = transform.forward * Input.GetAxisRaw("Vertical");
			_DirectionR += (Input.GetAxis("Horizontal") * transform.right).normalized;
			if(Input.GetButton("StickG"))
				_DirectionR += transform.up;
			if(Input.GetButton("StickD"))
				_DirectionR -= transform.up;
			
			
			
			//REBOND
			
			if(attractionScript.curState != attractionFeature.attractionState.Placement){
				_DirectionR += bounceDir;
				bounceDir = Vector3.Lerp(bounceDir, Vector3.zero, bounceReverseSpeed * reverseByTime * Time.deltaTime);
			}
			
			//DEPLACEMENT

			lastKnownDirection = Vector3.Lerp(lastKnownDirection, _DirectionR, reverseByTime * Time.deltaTime);

			if(axisValue > 0.2){
				transform.position += lastKnownDirection * currentSpeed * reverseByTime * Time.deltaTime;
				//transform.position = Vector3.Lerp(transform.position, transform.position + (_DirectionR * currentSpeed), 0.5f * reverseByTime * Time.deltaTime);
			}else if (_bouncing){
				transform.position += _DirectionR * bounceDefaultForce * Time.deltaTime;
			}else if (axisValue < 0.2){
				transform.position += lastKnownDirection * currentSpeed * reverseByTime * Time.deltaTime;
				//transform.position = Vector3.Lerp(transform.position, transform.position + (_DirectionR * currentSpeed), 0.5f * reverseByTime * Time.deltaTime);
			}
			
			//Mode destruct/pas destruct
			Boost();
		//}		//else Placement
		
		//ROTATION

		curRotYSpeed = Mathf.Lerp (curRotYSpeed, rotSpeed * Input.GetAxis("StickD-Y-Axis"), reverseByTime * Time.deltaTime);
		curRotXSpeed = Mathf.Lerp (curRotXSpeed, rotSpeed * Input.GetAxis("StickD-X-Axis"), reverseByTime * Time.deltaTime);

		//Rotation Y
		if(REVERT_Y_ROTAXIS){
			transform.Rotate(transform.InverseTransformDirection(transform.right), -curRotYSpeed * reverseByTime * Time.deltaTime);
		}else{
			transform.Rotate(transform.InverseTransformDirection(transform.right), curRotYSpeed * reverseByTime * Time.deltaTime);
		}
		//RotationX
		transform.Rotate(transform.InverseTransformDirection(transform.up), curRotXSpeed * reverseByTime * Time.deltaTime);
		//rotation Z (Ace combat)
//		if(attractionScript.curState != attractionFeature.attractionState.Placement)
//			transform.Rotate(transform.InverseTransformDirection(transform.forward), (Input.GetAxis("LT-RT-Axis") * rotSpeed * reverseByTime * Time.deltaTime));
		
		}
	}
	
	void Boost (){
		
		destructionMode = Input.GetButton("Run");
		lineComp.enabled = destructionMode;
		
		if(destructionMode){

			lineComp.SetPosition(0, transform.forward * 83 + transform.position);
			lineComp.SetPosition(1, transform.forward * 4000 + transform.position);
		}
	}
	
	//Explode and Bounce
	void OnTriggerStay(Collider _Coll)
	{
		
		if (_Coll.transform.tag == "Sphere")
		{
			
			
			if(_CanSplit && destructionMode &&_Coll.transform.GetComponent<Agglomeration>().currentState != Agglomeration.PlanetoidState.BlackHole ){
				
				_Coll.transform.GetComponent<Agglomeration>().Explode(GetComponent<Collider>());
				_CanSplit = false;
				StartCoroutine(waitSplit());
				
			}else{

				_bouncing = true;
				StartCoroutine(haveBounce());

				bounceDir = transform.position - _Coll.transform.position;
				bounceDir *= bounceMultiplier;
				bounceDir = Vector3.ClampMagnitude(bounceDir, bounceMax);
				
				bounceDefaultForce = _Coll.transform.localScale.x / bounceScaleDivision; //force de bounce = taille planete divisé par...
				
			}
			
			
		}
		
		
	}
	IEnumerator waitSplit()
	{
		yield return new WaitForSeconds(0.25f);
		_CanSplit = true;
		
	}

	IEnumerator haveBounce(){
		yield return new WaitForSeconds(1.0f);
		_bouncing = false;
	}
	
	
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class attractionObjectBehavior : MonoBehaviour {

	public bool useRigidBody = true;

	public float baseScale = 60.0f;
	public bool isUsingDisableSpeed = true;
	public float disableSpeed = 3.0f;
	public float speedAttraction = 10.0f;
	public float ondulationEffect = 15.0f;

	List<Transform> planets = new List<Transform>();
	//List<Vector3> directions = new List<Vector3>();
//	Behaviour h;

	void OnTriggerEnter (Collider _coll) {
	
		if(_coll.name == "Sphere"){
	//		print ("collided");
			planets.Add(_coll.transform);
			//directions.Add(transform.position - _coll.transform.position);
			//_coll.GetComponent<Agglomeration>().enabled = false;
			//_coll.GetComponent<Rigidbody>().isKinematic = true;
			//_coll.GetComponent<Renderer>().material.color = Color.green;
			_coll.GetComponent<Agglomeration>().cangloup = true;

			_coll.GetComponentInChildren<renderMAJ>().EnableAttractionFeedback(true);

		}

	}

	void FixedUpdate(){

		//je me retrecis
		//si trop petit je meurs et je libère tous les planetoides que j'ai dans ma liste

		if(isUsingDisableSpeed){
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, disableSpeed * Time.fixedDeltaTime);
		}else{
			float randomScale = Random.Range(baseScale - ondulationEffect, baseScale + ondulationEffect);
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(randomScale, randomScale, randomScale), disableSpeed * Time.fixedDeltaTime);
		}
		if(transform.localScale.x < 0.01f){
			Destroy(gameObject);
			for (int i = 0; i < planets.Count; i++) {
				//planets[i].GetComponent<Agglomeration>().enabled = true;
				//planets[i].GetComponent<Rigidbody>().isKinematic = false;
				for (int j = 0; j < planets.Count; j++) {
					BackToNormal(planets[j].GetComponent<Collider>());
				}
				planets.Clear();
			}
		}

		//for loop, je déplace tous ceux dans ma liste vers la coordonnée que je leur ai assigné
		for (int i = 0; i < planets.Count; i++) {
			//planets[i].transform.position = Vector3.MoveTowards(planets[i].transform.position, transform.position, speedAttraction * Time.deltaTime);

			if(!useRigidBody){
				planets[i].transform.position = Vector3.Lerp(planets[i].transform.position, transform.position, speedAttraction * Time.deltaTime);
			}else{
				Vector3 _v = transform.position - planets[i].transform.position;
				float _T = transform.localScale.x * 100;
				planets[i].GetComponent<Rigidbody>().AddForce(_v.normalized * (1 / _v.magnitude) * _PullStrenght * _T * _T);
			}
		
//
//			if(planets[i].GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
//			{
//				planets[i].GetComponent<Rigidbody>().AddForce(-_v.normalized * (1 / _v.magnitude) * _PullStrenght * _T * _T);
//				//planets[i].GetComponent<Rigidbody>().velocity = -planets[i].GetComponent<Rigidbody>().velocity;
//			}
		}

	}
	public float _PullStrenght = 0.001f;
	public float maxSpeed = 50f;

//	void OnTriggerExit(Collider _coll)
//	{
//		if(!isUsingDisableSpeed){
//			if (_coll.tag == "Sphere")
//			{
//				BackToNormal(_coll);
//				planets.Remove(_coll);
//			}
//		}
//	}
	
	void OnDisable(){
//		print ("Disabled");
		for (int i = 0; i < planets.Count; i++) {
			BackToNormal(planets[i].GetComponent<Collider>());
		}
		planets.Clear();
	}

	void OnEnable(){
//		print ("enable attract");
		for (int i = 0; i < planets.Count; i++) {
			planets[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
			BackToNormal(planets[i].GetComponent<Collider>());
		}
		planets.Clear();
	}
	
	void BackToNormal(Collider _coll){
		
		//_coll.GetComponent<Renderer>().material.color = Color.red;
		//_coll.GetComponent<Agglomeration>().enabled = true;
		_coll.GetComponent<Rigidbody>().isKinematic = false;
		_coll.transform.Find("Render").GetComponentInChildren<renderMAJ>().EnableAttractionFeedback(false);
		planets.Remove(_coll.transform);
		//_coll.GetComponent<Renderer>().material.color = Color.red;
		
	}

}

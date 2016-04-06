using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colliderFeedback : MonoBehaviour {

	List<Collider> planets = new List<Collider>();

	void OnTriggerStay(Collider _coll)
	{
		if (_coll.tag == "Sphere")
		{
		
			_coll.GetComponent<Renderer>().material.color = Color.green;
			planets.Add(_coll);

		}

	}

	void OnTriggerExit(Collider _coll)
	{
		if (_coll.tag == "Sphere")
		{
			BackToNormal(_coll);
			planets.Remove(_coll);
		}
	}

	void OnDisable(){
		//print ("Disabled");
		for (int i = 0; i < planets.Count; i++) {
			BackToNormal(planets[i].GetComponent<Collider>());
		}

	}

	void BackToNormal(Collider _coll){

		_coll.GetComponent<Renderer>().material.color = Color.red;

	}

}

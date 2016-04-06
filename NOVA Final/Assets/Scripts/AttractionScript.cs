using UnityEngine;
using System.Collections;

public class AttractionScript : MonoBehaviour {

	public float _PullStrenght = 1;
	public float _PullRange = 100.0f;

	public float maxSpeed = 200f;

//	void OnDrawGizmos(){
//		Gizmos.DrawSphere(transform.position, _PullRange);
//	}

	void FixedUpdate()
	{

		//Attraction

		GameObject[] _AllSphere = GameObject.FindGameObjectsWithTag("Sphere");
		foreach (GameObject _g in _AllSphere)
		{

			if (_g.GetComponent<Rigidbody>() && Vector3.Distance(transform.position, _g.transform.position) < _PullRange && _g.GetComponent<Agglomeration>().cangloup)
			{
				Vector3 _v = transform.position - _g.transform.position;
				float _T = transform.localScale.x * 100;
				_g.GetComponent<Rigidbody>().AddForce(_v.normalized * (1 / _v.magnitude) * _PullStrenght * _T * _T);
			
				if(_g.GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
				{
					_g.GetComponent<Rigidbody>().velocity = _g.GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
				}
			


			}
		
//			ParticleSystem _part = transform.GetComponent<ParticleSystem>();
//
//			_part.startSize = 
		}
		
	}
}

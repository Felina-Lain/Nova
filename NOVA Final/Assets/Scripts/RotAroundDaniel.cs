using UnityEngine;
using System.Collections;

public class RotAroundDaniel : MonoBehaviour {

	public float speed = 10.0f;
	public Transform target;

	void FixedUpdate () {

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		horizontal = 1.0f;
		vertical = 1.0f;

		Vector3 direction = (target.position - transform.GetComponent<Rigidbody>().position).normalized;

		Vector3 vec = Vector3.up;
//		vec = target.position - Vector3.Project(target.position, transform.GetComponent<Rigidbody>().position);
//		vec = vec.normalized;

		Vector3 rotation = Quaternion.AngleAxis(horizontal * 60, vec) * direction * Mathf.Abs(horizontal);
		Vector3 desired = rotation + vertical * direction;
		Vector3 change = desired * speed - GetComponent<Rigidbody>().velocity;
		// Debug lines: Red - current heading
		//              Blue - applied heading
		Debug.DrawLine(transform.GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().position + GetComponent<Rigidbody>().velocity, Color.red);
		Debug.DrawLine(transform.GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().position + change, Color.blue);
		GetComponent<Rigidbody>().AddForce(change * Time.deltaTime, ForceMode.VelocityChange);
		
	}
}

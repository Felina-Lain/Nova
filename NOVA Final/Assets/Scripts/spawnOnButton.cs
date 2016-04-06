using UnityEngine;
using System.Collections;

public class spawnOnButton : MonoBehaviour {

	public KeyCode button;
	public GameObject prefab;

	void Update () {
	
		if(Input.GetKeyDown(button)){
			Instantiate(prefab, transform.position, transform.rotation);
		}

	}
}

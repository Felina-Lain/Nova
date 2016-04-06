using UnityEngine;
using System.Collections;

public class LookSomething : MonoBehaviour {
	
	//Ce script permet à l'objet auquel il est rattaché de regarder la position définie dans l'inspector
	//Il est aussi possible d'y accéder par un autre script via la variable enum thingToLook
	
	public ThingToLook thingToLook;
	
	private Transform player;
	
	public enum ThingToLook
	{
		MousePos,
		Player,
		PlayerCamera
	}
	
	
	void Awake() {
		
		if (thingToLook == ThingToLook.Player) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
			//player = GameObject.Find("PlayerBehavior").transform;
		}else if (thingToLook == ThingToLook.PlayerCamera){
			//player = Camera.main.transform;
			player = GameObject.Find("Main Camera").transform;
		}
		
	}
	
	void Update () {
		
		Vector3 positionToLook = Vector3.zero;
		
		switch (thingToLook)
		{
		case ThingToLook.MousePos:
			positionToLook = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			break;
		case ThingToLook.Player:
			positionToLook = player.position;
			break;
		case ThingToLook.PlayerCamera:
			positionToLook = player.position;
			break;
		}
		
		//a transformer en quaternion
		transform.LookAt(positionToLook);
		//Quaternion rot = Quaternion.LookRotation(positionToLook - transform.position, transform.TransformDirection(Vector3.forward));
		//transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
		
	}
}


using UnityEngine;
using System.Collections;

public class FlareByParent : MonoBehaviour {

	//Ce script convertit le scale et la disctance par rapport au joueur en taille de flare

	Transform mySolar;
	LensFlare myFlare;
	Transform player;

	public float brightnessMultiplier = 2000.0f; //Plus c'est haut, plus le flare va etre affecté par distance et scale
	public float brightSpeedChange = 1.0f;	//vitesse de changement brightness /seconde
	public float randomFlickeringRange = 5.0f;

	void Start () {
	
		//Application.targetFrameRate = 50;
		mySolar = transform.parent.parent;
//		print (mySolar);
		myFlare = GetComponent<LensFlare> ();
		player = GameObject.Find ("PlayerBehavior").transform;
	}

	void Update () {
	
		//B: bright = 1 / (milieu entre taille et distance) / 10
		float wishedBrightness = 1 / (((transform.localScale.x + Vector3.Distance (player.position, mySolar.position) / 2) / brightnessMultiplier));

		wishedBrightness += Random.Range (-randomFlickeringRange, randomFlickeringRange);

		myFlare.brightness = Mathf.Lerp (myFlare.brightness, wishedBrightness, brightSpeedChange * Time.deltaTime);
	}
}

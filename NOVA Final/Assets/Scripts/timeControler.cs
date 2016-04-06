using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class timeControler : MonoBehaviour {

	public float bulletTimeValue = 0.5f;	//la vitesse de l'écoulement du temps (1 = normalement)
	public float transitionIn = 1.0f;	//la vitesse de transition de la vitesse du temps à l'ACTIVATION
	public float transitionOut = 1.0f;	//la vitesse de transition de la vitesse du temps à DESACTIVATION

	private bool timeSlowed = false;
	private ColorCorrectionCurves colorCorrection;	//Reference au script de correction de couleur

	void Start(){
		colorCorrection = GameObject.Find("Main Camera").GetComponent<ColorCorrectionCurves>();
	}

	void Update () {
		//print(Time.realtimeSinceStartup);

		if(!timeSlowed){

//			Time.timeScale = Mathf.Lerp(bulletTimeValue, 1.0f, transitionOut * Time.deltaTime);
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1.0f, transitionOut * Time.deltaTime);

		}else{

//			Time.timeScale = Mathf.Lerp(0.0f, bulletTimeValue, transitionIn * Time.deltaTime);
			Time.timeScale = Mathf.Lerp(Time.timeScale, bulletTimeValue, transitionIn * Time.deltaTime);

		}

		if(Input.GetButtonDown("XBOX-X")){
			timeSlowed = !timeSlowed;
//			print ("arg");
		}

//		print (Time.timeScale);

		//Feedback ralentissement du temps
		colorCorrection.saturation = Time.timeScale;
	}

}

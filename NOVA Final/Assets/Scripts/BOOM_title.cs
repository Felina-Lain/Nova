using UnityEngine;
using System.Collections;

public class BOOM_title : MonoBehaviour {

	AudioSource source;
	Material myMaterial;
	bool levelLoaded = false;

	bool jauraiesessaye = false;

	Color curColor;

	void Start(){
		myMaterial = GetComponent<MeshRenderer>().material;
		source = GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);
	}

	public void TitleBoomAvecPanache(){
		source.Play();
		//StartCoroutine(VoileDePanache());
		jauraiesessaye = true;
		curColor = myMaterial.color;
	}

	void Update(){

		if(jauraiesessaye){

			if(levelLoaded){

				curColor.a = Mathf.Lerp(myMaterial.color.a, 0f, Time.deltaTime);
				myMaterial.color = curColor;
				//myMaterial.SetColor("_Color", curColor);

				//myMaterial.color.a = Mathf.Lerp(myMaterial.color.a, 0f, Time.deltaTime);
			}else{
				curColor.a = Mathf.Lerp(myMaterial.color.a, 255f, 0.01f * Time.deltaTime);
				myMaterial.color = curColor;
				//myMaterial.SetColor("_Color", curColor);

				//myMaterial.color.a = Mathf.Lerp(myMaterial.color.a, 128f, Time.deltaTime);
			}

			if(Application.loadedLevelName == "Scene 3 Main"){
				levelLoaded = true;
//				print ("loaded");
			}
		}
	}

//	IEnumerator VoileDePanache(){
//
//		Color curColor = myMaterial.color;
//
//		while(enabled){
//
//			if(levelLoaded){
//
//				curColor.a = Mathf.Lerp(myMaterial.color.a, 0f, Time.deltaTime);
//				myMaterial.color = curColor;
//				//myMaterial.SetColor("_Color", curColor);
//
//				//myMaterial.color.a = Mathf.Lerp(myMaterial.color.a, 0f, Time.deltaTime);
//			}else{
//				curColor.a = Mathf.Lerp(myMaterial.color.a, 255f, 0.1f * Time.deltaTime);
//				myMaterial.color = curColor;
//				//myMaterial.SetColor("_Color", curColor);
//
//				//myMaterial.color.a = Mathf.Lerp(myMaterial.color.a, 128f, Time.deltaTime);
//			}
//
//			if(Application.loadedLevelName == "Scene 3 Main"){
//				levelLoaded = true;
//				print ("loaded");
//			}
//			yield return new WaitForEndOfFrame();
//		}
//
//	}

}

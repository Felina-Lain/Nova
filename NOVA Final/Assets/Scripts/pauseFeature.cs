using UnityEngine;
using System.Collections;

public class pauseFeature : MonoBehaviour {
	
	public GameObject uicam;
	public GameObject pauseCanvas;
	public Behaviour mainCamBlur;
	
	float lastTimeScale;
	bool paused = false;
	
	void Start(){
		
		//uicam = GameObject.Find("UI Camera");
		//pauseCanvas = GameObject.Find("Canvas");
		StartCoroutine(PauseChecker());
		
	}
	
	IEnumerator PauseChecker(){
		
		while (enabled){
			
			if(!paused){
				
				if(Input.GetButtonUp("Back")){
					//Pause enabled
					
					PauseEnabler(true);
				}
			}else{
				if(Input.GetButtonUp("Back")){
					
					PauseEnabler(false);
				}
			}
			//yield return new WaitForEndOfFrame();
			yield return 0;
		}
	}
	
	public void PauseEnabler(bool value){
		
		if(value){
			lastTimeScale = Time.timeScale;
			Time.timeScale = 0f;
		}else{
			Time.timeScale = lastTimeScale;
		}
		
		mainCamBlur.enabled = value;
		uicam.SetActive(value);
		pauseCanvas.SetActive(value);
		paused = value;
		
	}
	
}

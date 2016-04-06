using UnityEngine;
using System.Collections;

public class animBool : MonoBehaviour {

	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.anyKey || Input.GetAxis("StickD-Y-Axis") !=0 || Input.GetAxis("StickD-X-Axis") !=0 || Input.GetAxis("LT-RT-Axis") !=0 || Input.GetAxis("Vertical") !=0 || Input.GetAxis("Horizontal") !=0 ){
			this.GetComponent<Animator>().SetBool("inflight", true);
		}else{
			this.GetComponent<Animator>().SetBool("inflight", false);
		}


	}

	public float pitchDistortion = 0.25f;
	public float volumeDistortion = 0.15f;

	public void PlayWingSound (){
		//print ("wing");

		playMysound.masterFxVolume = optionsParameters.fxVolume;

		source.clip = fxSoundManager.uniqueFXinstance.SetRandomSound(6, 6);
		source.pitch = Random.Range(1 - pitchDistortion, 1 + pitchDistortion);
		source.volume = Random.Range(1 - volumeDistortion, 1 + volumeDistortion);
		source.volume = Mathf.Clamp(source.volume, 0f, playMysound.masterFxVolume);
		source.Play();
	}
}

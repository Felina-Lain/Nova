using UnityEngine;
using System.Collections;

public class playMysound : MonoBehaviour {
	
	[Range(0f,1f)]
	public static float masterFxVolume = 1.0f;
	
	public int indexA = 0;
	public int indexB = 2;
	
	public float pitchDistortion = 0.25f;
	public float volumeDistortion = 0.15f;
	
	void OnEnable(){
		
		masterFxVolume = optionsParameters.fxVolume;
		
		AudioSource source = GetComponent<AudioSource>();
		source.clip = fxSoundManager.uniqueFXinstance.SetRandomSound(indexA, indexB);
		source.pitch = Random.Range(1 - pitchDistortion, 1 + pitchDistortion);
		source.volume = Random.Range(1 - volumeDistortion, 1 + volumeDistortion);
		source.volume = Mathf.Clamp(source.volume, 0f, masterFxVolume);
		source.Play();
	}
	
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class soundManager : MonoBehaviour {

	public static int singCount = 0;
	public static int flareCount = 0;

	[Header("Slider de l'état de la musique")]
	[Range(0f, 1f)]
	public float singparameter = 0.0f;
	[Range(0f, 1f)]
	public float flareparameter = 0.0f;
	[Range(0f,1f)]
	public float masterVolume = 1.0f;
	
	[System.Serializable]
	public class BGM_Layers
	{
		public string name;
		public AudioClip song;
		public AnimationCurve theCurve;
	};
	public BGM_Layers[] bgm;
	
	List<AudioSource> sources = new List<AudioSource>();
	
	void Awake(){
		
//		for (int i = 0; i < bgm.Length; i++) {
//			
//			//AudioSource newSource = gameObject.AddComponent("AudioSource") as AudioSource;
//			AudioSource newSource = gameObject.AddComponent<AudioSource>() as AudioSource;
//			newSource.clip = bgm[i].song;
//			newSource.loop = true;
//			newSource.Play();
//			sources.Add(newSource);
//		}
//		
//		StartCoroutine(MajMusic());
		
	}
	
	IEnumerator MajMusic(){
		
		while(enabled){
			
			masterVolume = optionsParameters.bgmVolume;

			singparameter = singCount;
			flareparameter = flareCount / 3f;

			//Musique ambiance
			sources[0].volume = bgm[0].theCurve.Evaluate(singparameter);
			sources[0].volume = Mathf.Clamp(sources[0].volume, 0.0f, masterVolume);
			//Musique Flare
			sources[1].volume = bgm[1].theCurve.Evaluate(flareparameter);
			sources[1].volume = Mathf.Clamp(sources[1].volume, 0.0f, masterVolume);
			//Musique Trou noir
			sources[2].volume = bgm[2].theCurve.Evaluate(singparameter);
			sources[2].volume = Mathf.Clamp(sources[2].volume, 0.0f, masterVolume);

//			for (int i = 0; i < sources.Count; i++) {
//				sources[i].volume = bgm[i].theCurve.Evaluate(parameter);
//				sources[i].volume = Mathf.Clamp(sources[i].volume, 0.0f, masterVolume);
//			}
			
			
			yield return new WaitForSeconds(0.5f);
		}
		
	}
	
}
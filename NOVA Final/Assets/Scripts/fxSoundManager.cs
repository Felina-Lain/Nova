using UnityEngine;
using System.Collections;

public class fxSoundManager : MonoBehaviour {
	
	public static fxSoundManager uniqueFXinstance;
	
	[Header("Garder la dernière value EMPTY s'il vous plait")]
	public AudioClip[] sounds;
	
	public AudioClip[] ambientPlanetSounds;
	
	void OnEnable(){
		uniqueFXinstance = this;
	}
	
	public AudioClip SetRandomSound(int indexA, int indexB){
		
		return sounds[Random.Range(indexA, indexB + 1)];
		
	}
	
}
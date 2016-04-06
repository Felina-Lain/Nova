using UnityEngine;
using System.Collections;

public class optionsParameters : MonoBehaviour {
	
	
	public static bool revertYAxis = false;
	
	[Range(0f, 1f)]
	public static float bgmVolume = 1.0f;
	[Range(0f, 1f)]
	public static float fxVolume = 1.0f;
	
	public void SetReverseAxis(bool value){
		revertYAxis = value;
		//print (revertYAxis);
	}
	
	public void SetBGMVolume(float value){
		bgmVolume = value;
		//print (bgmVolume);
	}
	
	public void SetFXVolume(float value){
		fxVolume = value;
		//print (fxVolume);
	}
}

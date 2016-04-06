using UnityEngine;
using System.Collections;

public class gravityFeedback : MonoBehaviour {
	
	public float scaleMultiplier = 2.0f;
	
	Agglomeration aggloscript;
	MeshRenderer myRenderer;
	
	AudioSource source;
	
	void OnEnable(){
		source = GetComponent<AudioSource>();
		myRenderer = this.GetComponent<MeshRenderer> ();
		aggloscript = transform.parent.gameObject.GetComponent<Agglomeration>();
		this.GetComponent<MeshRenderer> ().enabled = false;
		StartCoroutine(ScaleMaj());
	}
	
	void OnTriggerStay (Collider _col){
		
		//print ("feedback hit");
		
		if (_col.gameObject.tag == "Player") {
			
			//print ("abandon ship!");
			myRenderer.enabled = true;
			//this.GetComponent<MeshRenderer> ().enabled = true;
		}
	}
	
	void OnTriggerExit(){
		myRenderer.enabled = false;
		//this.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	IEnumerator ScaleMaj(){
		while(enabled){
			float range = aggloscript._PullRange * scaleMultiplier  / transform.parent.transform.localScale.x;
			
			transform.localScale = new Vector3(range, range, range);
			
			
			source.maxDistance = aggloscript._PullRange * scaleMultiplier;
			
			
			yield return new WaitForSeconds(0.5f);
		}
	}
	
	
}
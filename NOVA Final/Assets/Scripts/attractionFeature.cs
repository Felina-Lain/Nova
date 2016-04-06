using UnityEngine;
using System.Collections;

public class attractionFeature : MonoBehaviour {

	public GameObject previsualisator;	//Objet de pre-visualisation de la zone d'attraction
	public GameObject attractionPrefab;	//Objet d'attraction
	public GameObject permanentAttractionObject;	//l'objet d'attraction permanente
	public float speedSizeChange = 10.0f;
	public float baseAttractionSize = 60.0f;
	public float minAttractionSize = 20.0f;
	public float maxAttractionSize = 200.0f;
	public float pressionTimeMin = 0.5f;

	float pressionTime = 0.0f;
	float coolDown = 0.5f;
	float curCollDown = 0.0f;

	//[HideInInspector]
	public attractionState curState;

	public enum attractionState
	{
		Placement,
		Permanent,
		None
	}

	//L1 active/desactive mode placer attraction
	//Cercle attraction permanente

	void Start(){
		curState = attractionState.None;
	}

	void LateUpdate () {

		StateChecker();
		StateBehavior();
	}

	//Met a jour les state
	void StateChecker(){

		if(Input.GetButton("LB")){
			pressionTime += Time.deltaTime;
		}else{
			pressionTime = 0.0f;
		}

		curCollDown += Time.deltaTime;

		if(curState == attractionState.None){

			if(Input.GetButtonUp("LB") && pressionTime < pressionTimeMin && curCollDown > coolDown && curState == attractionState.None)
				curState = attractionState.Placement;
			if(Input.GetButton("LB") && pressionTime > pressionTimeMin && curState == attractionState.None)
				curState = attractionState.Permanent;
			
		}else if(curState == attractionState.Placement){
			
			//Annulation du state
			if(Input.GetButtonDown("XBOX-B") || Input.GetButtonDown("XBOX-Y") || Input.GetButtonDown("LB")){
				curState = attractionState.None;
				curCollDown = 0.0f;
			}
			
		}else if(curState == attractionState.Permanent){

			//Annulation du state
			if(!Input.GetButton("LB")){
				curState = attractionState.None;
				curCollDown = 0.0f;
			}
		}

	}
	
	//Agit en fonction du state
	void StateBehavior(){

		if(curState == attractionState.None){

			if(previsualisator.activeInHierarchy){
				previsualisator.transform.localScale = Vector3.zero;
				previsualisator.transform.localScale = new Vector3(baseAttractionSize, baseAttractionSize, baseAttractionSize);
				previsualisator.SetActive(false);
			}

			if(permanentAttractionObject.activeInHierarchy){
				permanentAttractionObject.SetActive(false);
			}

		}else if(curState == attractionState.Placement){
			
			previsualisator.SetActive(true);
			Vector3 newSize = new Vector3(-Input.GetAxis("LT-RT-Axis"), -Input.GetAxis("LT-RT-Axis"), -Input.GetAxis("LT-RT-Axis")) * speedSizeChange;
			//if(previsualisator.transform.localScale.magnitude > minAttractionSize)
				previsualisator.transform.localScale += newSize * (1/Time.timeScale) * Time.deltaTime;
			previsualisator.transform.localScale = Vector3.ClampMagnitude(previsualisator.transform.localScale, maxAttractionSize);

			if(Input.GetButtonDown("XBOX-A") || Input.GetButtonDown("RB")){
				curState = attractionState.None;
				GameObject lastInstance = Instantiate(attractionPrefab, previsualisator.transform.position, Quaternion.identity) as GameObject;
				lastInstance.transform.localScale = previsualisator.transform.localScale;
//				print ("SPAWN !!");
			}
			
		}else if(curState == attractionState.Permanent){

			permanentAttractionObject.SetActive(true);

		}

	}

	//!Placer attraction:
	//Cercle = attraction permanente vers joueur

	//Placer attraction :
	//L2 et R2 regle taille de la zone
	//N'importe quel autre bouton = placer zone
	//Cercle = annuler
	//
	//Planetes dans la zone = feedback "je serais affecté !"

	//Attraction permanente
	//Camera.position = lerp vers l'arrière (une position définie, pas évolutive en fonction de la taille de la zone d'attraction)

	//Placer attraction && Attraction permanente
	//les deux = false ET reinitialiser

}


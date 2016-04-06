using UnityEngine;
using System.Collections;

public class PlanetRenderSettup : MonoBehaviour {

	public static PlanetRenderSettup uniqueInstance;

//	public MeshFilter[] filters;
//	public MeshRenderer[] renderers;

	[Header("Ensuite viennent leurs aggrandissements 3 4 5 puis 6 7 8")]
	[Header("Les elements 0 1 2 sont les planetes de plus petite taille.")]
	public GameObject[] rendersObjects;
	public GameObject[] renderPlanets;

	[Header("Objet graphique Trou Noir")]
	public GameObject singularity;
	[Header("Objet graphique Soleil")]
	public GameObject solarFlare;

	float intervalePlanet;
	float intervaleSolar;
	float multiSolar;
	float intervaleHole;
	float multiHole;

	void OnEnable(){
		uniqueInstance = this;	//Rend le script tout entier static (accessible via PlanetRenderSettup.uniqueInstance)

//		filters = new MeshFilter[rendersObjects.Length];
//		renderers = new MeshRenderer[rendersObjects.Length];
//
//		for (int i = 0; i < rendersObjects.Length; i++) {
//			filters[i] = rendersObjects[i].GetComponent<MeshFilter>();
//			renderers[i] = rendersObjects[i].GetComponent<MeshRenderer>();
//		}

		intervalePlanet = CommonSettupv2.planetoidTriggerValuesS[1].triggerValue / 3;

		//intervaleSolar = CommonSettupv2.planetoidTriggerValuesS[1].triggerValue + ((CommonSettupv2.planetoidTriggerValuesS[2].triggerValue - CommonSettupv2.planetoidTriggerValuesS[1].triggerValue)) / 3;
		intervaleSolar = CommonSettupv2.planetoidTriggerValuesS[1].triggerValue;
		multiSolar = (CommonSettupv2.planetoidTriggerValuesS[2].triggerValue - CommonSettupv2.planetoidTriggerValuesS[1].triggerValue) / 3;
		
		//intervaleHole = CommonSettupv2.planetoidTriggerValuesS[2].triggerValue + ((CommonSettupv2.planetoidTriggerValuesS[3].triggerValue - CommonSettupv2.planetoidTriggerValuesS[2].triggerValue)) / 3;
		intervaleHole = CommonSettupv2.planetoidTriggerValuesS[2].triggerValue;
		multiHole = (CommonSettupv2.planetoidTriggerValuesS[3].triggerValue - CommonSettupv2.planetoidTriggerValuesS[2].triggerValue) / 3;

		//print ("Intervales : " + intervalePlanet + " / " + multiSolar + " / " + multiHole);
	}

	//Verifie quel genre de planete ou de soleil c'est, en fonction de la taille
	public void PlanetSubSizeCheck (Agglomeration targetAgglo, float curSize){

//		print (curSize);

		//Planete
		if(curSize < intervalePlanet){
			//SwapRenderObject(target);
			//print ("Petite planete");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.littlePlanet);

		}else if(curSize < intervalePlanet * 2){

			//print ("moyenne planete");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.middlePlanet);

		}else if(curSize < intervalePlanet * 3){

			//print ("Grande planete");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.bigPlanet);

		}else

		//Soleil
		if(curSize < intervaleSolar + multiSolar){
			
			//print ("Petit soleil");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.littleSun);
			
		}else if(curSize < intervaleSolar + multiSolar * 2){
			
			//print ("Moyen soleil");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.middleSun);
			
		}else if(curSize < intervaleSolar + multiSolar * 3){
			
//			print ("A Grand soleil");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.bigSun);
			
		}else
			
			//Hole
		if(curSize < intervaleHole + multiHole){
			
			//print ("Petit trou noir");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.littleHole);
			
		}else if(curSize < intervaleHole + multiHole * 2){
			
			//print ("Moyen trou noir");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.middleHole);
			
		}else if(curSize < intervaleHole + multiHole * 3){
			
			//print ("Grand trou noir");
			targetAgglo.myRenderManager.ChangeRenderStatus(renderMAJ.RenderStatus.bigHole);
			
		}




	}

//	GameObject GetCurrentRenderObject (Transform planet){
//		//cherche l'objet de rendu
//		return null;
//	}
//
//	void SwapRenderObject(Transform target, string swapIn){
//
//		GameObject swapOut = GetCurrentRenderObject(target);	//recupère le render si render il y a
//
//		ObjectPool.instance.PoolObject(swapOut);										//out
//		GameObject _g = ObjectPool.instance.GetObjectForType (swapIn, false);	//in
//		_g.transform.position = transform.position;
//		_g.transform.parent = transform;
//		_g.transform.rotation = Quaternion.identity;
//
//	}


}

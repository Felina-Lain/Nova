using UnityEngine;
using System.Collections;

public class CommonSettupv2 : MonoBehaviour {

	//Dans l'inspector il y a deux tableaux
	/*scales intervale:
	 * l'INDEX les intervalles entre chaque elements est définit par l'INDEX le plus bas des deux intervalles
	 * 
	 * Cet INDEX est recupere pour definir quel element dans le deuxieme tableau est recupere
	 * 
	 * Exemple:
	 * le scale de l'entitee qui explose est de 3.0.
	 * ce chiffre se trouvant entre Element 0 (0) et Element 1 (5)		Ces valeurs sont indicatives
	 * 			l'index recupere est egal a 0
	 * On cherche dans l'autre tableau l'index 0
	 * ce dernier comprend A (1) et B (3)
	 * Nous cherchons donc une valeur aleatoire entre 1 et 3
	 * 
	 * */

	public static float[] scalesIntervaleS = new float[4];
	public static Row[] entityNumberRandomIntervaleS;
	public static PlanetoidsIntervales[] planetoidTriggerValuesS;
	public float yieldvlue;
	public static float yieldvlueStatic;

//	public GameObject[] planetsRenders;
//	public static GameObject[] planetsRendersStratic;
//
//	public static float planetRenderTypes;

	public float[] scalesIntervale = new float[4];
	//public int[][][] entityRandomIntervale = new int[4][][];

	[System.Serializable]
	public class Row
	{
		public int A;
		public int B;
	};
	public Row[] entityNumberRandomIntervale = new Row[3];

	[System.Serializable]
	public class PlanetoidsIntervales
	{
		public string name;	//nom descriptif (c'est plus pratique que "Element0, Element1, etc.") => http://shattereddeveloper.blogspot.fr/2012/10/trick-for-visualizing-arrays-of.html
		public float triggerValue;
		public Material planetMaterial;
	}
	public PlanetoidsIntervales[] planetoidTriggerValues = new PlanetoidsIntervales[3];

	void OnEnable(){
		CommonSettupv2.scalesIntervaleS = scalesIntervale;
		CommonSettupv2.entityNumberRandomIntervaleS = entityNumberRandomIntervale;
		//print (CommonSettupv2.entityNumberRandomIntervaleS[2].A);
		CommonSettupv2.planetoidTriggerValuesS = planetoidTriggerValues;
//		print(CommonSettupv2.planetoidTriggerValuesS[1].triggerValue);
		CommonSettupv2.yieldvlueStatic = yieldvlue;
//		CommonSettupv2.planetsRendersStratic = planetsRenders;
//		planetRenderTypes = CommonSettupv2.planetoidTriggerValuesS[1].triggerValue / 3;
//		print (planetRenderTypes);
	}

	public static int SubdivisionByRange(float currentScale){

		//Recherche dans quel intervale se trouve CURSCALE
		for (int i = 0; i < CommonSettupv2.scalesIntervaleS.Length - 1; i++) {

			//Si compris dans l'intervale
			if(currentScale >= CommonSettupv2.scalesIntervaleS[i] && currentScale <= CommonSettupv2.scalesIntervaleS[i + 1]){

				//print(CommonSettupv2.entityNumberRandomIntervaleS[i].A + " " + CommonSettupv2.entityNumberRandomIntervaleS[i].B);

				//	random entre A et B
				return Random.Range(CommonSettupv2.entityNumberRandomIntervaleS[i].A, CommonSettupv2.entityNumberRandomIntervaleS[i].B);

			}

		}

		//Si on ne trouve rien, on renvoi un (on dit a l'explosion de recrer un element)
		return 1;
	}


	public static Agglomeration.PlanetoidState TweakState (float curSize){

		if(CommonSettupv2.planetoidTriggerValuesS != null){
			//On check dans quelle intervalle se situe notre planette. On renvoie son state en fonction de sa taille
			if(curSize > CommonSettupv2.planetoidTriggerValuesS[0].triggerValue && curSize < CommonSettupv2.planetoidTriggerValuesS[1].triggerValue){
	//			print ("Planet");
				return Agglomeration.PlanetoidState.Planet;
			}else if(curSize > CommonSettupv2.planetoidTriggerValuesS[1].triggerValue && curSize < CommonSettupv2.planetoidTriggerValuesS[2].triggerValue){
	//			print ("Solar");
				return Agglomeration.PlanetoidState.Solar;
			}else if(curSize > CommonSettupv2.planetoidTriggerValuesS[2].triggerValue && curSize < CommonSettupv2.planetoidTriggerValuesS[3].triggerValue){
	//			print ("Black hole");
				return Agglomeration.PlanetoidState.BlackHole;
			}else if(curSize > CommonSettupv2.planetoidTriggerValuesS[3].triggerValue){
				//			print ("Black hole");
				return Agglomeration.PlanetoidState.BlackHoleBoom;
			}

			print ("nope, il y a un probleme dans l'assignation de state");
		}else{
			print ("curSize = " + curSize + " / Commontralala = " + CommonSettupv2.planetoidTriggerValuesS[0]);
		}
		return Agglomeration.PlanetoidState.Planet;
	}

//	public static GameObject CheckRenderIntervale(float curSize){
//
//		if(curSize < CommonSettupv2.planetRenderTypes){
//			return planetsRendersStratic[0];
//		}else if(curSize < CommonSettupv2.planetRenderTypes * 2){
//			return planetsRendersStratic[1];
//		}else if(curSize < CommonSettupv2.planetRenderTypes * 3){
//			return planetsRendersStratic[2];
//		}else if(curSize > CommonSettupv2.planetRenderTypes * 3){
//			return planetsRendersStratic[3];
//		}
//
//		return planetsRendersStratic[0];
//	}


}

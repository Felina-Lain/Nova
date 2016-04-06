using UnityEngine;
using System.Collections;

public class spawnForYou : MonoBehaviour {

	//I will spawn the staaaaaaaaars for youuuuu
	//public GameObject aLotOfLove;
	public GameObject flareObject;
	public GameObject holeObject;

	//public static GameObject aLotOfLoveStatic;
	public static GameObject flareObjectStatic;
	public static GameObject holeObjectStatic;

	void OnEnable(){
	
		//spawnForYou.aLotOfLoveStatic = aLotOfLove;
		spawnForYou.flareObjectStatic = flareObject;
		spawnForYou.holeObjectStatic = holeObject;

	}

	/*//spawn planet
	public static GameObject SpawnForYou(Vector3 pos, Quaternion rot){

		GameObject theObject = ObjectPool.instance.GetObjectForType ("Sphere", true);
		//GameObject theObject = Instantiate (spawnForYou.aLotOfLoveStatic, pos, rot) as GameObject;

		return theObject;
	}*/

	//spawn l'objet renseigné
	public static GameObject Spawn(GameObject obj, Vector3 pos, Quaternion rot){

		GameObject theObject = Instantiate (obj, pos, rot) as GameObject;
		
		return theObject;
	}

}

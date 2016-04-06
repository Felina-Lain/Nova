using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	
	public static ObjectPool instance;
	
	//prefab du pool
	public GameObject[] objectPrefabs;
	//liste des truc poolé
	public List<GameObject>[] pooledObjects;
	//nb a poolé
	public int[] amountToBuffer;
	
	public int defaultBufferAmount = 3;
	//parent pool
	protected GameObject containerObject;
	
	void OnEnable ()
	{
		instance = this;
	}
	
	// Use this for initialization
	void Start ()
	{
		containerObject = new GameObject("ObjectPool");
		
		pooledObjects = new List<GameObject>[objectPrefabs.Length];
		
		int i = 0;
		foreach ( GameObject objectPrefab in objectPrefabs )
		{
			pooledObjects[i] = new List<GameObject>(); 
			
			int bufferAmount;
			
			if(i < amountToBuffer.Length) 
				bufferAmount = amountToBuffer[i];
			else
				bufferAmount = defaultBufferAmount;
			
			for ( int n=0; n<bufferAmount; n++)
			{
				GameObject newObj = Instantiate(objectPrefab) as GameObject;
				newObj.name = objectPrefab.name;
				PoolObject(newObj);
			}
			
			i++;
		}
	}
	
	
	//cherche si le pool est vide, ou si on a le droit de spawner des nouveau trucs dans le pool quand on l'utilise
	public GameObject GetObjectForType ( string objectType , bool onlyPooled )
	{
		for(int i=0; i<objectPrefabs.Length; i++)
		{
			GameObject prefab = objectPrefabs[i];
			if(prefab.name == objectType)
			{
				
				if(pooledObjects[i].Count > 0)
				{
					GameObject pooledObject = pooledObjects[i][0];
					pooledObjects[i].RemoveAt(0);
					//pooledObject.transform.parent = transform;
					pooledObject.SetActive(true);
					if(pooledObject.name == "Sphere"){
						pooledObject.GetComponent<Agglomeration>().enabled = true;
						pooledObject.GetComponent<Agglomeration>().cangloup = false;
						//pooledObject.GetComponent<Agglomeration>().StartCoroutine("fixerroutine");
					}
					//Debug.Log("swiggly");
					return pooledObject;
					
				} else if(!onlyPooled) {
					return Instantiate(objectPrefabs[i]) as GameObject;
				}
				
				break;
				
			}
		}
		
		return null;
	}
	
	//pool le bordel
	public void PoolObject ( GameObject obj )
	{
		for ( int i=0; i<objectPrefabs.Length; i++)
		{
			if(objectPrefabs[i].name == obj.name)
			{
				if(obj.name == "Sphere"){
					obj.GetComponent<Agglomeration>().enabled = false;
				}
				obj.transform.localScale = new Vector3(1f,1f,1f);
				obj.SetActive(false);
				obj.transform.parent = containerObject.transform;
				pooledObjects[i].Add(obj);
				return;
			}
		}
	}
	
}


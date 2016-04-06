using UnityEngine;
using System.Collections;

public class renderMAJ : MonoBehaviour {
	
	public RenderStatus currentState;
	
	MeshFilter myFilter;
	MeshRenderer myRenderer;
	PlanetRenderSettup planetCommonScript;
	
	ParticleRenderer _particleRender;
	MeshParticleEmitter _meshParticleEmitter;
	//ParticleAnimator _particleAnimator;
	
	AudioSource mySource;
	
	public enum RenderStatus
	{
		middlePlanet,
		bigPlanet,
		littleSun,
		middleSun,
		bigSun,
		littleHole,
		middleHole,
		bigHole,
		littlePlanet //Le dernier est le state par defaut
	}
	
	void OnEnable(){
		mySource = transform.parent.transform.Find("AttractionFeedback").GetComponent<AudioSource>();
		
		myFilter = GetComponent<MeshFilter>();
		myRenderer = GetComponent<MeshRenderer>();
		planetCommonScript = PlanetRenderSettup.uniqueInstance;
		
		_particleRender = GetComponent<ParticleRenderer>();
		_meshParticleEmitter = GetComponent<MeshParticleEmitter>();
		//_particleAnimator = GetComponent<ParticleAnimator>();
	}
	
	public void EnableAttractionFeedback(bool enableFeedback){
		
		if(enableFeedback){
			_particleRender.enabled = true;
			_meshParticleEmitter.enabled = true;
			//_particleAnimator.enabled = true;
		}else{
			_particleRender.enabled = false;
			_meshParticleEmitter.enabled = false;
			//_particleAnimator.enabled = false;
		}
		
	}
	
	public void ChangeRenderStatus(RenderStatus newStatus){
		
		if(newStatus != currentState){
			//J'ai changé de state de rendu !!
			//   print (newStatus);
			ChangeMeshAndMaterialByStatus(newStatus);
		}

		currentState = newStatus;
	}
	
	void ChangeMeshAndMaterialByStatus (RenderStatus newStatus){
		
		GameObject thePrefab = null;
		
		switch(newStatus)
		{
		case RenderStatus.littlePlanet:
			//thePrefab = planetCommonScript.rendersObjects[0];
			thePrefab = RandomPlanet();
			break;
		case RenderStatus.middlePlanet:
			//thePrefab = planetCommonScript.rendersObjects[1];
			thePrefab = RandomPlanetBis(newStatus);
			break;
		case RenderStatus.bigPlanet:
			//thePrefab = planetCommonScript.rendersObjects[2];
			thePrefab = RandomPlanetBis(newStatus);
			break;
			
		case RenderStatus.littleSun:
			thePrefab = planetCommonScript.rendersObjects[3];
			break;
		case RenderStatus.middleSun:
			thePrefab = planetCommonScript.rendersObjects[4];
			break;
		case RenderStatus.bigSun:
			thePrefab = planetCommonScript.rendersObjects[5];
			break;
		case RenderStatus.littleHole:
			thePrefab = planetCommonScript.rendersObjects[6];
			break;
		case RenderStatus.middleHole:
			thePrefab = planetCommonScript.rendersObjects[7];
			break;
		case RenderStatus.bigHole:
			thePrefab = planetCommonScript.rendersObjects[8];
			break;
		default:
			print ("error");
			break;
		}

		if(newStatus == RenderStatus.littleSun || newStatus == RenderStatus.middleSun || newStatus == RenderStatus.bigSun ||
		   newStatus == RenderStatus.littleHole || newStatus == RenderStatus.middleHole || newStatus == RenderStatus.bigHole){
			CreateFX(newStatus);

			mySource.clip = fxSoundManager.uniqueFXinstance.ambientPlanetSounds[9];
			mySource.Play();
		}

		myFilter.sharedMesh = thePrefab.GetComponent<MeshFilter>().sharedMesh;
		myRenderer.sharedMaterial = thePrefab.GetComponent<MeshRenderer>().sharedMaterial;
		
	}

	public GameObject myFx;

	void CreateFX(RenderStatus newStatus){
		if(myFx != null){
//			print ("j'ai un fx");
			if(myFx.name == "Singularity"){
				//retirer 1 sigularity du compte
				soundManager.singCount = 0;
			}else if(myFx.name == "Flare"){
				//retirer 1 flare du compte
				soundManager.flareCount --;
			}
			Destroy(myFx);
			if(newStatus == RenderStatus.littleHole || newStatus == RenderStatus.middleHole || newStatus == RenderStatus.bigHole){
				myFx = Instantiate(spawnForYou.holeObjectStatic, transform.position, transform.rotation) as GameObject;
				myFx.transform.parent = transform.parent;
				myFx.transform.localScale = new Vector3(1,1,1);
				//ajouter 1 singularity au compte
				soundManager.singCount ++;
			}else if(newStatus == RenderStatus.littleSun || newStatus == RenderStatus.middleSun || newStatus == RenderStatus.bigSun){
				myFx = Instantiate(spawnForYou.flareObjectStatic, transform.position, transform.rotation) as GameObject;
				myFx.transform.parent = transform.parent;
				myFx.transform.localScale = new Vector3(1,1,1);
				//ajouter 1 Flare au compte
				soundManager.flareCount ++;
			}
		}else{
			if(newStatus == RenderStatus.littleHole || newStatus == RenderStatus.middleHole || newStatus == RenderStatus.bigHole){
				myFx = Instantiate(spawnForYou.holeObjectStatic, transform.position, transform.rotation) as GameObject;
				myFx.transform.parent = transform.parent;
				myFx.transform.localScale = new Vector3(1,1,1);
				//ajouter 1 singularity au compte
				soundManager.singCount ++;
			}else if(newStatus == RenderStatus.littleSun || newStatus == RenderStatus.middleSun || newStatus == RenderStatus.bigSun){
				myFx = Instantiate(spawnForYou.flareObjectStatic, transform.position, transform.rotation) as GameObject;
				myFx.transform.parent = transform.parent;
				myFx.transform.localScale = new Vector3(1,1,1);
				//ajouter 1 Flare au compte
				soundManager.flareCount ++;
			}
		}

//		print (soundManager.singCount + " " + soundManager.flareCount);
	}
	
	GameObject RandomPlanet(){
		
		IDRender = Random.Range(0, 3);
		mySource.clip = fxSoundManager.uniqueFXinstance.ambientPlanetSounds[IDRender];
		mySource.Play();
		return planetCommonScript.renderPlanets[IDRender];
		
	}
	
	GameObject RandomPlanetBis(RenderStatus newStatus){
		
		if(currentState != RenderStatus.littlePlanet && currentState != RenderStatus.middlePlanet && currentState != RenderStatus.bigPlanet){
			//passe de soleil ou plus à planete
			switch(newStatus)
			{
			case RenderStatus.littlePlanet:
				IDRender = Random.Range(0, 3);
				//return planetCommonScript.renderPlanets[IDRender];
				break;
			case RenderStatus.middlePlanet:
				IDRender = Random.Range(3, 6);
				//return planetCommonScript.renderPlanets[IDRender];
				break;
			case RenderStatus.bigPlanet:
				IDRender = Random.Range(6, 9);
				//return planetCommonScript.renderPlanets[IDRender];
				break;
			default:
				print ("What ?");
				break;
			}
			mySource.clip = fxSoundManager.uniqueFXinstance.ambientPlanetSounds[IDRender];
			mySource.Play();
			return planetCommonScript.renderPlanets[IDRender];
		}else{
			//passe de planete à planete
			
			//if precedent == 0
			//alors nouveau = 3
			
			//...
			
			switch(IDRender){
			case 0:
				IDRender = 3;
				break;
			case 1:
				IDRender = 4;
				break;
			case 2:
				IDRender = 5;
				break;
			case 3:
				IDRender = 6;
				break;
			case 4:
				IDRender = 7;
				break;
			case 5:
				IDRender = 8;
				break;
			case 6:
				IDRender = 9;
				break;
			default:
				print ("valeur non autorisée : " + IDRender);
				break;
			}
			
			return planetCommonScript.renderPlanets[IDRender];
			
		}
		
		print ("A parcouru Random planet bis mais n'a pas trouvé de nouvel ID");
		return null;
	}
	
	int IDRender = 0;
	
}
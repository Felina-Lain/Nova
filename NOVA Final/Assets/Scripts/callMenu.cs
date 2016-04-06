using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class callMenu : MonoBehaviour {

	public static MenuStates currentState = MenuStates.Main;

	public GameObject[] panels;

	public EventSystem myEventSystem;

	public GameObject[] initialSelection;
	
	public enum MenuStates
	{
		Main,
		Options,
		Game,
		Quit
	}

	public pauseFeature pauseScript;

	AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
	}

	public void Bip(){
//		print ("bip");
		source.Play();
	}

	public void ToMain(){
		currentState = MenuStates.Main;
		EventByState();
	}

	public void ToOption(){
		currentState = MenuStates.Options;
		EventByState();
	}

	public void ToGame(){
		currentState = MenuStates.Game;
		EventByState();
	}
	public void ToReturnMenu(){
		currentState = MenuStates.Main;
		Time.timeScale = 1;
		Application.LoadLevel("Menu");
	}

	public void ToQuit(){
		currentState = MenuStates.Quit;
		EventByState();
	}

	public void FromGameToOption(){
		pauseScript.PauseEnabler(true);
		myEventSystem.SetSelectedGameObject(initialSelection[0]);
	}

	public void FromOptionToQuit(){
		currentState = MenuStates.Quit;
		EventByState();
	}

	public void FromOptionToGame(){
		pauseScript.PauseEnabler(false);
	}

	void EventByState(){

		switch(currentState)
		{
		case MenuStates.Main:
			panels[1].SetActive(false);
			panels[0].SetActive(true);
			myEventSystem.SetSelectedGameObject(initialSelection[0]);
			break;
		case MenuStates.Options:
			panels[1].SetActive(true);
			panels[0].SetActive(false);
			myEventSystem.SetSelectedGameObject(initialSelection[1]);
			break;
		case MenuStates.Game:
			StartCoroutine(LoadInXSeconds());
			this.enabled = false;
			break;
		case MenuStates.Quit:
			print ("Quit");
			Application.Quit();
			break;
		}
	}

	IEnumerator LoadInXSeconds(){

		yield return new WaitForSeconds(1f);
		Application.LoadLevel("Scene 3 Main");
	}
}

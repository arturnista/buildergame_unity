using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public AudioClip clickAudio;
	public GameObject buildingPanel;
	public GameObject optionsPanel;

	private EventManager eventManager;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		eventManager = GameObject.FindObjectOfType<EventManager>();
	}

	public void ToggleBuildingPanel () {
		buildingPanel.SetActive(!buildingPanel.activeInHierarchy);
		ClickSound();
	}

	public void ToggleOptionsPanel () {
		optionsPanel.SetActive(!optionsPanel.activeInHierarchy);
		ClickSound();
	}

	public void PauseClick(){
		if(GameTimeController.timeStatus != GameTimeController.TimeStatus.Pause){
			GameTimeController.Pause();
			eventManager.FireEvent(EventStr.PAUSE_GAME_EVENT);
			ClickSound();
		}
	}

	public void PlayClick(){
		if(GameTimeController.timeStatus != GameTimeController.TimeStatus.Play){
			GameTimeController.Play();
			eventManager.FireEvent(EventStr.PLAY_GAME_EVENT);
			ClickSound();
		}
	}

	public void FastforwardClick(){
		GameTimeController.FastForward();
		eventManager.FireEvent(EventStr.PLAY_GAME_EVENT);
		ClickSound();
	}

	void ClickSound(){
		audioSource.clip = clickAudio;
		audioSource.Play();
	}
}

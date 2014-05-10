using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public static MenuController Instance;
	private GameObject menuObject;
	private MenuScript mScript;
	private GameObject optionsObject;
	private OptionsScript oScript;
	private GameObject gameMObject;
	private GameModeScript gmScript;
	public bool menuActive;
	public bool optionsActive;
	public bool modesActive;

	public AudioClip menuClick;
	public bool startClick = false;


	void Awake()
	{
		Instance = this;
		menuObject = GameObject.Find("MainMenu");
		mScript = menuObject.GetComponent<MenuScript>();
		gameMObject = GameObject.Find("GameModes");
		gmScript = gameMObject.GetComponent<GameModeScript>();
		optionsObject = GameObject.Find("Options");
		oScript = optionsObject.GetComponent<OptionsScript>();

		menuActive = true;
		optionsActive = false;
		modesActive = false;
	}

	public void PlaySound()
	{
		this.gameObject.audio.PlayOneShot (menuClick);
	}

	// Update is called once per frame
	void Update () 
	{
		if (startClick) 
			{
				PlaySound();
				startClick = false;
			}

		if(menuActive)
		{
			menuObject.SetActive(true);
			optionsObject.SetActive(false);
			gameMObject.SetActive(false);
			optionsActive = false;
			modesActive = false;
		}
		else if(modesActive)
		{
			gameMObject.SetActive(true);
			optionsObject.SetActive(false);
			menuObject.SetActive(false);
			optionsActive = false;
			menuActive = false;
		}
		else if(optionsActive)
		{
			gameMObject.SetActive(false);
			optionsObject.SetActive(true);
			menuObject.SetActive(false);
			modesActive = false;
			menuActive = false;
		}
	}
}

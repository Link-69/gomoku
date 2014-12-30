using UnityEngine;
using System.Collections;

public class ManageMenu : MonoBehaviour
{
	public GameObject menuInGame;
	public GameObject player;
	public GameObject menuOptions;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && Time.timeScale == 1)
		{
			menuInGame.SetActive(true);
			player.SetActive(false);
			Time.timeScale = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
		{
			menuOptions.SetActive(false);
			menuInGame.SetActive(false);
			player.SetActive(true);
			Time.timeScale = 1;
		}
	}
}

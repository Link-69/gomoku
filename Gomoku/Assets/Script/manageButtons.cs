using UnityEngine;
using System.Collections;

public class manageButtons : MonoBehaviour
{
	public GameObject	MenuPvP;
	public GameObject	MenuOptions;
	public GameObject	MenuInGame;
	public GameObject	AffArbitre;

    void Start()
    {

    }
	
    void Update()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadPlayerVSAI()
    {
		Application.LoadLevel ("PlayerVSAI");
    }

    public void LoadPlayerVSPlayer()
    {
        Application.LoadLevel("PlayerVSPlayer");
    }

	public void ReturnMenu()
	{
		Application.LoadLevel ("Menu");
	}

	public void ResumeGame()
	{
		MenuPvP.gameObject.SetActive (false);
		Time.timeScale = 1;
	}

	public void Options()
	{
		MenuOptions.gameObject.SetActive (true);
		MenuInGame.gameObject.SetActive (false);
	}

	public void DisplayPiecesEaten()
	{

	}

	public void NotDisplayPiecesEaten()
	{

	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AffArbitre : MonoBehaviour
{
	public GameObject Arbitre;
	public Text DisplayPlayer1Pieces;
	public Text DisplayPlayer2Pieces;
	public bool	trigDisplay = true;
	public bool trigDTrois = true;
	public bool trigCinq = true;
	public bool trigMsg = true;

	void Start ()
	{
	}

	void Update ()
	{

	}

	public void ModifTextPiecesEatenByAll()
	{
		DisplayPlayer1Pieces.text = "Number of pieces captured by player 1 : " + Arbitre.GetComponent<ArbitreScript> ().nbEatPlayer1;
		DisplayPlayer2Pieces.text = "Number of pieces captured by player 2 : " + Arbitre.GetComponent<ArbitreScript> ().nbEatPlayer2;
	}

	public void DisplayPiecesEaten()
	{
		if (trigDisplay == true) {
			DisplayPlayer1Pieces.gameObject.SetActive (true);
			DisplayPlayer2Pieces.gameObject.SetActive (true);
			trigDisplay = false;
			GameObject.Find ("ButtonScore").GetComponentInChildren<Text>().text = "Score : Yes";			
			DisplayPlayer1Pieces.text = "Number of pieces captured by player 1 : " + Arbitre.GetComponent<ArbitreScript> ().nbEatPlayer1;
			DisplayPlayer2Pieces.text = "Number of pieces captured by player 2 : " + Arbitre.GetComponent<ArbitreScript> ().nbEatPlayer2;
		}
		else {
			DisplayPlayer1Pieces.gameObject.SetActive (false);
			DisplayPlayer2Pieces.gameObject.SetActive (false);
			trigDisplay = true;
			GameObject.Find ("ButtonScore").GetComponentInChildren<Text>().text = "Score : No";
		}
	}

	public void ActiveDoubleTrois()
	{
		if (trigDTrois == true) {
			Arbitre.GetComponent<ArbitreScript> ().DTrois = false;
			trigDTrois = false;
			GameObject.Find ("ButtonDoubleTrois").GetComponentInChildren<Text>().text = "Double Three : No";
		}
		else 
		{
			Arbitre.GetComponent<ArbitreScript>().DTrois = true;
			trigDTrois = true;
			GameObject.Find ("ButtonDoubleTrois").GetComponentInChildren<Text>().text = "Double Three : Yes";
		}
	}

	public void ActiveVictoireCinq()
	{
		if (trigCinq == true) 
		{
			Arbitre.GetComponent<ArbitreScript>().VCinq = false;
			trigCinq = false;
			GameObject.Find("ButtonLineFive").GetComponentInChildren<Text>().text = "Victory 5 : No";
		}
		else 
		{
			Arbitre.GetComponent<ArbitreScript>().VCinq = true;
			trigCinq = true;
			GameObject.Find("ButtonLineFive").GetComponentInChildren<Text>().text = "Victory 5 : Yes";
		}
	}

	public void ActiveMessages()
	{
		if (trigMsg == true) 
		{
			Arbitre.GetComponent<ArbitreScript> ().Msg = false;
			trigMsg = false;
			GameObject.Find ("ButtonMsg").GetComponentInChildren<Text> ().text = "Error Messages : No";
		}
		else
		{
			Arbitre.GetComponent<ArbitreScript>().Msg = true;
			trigMsg = true;
			GameObject.Find("ButtonMsg").GetComponentInChildren<Text>().text = "Error Messages : Yes";
		}
	}
}

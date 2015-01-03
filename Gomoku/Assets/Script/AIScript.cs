using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIScript : MonoBehaviour {

	public	int				id;
	public	GameObject		pionCurseur;
	public	GameObject		arbitre;
	GameObject		newPion;
	public	Text			TextWhoPlay;
	public	Vector3			position;
	public  int[][] 		tab;
    

	void Start ()
	{
		newPion = Instantiate (pionCurseur, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		newPion.gameObject.GetComponent<PionScript> ().idPlayer = 1;
		newPion.gameObject.GetComponent<PionScript> ().dontTouchId = true;
		newPion.gameObject.GetComponent<PionScript> ().Arbitre = arbitre;
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			if (arbitre.gameObject.GetComponent<ArbitreScript>().CheckPut ((int)newPion.transform.position.x, (int)newPion.transform.position.y, id))
			{
					newPion.gameObject.GetComponent<PionScript> ().idPlayer = 1;
					newPion.gameObject.GetComponent<PionScript> ().dontTouchId = true;
					newPion.gameObject.GetComponent<PionScript> ().Arbitre = arbitre;
					IAmaker();
				}
		}
	}

	void IAmaker()
	{
        int i = -1;
        int j = -1;
        var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript>();

		//parcours du tableau
		tab = arbitre.gameObject.GetComponent<ArbitreScript> ().tab;
		while (++i < 19)
		{
			j = -1;
			while (++j < 19)
			{
				if(tab[i][j] == 0)
				{
					//check si on peut gg en pos i,j
					if (checkwin(tab, i, j) == true)
					{
                        //poser le pion en i,j
                        if ((get_arbitre.DTrois == true && get_arbitre.DoubleThree(j, i, -1) == false) || get_arbitre.DTrois == false)
                        {
                            newPion = Instantiate(get_arbitre.pion, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
                            newPion.gameObject.GetComponent<PionScript>().idPlayer = -1;
                            newPion.gameObject.GetComponent<PionScript>().Arbitre = gameObject;
                            newPion.gameObject.GetComponent<PionScript>().isPut = true;
                            tab[j][i] = -1;
                        }
                    }
				
					//check pour ne pas perdre en pos i, j
					else if (checklose(tab, i, j) == true)
					{
						arbitre.gameObject.GetComponent<ArbitreScript>().CheckPut(j, i, -1);
						//poser le pion en i,j
					}
			
					//sinon check si le coup est intérressant 
					else
					{
						//trouver le meilleur coup et poser
						playbest(tab);
					}
				}
			}
		}
	}

	bool checkwin(int[][] tab, int i, int j)
	{
		var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript>();

		// check 5 de suite
		if (get_arbitre.CheckFive(j, i, -1) == true)
				return true;

		// check manger 10
        if (get_arbitre.nbEatPlayer2 == 8)
        {
            get_arbitre.VerifEaten(j, i, -1);
            if (get_arbitre.nbEatPlayer2 == 10)
                return true;
        }
        return false;
	}

	bool checklose(int[][] tab, int i, int j)
	{
		var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript>();

		// check 3 enemi de suite
		if (get_arbitre.CheckLineFive (j, i, j - 4, i, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j - 4, i + 4, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j, i + 4, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j + 4, i + 4, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j +4, i, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j + 4, i - 4, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j, i - 4, 1, 1) == 3)
			return true;
		else if (get_arbitre.CheckLineFive (j, i, j - 4, i - 4, 1, 1) == 3)
			return true;

		// check si enemi peut manger
        return false;
	}

	void playbest(int[][] tab)
	{
		// je sais pas trop
	}
}




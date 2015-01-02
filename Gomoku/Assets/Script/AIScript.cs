using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIScript : MonoBehaviour {

	public	int				id;
	public	GameObject		pionCurseur;
	public	GameObject		arbitre;
	GameObject				newPion;
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
					}
				
					//check pour ne pas perdre en pos i, j
					else if (checklose(tab, i, j) == true)
					{
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
		// check 5 de suite
		// check manger 10
        var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript>();
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
		// check 3 enemi de suite
		// check si enemi peut manger
        return false;
	}

	void playbest(int[][] tab)
	{
		// je sais pas trop
	}
}




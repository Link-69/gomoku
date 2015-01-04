using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIScript : MonoBehaviour
{

    public int id;
    public GameObject pionCurseur;
    public GameObject arbitre;
    GameObject newPion;
    GameObject newPion2;
    public Text TextWhoPlay;
    public Vector3 position;
    public int[][] tab;

    void Start()
    {
        newPion = Instantiate(pionCurseur, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newPion.gameObject.GetComponent<PionScript>().idPlayer = 1;
        newPion.gameObject.GetComponent<PionScript>().dontTouchId = true;
        newPion.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            if (arbitre.gameObject.GetComponent<ArbitreScript>().CheckPut((int)newPion.transform.position.x, (int)newPion.transform.position.y, id))
            {
                newPion.gameObject.GetComponent<PionScript>().idPlayer = 1;
                newPion.gameObject.GetComponent<PionScript>().dontTouchId = true;
                newPion.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
                IAmaker();
            }
        }
    }

    int IAmaker()
    {
        int i = -1;
        int j = -1;
        var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript>();

        //parcours du tableau
        tab = arbitre.gameObject.GetComponent<ArbitreScript>().tab;
        while (++i < 19)
        {
            j = -1;
            while (++j < 19)
            {
                if (tab[j][i] == 0)
                {
                    //check si on peut gg en pos i,j
                    if (checkwin(i, j) == true)
                    {
                        //poser le pion en i,j
                        if ((get_arbitre.DTrois == true && get_arbitre.DoubleThree(j, i, -1) == false) || get_arbitre.DTrois == false)
                        {
                            newPion2 = Instantiate(get_arbitre.pion, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
                            newPion2.gameObject.GetComponent<PionScript>().idPlayer = -1;
                            newPion2.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
                            newPion2.gameObject.GetComponent<PionScript>().isPut = true;
                            tab[j][i] = -1;
							arbitre.gameObject.GetComponent<ArbitreScript>().CheckVictory(j, i, -1);
                            return 0;
                        }
                    }

                    //check pour ne pas perdre en pos i, j
                    else if (checklose(i, j) == true)
                    {
                        //poser le pion en i,j
                        if ((get_arbitre.DTrois == true && get_arbitre.DoubleThree(j, i, -1) == false) || get_arbitre.DTrois == false)
                        {
                            newPion2 = Instantiate(get_arbitre.pion, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
                            newPion2.gameObject.GetComponent<PionScript>().idPlayer = -1;
                            newPion2.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
                            newPion2.gameObject.GetComponent<PionScript>().isPut = true;
                            tab[j][i] = -1;
                            return 0;
                        }
                    }
                }
            }
        }
		i = -1;
		
		while (++i < 19)
		{
			j = -1;
			while (++j < 19)
			{
				if (tab[j][i] == 0)
				{
					if ((get_arbitre.DTrois == true && get_arbitre.DoubleThree(j, i, -1) == false) || get_arbitre.DTrois == false)
					{
						if(canEat(i, j) == true)
						{
							newPion2 = Instantiate(get_arbitre.pion, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
							newPion2.gameObject.GetComponent<PionScript>().idPlayer = -1;
							newPion2.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
							newPion2.gameObject.GetComponent<PionScript>().isPut = true;
							tab[j][i] = -1;
							return 0;
						}
					}
				}
			}
		}

		i = -1;
		
		while (++i < 19)
		{
			j = -1;
			while (++j < 19)
			{
				if (tab[j][i] == 0)
				{
					if ((get_arbitre.DTrois == true && get_arbitre.DoubleThree(j, i, -1) == false) || get_arbitre.DTrois == false)
					{
						if(canEat(i, j) == true)
						{
							newPion2 = Instantiate(get_arbitre.pion, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
							newPion2.gameObject.GetComponent<PionScript>().idPlayer = -1;
							newPion2.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
							newPion2.gameObject.GetComponent<PionScript>().isPut = true;
							tab[j][i] = -1;
							return 0;
						}
					}
				}
			}
		}

		bool put = false;

		while (put == false) 
		{
			i = Mathf.FloorToInt(Random.Range(0.0F, 18.0F));
			j = Mathf.FloorToInt(Random.Range(0.0F, 18.0F));
			
			if (tab[j][i] == 0)
			{
				if ((get_arbitre.DTrois == true && get_arbitre.DoubleThree(j, i, -1) == false) || get_arbitre.DTrois == false)
				{
					if(canFive(i, j) == true)
					{
						newPion2 = Instantiate(get_arbitre.pion, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
						newPion2.gameObject.GetComponent<PionScript>().idPlayer = -1;
						newPion2.gameObject.GetComponent<PionScript>().Arbitre = arbitre;
						newPion2.gameObject.GetComponent<PionScript>().isPut = true;
						tab[j][i] = -1;
						return 0;
					}
				}
			}
		}
        return (1);
    }

    bool dontGetHit(int i, int j)
    {
        if (j > 1 && j < 18 && tab[j - 1][i] == -1 && tab[j - 2][i] == 1 && tab[j + 1][i] == 0) // pc--
            return (false);
        else if (j > 0 && j < 17 && tab[j + 1][i] == -1 && tab[j + 2][i] == 1 && tab[j - 1][i] == 0) // --cp
            return (false);
        else if (i > 1 && i < 18 && tab[j][i - 1] == -1 && tab[j][i - 2] == 1 && tab[j][i + 1] == 0) // pc--
            return (false);
        else if (i > 0 && i < 17 && tab[j][i + 1] == -1 && tab[j][i + 2] == 1 && tab[j][i - 1] == 0) // --cp
            return (false);
        else if (j > 0 && j < 17 && tab[j + 1][i] == -1 && tab[j - 1][i] == 1 && tab[j + 2][i] == 0) // p-c-
            return (false);
        else if (j > 1 && j < 18 && tab[j - 1][i] == -1 && tab[j + 1][i] == 1 && tab[j - 2][i] == 0) // -c-p
            return (false);
        else if (i > 0 && i < 17 && tab[j][i + 1] == -1 && tab[j][i - 1] == 1 && tab[j][i + 2] == 0) // p-c-
            return (false);
        else if (i > 1 && i < 18 && tab[j][i - 1] == -1 && tab[j][i + 1] == 1 && tab[j][i - 2] == 0) // -c-p
            return (false);
        return (true);
    }

    bool checkwin(int i, int j)
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

    bool checklose(int i, int j)
    {
        var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript>();

        // check 3 enemi de suite
        if (get_arbitre.CheckLineFive(j, i, j - 2, i, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j - 2, i + 2, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j, i + 2, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j + 2, i + 2, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j + 2, i, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j + 2, i - 2, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j, i - 2, 1, 1) == 3)
            return true;
        else if (get_arbitre.CheckLineFive(j, i, j - 2, i - 2, 1, 1) == 3)
            return true;

        // check si enemi peut manger

        return false;
    }

	bool canEat(int i, int j)
	{
		var get_arbitre = arbitre.gameObject.GetComponent<ArbitreScript> ();
		int actuEat = get_arbitre.nbEatPlayer2;
		
		get_arbitre.VerifEaten (j, i, -1);
		if (get_arbitre.nbEatPlayer2 > actuEat)
			return true;
		return false;
	}
	
	bool canFive(int i, int j)
	{
		if (CanLineFive(j, i, j - 4, i, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j - 4, i + 4, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j, i + 4, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j + 4, i + 4, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j + 4, i, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j + 4, i - 4, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j, i - 4, id, 1) == 5)
			return true;
		else if (CanLineFive(j, i, j - 4, i - 4, id, 1) == 5)
			return true;
		else
			return false;
	}
	
	int CanLineFive(int x1, int y1, int x2, int y2, int id, int incr)
	{
		if (x2 == x1 && y2 == y1)
			return (incr);
		if ((x2 < 0 || x2 > 18) || (y2 < 0 || y2 > 18))
			return (-1);
		if (tab[x2][y2] == 1)
			return (-1);
		if (x2 < x1)
			x2 = x2 + 1;
		else if (x2 > x1)
			x2 = x2 - 1;
		if (y2 < y1)
			y2 = y2 + 1;
		else if (y2 > y1)
			y2 = y2 - 1;
		return (CanLineFive(x1, y1, x2, y2, id, incr + 1));
	}
}




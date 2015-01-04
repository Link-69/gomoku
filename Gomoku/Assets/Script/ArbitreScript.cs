using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArbitreScript : MonoBehaviour
{
    public int[][] tab = new int[19][];
    public GameObject pion;
    public GameObject menuVictory;
    public GameObject AffArbitre;
    public Text textWhoWin;
    public Text textHowWin;
    public Text textWhyYouFail;
    public int nbEatPlayer1 = 0;
    public int nbEatPlayer2 = 0;
    public bool DTrois = true;
    public bool VCinq = true;
    public bool Msg = true;

    void Start()
    {
        int i = -1;
        int j;

        while (++i < 19)
        {
            tab[i] = new int[19];
            j = -1;
            while (++j < 19)
            {
                tab[i][j] = 0;
            }
        }
    }

    void Update()
    {

    }

    int CheckLine(int x1, int y1, int x2, int y2, int id)
    {
        int ally = 0;

        if ((x2 >= 0 && x2 <= 18) && (y2 >= 0 && y2 <= 18))
        {
            if (id == tab[x2][y2])
            {
                ally = ally + 1;
            }
        }
        while (x2 != x1 || y2 != y1)
        {
            if (x2 < x1)
                x2 = x2 + 1;
            else if (x2 > x1)
                x2 = x2 - 1;
            if (y2 < y1)
                y2 = y2 + 1;
            else if (y2 > y1)
                y2 = y2 - 1;
            if ((x2 < 0 || x2 > 18) || (y2 < 0 || y2 > 18))
                break;
            if (id == tab[x2][y2])
            {
                ally = ally + 1;
            }
            else if (tab[x2][y2] == (id * -1))
            {
                ally = 0;
            }
        }
        if (ally == 3)
            return 0;
        return ally;
    }

    public bool DoubleThree(int x, int y, int id)
    {
        int checker = 0;

        checker = checker + CheckLine(x, y, x, y + 3, id);
        checker = checker + CheckLine(x, y, x + 3, y + 3, id);
        checker = checker + CheckLine(x, y, x + 3, y, id);
        checker = checker + CheckLine(x, y, x + 3, y - 3, id);
        checker = checker + CheckLine(x, y, x, y - 3, id);
        checker = checker + CheckLine(x, y, x - 3, y - 3, id);
        checker = checker + CheckLine(x, y, x - 3, y, id);
        checker = checker + CheckLine(x, y, x - 3, y + 3, id);
        if (checker < 4)
            return false;
        else
            return true;
    }

    public bool CheckLineEat(int x1, int y1, int x2, int y2, int id)
    {
        int xsave = -1;
        int ysave = -1;

        if ((x2 >= 0 && x2 <= 18) && (y2 >= 0 && y2 <= 18))
        {
            if (id != tab[x2][y2])
            {
                return false;
            }
        }
        else
            return false;
        while (x2 != x1 || y2 != y1)
        {
            if (x2 < x1)
                x2 = x2 + 1;
            else if (x2 > x1)
                x2 = x2 - 1;
            if (y2 < y1)
                y2 = y2 + 1;
            else if (y2 > y1)
                y2 = y2 - 1;
            if ((x2 < 0 || x2 > 18) || (y2 < 0 || y2 > 18))
                break;
            if (tab[x2][y2] == id * -1)
            {
                if (xsave == -1 && ysave == -1)
                {
                    xsave = x2;
                    ysave = y2;
                }
                else
                {
                    tab[xsave][ysave] = 0;
                    tab[x2][y2] = 0;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void VerifEaten(int x, int y, int id)
    {
        int iHaveEat = 0;

        if (CheckLineEat(x, y, x, y + 3, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x + 3, y + 3, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x + 3, y, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x + 3, y - 3, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x, y - 3, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x - 3, y - 3, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x - 3, y, id) == true)
            iHaveEat = iHaveEat + 2;
        if (CheckLineEat(x, y, x - 3, y + 3, id) == true)
            iHaveEat = iHaveEat + 2;
        if (id == 1)
            nbEatPlayer1 = nbEatPlayer1 + iHaveEat;
        else
            nbEatPlayer2 = nbEatPlayer2 + iHaveEat;
        AffArbitre.gameObject.GetComponent<AffArbitre>().ModifTextPiecesEatenByAll();
    }

    bool CheckBreak(int x3, int y3, int id)
    {
        if (x3 + 1 < 19)
            if (tab[x3 + 1][y3] == id)
                if (x3 - 1 >= 0)
                    if (tab[x3 - 1][y3] != id)
                        if (x3 + 2 < 19)
                            if (tab[x3 + 2][y3] != id)
                                return true;
        if (x3 + 1 < 19 && y3 + 1 < 19)
            if (tab[x3 + 1][y3 + 1] == id)
                if (x3 - 1 >= 0 && y3 - 1 >= 0)
                    if (tab[x3 - 1][y3 - 1] != id)
                        if (x3 + 2 < 19 && y3 + 2 < 19)
                            if (tab[x3 + 2][y3 + 2] != id)
                                return true;
        if (y3 + 1 < 19)
            if (tab[x3][y3 + 1] == id)
                if (y3 - 1 >= 0)
                    if (tab[x3][y3 - 1] != id)
                        if (y3 + 2 < 19)
                            if (tab[x3][y3 + 2] != id)
                                return true;
        if (x3 - 1 >= 0 && y3 + 1 < 19)
            if (tab[x3 - 1][y3 + 1] == id)
                if (x3 + 1 < 19 && y3 - 1 >= 0)
                    if (tab[x3 + 1][y3 - 1] != id)
                        if (x3 - 2 >= 0 && y3 + 2 < 19)
                            if (tab[x3 - 2][y3 + 2] != id)
                                return true;
        if (x3 - 1 >= 0)
            if (tab[x3 - 1][y3] == id)
                if (x3 + 1 < 19)
                    if (tab[x3 + 1][y3] != id)
                        if (x3 - 2 >= 0)
                            if (tab[x3 - 2][y3] != id)
                                return true;
        if (x3 - 1 >= 0 && y3 - 1 >= 0)
            if (tab[x3 - 1][y3 - 1] == id)
                if (x3 + 1 < 19 && y3 + 1 < 19)
                    if (tab[x3 + 1][y3 + 1] != id)
                        if (x3 - 2 >= 0 && y3 - 2 >= 0)
                            if (tab[x3 - 2][y3 - 2] != id)
                                return true;
        if (y3 - 1 >= 0)
            if (tab[x3][y3 - 1] == id)
                if (y3 + 1 < 19)
                    if (tab[x3][y3 + 1] != id)
                        if (y3 - 2 >= 0)
                            if (tab[x3][y3 - 2] != id)
                                return true;
        if (x3 + 1 < 19 && y3 - 1 >= 0)
            if (tab[x3 + 1][y3 - 1] == id)
                if (x3 - 1 >= 0 && y3 + 1 < 19)
                    if (tab[x3 - 1][y3 + 1] != id)
                        if (x3 + 2 < 19 && y3 - 2 >= 0)
                            if (tab[x3 + 2][y3 - 2] != id)
                                return true;
        return false;
    }

    public int CheckLineFive(int x1, int y1, int x2, int y2, int id, int incr)
    {
        if (x2 == x1 && y2 == y1)
            return (incr);
        if ((x2 < 0 || x2 > 18) || (y2 < 0 || y2 > 18))
            return (-1);
        if (tab[x2][y2] != id)
            return (-1);
        if (CheckBreak(x2, y2, id) == true)
            return (-1);
        if (x2 < x1)
            x2 = x2 + 1;
        else if (x2 > x1)
            x2 = x2 - 1;
        if (y2 < y1)
            y2 = y2 + 1;
        else if (y2 > y1)
            y2 = y2 - 1;
        return (CheckLineFive(x1, y1, x2, y2, id, incr + 1));
    }

    public bool CheckFive(int x, int y, int id)
    {
        if (CheckLineFive(x, y, x - 4, y, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x - 4, y + 4, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x, y + 4, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x + 4, y + 4, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x + 4, y, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x + 4, y - 4, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x, y - 4, id, 1) == 5)
            return true;
        else if (CheckLineFive(x, y, x - 4, y - 4, id, 1) == 5)
            return true;
        else
            return false;
    }

    /*
    ** Vérifie le 5 cassable et les 10 pions mangés dès qu'un joueur à jouer la frame d'après (normalement)
    */
    public void CheckVictory(int x, int y, int id)
    {
        if (nbEatPlayer1 == 10 || nbEatPlayer2 == 10)
        {
            menuVictory.SetActive(true);
            if (nbEatPlayer1 == 10)
                textWhoWin.text = "Player One Win !";
            else
                textWhoWin.text = "Player Two Win !";
            textHowWin.text = "You have captured 10 pieces";
        }
        if (VCinq == true && CheckFive(x, y, id) == true)
        {
            menuVictory.SetActive(true);
            if (id == 1)
                textWhoWin.text = "Player One Win !";
            else
                textWhoWin.text = "Player Two Win !";
            textHowWin.text = "You've done a line of 5 pieces";
        }
    }

    public bool CheckPut(int x, int y, int id)
    {
        Debug.Log("coucou x = " + x + " y = " + y);
        textWhyYouFail.text = "";
        if (tab[x][y] == 0)
        {
            if (DTrois == false)
            {
                GameObject newPion;
                newPion = Instantiate(pion, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                newPion.gameObject.GetComponent<PionScript>().idPlayer = id;
                newPion.gameObject.GetComponent<PionScript>().Arbitre = gameObject;
                newPion.gameObject.GetComponent<PionScript>().isPut = true;
                tab[x][y] = id;
                VerifEaten(x, y, id);
                CheckVictory(x, y, id);
                return true;
            }
            else if (DoubleThree(x, y, id) == false)
            {
                GameObject newPion;
                newPion = Instantiate(pion, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                newPion.gameObject.GetComponent<PionScript>().idPlayer = id;
                newPion.gameObject.GetComponent<PionScript>().Arbitre = gameObject;
                newPion.gameObject.GetComponent<PionScript>().isPut = true;
                tab[x][y] = id;
                VerifEaten(x, y, id);
                CheckVictory(x, y, id);
                return true;
            }
            else
            {
                if (Msg == true)
                    textWhyYouFail.text = "You can not play because of the \"No-double-unblocked-threes\" rule";
                return false;
            }
        }
        else
        {
            if (Msg == true)
                textWhyYouFail.text = "You can not play because he already has a piece here";
            return false;
        }
    }
}

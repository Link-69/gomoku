﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIScript : MonoBehaviour {

	public	int		id;
	public	GameObject		pionCurseur;
	public	GameObject		arbitre;
	GameObject				newPion;
	public	Text			TextWhoPlay;

	void Start ()
	{
		newPion = Instantiate (pionCurseur, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		newPion.gameObject.GetComponent<PionScript> ().idPlayer = id;
		newPion.gameObject.GetComponent<PionScript> ().dontTouchId = true;
		newPion.gameObject.GetComponent<PionScript> ().Arbitre = arbitre;
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			if (arbitre.gameObject.GetComponent<ArbitreScript>().CheckPut ((int)newPion.transform.position.x, (int)newPion.transform.position.y, id))
			{
					newPion.gameObject.GetComponent<PionScript> ().idPlayer = id;
					newPion.gameObject.GetComponent<PionScript> ().dontTouchId = true;
					newPion.gameObject.GetComponent<PionScript> ().Arbitre = arbitre;
				}
		}
	}

	void IAmaker()
	{

	}
}


using UnityEngine;
using System.Collections;

public class PionScript : MonoBehaviour {

	public	bool	isPut;
	public	Vector3	position;
	public	int		idPlayer;
	public	bool	dontTouchId;
	public	GameObject Arbitre;

	void Start ()
	{

	}
	
	void Update ()
		{
			if (dontTouchId == false)
				idPlayer = Arbitre.gameObject.GetComponent<ArbitreScript> ().tab [(int)gameObject.transform.position.x] [(int)gameObject.transform.position.y];
			if (idPlayer == -1)
						gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
				else if (idPlayer == 1)
						gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
				else if (idPlayer == 0)
						Destroy (gameObject);
			if (isPut == false)
			{
				putPion();
			}
		}

	void putPion()
	{
		float 	x;
		float	y;
		Ray 	ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		position.x = ray.origin.x;
		position.y = ray.origin.y;
		position.x = (int)position.x;
		position.y = (int)position.y;
		if (position.x > 18)
			position.x = 18;
		else if (position.x < 0)
			position.x = 0;
		if (position.y > 18)
			position.y = 18;
		else if (position.y < 0)
			position.y = 0;
		x = ray.origin.x - (int)ray.origin.x;
		y = ray.origin.y - (int)ray.origin.y;
		if (x > 0.5f && position.x != 18)
			position.x += 1;
		if (y > 0.5f && position.y != 18)
			position.y += 1;
		transform.position = position;
	}
}

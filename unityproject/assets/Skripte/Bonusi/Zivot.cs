using UnityEngine;
using System.Collections;

public class Zivot : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		if(c.tag == "Player")
		{
			Postavke.brojZivota++;
			Destroy (this.gameObject);
		}
	}
}

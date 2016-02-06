using UnityEngine;
using System.Collections;

public class DodatnaBomba : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		if(c.tag == "Player")
		{
			Postavke.brojBombi++;
			Destroy (this.gameObject);
		}
	}
}

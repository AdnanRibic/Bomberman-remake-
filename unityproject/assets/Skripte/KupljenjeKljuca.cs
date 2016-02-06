using UnityEngine;
using System.Collections;

public class KupljenjeKljuca : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		if(c.tag == "Player")
		{
			Postavke.imaKljuc=true;
			Destroy (this.gameObject);
		}
	}
}

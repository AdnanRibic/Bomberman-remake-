using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider c)
	{
		if(c.tag == "Player")
		{
			Postavke.bombRange++;
			Destroy (this.gameObject);
		}
	}
}

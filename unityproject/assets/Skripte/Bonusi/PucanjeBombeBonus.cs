using UnityEngine;
using System.Collections;

public class PucanjeBombeBonus : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		if(c.tag == "Player")
		{
			Postavke.mozeAktivirati=true;
			Destroy (this.gameObject);
		}
	}
}

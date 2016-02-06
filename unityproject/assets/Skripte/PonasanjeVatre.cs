using UnityEngine;
using System.Collections;

public class PonasanjeVatre : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 1f);
	}
	


	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			Postavke.oduzmiZivot();
		}
		else if(c.tag == "Enemy")
		{
			Destroy(c.gameObject);

		}
	}
}

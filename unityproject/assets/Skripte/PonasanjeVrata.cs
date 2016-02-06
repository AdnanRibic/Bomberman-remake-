using UnityEngine;
using System.Collections;

public class PonasanjeVrata : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		if(c.tag == "Player")
		{
			if(Postavke.imaKljuc && Postavke.preostaloNeprijatelja==0)
			{
				Postavke.gotovLevel=true;
			}
		}
	}
}

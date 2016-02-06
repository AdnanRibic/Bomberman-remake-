using UnityEngine;
using System.Collections;

public class ProvjeriKraj : MonoBehaviour {

	void Update () 
	{
	if(Postavke.kraj)
		{
			guiText.enabled=true;
			guiText.text = "Igra gotova, dosli ste do " + Postavke.nivo + ". nivoa\nBroj bodova: " + Postavke.bodovi + "\nEnter za izlazak u meni";
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				Application.LoadLevel(0);
			}
		}
	}
}

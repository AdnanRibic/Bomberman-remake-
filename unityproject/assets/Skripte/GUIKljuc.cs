using UnityEngine;
using System.Collections;

public class GUIKljuc : MonoBehaviour {



	void Update () 
	{

	if(Postavke.imaKljuc)
		{
			this.guiTexture.enabled=true;
		}
		else
			this.guiTexture.enabled=false;
	}
}

using UnityEngine;
using System.Collections;

public class MenuTipke : MonoBehaviour {
	public bool start;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown ()
	{
		if(start)
		{
		Postavke.postaviPocetneVrijednosti();
		Application.LoadLevel(1);
		}
		else
			Application.Quit();
	}
}

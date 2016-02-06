using UnityEngine;
using System.Collections;

public class UpravljanjeZvukovima : MonoBehaviour {

	public AudioClip[] nizKlipova;
	private bool sviraKraj=false;

	// Use this for initialization
	void Start () {
		postaviNoviClip(0);
		audio.Play();
		audio.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(audio.clip==nizKlipova[0] && !audio.isPlaying)
		{

			postaviNoviClip(1);
			audio.Play();
			audio.loop = true;
		}
		if(Postavke.kraj && !sviraKraj)
		{
			sviraKraj=true;
			postaviNoviClip(2);
			audio.Play();
			audio.loop=false;
		}
		if(Postavke.imaKljuc && audio.clip==nizKlipova[1])
		{
			postaviNoviClip(3);
			audio.Play();
			audio.loop=true;
		}
		if(Postavke.poginuo && audio.clip!=nizKlipova[4] && !Postavke.kraj)
		{
			postaviNoviClip(4);
			audio.Play();
			audio.loop=false;
		}
		if(Postavke.poginuo && !audio.isPlaying && !Postavke.kraj)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if(Postavke.gotovLevel && audio.clip!=nizKlipova[5])
		{
			postaviNoviClip(5);
			audio.Play();
			audio.loop=false;
		}
		if(Postavke.gotovLevel && !audio.isPlaying)
		{
			Postavke.nivo++;
			if(Application.loadedLevel>=3)
				Application.LoadLevel(1);
			else
				Application.LoadLevel(Application.loadedLevel+1);
		}

	}

	void postaviNoviClip(int id)
	{
		audio.clip = nizKlipova[id];

	}
}

using UnityEngine;
using System.Collections;

public class GUIPrikazStatusa : MonoBehaviour {

	void Update () {
		guiText.text = Postavke.brojZivota + "\nNivo: " + Postavke.nivo + "\nBodovi: " + Postavke.bodovi + "\nHighscore: " + Postavke.highScore;
	}
}

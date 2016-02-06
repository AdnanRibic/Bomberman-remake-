using UnityEngine;
using System.Collections;

public static class Postavke {

	public static float bombRange=1f;
	public static int brojBombi=1;
	public static int trenutniBrojBombi=0;
	public static int brojZivota=3;
	public static bool mozeAktivirati=false;
	public static bool imaKljuc=false;
	public static int nivo=1;
	public static bool kraj;
	public static int preostaloNeprijatelja;
	public static int bodovi;
	public static int highScore=2000;
	public static bool poginuo;
	public static bool gotovLevel;


	public static void postaviPocetneVrijednosti()
	{
		bombRange=1f;
		brojBombi=1;
		trenutniBrojBombi=0;
		brojZivota=3;
		mozeAktivirati=false;
		imaKljuc=false;
		nivo=1;
		kraj=false;
		bodovi=0;
		poginuo=false;
		gotovLevel=false;
	}

	public static void postaviSlijedeciNivo()
	{
		imaKljuc=false;
		kraj=false;
		poginuo=false;
		gotovLevel=false;
		trenutniBrojBombi=0;
	}

	public static void oduzmiZivot ()
	{
		brojZivota--;
		if(brojZivota<=0)
			kraj=true;
		poginuo=true;
	}

	public static void dodajBodove (int i)
	{
		bodovi+=i;
		if(bodovi>highScore)
			highScore=bodovi;
	}
}

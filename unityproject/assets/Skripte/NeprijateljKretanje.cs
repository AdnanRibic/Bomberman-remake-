using UnityEngine;
using System.Collections;

public class NeprijateljKretanje : MonoBehaviour {

	public float speed;
	public bool tipNeprijatelja;

	private int smjer;
	int[] udaljenostSvihPolja;
	bool svaPuna;
	bool mozeSeKretati;
	float vrijeme;

	void Start()
	{
		vrijeme=0;
		mozeSeKretati=true;
	}

	void Update () 
	{
		if(Postavke.kraj || Postavke.poginuo)//provjerava se da li je igrac izbio zivot ili da li je gotovo
			return;//ukoliko jeste nece se izvrsavati dalje funkcija
		if(vrijeme>Time.time)//provjerava se da li se igrac moze kretati (da li je isteklo vrijeme)
			return;//ukoliko nije nece se izvrsavati dalje funkc
		else//ukoliko je isteklo vrijeme
		{
			vrijeme=Time.time+speed;//nova vrijednost vremena koje ce odbrojavati
			mozeSeKretati=false;//da bi se izvrsio donji dio koda
		}
		if(!mozeSeKretati)
		{
		int udaljenost = 0;
		udaljenostSvihPolja = getPraznaPolja();//puni se niz integera, da se provjeri u kojim se smjerovima moze kretati neprijatelj
		System.Collections.Generic.List<int> listaIdeova = new System.Collections.Generic.List<int>();//kreira se nova lista
		svaPuna=true;//sva puna se postavlja na true
		for (int i=0; i<4; i++) 
		{
			if(udaljenostSvihPolja[i]>0)//prolazi se kroz svaku vrijednost udaljenostSvihPolja i provjerava se da li se nalazi ista pored neprijatelja
			{
				svaPuna=false;//ukoliko pored nije zid, sva puna se postavlja na false i dodaje se index udaljenostiSvihPolja
				listaIdeova.Add(i);

			}
		}



		if(svaPuna)//u slucaju da se sa sve 4 strane nalazi zid ili bombe, ne izvrsava se dalje funkcija
			return;


		smjer = getRandom(listaIdeova);//odvdje se dobija random smjer u kojem ce se kretati neprijatelj

		if (smjer==0) {//ukoliko je smjer 0, kretat ce se lijevo
			udaljenost = provjeriUdaljenost (transform.right);
			if (udaljenost > 0) {
				transform.Translate (new Vector3 (1, 0, 0));
					mozeSeKretati=true;
			}
		}
			if (smjer==1) {//ukoliko je smjer 1, kretat ce se desno
			udaljenost = provjeriUdaljenost (-transform.right);
			if (udaljenost > 0) {
				transform.Translate (new Vector3 (-1, 0, 0));
					mozeSeKretati=true;
			}
		}
			if (smjer==2) {//ukoliko je smjer 2, kretat ce se naprijed
			udaljenost = provjeriUdaljenost (-transform.forward);
			if (udaljenost > 0) {
				transform.Translate (new Vector3 (0, 0, -1));
					mozeSeKretati=true;
				}
		}
			if (smjer==3) {//ukoliko je smjer 3, kretat ce se nazad
			udaljenost = provjeriUdaljenost (transform.forward);
			if (udaljenost > 0) {
				transform.Translate (new Vector3 (0, 0, 1));
					mozeSeKretati=true;
				}
		}

		}
	
	}

	int[] getPraznaPolja ()
	{
		int[] udaljenost = new int[4];//puni se udaljenost u svim smjerovima od neprijatelja
	
		udaljenost[0] = provjeriUdaljenost (transform.right);
		udaljenost[1] = provjeriUdaljenost (-transform.right);
		udaljenost[2] = provjeriUdaljenost (-transform.forward);
		udaljenost[3] = provjeriUdaljenost (transform.forward);
	
		return udaljenost;

	}

	int provjeriUdaljenost (Vector3 smijer)
	{
		Ray ray;
		RaycastHit hit;
		int udaljenost = (int)Postavke.bombRange;
		ray = new Ray (transform.position, smijer);//gore
		if (Physics.Raycast (ray, out hit, Postavke.bombRange)) {
			if (hit.collider.tag == "Zid" || hit.collider.tag == "Kutija" || hit.collider.tag == "Bomba") {
				udaljenost = (int)hit.distance;
			}
		}
		return udaljenost;
	}

	int getRandom(System.Collections.Generic.List<int> range)
	{
		return range[Random.Range(0, range.Count)];
	}

	void OnTriggerEnter(Collider c)//provjerava da li je ovaj neprijatelj dirnuo igraca
	{
		if(c.tag == "Player")
		{
			Postavke.oduzmiZivot();//oduzima zivot igracu
		}
	}

	void OnDestroy()//funkcija se poziva prilikom unistavnja ovog objekta
	{
		if(tipNeprijatelja)
			Postavke.dodajBodove(100);
		else
			Postavke.dodajBodove(400);
		Postavke.preostaloNeprijatelja--;
	}
}

using UnityEngine;
using System.Collections;

public class PostavljanjeResursa : MonoBehaviour {

	public int brojBunusa;
	public GameObject[] bonusi;
	public GameObject kljuc;
	public GameObject vrata;


	void Start () {
		Postavke.postaviSlijedeciNivo();
		GameObject[] listaZidova = GameObject.FindGameObjectsWithTag("Kutija");
		int velicinaListeZidova = listaZidova.GetLength(0);
		int velicinaListeBonusa = bonusi.GetLength(0);
		for(int i=0; i<brojBunusa; i++)
		{
			Instantiate (bonusi[getId(velicinaListeBonusa)], listaZidova[getId(velicinaListeZidova)].transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
		}

		//za kljuc
		Instantiate(kljuc, listaZidova[getId(velicinaListeZidova)].transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		//za vrata
		Instantiate(vrata, listaZidova[getId(velicinaListeZidova)].transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

		GameObject[] listaNeprijatelja = GameObject.FindGameObjectsWithTag("Enemy");

		Postavke.preostaloNeprijatelja = listaNeprijatelja.Length;
		Debug.Log(Postavke.preostaloNeprijatelja);
	}


	int getId(int range)
	{
		int id = Random.Range(0, range);
		if(id==range)
			return range-1;
		return id;
	}
}

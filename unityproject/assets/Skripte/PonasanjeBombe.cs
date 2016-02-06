using UnityEngine;
using System.Collections;

public class PonasanjeBombe : MonoBehaviour {
	private float vrijemeIsteka;
	public GameObject vatra;
	public GameObject zvukBombe;
	// Use this for initialization
	void Start () {
		Postavke.trenutniBrojBombi++;
		vrijemeIsteka=Time.time + 3f;
		}
	
	void Update () {
		if(!Postavke.mozeAktivirati)
		{
			if(vrijemeIsteka<Time.time)
				{
					eksplodiraj();
				}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				eksplodiraj();
			}
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.tag=="Vatra")
		{
			eksplodiraj();
		}
	}

	void eksplodiraj ()
	{
		Instantiate(zvukBombe);
		int udaljenost;

		udaljenost = provjeriUdaljenost(transform.forward);
		for(int i=0; i<=udaljenost; i++)//za gore
		{
			Instantiate(vatra, new Vector3(transform.position.x, transform.position.y, transform.position.z-i), transform.rotation);
		}

		udaljenost = provjeriUdaljenost(-transform.forward);
		for(int i=0; i<=udaljenost; i++)//za dole
		{
			Instantiate(vatra, new Vector3(transform.position.x, transform.position.y, transform.position.z+i), transform.rotation);
		}

		udaljenost = provjeriUdaljenost(-transform.right);
		for(int i=0; i<=udaljenost; i++)//za lijevo
		{
			Instantiate(vatra, new Vector3(transform.position.x+i, transform.position.y, transform.position.z), transform.rotation);
		}

		udaljenost = provjeriUdaljenost(transform.right);
		for(int i=0; i<=udaljenost; i++)//za desno
		{
			Instantiate(vatra, new Vector3(transform.position.x-i, transform.position.y, transform.position.z), transform.rotation);
		}
		Postavke.trenutniBrojBombi--;
		Destroy(this.gameObject);
	}


	int provjeriUdaljenost(Vector3 smijer)
	{
		Ray ray;
		RaycastHit hit;
		int udaljenost = (int)Postavke.bombRange;
		ray = new Ray(transform.position, smijer);//gore
		if(Physics.Raycast(ray, out hit, Postavke.bombRange))
		{
			if(hit.collider.tag == "Zid")
			{
				udaljenost = (int)hit.distance;
			}
			if(hit.collider.tag == "Kutija")
			{
				udaljenost = (int)hit.distance;
				Destroy(hit.transform.gameObject);
			}
			
		}
		return udaljenost;
	}
}

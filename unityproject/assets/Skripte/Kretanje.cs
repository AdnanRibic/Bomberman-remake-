using UnityEngine;
using System.Collections;

public class Kretanje : MonoBehaviour
{

		public GameObject bomba;
		private bool bombaPostavljena=false;

		void Update ()
		{
		if(Postavke.kraj || Postavke.poginuo)
			return;
				int udaljenost = 0;
			


				if (Input.GetKeyDown (KeyCode.A)) {
						udaljenost = provjeriUdaljenost (transform.right);
						if (udaljenost > 0) {
								transform.Translate (new Vector3 (1, 0, 0));
								bombaPostavljena = false;
						}
				}
				if (Input.GetKeyDown (KeyCode.D)) {
						udaljenost = provjeriUdaljenost (-transform.right);
						if (udaljenost > 0) {
								transform.Translate (new Vector3 (-1, 0, 0));
								bombaPostavljena = false;
						}
				}
				if (Input.GetKeyDown (KeyCode.W)) {
						udaljenost = provjeriUdaljenost (-transform.forward);
						if (udaljenost > 0) {
								transform.Translate (new Vector3 (0, 0, -1));
								bombaPostavljena = false;
						}
				}
				if (Input.GetKeyDown (KeyCode.S)) {
						udaljenost = provjeriUdaljenost (transform.forward);
						if (udaljenost > 0) {
								transform.Translate (new Vector3 (0, 0, 1));
								bombaPostavljena = false;
						}
				}


				if (Input.GetKeyDown (KeyCode.Space)) {
						if (!bombaPostavljena)
						{
							if(Postavke.trenutniBrojBombi<Postavke.brojBombi)
								{
									Instantiate (bomba, this.transform.position, this.transform.rotation);
									bombaPostavljena = true;
								}
						}
				}
		
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
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Bombers : MonoBehaviour {


	public float vitesse ; 
	public GameObject roiArthur;
	public int degat;
	public bool damages;

	Renderer rend;

	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		degat = 50;
		roiArthur = GameObject.Find ("Arthur");
		vitesse = 0.08f; 
		damages = false;
	}
	
	// Update is called once per frame
	void Update () {

		int wait = 0;
		RaycastHit hit, hitr, hitl;
		float distance, distancer, distancel;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			distance = hit.distance; 
			
			if(distance<7)
			{
				//calcul de la distance gauche
				Physics.Raycast (transform.position, -transform.right, out hitl);
				distancel = hitl.distance;

				//calcul de la distance droite
				Physics.Raycast (transform.position, transform.right, out hitr); 
				distancer = hitr.distance;
				
				if(distancel < distancer) 
				{
					transform.Rotate(transform.up);
					transform.Rotate(transform.up);
					transform.Rotate(transform.up);
				}
				else
				{
					transform.Rotate(-transform.up);
					transform.Rotate(-transform.up);
					transform.Rotate(-transform.up);
				}
			}
		}

		//si on est trop près du mur on se décale
		if (Physics.Raycast (transform.position, transform.right, out hit)) {
			distance = hit.distance ; 
			if(distance < 2)
				transform.Rotate(-transform.up);
			
		}
		if (Physics.Raycast (transform.position, -transform.right, out hit)) {
			distance = hit.distance ; 
			if(distance < 2)
				transform.Rotate(transform.up);
			
		}

		//si Arthur est dans un rayon <=10 le bomber court
		if (Vector3.Distance (transform.position, roiArthur.transform.position) <= 10) {
			
			vitesse *= 2;
			transform.LookAt (roiArthur.transform.position);

		} else{
			
			transform.position += transform.forward*vitesse;

		}

		//si arthur est proche le bomber explose et inflige des dégats
		if ((Vector3.Distance (transform.position, roiArthur.transform.position) <= 2) && damages==false) {
			wait++;
			vitesse*=2;
			(transform.gameObject.GetComponent("Detonator") as Behaviour).enabled = true;
			roiArthur.GetComponent<Myhealthbar>().SetDamages(0.25f);
			damages=true;
			rend.enabled=false;


		}
	}
}


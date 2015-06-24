using UnityEngine;
using System.Collections;

public class Bombers : MonoBehaviour {


	public float vitesse ; 
	public GameObject roiArthur;
	public int degat;

	Renderer rend;

	// Pour l'instant, on suppose que le villageois (personnage) est présent dans la map, on va y attacher ce script de comportement
	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		degat = 50;
		roiArthur = GameObject.Find ("Arthur");
		vitesse = 0.08f; 
	}
	
	// Update is called once per frame
	void Update () {

		int wait = 0;
		RaycastHit hit, hitr, hitl;
		float distance, distancer, distancel;
//		print (roiArthur.transform.GetComponent ("Arthur"));

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

		//si Arthur est dans un rayon <=10
		if (Vector3.Distance (transform.position, roiArthur.transform.position) <= 10) {
			
			vitesse *= 2;
			transform.LookAt (roiArthur.transform.position);

		} else{
			
			transform.position += transform.forward*vitesse;
			
		}

		//si arthur est proche le bomber explose
		if (Vector3.Distance (transform.position, roiArthur.transform.position) <= 2) {
			wait++;
			vitesse*=2;
			(transform.gameObject.GetComponent("Detonator") as Behaviour).enabled = true;
			//on attend un peu avant l'explosion
			if(wait == 10){ 
				wait=0;
				//Destroy(transform.gameObject);
				//cache la boule
				rend.enabled=false;

			}
		}
	}
}


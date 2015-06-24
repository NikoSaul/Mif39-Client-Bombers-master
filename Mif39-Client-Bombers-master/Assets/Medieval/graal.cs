using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class graal : MonoBehaviour {

	public Text t ; 
	GameObject roiArthur;
	// Use this for initialization
	void Start () {
		t.enabled = false; 
		roiArthur = GameObject.Find ("Arthur");
	}

	void OnCollisionEnter(Collision collision)
	{
		if (Vector3.Distance (collision.transform.position, roiArthur.transform.position) <= 10) {
			Debug.Log (" Arthure GAGNE ! ");
			t.enabled = true ;  
		}
		t.enabled = false; 

	}

	
	// Update is called once per frame
	void Update () {

		/*if (Vector3.Distance (transform.position, roiArthur.transform.position) <= 10)&& vu<60  ) {
			
			if(vu==0){
				transform.LookAt(roiArthur.transform.position);
				print ( transform.gameObject.name + " dit: Hey Arthur !!!");
			}
			vu ++;
		} else if (connaissance) {
			transform.position += transform.forward*vitesse*Time.deltaTime ;
		} 
		else
		{
			transform.position += transform.forward*vitesse*Time.deltaTime ;
		}	
	*/
	}
}

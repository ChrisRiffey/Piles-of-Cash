using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject warpPoint;
	//public GameObject ball;
	private Transform startMarker;
	private Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	private bool warping = false;
	//private Vector3 offset = new Vector3(0.001f,0.001f,0.001f);
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Ray ray;
			RaycastHit hit;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				if ((hit.collider.name == "Floor") && (warping == false))
					{
					startTime = Time.time;
					warpPoint = Instantiate (warpPoint, hit.point, Quaternion.identity); Debug.Log("warpPoint is at " + warpPoint.transform.position.ToString());
					warping = true; Debug.Log("Warping is true");
					startMarker = gameObject.transform;
					endMarker = warpPoint.transform;
					journeyLength = Vector3.Distance (startMarker.position, endMarker.position);

					} 


			}
		}

		if (warping == true) 
		{	
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength; Debug.Log("fracJourney is " + fracJourney);
			transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);
			if (fracJourney == 1) 
			{ 
				warping = false; Debug.Log("Warping is false");
				Destroy (warpPoint);
			}
		}	
	}

}

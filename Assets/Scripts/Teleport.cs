using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	//public GameObject warpPoint;
	Vector3 warpTarget;
	private GameObject warpMarker;
	private Transform startMarker;
	private Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	private bool warping = false;
	private float distCovered;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Ray ray;
			RaycastHit hit;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				if ((hit.collider.tag == "floor") && (warping == false))
					{
					startTime = Time.time;
					warpTarget = hit.point + new Vector3 (0, 2f, 0);
					//warpMarker = Instantiate (warpPoint, hit.point + new Vector3(0,2f,0), Quaternion.identity); Debug.Log("warpPoint is at " + warpPoint.transform.position.ToString());
					warping = true; Debug.Log("Warping is true");
					startMarker = gameObject.transform;
					//endMarker = warpMarker.transform;
					journeyLength = Vector3.Distance (startMarker.position, warpTarget);
					} 
			}
		}

		if (warping == true) 
		{	
			
			//float distCovered = (Time.time - startTime) * speed;
			distCovered += Time.deltaTime * speed;
			//float distCovered = speed * Time.deltaTime;
			float fracJourney = distCovered / journeyLength; //Debug.Log("distCovered:"+distCovered+" - journeyLength:"+journeyLength+" - fracJourney:"+fracJourney+" - time:"+Time.time+" - startTime:"+startTime);
			transform.position = Vector3.Lerp (startMarker.position, warpTarget, fracJourney);
			if (Vector3.Distance(transform.position, warpTarget) <= 0.1f) 
			{ 
				warping = false; Debug.Log("Warping is false");
				//Destroy (warpPoint);
				distCovered = 0.0f;
				warpTarget = Vector3.zero;
			}
		}	
	}

}

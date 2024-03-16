using UnityEngine;
using System.Collections;

public class PickObjects : MonoBehaviour {

	Transform pickObj = null;
	RaycastHit hit;
	float dist;
	Vector3 newPos;
	Vector3 offset;

	void Update(){
		
		if (Input.GetMouseButton(0)){ 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction*10, Color.green);
			if (!pickObj){
				if (Physics.Raycast(ray, out hit)&& hit.transform.tag == "Pickable"){
					pickObj = hit.transform; 
					pickObj.GetComponent<Rigidbody>().isKinematic = true;
					dist = hit.distance;
					offset = pickObj.position - hit.point;
				}
			}
			else {
				//newPos = ray.GetPoint(dist);
				newPos = ray.GetPoint(dist) + offset;
				pickObj.position = newPos;
			}    
		}
		else {
			if (pickObj != null) {
			pickObj.GetComponent<Rigidbody>().isKinematic = false;
			Vector3 throwDir = Camera.main.transform.TransformDirection(Vector3.forward);
			pickObj.GetComponent<Rigidbody>().AddForce(throwDir*50, ForceMode.Impulse);
				}
			pickObj = null;
		}
	}
}
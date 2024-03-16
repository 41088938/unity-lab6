using UnityEngine;
using System.Collections;

public class HitObjects : MonoBehaviour {

	void Update () { 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction);

		RaycastHit hit;
		if (Input.GetButtonDown("Fire1")) { 
			Debug.Log("1b testing...");
			if (Physics.Raycast(ray, out hit)) { 
				if (hit.rigidbody)
					Debug.Log("sth has rigidbody component...");
					hit.rigidbody.AddForce(ray.direction*10, ForceMode.Impulse);
			}
	}

}
}


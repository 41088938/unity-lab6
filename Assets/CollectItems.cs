using UnityEngine;
using System.Collections;

public class CollectItems : MonoBehaviour {

	public AudioClip coinSound;

	void OnTriggerEnter(Collider col) {
		if(col.tag == "Coin") {
			Destroy(col.gameObject);
			AudioSource.PlayClipAtPoint(coinSound, transform.position);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		// being inside game bounds doesn't count
		if (other.CompareTag("Boundary"))
		{
			return;
		}
            Destroy(other.gameObject);
            Destroy(gameObject);
	}
}

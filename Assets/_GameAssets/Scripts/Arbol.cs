using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour {

    AudioSource explosion;
	// Use this for initialization
	void Start () {
        explosion = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("TriggerEnter");
        explosion.Play();
        Invoke("DestruirObjeto" ,1);

    }

    private void DestruirObjeto()
    {
        Destroy(this.gameObject);
    }
}

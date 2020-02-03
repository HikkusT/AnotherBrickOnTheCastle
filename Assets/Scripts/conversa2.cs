using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conversa2 : MonoBehaviour
{
    // Start is called before the first frame update
	private bool aux;
	public GameObject aaaa;
	
    void Start()
    {
        aux = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && aux){
		
			GetComponent<Renderer>().enabled = false;
			aaaa.GetComponent<Renderer>().enabled = true;
			aux = false;
			
		} else if (Input.GetKeyDown("space") && !aux){
			
			GetComponent<Renderer>().enabled = true;
			aaaa.GetComponent<Renderer>().enabled = false;
			aux = true;
			
		}
    }
}

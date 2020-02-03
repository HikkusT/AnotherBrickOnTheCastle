using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conversa : MonoBehaviour
{
    // Start is called before the first frame update
	private bool aux;
	
    void Start()
    {
        aux = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && aux){
		
			gameObject.SetActive(false);
			aux = false;
			
		} else if (Input.GetKeyDown("space") && !aux){
			
			gameObject.SetActive(true);
			aux = true;
			
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour{
	
	public GameObject tiro; 
	private bool atirar;
	
    void Start(){
		
		atirar = true;
		
	}

    // Update is called once per frame
    void Update(){
		
		if (atirar){
			
			StartCoroutine(Esperador());
			atirar = false;
			
		}
		
    }
	
	IEnumerator Esperador(){
        
		//yield on a new YieldInstruction that waits for n seconds.
        yield return new WaitForSeconds(1.1f);
        Instantiate(tiro, transform.position, transform.rotation);
		
    }
}

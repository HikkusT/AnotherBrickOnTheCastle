using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
	public GameObject hit; 
	public float speed;
    // Start is called before the first frame update
	
    void Start(){
		
		Instantiate(hit, transform.position, transform.rotation);
        Destroy(this.gameObject, speed);
		
    }
	
}

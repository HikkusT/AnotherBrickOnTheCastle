using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour{
	
    public float time;
	
    void Start(){
		
		transform.position = new Vector2(-0.84f, -1.93f);		//posicao inicial
        Destroy(this.gameObject, time);
		
    }

}

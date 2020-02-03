using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buff : MonoBehaviour
{
	public float speed;
    
    void Start(){
		
		//por dentro do canvas pra funcionar
        //transform.position = new Vector2(-121f, 3.35f);
        Destroy(this.gameObject, speed);
    }
}

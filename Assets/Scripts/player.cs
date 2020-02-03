using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour{
	private Rigidbody2D rb;
	private Vector2 velocity;
	public GameObject explosion; 
	
    void Start(){    
	
		transform.position = new Vector2(11f, -1.8f);		//posicao inicial do player
		rb = gameObject.GetComponent<Rigidbody2D>();
		velocity = new Vector2(-7.5f,0.0f);					//velocidade inicial do player
	
	}
	
	void OnTriggerEnter2D (Collider2D outro){
	
		if (outro.gameObject.tag == "castelo_Tag"){
		
			velocity = new Vector2(0f, 0f);										//velocidade do player apos colidir
			Instantiate(explosion, transform.position, transform.rotation);		//chama explosao
			Destroy(this.gameObject);
		
		}
		
	}

    void Update(){
		
		rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		
    }
	
}

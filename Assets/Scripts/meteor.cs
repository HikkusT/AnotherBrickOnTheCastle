using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour{
    
	public float force;
	private Rigidbody2D rb;
	public GameObject explosion;
	
    void Start(){
		
		transform.position = new Vector2(3.5f, 6f);				//posicao inicial
		transform.rotation = Quaternion.Euler(0f, 0f, -35f);	//rotacao inicial
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(-1f,-1f)*force);				//direcao da forca a ser aplicada
    
	}

	void OnTriggerEnter2D (Collider2D outro){
	
		if (outro.gameObject.tag == "castelo_Tag"){
		
			Instantiate(explosion, transform.position, Quaternion.Euler(0f, 0f, 0f));		//chama explosao
			Destroy(this.gameObject);
		
		}
		
	}
	
}

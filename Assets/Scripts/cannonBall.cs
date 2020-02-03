using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour{
	
    public float time;
	public float force;
	private Rigidbody2D rb;
	public GameObject explosion;
	public GameObject large_attack;
	
    void Start(){
		
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(-1f,1f) * force);
        Destroy(this.gameObject, time);
    
	}

	void OnTriggerEnter2D (Collider2D outro){
	
		if (outro.gameObject.tag == "castelo_Tag"){
		
			Instantiate(explosion, transform.position, transform.rotation);
			Instantiate(large_attack, transform.position, transform.rotation);
			Destroy(this.gameObject);
		
		}
		
	}
	
}

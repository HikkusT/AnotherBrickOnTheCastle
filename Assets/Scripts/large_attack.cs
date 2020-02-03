using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class large_attack : MonoBehaviour{
	
	private Rigidbody2D rb;
	private Vector2 velocity;
	public GameObject meteor;
	private bool atira;
	private float local_paradaX, atraso_meteoro;
    
    void Start(){
		
		transform.position = new Vector2(9.5f, 0.9f);		//posicao inicial fora da tela
		velocity = new Vector2(-2.5f,0.0f);					//velocidade com que entra na tela
		rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 6.1f);						//destroi instancia apos tempo n
		atira = true;										//chamada de meteoro
		local_paradaX = 4.76f;
		atraso_meteoro = 2.3f;
		
    }

    // Update is called once per frame
    void Update(){
		
		if (transform.position.x > local_paradaX){		
			
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);		//move personagem
			
		} else if (atira) {
			
			StartCoroutine(desEsperador());
			atira = false;
			
		}
    }
	
	IEnumerator desEsperador(){
		
        yield return new WaitForSeconds(atraso_meteoro);					//aguarda tempo n
        Instantiate(meteor, transform.position, transform.rotation);		//chama meteoro
		
    }
	
}

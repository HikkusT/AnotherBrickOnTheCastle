using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_castelo : MonoBehaviour {

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.002f;		
	public float shake_intensity = .1f;		//intensidade do choque(interface)

	private float temp_shake_intensity = 5;		//tempo em que o castelo fica exposto/treme
	
	void Start (){
		transform.position = new Vector2(-4.8f, 0.2f);		//posicao do castelo na tela
		var casteloRenderer = GetComponent<Renderer>();
		casteloRenderer.material.SetColor("_Color", Color.red);
		Shake();
		Destroy(this.gameObject, temp_shake_intensity);
	}
	
	void Update (){
		
		if (temp_shake_intensity > 0){
			
			transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.y + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.z + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.w + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;
			
		}
		
	}
	
	void Shake(){
		
		originPosition = transform.position;
		originRotation = transform.rotation;
		temp_shake_intensity = shake_intensity;

	}
}
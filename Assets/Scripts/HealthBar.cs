using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour{
	
	public Image _barra;
	
    private void Start(){
		
		_barra.fillAmount = 0.5f;
		
    }
	
}

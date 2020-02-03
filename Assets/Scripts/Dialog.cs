using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
	public TextMeshProUGUI textDisplay;
	public string[] sentences;
	private int index;
	public float typingSpeed, posX, posY;
	//public GameObject next_sentence, dialogue_box; 
	
	void Start(){
		
		transform.position = new Vector2(posX, posY);
		//dialogue_box.SetActive(true);
		//Instantiate(dialogue_box, transform.position, transform.rotation);
		StartCoroutine(Type());
		
	}
	
	void Update(){
		
		if (textDisplay.text == sentences[index] && Input.GetKeyDown("space")){
			
			//Instantiate(next_sentence, transform.position, transform.rotation);
			//Destroy(dialogue_box);
			//dialogue_box.SetActive(false);
			NextSentence();
		
		}
		
    }
	
	IEnumerator Type(){
		
		foreach(char letter in sentences[index].ToCharArray()){
			
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
			
		}
		
	}
	
	public void NextSentence(){
	
		if(index < sentences.Length - 1){
			
			index++;
			textDisplay.text = "";
			StartCoroutine(Type());
		
		} else {
			
			textDisplay.text = "";
            //da pra por aqui trigger pra prox evento
            SceneManager.LoadScene("MiniGame");
		}
	
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
	public bool forceDirection;
	public char mustFace;
	private char isFacing;
	public AudioSource interactSound;

	public bool interactionPause = false;


	private Text textBox;
	public string message;
	private TextWriter.TextWriterSingle textWriterSingle;

	private GameObject Player;
	private CharacterController pScript;
	

	void Start()
	{
		Player = GameObject.Find("Player");
		textBox = GameObject.Find("Text").GetComponent<Text>();
		pScript = Player.GetComponent<CharacterController>();
        
	}
	void Update()
	{   //Debug.Log("Facing Called: ");
		isFacing = CharacterController.getFacing();
	}

	void OnTriggerStay(Collider other)
    {
    	if(interactionPause == false) {

	    	if(forceDirection == true) {
	    		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && isFacing == mustFace) {
	    			interactSound.Play();
	    			TextAppear(message);
	    			//interactionPause= true;
    				//pScript.pause_flag = true;
	    		}
	   		}
	   		else {
	   			if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
	    			interactSound.Play();
	    			TextAppear(message);
	    			//interactionPause= true;
    				//pScript.pause_flag = true;
	    		}
	   		}
   		}
   		interactionPause = false;
 	}

 	void TextAppear(string m)
 	{
 		if(textWriterSingle != null && textWriterSingle.IsActive()) {
 			//Currently active TextWriter
 			//textWriterSingle.WriteAllAndDestroy();
 			textWriterSingle = TextWriter.AddWriter_Static(textBox, m, 0.05f, true, true);
 		} 
 		else {
 			textWriterSingle = TextWriter.AddWriter_Static(textBox, m, 0.05f, true, true);
 		}
 		
 		
 	}
}

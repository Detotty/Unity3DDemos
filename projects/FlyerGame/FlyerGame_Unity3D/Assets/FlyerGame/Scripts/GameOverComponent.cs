/**
 * Copyright (C) 2005-2012 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class GameOverComponent : MonoBehaviour {

	//--------------------------------------
	//  Properties
	//--------------------------------------
	AudioSource loseGameSound;
	AudioSource winGameSound;
	public bool isGameOver;
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		

	// Use this for initialization
	void Start () {
		
		loseGameSound 	= (GetComponents(typeof(AudioSource) )[0] as AudioSource);
		winGameSound 	= (GetComponents(typeof(AudioSource) )[1] as AudioSource);
		isGameOver = false;
		setScore (0);
	}
	
	// Update is called once per frame
	void Update () {
		
		var y = transform.position.y;

		if (y > 90 && !isGameOver) {
			doEndGameWithWin();
		} 
		
	}

	
	//OUTPUT A VICTORY MESSAGE AND 'STOP' THE GAME
	void doEndGameWithWin() {
		
		//MESSAGE
		Debug.Log("You Won the Game!");
			
		//SET SCORE
		setScore (100);
		
		//PLAY SOUND
		winGameSound.Play();
		
		
		//END GAME, STOP LISTENTING TO EVENTS
		doStopGame();
	
	}
	
	//OUTPUT A FAILURE MESSAGE AND 'STOP' THE GAME
	void doEndGameWithLoss() {
		
		//MESSAGE
		Debug.Log("You Lost the Game!");
		
		//SET SCORE
		setScore (-100);
		
		//PLAY SOUND
		loseGameSound.Play();
		
		//END GAME
		doStopGame();
	
	}
	
	public void setScore (float score)
	{
		TextMesh scoreText = GameObject.FindObjectOfType (typeof (TextMesh) ) as TextMesh;
		scoreText.text = "Score : " + score;
		
	}
	
	
	//THIS TRIGGERS ONLY ONE TIME ON THE FIRST OBJECT THE FLYER HITS - THAT'S OK FOR THIS GAME. BUT WHY IS THAT?
	public void OnTriggerEnter(Collider c)
	{
		//Debug.Log("OnTriggerEnter!");
		doEndGameWithLoss();
		
	}
	
	
	//THIS NEVER TRIGGERS - THAT'S OK. BUT WHY IS THAT?
	public void OnCollisionEnter(Collision c)
	{
		Debug.Log("OnCollisionEnter!");
		
	}


	//STOP THE GAME
	void doStopGame () {
		
		isGameOver = true;
		
		//END GAME - quick solution. 
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
		}
		

	}
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}

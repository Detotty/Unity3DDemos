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
public class MoveByKeyboardInputComponent : SuperMonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	float direction_float;
	private GameManagerComponent gameManagerComponent;
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		direction_float = 1;
		//
		GameObject gameManagerGameObject = GameObject.Find("GameManagerGameObject");
		gameManagerComponent = gameManagerGameObject.GetComponent<GameManagerComponent>();
			
	}
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		if (!isPaused) {
			
			float x_float = transform.position.x;
			float y_float = transform.position.y;
			
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				y_float += GameConstants.SPEED_FLYER;
				doMoveTheFlyer();
			} else 	if (Input.GetKeyUp (KeyCode.DownArrow)) {
				y_float -= GameConstants.SPEED_FLYER;
				doMoveTheFlyer();
			}
			
			
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				x_float += GameConstants.SPEED_FLYER;
				doMoveTheFlyer();
			} else 	if (Input.GetKeyUp (KeyCode.RightArrow)) {
				x_float -= GameConstants.SPEED_FLYER;
				doMoveTheFlyer();
			}
			
			transform.position = new Vector3 ( 
				x_float, 
				y_float, 
				transform.position.z
			);
			
		}
	
	}

	///<summary>
	///	Use this for initialization
	///</summary>
	void doMoveTheFlyer () 
	{
		
		SoundManagerComponent.PlayAudioClip  (SoundManagerComponent.AUDIO_CLIP_MOVE_FLYER_SOUND);
		
		//ROTATE WITH EACH MOVEMENT, ALTERNATE BETWEEN 2 SPECIFIC ANGLES
		if (direction_float == 1) {
			direction_float = 0;
			transform.eulerAngles = new Vector3 (
				0, 
				gameObject.transform.eulerAngles.y, 
				gameObject.transform.eulerAngles.z
			);
			
		} else {
			direction_float = 1;
			transform.eulerAngles = new Vector3 (
				45, 
				gameObject.transform.eulerAngles.y, 
				gameObject.transform.eulerAngles.z
			);
			
		}
		
		//CHECK FOR VICTORY
		if (transform.position.y > GameConstants.APP_Y_FLYER_VICTORY) {
			gameManagerComponent.doEndGameWithWin();
		} 
	
		
	}
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}

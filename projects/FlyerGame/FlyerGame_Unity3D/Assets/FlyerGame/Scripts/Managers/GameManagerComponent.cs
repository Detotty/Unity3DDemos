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
public class GameManagerComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	public bool isGameOver;

	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		isGameOver = false;
		GUIManagerComponent.SetScore(0);
	}
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{

		
	}

	///<summary>
	///	Output a victory message and stop the game
	///</summary>
	public void doEndGameWithWin() 
	{
		
		//MESSAGE
		Debug.Log("You Won the Game!");
			
		//SET SCORE
		GUIManagerComponent.SetScore(100);
		
		//PLAY SOUND
		SoundManagerComponent.PlayAudioClip (SoundManagerComponent.AUDIO_CLIP_WIN_GAME_SOUND);
		
		//END GAME, STOP LISTENTING TO EVENTS
		doStopGame();
	
	}
	
	///<summary>
	///	Output failure message and stop the game
	///</summary>
	public void doEndGameWithLoss() 
	{
		
		//MESSAGE
		Debug.Log("You Lost the Game!");
		
		//SET SCORE
		GUIManagerComponent.SetScore(-100);
		
		//PLAY SOUND
		SoundManagerComponent.PlayAudioClip (SoundManagerComponent.AUDIO_CLIP_LOSE_GAME_SOUND);
		
		//END GAME
		doStopGame();
	
	}

	///<summary>
	///	Stop the game.
	///</summary>
	void doStopGame () 
	{
		
		isGameOver = true;
		
		//END GAME - quick solution. 
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("onPauseGame", SendMessageOptions.DontRequireReceiver);
		}
		

	}
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}

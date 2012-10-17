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
public class GUIManagerComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	private static TextMesh scoreText;
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		//GET SCORE
		GameObject scoreTextGameObject = GameObject.Find("ScoreText");
		scoreText = scoreTextGameObject.GetComponent<TextMesh>();
		
		//SET SCORE
		SetScore (0);
		
		//CREATE RESET BUTTON
		
		
	}
	
	///<summary>
	///	Define this...
	///</summary>
    void OnGUI() 
	{

        if (GUI.Button(new Rect(GameConstants.APP_X + 175, GameConstants.APP_Y + 45, 120, 20), GameConstants.TEXT_RESET_BUTTON)) {
            
			//RESET THE CURRENT LEVEL
			Application.LoadLevel(Application.loadedLevel); 
		}
        
    }
	
	///<summary>
	///	Define this...
	///</summary>
	public static void SetScore (float score)
	{
		if (scoreText) {
			scoreText.text = "Score : " + score;
		}
	}
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}

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
public class QuitButtonComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	GameManagerComponent gameManagerComponent;
	public GUIText guiText2;
	public Texture2D upTexture2D;
	public Texture2D overTexture2D;
	public Texture2D downTexture2D;

	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//SETUP
		gameManagerComponent = GetComponent<GameManagerComponent>();
		
				
		guiTexture.texture = overTexture2D;
		
		//guiText2 = Instantiate (new GUIText()) as GUIText;
		//guiText2.text = "Press!";
		//guiText2.transform.position = gameObject.transform.position;

	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		
	}



	
	//--------------------------------------
	//  Events
	//--------------------------------------
	///<summary>
	///	UPON CLICK: add cube
	///</summary>
	public void OnGui () 
	{
				
		Debug.Log("gggggg");
		
	}
	
	
	///<summary>
	///	UPON CLICK: add cube
	///</summary>
	public void OnMouseEnter () 
	{
				
		Debug.Log("OnMouseEnter()" + this);
		guiTexture.texture = overTexture2D;
		
	}
	
	
	public void OnMouseExit () 
	{
				
		Debug.Log("OnMouseExit()");
		guiTexture.texture = upTexture2D;
		
	}
	
	public void OnMouseDown () 
	{
			
		Debug.Log("OnMouseDown()");
		guiTexture.texture = downTexture2D;
		//gameManagerComponent.doQuitApplication();
		
	}
	
	public void OnMouseUp () 
	{
		guiTexture.texture = upTexture2D;
	}
}

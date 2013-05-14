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
	GUIManagerComponent guiManagerComponent;
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//SETUP
		guiManagerComponent = GetComponent<GUIManagerComponent>();
		
		//CREATE THE FIRST CUBE
		doAddNewCube();
		

	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		
	}
	
	///<summary>
	///	UPON CLICK: reset all cubes
	///</summary>
	public void doResetAllCubes () 
	{
		//UPDATE THE COUNT
		GameObject[] cubePrefabs = GameObject.FindGameObjectsWithTag ("CubePrefab");
		
		//DESTROY
		foreach(GameObject cubePrefab in cubePrefabs) {
			DestroyObject (cubePrefab);
		}
		
	}
	
	///<summary>
	///	UPON CLICK: add cube
	///</summary>
	public void doAddNewCube () 
	{
		//CREATE A NEW CUBE
		GameObject instance = Instantiate(Resources.Load("Prefabs/CubePrefab"), new Vector3 (.5f, 7.8f, .20f), Quaternion.identity) as GameObject;
		
		
		//UPDATE THE COUNT
		GameObject[] cubePrefabs = GameObject.FindGameObjectsWithTag ("CubePrefab");
		int totalCubes_int = cubePrefabs.Length;
		
		//UPDATE THE NAME (OPTIONAL)
		instance.name = "CubePrefab_" + totalCubes_int;
		
		//Debug.Log("cubePrefabs: " + totalCubes_int);
		
		//UPDATE GUI
		guiManagerComponent.setScore (totalCubes_int);
		
		//PLAY SOUND
		SoundManagerComponent.PlayAudioClip (SoundManagerComponent.AUDIO_CLIP_MOVE_FLYER_SOUND);
		
	}

	///<summary>
	///	UPON CLICK: quit application
	///</summary>
	public void doQuitApplication () 
	{
		//Application.Quit();
	}
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}

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
public class MouseDragAndDropComponent : SuperMonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	private bool _isDragging_boolean = false;
	private GameManagerComponent _gameManagerComponent;
	private Vector3 _mouseOffset_vector3;

	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{

		GameObject gameManagerGameObject = GameObject.Find("GameManagerGameObject");
		_gameManagerComponent = gameManagerGameObject.GetComponent<GameManagerComponent>();
	}
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		if (!isPaused) {
			
			if (_isDragging_boolean) {
				//TODO, SET THE DRAGGED SPRITE TO THE MOUSE COORDINATES (CURRENTLY FAKING THE NUMBERS)
				transform.position = _getCurrentMousePositionVector3() + _mouseOffset_vector3;
			}
			
		}

	
	}
	
	///<summary>
	///	Start Drag
	///</summary>
	private void _doStartDrag () 
	{
		if (!_isDragging_boolean) {
			_isDragging_boolean = true;
			_mouseOffset_vector3 = transform.position - _getCurrentMousePositionVector3();
			MoveToWaypointComponent moveToWaypointComponent = gameObject.GetComponent<MoveToWaypointComponent>();
			Destroy (moveToWaypointComponent);
		}
		
	}
	
	///<summary>
	///	Stop Drag
	///</summary>
	private void _doStopDrag () 
	{
		if (_isDragging_boolean) {
			_isDragging_boolean = false;
			gameObject.AddComponent ("MoveToWaypointComponent");
			
			_gameManagerComponent.doStartAnyDateBetweenRabbits(gameObject);
		}
	}
		
	
	///<summary>
	///	Stop Drag
	///</summary>
	private Vector3 _getCurrentMousePositionVector3 () 
	{
		return Input.mousePosition/8; //TODO, FIX THIS FUDGED MATH
		
	}
		
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	///<summary>
	///	When Mouse Down
	///</summary>
	void OnMouseDown () 
	{
		_doStartDrag();
	}
	
	///<summary>
	///	When Mouse Up
	///</summary>
	void OnMouseUp () 
	{
		
		_doStopDrag();
	}
	
	
}

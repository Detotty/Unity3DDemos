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
public class MoveToWaypointComponent : SuperMonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	public Vector3 lastWaypoint_vector3;
	public Vector3 nextWaypoint_vector3;
	private float journeyLength;
	private GameManagerComponent gameManagerComponent;
		
	        
    // Movement speed in units/sec.
    float speed = 20.0f;
	
    // Time when the movement started.
    private float startTime;
    
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () {
	
		//TODO, figure out how to call 'super.Start' so that I can set manager instances for every subclass easily
		
		GameObject gameManagerGameObject = GameObject.Find("GameManagerGameObject");
		gameManagerComponent = gameManagerGameObject.GetComponent<GameManagerComponent>();
		
		_doPickNewWayPoint();
	
	}
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () {
		
		if (!isPaused) {
			
			
				 // Distance moved = time * speed.
		        float distCovered = (Time.time - startTime) * speed;
		        
		        // Fraction of journey completed = current distance divided by total distance.
		        float fracJourney = distCovered / journeyLength;
				
				//Debug.Log("fracJourney: "  + fracJourney);
		        
		        // Set our position as a fraction of the distance between the markers.
		        transform.position = Vector3.Lerp(lastWaypoint_vector3, nextWaypoint_vector3, fracJourney);
				if (fracJourney > 1) {
					_doPickNewWayPoint();
				}
					
			
		}

	
	}
	
		///<summary>
	///	Called once per frame
	///</summary>
	void _doPickNewWayPoint () {
		
		// Keep a note of the time the movement started.
        startTime = Time.time;
		
		

		nextWaypoint_vector3 = gameManagerComponent.getValidPositionForObjectOfScale();
		lastWaypoint_vector3 = transform.position;
		journeyLength = Vector3.Distance(lastWaypoint_vector3, nextWaypoint_vector3); 
		
	}
		
	//--------------------------------------
	//  Events
	//--------------------------------------
}

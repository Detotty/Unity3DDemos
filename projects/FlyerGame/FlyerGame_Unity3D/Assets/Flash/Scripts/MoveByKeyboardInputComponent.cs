/*
/***************************************************************************************************
 * Copyright (C) 2007 - 2010  : Rivello Multimedia Consulting
 * For more information email : presentations2010@RivelloMultimediaConsulting.com
 * For more information see   : http://www.RivelloMultimediaConsulting.com
 * 
 * This file and/or its constituents are licensed under the terms of the MIT license, 
 * which is included in the License.html file at the root directory of this SDK.
 ***************************************************************************************************/

//Marks the right margin of code *******************************************************************

//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class MoveByKeyboardInputComponent : MonoBehaviour {

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		float x_float = transform.position.x;
		float y_float = transform.position.y;
		float movementRadius_float = 10;
		
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			y_float += movementRadius_float;
		} else 	if (Input.GetKeyUp (KeyCode.DownArrow)) {
			y_float -= movementRadius_float;
		}
		
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			x_float += movementRadius_float;
		} else 	if (Input.GetKeyUp (KeyCode.RightArrow)) {
			x_float -= movementRadius_float;
		}
		

		transform.position = new Vector3 ( 
			x_float, 
			y_float, 
			transform.position.z
		);
	
	}
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}

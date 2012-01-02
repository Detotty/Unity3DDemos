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
public class ScreenWrapComponent : MonoBehaviour {

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
		
		var x = transform.position.x;
		
				
		if (x > 100) {
			x = 0;
		} else if (x < 0) {
			x = 100;
		}
		
		transform.position = new Vector3 ( 
		
		x, 
		transform.position.y, 
		transform.position.z
		
		);

	
	}
	//--------------------------------------
	//  Events
	//--------------------------------------
}

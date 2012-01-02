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
public class FaceForwardComponent : MonoBehaviour {

	//--------------------------------------
	//  Properties
	//--------------------------------------
	private MoveHorizontallyComponent moveHorizontallyComponent;
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		

	// Use this for initialization
	void Start () {
	
		moveHorizontallyComponent = gameObject.GetComponent("MoveHorizontallyComponent") as MoveHorizontallyComponent;
		
		float direction_float = moveHorizontallyComponent.direction_float;
		
		if (direction_float == 1) {

			transform.eulerAngles = new Vector3 (
			
				gameObject.transform.eulerAngles.x + 180, 
				gameObject.transform.eulerAngles.y, 
				gameObject.transform.eulerAngles.z
			);
			
		} else {

			transform.eulerAngles = new Vector3 (
			
				gameObject.transform.eulerAngles.x, 
				gameObject.transform.eulerAngles.y, 
				gameObject.transform.eulerAngles.z
			);
			
		}

	}
	
	// Update is called once per frame
	void Update () {

	
	}
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}

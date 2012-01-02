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
public class ScreenTrapComponent : MonoBehaviour {

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
		var y = transform.position.y;
		
				
		if (x > 100) {
			x = 100;
		} else if (x < 0) {
			x = 0;
		}
		
		if (y > 50) {
			y = 50;
		} else if (y < -50) {
			y = -50;
		}
		
		
		
		
		transform.position = new Vector3 ( 
			x, 
			y, 
			transform.position.z
		);

	
	}
	
	
	/*
				//	CHECK PROPERTIES
			_position_point = owner.getProperty(_position_propertyreference);
			_size_point 	= owner.getProperty(_size_propertyreference);
			
			//	CHECK BOUNDS: HORIZONTAL
			if (_position_point.x - _size_point.x /2 > PBE.scene.sceneViewBounds.right) {
				_position_point.x = PBE.scene.sceneViewBounds.left - _size_point.x / 2;
			} else if (_position_point.x + _size_point.x /2 < PBE.scene.sceneViewBounds.left) {
				_position_point.x = PBE.scene.sceneViewBounds.right + _size_point.x / 2;
			}
			
			//	CHECK BOUNDS: VERTICAL
			if (_position_point.y - _size_point.y /2 > PBE.scene.sceneViewBounds.bottom) {
				_position_point.y = PBE.scene.sceneViewBounds.top - _size_point.y / 2;
			} else if (_position_point.y + _size_point.y /2 < PBE.scene.sceneViewBounds.top) {
				_position_point.y = PBE.scene.sceneViewBounds.bottom - _size_point.y / 2;
			}
			
			//	UPDATE PROPERTY REFERENCE(S)
			owner.setProperty(_position_propertyreference, _position_point);
	*/
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}

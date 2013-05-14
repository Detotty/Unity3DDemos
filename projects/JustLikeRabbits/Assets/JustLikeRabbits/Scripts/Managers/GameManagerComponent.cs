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
	public GameObject RabbitAdultPrefab;

	
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
		_doStartNextLevel();
	}
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{

		
	}

	///<summary>
	///	Start Next Level
	///</summary>
	public void _doStartNextLevel() 
	{
		
		_doLayoutSprites();
	}
	
	///<summary>
	///	Start Next Level
	///</summary>
	public void _doLayoutSprites() 
	{
		//REMEMBER THERE IS *ALREADY* ONE ON THE STAGE
		int TOTAL_RABBITS_INT = 4;
		for (int rabbitIndex_int = 0; rabbitIndex_int < TOTAL_RABBITS_INT-1; rabbitIndex_int ++) {
			
			GameObject gameObject = (GameObject) Instantiate (RabbitAdultPrefab, new Vector3 (100,100, GameConstants.RABBIT_Z_POSITION), Quaternion.identity);
			
			gameObject.transform.position = getValidPositionForObjectOfScale();
			gameObject.transform.rotation = new Quaternion (gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
			
		}
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
	
	///<summary>
	///	Stop the game.
	///</summary>
	public Vector3 getValidPositionForObjectOfScale () 
	{
		//TODO, pass scale into this somehow
		Vector3 aScale_vector3 = new Vector3 (5,5,GameConstants.RABBIT_Z_SCALE);
		
		float x_float = Random.Range (GameConstants.APP_X + aScale_vector3.x/2, GameConstants.APP_WIDTH - aScale_vector3.x/2);
		float y_float = Random.Range (GameConstants.APP_Y + aScale_vector3.y/2, GameConstants.APP_HEIGHT - aScale_vector3.y/2);
		
		return new Vector3 (x_float, y_float, GameConstants.RABBIT_Z_POSITION);

	}
	
	
	///<summary>
	///	Stop the game.
	///</summary>
	public void doStartAnyDateBetweenRabbits (GameObject aGameObject) 
	{
		
		//FIND CLOSEST TO aGameObject THAT IS *NOT* aGameObject
		GameObject closestRabbit_gameobject  = getClosestRabbitTo(aGameObject);
		
		
		//CLOSE ENOUGH?
		Vector3 deltaPosition_vector3 = gameObject.transform.position - closestRabbit_gameobject.transform.position;
		float distanceToClosestRabbit_float = deltaPosition_vector3.magnitude;
		
		//DELETE BOTH AND SPAWN 3 CHILDREN (LATER WE'LL MAKE 'SEX' FOR A BIT HERE)
		if (distanceToClosestRabbit_float < GameConstants.RABBIT_PROXIMITY_TO_DATE) {
			MakeDateComponent makeDateComponent1 = aGameObject.GetComponent<MakeDateComponent>();
			MakeDateComponent makeDateComponent2 = closestRabbit_gameobject.GetComponent<MakeDateComponent>();
			
			if (makeDateComponent1 != null) {
				makeDateComponent1.doStartDate();	
			}
			if (makeDateComponent2 != null) {
				makeDateComponent2.doStartDate();	
			}
				
		}
		

	}
	
	GameObject getClosestRabbitTo(GameObject aGameObject) 
	{
        GameObject[] allRabbits_gameobjects;
        allRabbits_gameobjects = GameObject.FindGameObjectsWithTag("Rabbit");
		
        GameObject closestRabbit_gameobject = allRabbits_gameobjects[0];
		
		
       	float closestDistanceSoFar_float = Mathf.Infinity;
        Vector3 aGameObjectPosition_vector3 = transform.position;
		//
		Debug.Log ("----");
        foreach (GameObject gameObject in allRabbits_gameobjects) {
			if (!gameObject.Equals (aGameObject)) {
				
	            Vector3 deltaPosition_vector3 = gameObject.transform.position - aGameObjectPosition_vector3;
	            float currentDistance_float = Mathf.Abs(deltaPosition_vector3.magnitude);
				Debug.Log ("distance: " + currentDistance_float);
	            if (currentDistance_float < closestDistanceSoFar_float) {
	                closestRabbit_gameobject = gameObject;
	                closestDistanceSoFar_float = currentDistance_float;
	            }
			}
            
        }
		return closestRabbit_gameobject;
		
	}
	

	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}

/*
BuzzSawBladeSpawner Script v.1.0
Copyright © 2012 Unluck Software - Egil A Larsen
www.chemicalbliss.com
*/

using UnityEngine;
using System;
using System.Collections;


public class BuzzSawBladeSpawner:MonoBehaviour{
    public BuzzSawBlade _blade;													//BuzzSawBlade prefab
    public float _spawnInterval = 1.0f;												//Delay between each blade
    public float _selfDestruct = 3.0f;												//Delay before removing from stage
    public float _bladeVelocity = 25.0f;												//Blade speed
    public float _useGravity = 3.0f;													//Delay before enabling gravity
    public float _delayBeforeHurl =1.0f;												//Delay before throwing blade
    BuzzSawBlade _newBlade;
    
    public void Start() {
    	InvokeRepeating("spawnBlade", 1.0f, _spawnInterval);						//Starts the repeating spawnBlade() function
    }
    
    public void spawnBlade() {														
    	_newBlade = (BuzzSawBlade)Instantiate(_blade, transform.position, transform.rotation);//Adds blade to stage
    //	_newBlade.transform.localScale = Vector3.zero;
    //	iTween.ScaleTo(_newBlade.gameObject, Vector3.one, 0.3);	//Download iTween from the asset store to enable gradual size increase from zero to one before releasing the blade
    	StartCoroutine(hurlBlade());
    }
    
    public IEnumerator hurlBlade() {
    	yield return new WaitForSeconds(_delayBeforeHurl);									//Delay
    	Rigidbody rigid = _newBlade.transform.GetComponent<Rigidbody>();		//Attaches rigidbody to the blade, for physics	
    	rigid.velocity = transform.forward * _bladeVelocity;					//Blade speed
    	_newBlade.selfDestruct(_selfDestruct);									//Tells blade to destroy itself, selfDestruct(delay)
    	StartCoroutine(_newBlade.useGravity(_useGravity));										//Enables gravity, useGravity(delay)		
    }
}
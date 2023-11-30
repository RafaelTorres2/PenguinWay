/*
Simple Rolling Ball Script v.1.01
Copyright © 2012 Unluck Software - Egil A Larsen
*/

using UnityEngine;
using System;


public class UnluckRollingBall:MonoBehaviour{
    public void FixedUpdate() {
    	if (Input.GetKey ("up")||Input.GetKey ("w")) {
    		GetComponent<Rigidbody>().AddForce (Camera.main.transform.forward * 450);
    	}
    	if (Input.GetKey ("down")||Input.GetKey ("s")) {
    		GetComponent<Rigidbody>().AddForce (Camera.main.transform.forward * -250);
    	}
    	if (Input.GetKey ("right")||Input.GetKey ("d")) {
    		transform.Rotate(Camera.main.transform.up,Space.World);
    	}
    	if (Input.GetKey ("left")||Input.GetKey ("a")) {
    		transform.Rotate(Camera.main.transform.up,Space.World);
    	}
    }
}
/*
BuzzSawBlade Script v.1.0.1
Copyright © 2012 Unluck Software
www.chemicalbliss.com
*/

using UnityEngine;
using System.Collections;
#pragma warning disable 0618

public class BuzzSawBlade:MonoBehaviour{
    public ParticleSystem _spark;
    public string _limitSparksToTag ="Player";	//Leave blank(null) for sparks on all collision.
    
    public void Start() {
    	_spark.enableEmission= false;                                               //Disables sparks
		ParticleSystem[] psChildren = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem ps in psChildren) {	
			ps.enableEmission = false;												//Disables sparks children
		}
    }
    
    public void selfDestruct(float delay) {											//Removes the blade from the scene by delay > removing collider > delay > destoy
    	Destroy(transform.GetComponent<MeshCollider>(),delay);						//Removes collider
    	Destroy(this.gameObject, delay+2);											//Removes gameObject
    }
    
    public IEnumerator useGravity(float delay) {												//Sets gravity on rigidbody to true after delay
    	yield return new WaitForSeconds(delay);												//Delay
    	GetComponent<Rigidbody>().useGravity = true;												//Enables Gravity
    	GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;							//Removes any constraints to the rigidbody
    }
    
    public void OnCollisionEnter(Collision collision) {								//Handles sparks on collision
    	if(collision.gameObject.tag == _limitSparksToTag||_limitSparksToTag==""){	//Checks tag on other collision object, if _limitSparksToTag has a value sparks will be limited to this collision
    		_spark.enableEmission= true;											//Enables spark particle system	
    		foreach(Transform child in _spark.transform) {			
       		 child.GetComponent<ParticleSystem>().enableEmission = true;							//Enables spark children
    		}
    		_spark.transform.position = collision.contacts[0].point;				//Sets spark position to collision point zero
    	}
    	StartCoroutine(useGravity(0.0f));																//Enables Gravity
    	}
    
    public void OnCollisionStay(Collision collision) {								//Handles collsions that keep occuring over time (stay)
    	if(collision.gameObject.tag == _limitSparksToTag||_limitSparksToTag==""){	
    		if(collision.contacts.Length > 0){
    			_spark.transform.position = collision.contacts[0].point;			//Sets spark position to collision point zero
    		}
    	}
    }
    
    public void OnCollisionExit(Collision collision) {								//Handles event when collision has ended, disables sparks
    	if(collision.gameObject.tag == _limitSparksToTag||_limitSparksToTag==""){	
    		_spark.enableEmission= false;
			ParticleSystem[] psChildren = GetComponentsInChildren<ParticleSystem>();
			foreach (ParticleSystem ps in psChildren) {
				ps.GetComponent<ParticleSystem>().enableEmission = false;
    		}
    	}
    }
}
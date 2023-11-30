using UnityEngine;
using System;


public class BuzzSawBladeRotator:MonoBehaviour
{
    public int speed = 10;
    
    public void Update() {
    transform.Rotate(Vector3.right*speed*Time.deltaTime);
    }
}
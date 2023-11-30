using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorObjetosDelante : MonoBehaviour
{

    private Transform transform;
    public Transform personaje;

    // Start is called before the first frame update
    void Start()
    {

        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 posicionOriginal = personaje.position;

        posicionOriginal = new Vector3(personaje.position.x + 1, posicionOriginal.y, posicionOriginal.z);

        transform.position = posicionOriginal;


    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("xd");

        if (other.gameObject.CompareTag("Objeto"))
        {

            GameController.objetoDelante = true;

        }

    }

}

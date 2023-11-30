using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorObjetosIzquierda : MonoBehaviour
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

        posicionOriginal = new Vector3(posicionOriginal.x, posicionOriginal.y, personaje.position.z - 1);

        transform.position = posicionOriginal;


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Objeto"))
        {

            GameController.objetoDerecha = true;

        }

    }

}

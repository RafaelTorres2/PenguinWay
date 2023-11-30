using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    //public Collider personaje;

    public Transform limite1,limite2;
    public float velocidadSierra;

    private Transform transformSierra;
    private bool direccionSierra;


    // Start is called before the first frame update
    void Start()
    {

        transformSierra = GetComponent<Transform>();
        direccionSierra = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (direccionSierra)
        {

            if ((Mathf.Round(limite1.position.z)) != (Mathf.Round(transformSierra.position.z)))
            {

                transformSierra.Translate(Vector3.forward * velocidadSierra * Time.deltaTime);

            }
            else
            {

                direccionSierra = false;

            }

        }
        else
        {

            if ((Mathf.Round(limite2.position.z)) != (Mathf.Round(transformSierra.position.z)))
            {

                transformSierra.Translate(-Vector3.forward * velocidadSierra * Time.deltaTime);

            }
            else
            {

                direccionSierra = true;

            }

        }

    }

}

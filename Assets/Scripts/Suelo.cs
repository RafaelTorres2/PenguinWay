using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{

    private Rigidbody rigidbodyFilaSuelo;
    public float tiempoAntesDeCaida;
    private bool tocadoPorJugador = false;

    // Start is called before the first frame update
    void Start()
    {

        rigidbodyFilaSuelo = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (tocadoPorJugador)
        {

            tiempoAntesDeCaida -= Time.deltaTime;

        }

        if(tiempoAntesDeCaida <= 0)
        {

            rigidbodyFilaSuelo.isKinematic = false;

            Destroy(this.gameObject, 1f);

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            tocadoPorJugador = true;

        }

    }

}

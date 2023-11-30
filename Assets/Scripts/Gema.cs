using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gema : MonoBehaviour
{

    public AudioSource audioGema;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            GameController.gemasRecogidas++;
            audioGema.Play();
            Destroy(this.gameObject);

        }

    }

}

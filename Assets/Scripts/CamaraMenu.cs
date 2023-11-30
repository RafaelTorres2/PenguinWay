using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMenu : MonoBehaviour
{

    public float velocidad;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, velocidad * Time.deltaTime,0);

    }
}

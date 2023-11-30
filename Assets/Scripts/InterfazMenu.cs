using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfazMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iniciarJuego()
    {

        SceneManager.LoadScene("Nivel1");

    }
    public void cerrarJuego()
    {

        Application.Quit(0);

    }

}

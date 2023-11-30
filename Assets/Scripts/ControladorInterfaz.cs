using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControladorInterfaz : MonoBehaviour
{

    public GameObject interfazJugando, interfazPausa, interfazMuerte, interfazCompletado;
    public TMP_Text textoMuertePuntuacion, textoCompletadoPuntuacion;
    public static bool muerto = false;
    public static bool completado = false;

    private void Update()
    {

        if (muerto)
        {

            activarInterfazMuerte();

        }

        if (completado)
        {

            nivelCompletado();

        }

        textoMuertePuntuacion.text = GameController.gemasRecogidas * 100 + "";
        textoCompletadoPuntuacion.text = GameController.gemasRecogidas * 100 + "";

    }

    public void pausarJuego()
    {

        interfazMuerte.SetActive(false);
        interfazPausa.SetActive(true);
        interfazJugando.SetActive(false);
        detenerAnimacionGema();
        Time.timeScale = 0f;

    }

    public void reanudarJuego()
    {

        interfazMuerte.SetActive(false);
        interfazJugando.SetActive(true);
        interfazPausa.SetActive(false);
        reanudarAnimacionGema();
        Time.timeScale = 1f;

    }

    public void reiniciarNivel()
    {

        GameController.gemasRecogidas = 0;
        SceneManager.LoadScene("Nivel1");
        reanudarJuego();

    }

    public void activarInterfazMuerte()
    {

        muerto = false;
        interfazMuerte.SetActive(true);
        interfazJugando.SetActive(false);

    }

    public void nivelCompletado()
    {

        completado = false;
        interfazCompletado.SetActive(true);
        interfazJugando.SetActive(false);
        Time.timeScale = 0f;

    }

    public void volverMenu()
    {

        reanudarAnimacionGema();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    private void detenerAnimacionGema()
    {

        GameObject[] gemas = GameObject.FindGameObjectsWithTag("Gema");

        for (int cont = 0; cont < gemas.Length; cont++)
        {

            gemas[cont].GetComponent<AnimationScript>().enabled = false;

        }

    }

    private void reanudarAnimacionGema()
    {

        GameObject[] gemas = GameObject.FindGameObjectsWithTag("Gema");

        for (int cont = 0; cont < gemas.Length; cont++)
        {

            gemas[cont].GetComponent<AnimationScript>().enabled = true;

        }

    }

}

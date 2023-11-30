using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public float velocidad;
    public float salto;
    public static bool objetoDelante = false, objetoIzquierda = false, objetoDerecha = false;
    public static int gemasRecogidas = 0;
    public TMP_Text textoContador;

    private Vector2 posicionInicialDedo, posicionFinalDedo;
    private Touch touch;
    private bool libre = true, efectoCamaraActivo = false;
    private IEnumerator goCoroutine;
    private Quaternion rotacionDerecha,rotacionIzquierda,rotacionFrente;

    // Start is called before the first frame update
    void Start()
    {
        rotacionIzquierda = new Quaternion(0,0,0,0);
        rotacionDerecha = new Quaternion(0, 45, 0, 0);
        rotacionFrente = new Quaternion(0, 1, 0, 1);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

        }

        if(touch.phase == TouchPhase.Began)
        {

            posicionInicialDedo = touch.position;

        }

        if(Input.touchCount > 0 && touch.phase == TouchPhase.Ended && libre)
        {

            posicionFinalDedo = touch.position;

            if((posicionFinalDedo.y > posicionInicialDedo.y) && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
            {

                if (!(objetoIzquierda))
                {

                    goCoroutine = Go(new Vector3(0f, salto, velocidad));
                    StartCoroutine(goCoroutine);
                    transform.rotation = rotacionIzquierda;

                } 


            }else if((posicionFinalDedo.y < posicionInicialDedo.y) && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
            {

                if (!(objetoDerecha))
                {

                    goCoroutine = Go(new Vector3(0f, salto, -velocidad));
                    StartCoroutine(goCoroutine);
                    transform.rotation = rotacionDerecha;

                }

            }
            /*else if((posicionFinalDedo.x < posicionInicialDedo.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {


               goCoroutine = Go(new Vector3(-velocidad, salto, 0f));
               StartCoroutine(goCoroutine);

            }*/
            else if((posicionFinalDedo.x > posicionInicialDedo.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {

                if (!(objetoDelante))
                {

                    goCoroutine = Go(new Vector3(velocidad, salto, 0f));
                    StartCoroutine(goCoroutine);
                    transform.rotation = rotacionFrente;

                }

            }

        }

        textoContador.text = gemasRecogidas + "";

    }

    private IEnumerator Go(Vector3 direccion)
    {

        libre = false;

        for(int cont = 0; cont <= 2 ; cont++)
        {

            transform.Translate(direccion,Space.World);
            yield return new WaitForSeconds(0.01f);

        }

        for (int cont = 0; cont <= 2; cont++)
        {

            transform.Translate(direccion,Space.World);
            yield return new WaitForSeconds(0.01f);

        }

        transform.Translate(direccion,Space.World);

        objetoDelante = false;
        objetoDerecha = false;
        objetoIzquierda = false;

        yield return new WaitForSeconds(0.5f);
        libre = true;

    }

}

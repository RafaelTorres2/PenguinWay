using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoMuerte : MonoBehaviour
{

    public Transform cameraTransform;
    private Vector3 orignalCameraPos;
    private Collider collider;

    public ParticleSystem particulasSangre;
    public GameObject trozo1, trozo2;
    public GameController gameController;
    public MeshRenderer body, alaDerecha, alaIzquierda;

    // Shake Parameters
    public float shakeDuration = 2f;
    public float shakeAmount = 0.7f;

    private bool canShake = false;
    private float _shakeTimer;





    // Start is called before the first frame update
    void Start()
    {
        orignalCameraPos = cameraTransform.localPosition;
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera();
        }

        if (canShake)
        {
            StartCameraShakeEffect();
        }
    }

    public void ShakeCamera()
    {
        canShake = true;
        _shakeTimer = shakeDuration;
    }

    public void StartCameraShakeEffect()
    {
        if (_shakeTimer > 0)
        {
            cameraTransform.localPosition = orignalCameraPos + Random.insideUnitSphere * shakeAmount;
            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            _shakeTimer = 0f;
            cameraTransform.position = orignalCameraPos;
            canShake = false;
        }
    }

    public void muerte()
    {

        //this.gameObject.SetActive(false);
        body.enabled = false;
        alaDerecha.enabled = false;
        alaIzquierda.enabled = false;

        Rigidbody rigidbodyTrozo1 = trozo1.GetComponent<Rigidbody>();
        Rigidbody rigidbodyTrozo2 = trozo2.GetComponent<Rigidbody>();

        trozo1.SetActive(true);
        trozo2.SetActive(true);

        Invoke("impulsarTrozos", 0.1f);
        ShakeCamera();

        particulasSangre.Play(true);
        collider.enabled = false;
        gameController.enabled = false;
        ControladorInterfaz.muerto = true;

    }

    private void impulsarTrozos()
    {

        Rigidbody rigidbodyTrozo1 = trozo1.GetComponent<Rigidbody>();
        Rigidbody rigidbodyTrozo2 = trozo2.GetComponent<Rigidbody>();

        rigidbodyTrozo1.AddForce(new Vector3(Random.Range(-200, 200), Random.Range(200, 300), Random.Range(-200, 200)));
        rigidbodyTrozo2.AddForce(new Vector3(Random.Range(-200, 200), Random.Range(200, 300), Random.Range(-200, 200)));

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            muerte();

        }

    }

}

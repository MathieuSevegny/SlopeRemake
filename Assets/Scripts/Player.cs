using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject vueJoueur;

    public static Player Instance;
    [Header("Vitesse")]
    public float vitesse;

    [Header("Contrôle")]
    public KeyCode toucheGauche = KeyCode.A;
    public KeyCode toucheDroite = KeyCode.D;

    [Header("Positions")]
    public Vector3 decalageCamera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vueJoueur = Instantiate(vueJoueur);
        vueJoueur.transform.position = this.transform.position + decalageCamera;
        var rigidBodyBoule = GetComponent<Rigidbody>();
    }
    public void Accelerate()
    {
        var rigidBodyBoule = GetComponent<Rigidbody>();
        rigidBodyBoule.AddForce(Vector3.back * 5, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Jump")
        {
            Accelerate();
        }
    }

    private void FixedUpdate()
    {
        var rigidBodyBoule = GetComponent<Rigidbody>();
        rigidBodyBoule.AddForce(Vector3.back * 3, ForceMode.Acceleration);
    }
    // Update is called once per frame
    void Update()
    {
        var rigidBodyBoule = GetComponent<Rigidbody>();

        //Mouvements lattéraux
        if (Input.GetKey(toucheGauche))
        {
            //playerBody.transform.position += Vector3.left * vitesse * Time.deltaTime;
            rigidBodyBoule.AddForce(Vector3.right * vitesse, ForceMode.Impulse);
        }
        if (Input.GetKey(toucheDroite))
        {
            //playerBody.transform.position += Vector3.right * vitesse * Time.deltaTime;
            rigidBodyBoule.AddForce(Vector3.left * vitesse, ForceMode.Impulse);
        }
        rigidBodyBoule.AddForce(Vector3.back * 10 * Time.deltaTime, ForceMode.Acceleration);
        this.transform.position = transform.position;
        vueJoueur.transform.position = this.transform.position + decalageCamera;
    }
}

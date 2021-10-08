using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerBody;
    public GameObject vueJoueur;
    [Header("Vitesse")]
    public float vitesse;

    [Header("Contrôle")]
    public KeyCode toucheGauche = KeyCode.A;
    public KeyCode toucheDroite = KeyCode.D;

    [Header("Positions")]
    public Vector3 decalageCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = Instantiate(playerBody);
        playerBody.transform.position = this.transform.position;
        vueJoueur = Instantiate(vueJoueur);
        vueJoueur.transform.position = this.transform.position + decalageCamera;
        var rigidBodyBoule = playerBody.GetComponent<Rigidbody>();
        rigidBodyBoule.AddForce(Vector3.back * vitesse * 20, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        var rigidBodyBoule = playerBody.GetComponent<Rigidbody>();
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
        this.transform.position = playerBody.transform.position;
        vueJoueur.transform.position = this.transform.position + decalageCamera;
    }
}

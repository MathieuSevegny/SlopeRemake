using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitDetecter : MonoBehaviour
{
    static Event detectPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        ControlleurJeu.Instance.SortiDeStructure();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurJeu : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] ModelRamps;
    public List<GameObject> ramps;
    public static ControlleurJeu Instance;

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

        for (int i = 0; i < 10; i++)
        {
            AjoutStructure();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AjoutStructure()
    {
        var randomPosition = Random.Range(0, ModelRamps.Length);
        var modelToCreate = ModelRamps[randomPosition];
        var last = ramps[ramps.Count - 1];
        var lastTransform = last.transform.Find("EndPosition").gameObject.transform;

        modelToCreate = Instantiate(modelToCreate);

        modelToCreate.transform.position = lastTransform.position - Vector3.forward * 4 + Vector3.down * 3;
        modelToCreate.transform.rotation = last.transform.rotation;

        ramps.Add(modelToCreate);
    }
    public void SortiDeStructure()
    {
        Destroy(ramps[0]);
        ramps.RemoveAt(0);
        AjoutStructure();
    }
}

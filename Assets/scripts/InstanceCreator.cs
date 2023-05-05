using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCreator : MonoBehaviour
{
    private static InstanceCreator instance;

    [SerializeField]
    private GameObject basePrefab;
    private GameObject currentInstance;
    private int instanceCount = 0;

    public static InstanceCreator Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        //patrón singleton
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (basePrefab != null)
            {
                if (currentInstance != null)
                {
                    Destroy(currentInstance);
                    currentInstance = null;
                }

                currentInstance = Instantiate(basePrefab, Vector3.zero, Quaternion.identity);
                instanceCount++;
                currentInstance.name = $"Cube{instanceCount}";
                currentInstance.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 255F), Random.Range(0, 255F), Random.Range(0, 255F));
            }
        }
        
    }
}

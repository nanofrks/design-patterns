using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCreator : MonoBehaviour
{
    private static InstanceCreator instance;

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
            CubeFactory.Instance.DeliverNewProduct();
        }
        
    }
}

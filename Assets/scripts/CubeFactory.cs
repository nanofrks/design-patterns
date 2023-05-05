using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    private static CubeFactory instance;

    //exponer una forma para que mi cliente pida instancias
    [SerializeField]
    private GameObject product;
    private GameObject productInstance;
    private int instanceCount = 0;

    public static CubeFactory Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        //patrón singleton
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }

    public GameObject DeliverNewProduct()
    {

        if (productInstance != null)
        {
            Destroy(productInstance);
            productInstance = null;
        }

        productInstance = Instantiate(product, Vector3.zero, Quaternion.identity);
        instanceCount++;
        productInstance.name = $"Cube{instanceCount}";
        productInstance.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1F), Random.Range(0, 1F), Random.Range(0, 1F), 1F);

        return productInstance;
    }
}

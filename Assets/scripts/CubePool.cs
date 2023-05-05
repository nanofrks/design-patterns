using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    private static CubePool instance;

    [SerializeField]
    private int size = 3;

    [SerializeField]
    private GameObject cubePrefab;
    private List<GameObject> instances = new List<GameObject>();

    public static CubePool Instance { get => instance; private set => instance = value; }

    public GameObject Retrieve()
    {
        GameObject target = instances[0];
        target.transform.parent = null;
        instances.Remove(target);
        target.SetActive(true);

        return target;
    }

    public void Recycle(GameObject target)
    {
        target.SetActive(false); //apago el gameObject
        target.transform.position = transform.position;
        target.transform.rotation = Quaternion.identity;
        target.transform.parent = transform;
        instances.Add(target);
    }

    private void Awake()
    {
        //patrón singleton
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        if (cubePrefab != null)
        {
            for (int i = 0; i < size; i++)
            {
                AddNewInstanceToPool();
            } 
        }
        
    }

    private void AddNewInstanceToPool()
    {
        //GameObject newInstance = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        GameObject newInstance = CubeFactory.Instance.DeliverNewProduct();
        Recycle(newInstance);
    }


}

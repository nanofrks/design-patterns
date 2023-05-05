using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject basePrefab;
    private GameObject currentInstance;

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
            }
        }
        
    }
}

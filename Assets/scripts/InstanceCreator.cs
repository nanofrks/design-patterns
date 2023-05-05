using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCreator : MonoBehaviour
{

    [SerializeField]
    private float recycleTime = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentCube = CubePool.Instance.Retrieve();
            currentCube.transform.position = Vector3.zero;
            currentCube.transform.rotation = Quaternion.identity;
            StartCoroutine(RecycleCubeCR(currentCube));
        }
        
    }

    private IEnumerator RecycleCubeCR(GameObject cube)
    {
        yield return new WaitForSeconds(recycleTime);
        CubePool.Instance.Recycle(cube);
    }

}

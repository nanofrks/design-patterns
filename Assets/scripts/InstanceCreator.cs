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

        if (Input.GetKeyDown(KeyCode.V))
        {
            SimpleVFX currentVFX = VFXPool.Instance.Retrieve();
            currentVFX.transform.position = Vector3.zero;
            currentVFX.transform.rotation = Quaternion.identity;
            StartCoroutine(RecycleVFXCR(currentVFX));

        }


    }

    private IEnumerator RecycleVFXCR(SimpleVFX currentVFX)
    {
        currentVFX.StartVFX();
        yield return new WaitForSeconds(recycleTime);
        VFXPool.Instance.Recycle(currentVFX);

    }

    private IEnumerator RecycleCubeCR(GameObject cube)
    {
        yield return new WaitForSeconds(recycleTime);
        CubePool.Instance.Recycle(cube);
    }

}

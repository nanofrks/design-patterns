using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : PoolBase<GameObject>
{
    
    protected override void AddNewInstanceToPool()
    {
        GameObject newInstance = CubeFactory.Instance.DeliverNewProduct();
        Recycle(newInstance);
    }

    protected override void ProcessTargetToRetrieve(GameObject target)
    {
        target.transform.parent = null;
        instances.Remove(target);
        target.SetActive(true);
    }

    protected override void ProcessTargetToRecycle(GameObject target)
    {
        target.SetActive(false); //apago el gameObject
        target.transform.position = transform.position;
        target.transform.rotation = Quaternion.identity;
        target.transform.parent = transform;
    }

}

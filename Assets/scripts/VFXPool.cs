using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPool : PoolBase<SimpleVFX>
{
    [SerializeField]
    private GameObject basePrefab;

    protected override void AddNewInstanceToPool()
    {
        SimpleVFX newInstance = Instantiate(basePrefab, transform.position, Quaternion.identity).GetComponent<SimpleVFX>();
        Recycle(newInstance);
    }

    protected override void ProcessTargetToRecycle(SimpleVFX target)
    {
        target.StopVFX();
        target.gameObject.transform.position = transform.position;
        target.gameObject.transform.parent = transform;
    }

    protected override void ProcessTargetToRetrieve(SimpleVFX target)
    {
        target.gameObject.transform.parent = null;
    }

}

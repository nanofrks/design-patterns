using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase<T> : MonoBehaviour
{
    private static PoolBase<T> instance;

    [SerializeField]
    private int size = 25;

    protected List<T> instances = new List<T>();

    public static PoolBase<T> Instance { get => instance; set => instance = value; }

    public virtual T Retrieve()
    {
        if (instances.Count < 1)
        {
            AddNewInstanceToPool();
        }

        T target = instances[0];
        ProcessTargetToRetrieve(target);

        return target;
    }

    public virtual void Recycle(T target)
    {
        ProcessTargetToRecycle(target);
        instances.Add(target);
    }

    protected abstract void ProcessTargetToRetrieve(T target);
    protected abstract void ProcessTargetToRecycle(T target);
    protected abstract void AddNewInstanceToPool();

    protected void Awake()
    {
        //patrón singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

    }

    // Start is called before the first frame update
    protected void Start()
    {
        for(int i=0; i < size; i++)
        {
            AddNewInstanceToPool();
        }
    }

}

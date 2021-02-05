using System.Collections.Generic;
using UnityEngine;

public abstract class PooledObject<T> : MonoBehaviour where T : PooledObject<T>
{
    private static readonly Queue<T> Pool = new Queue<T>();

    [SerializeField] private int poolSize = 50;

    public int CurrentPoolSize => Pool.Count;

    public T Get(Transform source = null)
    {
        if (Pool.Count == 0)
            PopulatePool();
        T obj = Pool.Dequeue();
        obj.gameObject.SetActive(true);
        if (source != null)
            obj.transform.SetPositionAndRotation(source.position, source.rotation);
        Debug.Log(CurrentPoolSize);
        Debug.Log(obj);
        Debug.Log(obj.gameObject);
        Debug.Log(obj.gameObject.activeSelf);
        return obj;
    }

    public void Return()
    {
        Pool.Enqueue(GetComponent<T>());
        gameObject.SetActive(false);
    }

    private void PopulatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            T obj = Instantiate<T>(GetComponent<T>());
            obj.Return();
        }
        
    }

    protected void ClearPool() => Pool.Clear();
}
using System.Collections.Generic;
using UnityEngine;

// Object Pooler Made By Julian Rijken
public class ObjectPooler : MonoBehaviour
{

    [SerializeField] private Pool[] m_pools;

    private static ObjectPooler m_instance;

    private void Awake()
    {

        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Add Start Size To Pools
        for (int i = 0; i < m_pools.Length; i++)
        {
            m_pools[i].m_pooledObjects = new List<GameObject>();
            AddToPool(m_pools[i],m_pools[i].m_startSize);
        }

    }


    private GameObject AddToPool(Pool pool, int itmeCount = 1)
    {
        if (itmeCount < 1)
            itmeCount = 1;

        GameObject retunObject = null;

        if (pool != null)
        {

            for (int i = 0; i < itmeCount; i++)
            {
                GameObject addedObject = Instantiate(pool.m_object, Vector3.zero, transform.rotation);

                pool.m_pooledObjects.Add(addedObject);

                addedObject.SetActive(false);
                addedObject.transform.parent = transform;

                retunObject = addedObject;
            }
        }

        return retunObject;
    }

    private Pool GetPool(string poolName)
    {
        for (int i = 0; i < m_pools.Length; i++)
        {
            if (m_pools[i].m_name == poolName)
                return m_pools[i];
        }

        return null;
    }

    private GameObject GetObjectFromPool(Pool pool)
    {
        if (pool != null)
        {
            for (int i = 0; i < pool.m_pooledObjects.Count; i++)
            {
                if (!pool.m_pooledObjects[i].activeInHierarchy)
                    return pool.m_pooledObjects[i];
            }

            return AddToPool(pool);
        }
        else
        {
            return null;
        }
    }


    public static GameObject SpawnObject(string name,Vector3 postion,Quaternion rotation, bool active = true)
    {
        ObjectPooler objectPooler = m_instance;

        Pool pool = objectPooler.GetPool(name);

        if (pool != null)
        {
            GameObject item = objectPooler.GetObjectFromPool(pool);

            item.transform.position = postion;
            item.transform.rotation = rotation;
            item.SetActive(active);

            return item;
        }
        else
        {
            Debug.LogWarning("Pool: " + name + " does not exist");
            return null;
        }

    }

}

[System.Serializable]
public class Pool
{
    [HideInInspector]
    public List<GameObject> m_pooledObjects;

    public GameObject m_object;
    public int m_startSize;
    public string m_name;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class PoolManager : Singleton<PoolManager> {
    private static List<GameObject> prefabList = new List<GameObject>();
    private static Dictionary<Transform, ObjectPool> transformDictionary = new Dictionary<Transform, ObjectPool>();
    public static Dictionary<int, ObjectPool> objectPoolDictionary = new Dictionary<int, ObjectPool>();
    private bool clearFlag = false;
    private static List<Transform> trashList = new List<Transform>();

    private void Update()
    {
        ClearTrashList();
    }

    private void ClearTrashList()
    {
        if (clearFlag)
        {
            clearFlag = false;
            lock (trashList)
            {
                Debug.Log("has destoried " + trashList.Count + " from objectPool " + trashList[0].name);
                for(int i = 0; i < trashList.Count; i++)
                {
                    Destroy(trashList[i].gameObject);
                }
                trashList.Clear();
            }
        }
    }

    private static ObjectPool CreateObjectPool(GameObject prefab,int num,Vector3 pos = new Vector3(), Quaternion rotate = new Quaternion())
    {
        prefabList.Add(prefab);
        GameObject go = new GameObject();
        go.name = prefab.name + " Pool ";
        ObjectPool objectPool = go.AddComponent<ObjectPool>();
        objectPool.InitObjectPool(prefab, transformDictionary, num,pos, rotate);
        objectPoolDictionary.Add(prefab.GetInstanceID(), objectPool);
        return objectPool;
    }

    private static ObjectPool GetObjectPool(GameObject prefab, int num=1000, Vector3 pos = new Vector3(), Quaternion rotate = new Quaternion())
    {
        ObjectPool objectPool = null;
        int count = prefabList.Count;
        int prefabID = prefab.GetInstanceID();
        //判断集合中是否有预制体对应的对象池
        for(int i=0;i< prefabList.Count; i++)
        {
            
            if (prefabID == prefabList[i].GetInstanceID())
            {
                objectPool = objectPoolDictionary[prefabID];
                break;
            }
        }
        //如果找不到对象池，就生成一个对象池
        if (objectPool == null)
        {
            objectPool = CreateObjectPool(prefab, num,pos, rotate);
        }
        return objectPool;
    }

    private static ObjectPool GetPool(Transform handleTransform)
    {
        if (transformDictionary.ContainsKey(handleTransform))
        {
            return transformDictionary[handleTransform];
        }
        Debug.LogError(handleTransform.name + " has no find it's ObjectPool");
        return null;
    }

    public static void PushObjectToPool(Transform handleTransform , float delayTime = 0.0f)
    {
        ObjectPool objectPool = GetPool(handleTransform.transform);
        if (objectPool)
        {
            objectPool.PushObjectToPool(handleTransform,delayTime);
        }
        else
        {
            GameObject.Destroy(handleTransform.gameObject);
        }
    }

    public static Transform PullObjectFromPool(GameObject prefab,int num = 100, Vector3 pos = new Vector3(), Quaternion rotate = new Quaternion())
    {
        if (prefab == null)
        {
            Debug.Log("prefab is null!");
            return null;
        }
        ObjectPool objPool = GetObjectPool(prefab,num);
        return objPool.PullObjectFromObjectPool(pos,rotate);
    }
}

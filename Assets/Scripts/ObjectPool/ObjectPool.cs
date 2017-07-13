using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    /// <summary>
    /// 对象池类，测试使用
    /// </summary>
    public LinkedList<GameObject> workingLinkedList;
    public LinkedList<GameObject> idleLinkedList;
    [HideInInspector]
    public GameObject prefab;
    private Dictionary<GameObject, ObjectPool> poolDictionary;
    /// 单例模式
    private static ObjectPool instance;
	
    /// <summary>
    /// 获取单例对象
    /// </summary>
    public ObjectPool GetInstance()
    {
        if (instance == null)
        {
            instance = new ObjectPool();
        }
        return instance;
    }
    /// <summary>
    /// 初始化对象池
    /// </summary>
    public void InitObjectPool(GameObject prefab,Dictionary<GameObject, ObjectPool> poolDictionary, int loadNum,
        Vector3 pos = new Vector3(),Quaternion rotate = new Quaternion())
    {
        this.prefab = prefab;
        this.poolDictionary = poolDictionary;
        workingLinkedList = new LinkedList<GameObject>();
        idleLinkedList = new LinkedList<GameObject>();
        for(int i = 0; i < loadNum; i++)
        {
            GameObject go = GameObject.Instantiate(prefab, pos, rotate);
            go.name = i + "";
            go.SetActive(false);
            go.transform.SetParent(transform);
            idleLinkedList.AddFirst(go);
            poolDictionary.Add(go, this);
        }
    }
    
    public GameObject PullObjectFromObjectPool(Vector3 pos = new Vector3(), Quaternion rotate = new Quaternion())
    {
        GameObject myObject = null;
        //假如对象池已经有对象了
        if (idleLinkedList.Count > 0)
        {
            myObject = idleLinkedList.First.Value;
            myObject.gameObject.SetActive(false);
            idleLinkedList.RemoveFirst();
            workingLinkedList.AddLast(myObject);
        }
        //对象池中没有对象，生成实例
        else
        {
            myObject = GameObject.Instantiate(prefab, pos, rotate);
            //myObject.SetParent(transform);
            workingLinkedList.AddLast(myObject);
            poolDictionary.Add(myObject, this);
        }
        return myObject;
    }

    public void PushObjectToPool(GameObject objectTransform,float delayTime)
    {
        StartCoroutine(DelayPushObjectToPool(objectTransform, delayTime));
    }

    IEnumerator DelayPushObjectToPool(GameObject objectTransform, float delayTime)
    {
        while (delayTime > 0)
        {
            yield return null;
            if(!objectTransform.activeInHierarchy)
            {
                yield break;
            }
            delayTime -= Time.deltaTime;
        }
        if (objectTransform.activeSelf)
        {
            objectTransform.SetActive(false);
            idleLinkedList.AddFirst(objectTransform);
            workingLinkedList.Remove(objectTransform);
        }
    }

    public void Dispose()
    {
        workingLinkedList.Clear();
        idleLinkedList.Clear();
        workingLinkedList = null;
        idleLinkedList = null;
        prefab = null;
    }

}

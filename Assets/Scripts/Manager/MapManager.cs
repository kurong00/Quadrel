using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class MapManager : Singleton<MapManager> {

    /// <summary>
    /// 单例相关
    /// </summary>
    private GameColor mapColor;
    private Constant mapConstant;
    private ProbabilityManager mapProbability;
    /// <summary>
    /// 生成地图相关
    /// </summary>
    private GameObject mapWall;
	private GameObject mapTile;
    private GameObject mapCoin;
    private GameObject mapSpikes;
    private GameObject mapSkySpikes;
    private GameObject initItem = null;
    private List<GameObject[]> mapList = new List<GameObject[]>();
	/// <summary>
	/// 地图塌陷相关
	/// </summary>
    [HideInInspector]
	public int mapIndex = 0;
	public float offSetZ = 0f;
	/// <summary>
	/// 主角相关
	/// </summary>
	private GameObject player;

    void Start () {
		mapWall = Resources.Load ("wall") as GameObject;
		mapTile = Resources.Load ("tile") as GameObject;
        mapCoin = Resources.Load("coin") as GameObject;
        mapSkySpikes = Resources.Load("skySpikes") as GameObject;
        mapSpikes = Resources.Load("spikes") as GameObject;
        mapColor = ColorManager.Instance().SelectColor(ColorManager.ScenesType.MONDAY);
        mapConstant = Constant.Instance();
        mapProbability = ProbabilityManager.Instance();
        CreateMap ();
		player = GameObject.FindWithTag ("Player");
	}

	void Update () {
		if (mapList.Count - mapConstant.TILE_DOWN_DISTANCE < player.GetComponent<PlayerControl> ().z) {
			offSetZ = mapList [mapList.Count - 1] [0].GetComponent<Transform> ().position.z + mapConstant.BOTTOM_LENGTH / 2;
			CreateMap ();
		}
	}

	/// <summary>
	/// 初始化地图
	/// </summary>
	public void CreateMap(){
		for (int i = 0; i < 10; i++)
        {
			GameObject[] mapItem1 = new GameObject[6];
			for (int j = 0; j < 6; j++)
            {
				//第一种瓷砖的出生位置
				Vector3 initPos = new Vector3 (j * mapConstant.BOTTOM_LENGTH, 
                    0, offSetZ + i * mapConstant.BOTTOM_LENGTH);
				Vector3 initRota = new Vector3 (-90, 45, 0);
				if (j == 0 || j == 5)
                {
                    initItem = GameObject.Instantiate (mapWall, initPos, Quaternion.Euler (initRota));
					initItem.GetComponent<MeshRenderer> ().material.color = mapColor.colorOfWall;
				} else
                {
                    int pb = mapProbability.CalculatePb();
                    if (pb == 0)
                    {
                        initItem = GameObject.Instantiate(mapTile, initPos, Quaternion.Euler(initRota));
                        initItem.GetComponent<Transform>().Find("tile_plane").GetComponent<MeshRenderer>()
                            .material.color = mapColor.colorOfTileOne;
                        bool pbCoin = mapProbability.CalculateCoin();
                        if (pbCoin)
                        {
                            GameObject coin = PoolManager.PullObjectFromPool(mapCoin, mapConstant.COUNT_COIN_OBJECT_POOL, initPos, Quaternion.identity).gameObject;
                            coin.transform.parent = initItem.transform;
                        }
                    }
                    if (pb == 1)
                    {
                        initItem = new GameObject();
                        initItem.GetComponent<Transform>().position = initPos;
                        initItem.GetComponent<Transform>().rotation = Quaternion.Euler(initRota);
                    }
                    if (pb == 2)
                    {
                        initItem = GameObject.Instantiate(mapSpikes, initPos, Quaternion.Euler(initRota));
                    }
                    if (pb == 3)
                    {
                        initItem = GameObject.Instantiate(mapSkySpikes, initPos, Quaternion.Euler(initRota));
                    }
                }
				mapItem1 [j] = initItem;
                initItem.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
            }
			mapList.Add (mapItem1);
			GameObject[] mapItem2 = new GameObject[5];
			for (int j = 0; j < 5; j++) {
				//第二种瓷砖的出生位置
				Vector3 initPos = new Vector3 (j * mapConstant.BOTTOM_LENGTH + mapConstant.BOTTOM_LENGTH / 2,
                    0, offSetZ + i * mapConstant.BOTTOM_LENGTH + mapConstant.BOTTOM_LENGTH / 2);
				Vector3 initRota = new Vector3 (-90, 45, 0);
                int pb = mapProbability.CalculatePb();
                if (pb == 0)
                {
                    initItem = GameObject.Instantiate(mapTile, initPos, Quaternion.Euler(initRota));
                    initItem.GetComponent<Transform>().Find("tile_plane").GetComponent<MeshRenderer>()
                        .material.color = mapColor.colorOfTileTwo;
                    bool pbCoin = mapProbability.CalculateCoin();
                    if (pbCoin)
                    {
                        GameObject coin = PoolManager.PullObjectFromPool(mapCoin, mapConstant.COUNT_COIN_OBJECT_POOL, initPos, Quaternion.identity).gameObject;
                        coin.transform.parent = initItem.transform;
                    }
                }
                if (pb == 1)
                {
                    initItem = new GameObject();
                    initItem.GetComponent<Transform>().position = initPos;
                    initItem.GetComponent<Transform>().rotation = Quaternion.Euler(initRota);
                }
                if (pb == 2)
                {
                    initItem = GameObject.Instantiate(mapSpikes, initPos, Quaternion.Euler(initRota));
                }
                if (pb == 3)
                {
                    initItem = GameObject.Instantiate(mapSkySpikes, initPos, Quaternion.Euler(initRota));
                }
                mapItem2 [j] = initItem;
                initItem.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
            }
			mapList.Add (mapItem2);
            mapProbability.AddPb();
		}
	}

	public List<GameObject[]> GetMapList(){
		if (mapList.Count <= 0) {
			Debug.Log ("create map failed");
			CreateMap ();
		}
		return mapList;
	}
		
	public void StartTileDown(){
		StartCoroutine ("TileDown");
	}

	public void StopTileDown(){
		StopCoroutine ("TileDown");
	}

	private IEnumerator TileDown(){
		while (true) {
			yield return new WaitForSeconds (mapConstant.TILE_DOWN_TIME);
            for (int i = 0; i < mapList [mapIndex].Length; i++)
            {
                Rigidbody tempRigidbody = null;
                if(mapList[mapIndex][i].tag == "SkySpikes"|| mapList[mapIndex][i].tag == "Spikes")
                {
                    mapList[mapIndex][i].GetComponent<Spikes>().StopAllCoroutines();
                }
                if (mapList[mapIndex][i].transform.childCount > 1)
                {
                    PoolManager.PushObjectToPool(mapList[mapIndex][i].transform.GetChild(1),0.5f);
                }
                tempRigidbody = mapList [mapIndex] [i].AddComponent<Rigidbody> ();
                tempRigidbody.angularVelocity = new Vector3 (Random.Range (0f, 2f), Random.Range (0f, 2f), Random.Range (0f, 2f));
                Destroy(mapList[mapIndex][i], 0.5f);
			}
            if (mapIndex == player.GetComponent<PlayerControl>().z)
            {
				StopTileDown ();
                player.AddComponent<Rigidbody>();
                CameraManager.Instance ().startFollow = false;
                StartCoroutine(GameControl.Instance().GameOver(false));
			}
			mapIndex++;
		}
	}
		
}

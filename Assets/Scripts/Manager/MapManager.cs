using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class MapManager : Singleton<MapManager> {

	/// <summary>
	/// 生成地图相关
	/// </summary>
	private GameObject mapWall;
	private GameObject mapTile;
	private List<GameObject[]> mapList = new List<GameObject[]>();
	private float bottomTileLength = Mathf.Sqrt (2) * 0.254f;
	/// <summary>
	/// 地图塌陷相关
	/// </summary>
	private float tileFallTime = 0.2f;
	private int mapIndex = 0;
	private float offSetZ = 0f;
    private int mapTileDownDistance = 8;
	/// <summary>
	/// 主角相关
	/// </summary>
	private GameObject player;

    void Start () {
		mapWall = Resources.Load ("wall") as GameObject;
		mapTile = Resources.Load ("tile") as GameObject;
		CreateMap ();
		player = GameObject.FindWithTag ("Player");
	}

	void Update () {
		if (mapList.Count - mapTileDownDistance < player.GetComponent<PlayerControl> ().z) {
			offSetZ = mapList [mapList.Count - 1] [0].GetComponent<Transform> ().position.z + bottomTileLength / 2;
			CreateMap ();
		}
	}

	/// <summary>
	/// 初始化地图
	/// </summary>
	void CreateMap(){
		GameColor mapColor = ColorManager.Instance ().SelectColor (ColorManager.ScenesType.MONDAY);
		for (int i = 0; i < 10; i++) {
			GameObject[] mapItem1 = new GameObject[6];
			for (int j = 0; j < 6; j++) {
				//第一种瓷砖的出生位置
				Vector3 initPos = new Vector3 (j * bottomTileLength, 0, offSetZ + i * bottomTileLength);
				Vector3 initRota = new Vector3 (-90, 45, 0);
				GameObject initItem = null;
				if (j == 0 || j == 5) {
                    //墙壁的颜色
                    initItem = PoolManager.PullObjectFromPool(mapWall,20);
                    initItem.transform.position = initPos;
                    initItem.transform.rotation = Quaternion.Euler(initRota);
					//initItem = GameObject.Instantiate (mapWall, initPos, Quaternion.Euler (initRota));
					initItem.GetComponent<MeshRenderer> ().material.color = mapColor.colorOfWall;
				} else {
                    initItem = PoolManager.PullObjectFromPool(mapTile,90);
                    initItem.transform.position = initPos;
                    initItem.transform.rotation = Quaternion.Euler(initRota);
                    //initItem = GameObject.Instantiate (mapTile, initPos, Quaternion.Euler (initRota));
                    initItem.GetComponent<Transform> ().Find ("tile_plane").GetComponent<MeshRenderer> ()
						.material.color = mapColor.colorOfTileOne;
				}
				mapItem1 [j] = initItem;
			}
			mapList.Add (mapItem1);
			GameObject[] mapItem2 = new GameObject[5];
			for (int j = 0; j < 5; j++) {
				//第二种瓷砖的出生位置
				Vector3 initPos = new Vector3 (j * bottomTileLength + bottomTileLength / 2, 0, offSetZ + i * bottomTileLength + bottomTileLength / 2);
				Vector3 initRota = new Vector3 (-90, 45, 0);
                GameObject initItem = PoolManager.PullObjectFromPool(mapTile);
                initItem.transform.position = initPos;
                initItem.transform.rotation = Quaternion.Euler(initRota);
                //GameObject initItem = GameObject.Instantiate (mapTile, initPos, Quaternion.Euler (initRota)); 
                initItem.GetComponent<Transform> ().Find ("tile_plane").GetComponent<MeshRenderer> ()
					.material.color = mapColor.colorOfTileTwo;
				mapItem2 [j] = initItem;
			}
			mapList.Add (mapItem2);
		}
		//测试使用，修改名字
		/*for (int i = 0; i < mapList.Count; i++)
			for (int j = 0; j < mapList [i].Length; j++) {
				mapList [i] [j].name = (i + 1) + "--" + (j + 1);
			}*/
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
			yield return new WaitForSeconds (tileFallTime);
			for (int i = 0; i < mapList [mapIndex].Length; i++) {
				Rigidbody tempRigidbody = mapList [mapIndex] [i].AddComponent<Rigidbody> ();
				tempRigidbody.angularVelocity = new Vector3 (Random.Range (0f, 2f), Random.Range (0f, 2f), Random.Range (0f, 2f));
                PoolManager.PushObjectToPool(mapList[mapIndex][i],0.2f);
                //GameObject.Destroy (mapList [mapIndex] [i], 1f);
			}
			if (mapIndex == player.GetComponent<PlayerControl>().z) {
				StopTileDown ();
				CameraManager.Instance ().startFollow = false;
				player.AddComponent<Rigidbody2D> ();
				Destroy (player, 2f);
			}
			mapIndex++;
		}
	}
		
}

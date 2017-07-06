using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class MapManager : Singleton<MapManager> {

	/// <summary>
	/// 与地图相关：
	/// </summary>
	private GameObject mapWall;//墙壁
	private GameObject mapTile;//地板
	private List<GameObject[]> mapList = new List<GameObject[]>();
	private float bottomTileLength = Mathf.Sqrt (2) * 0.254f;

	void Start () {
		mapWall = Resources.Load ("wall") as GameObject;
		mapTile = Resources.Load ("tile") as GameObject;
		CreateMap ();
	}

	void Update () {
		
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
				Vector3 initPos = new Vector3 (j * bottomTileLength, 0, i * bottomTileLength);
				Vector3 initRota = new Vector3 (-90, 45, 0);
				GameObject initItem = null;
				if (j == 0 || j == 5) {
					//墙壁的颜色
					initItem = GameObject.Instantiate (mapWall, initPos, Quaternion.Euler (initRota));
					initItem.GetComponent<MeshRenderer> ().material.color = mapColor.colorOfWall;
				} else {
					initItem = GameObject.Instantiate (mapTile, initPos, Quaternion.Euler (initRota));
					initItem.GetComponent<Transform> ().Find ("tile_plane").GetComponent<MeshRenderer> ()
						.material.color = mapColor.colorOfTileOne;
				}
				mapItem1 [j] = initItem;
			}
			mapList.Add (mapItem1);
			GameObject[] mapItem2 = new GameObject[5];
			for (int j = 0; j < 5; j++) {
				//第二种瓷砖的出生位置
				Vector3 initPos = new Vector3 (j * bottomTileLength + bottomTileLength / 2, 0, i * bottomTileLength + bottomTileLength / 2);
				Vector3 initRota = new Vector3 (-90, 45, 0);
				GameObject initItem = GameObject.Instantiate (mapTile, initPos, Quaternion.Euler (initRota)); 
				initItem.GetComponent<Transform> ().Find ("tile_plane").GetComponent<MeshRenderer> ()
					.material.color = mapColor.colorOfTileTwo;
				mapItem2 [j] = initItem;
			}
			mapList.Add (mapItem2);
		}
		//测试使用，修改名字
		for (int i = 0; i < mapList.Count; i++)
			for (int j = 0; j < mapList [i].Length; j++) {
				mapList [i] [j].name = (i + 1) + "--" + (j + 1);
			}
	}

	public List<GameObject[]> GetMapList(){
		if (mapList.Count <= 0) {
			Debug.Log ("create map failed");
			CreateMap ();
		}
		return mapList;
	}
}

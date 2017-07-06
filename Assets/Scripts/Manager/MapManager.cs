using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	private GameObject mapWall;//墙壁
	private GameObject mapTile;//地板
	private List<GameObject[]> mapList = new List<GameObject[]>();
	private float bottomTileLength = Mathf.Sqrt (2) * 0.254f;

	void Start () {
		mapWall = Resources.Load ("wall") as GameObject;
		mapTile = Resources.Load ("tile") as GameObject;
	}

	void Update () {
		
	}

	void CreateMap(){
		for (int i = 0; i < 10; i++) {
			GameObject[] mapItem = new GameObject[6];
			for (int j = 0; j < 6; j++) {
				Vector3 initPos = new Vector3 (j * bottomTileLength, 0, i * bottomTileLength);
				Vector3 initRota = new Vector3 (-90, 45, 0);
				GameObject initItem = null;
				if (j == 0 || j == 5) {
					initItem = GameObject.Instantiate (mapWall, initPos, Quaternion.Euler (initRota));
					initItem.GetComponent<MeshRenderer> ().material.color = Color.black;
				}
			}
		}
	}
}

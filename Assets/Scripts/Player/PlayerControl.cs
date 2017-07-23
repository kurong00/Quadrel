using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class PlayerControl : MonoBehaviour {

    /// <summary>
    /// 角色控制相关
    /// </summary>
	[HideInInspector]
	public int x = 3,z = 2;
    /// <summary>
    /// 单例相关
    /// </summary>
    private GameColor playerPosColor;
    private MapManager mapManager;
    private GameOverControl gameOverControl;
    private DataManager dataManager;
    void Start () {
		playerPosColor = ColorManager.Instance ().SelectColor (ColorManager.ScenesType.MONDAY);
		mapManager =  MapManager.Instance();
        dataManager = DataManager.Instance();
        gameOverControl = GameOverControl.Instance();
    }
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			CameraManager.Instance ().startFollow = true;
			SetPlayerPosition ();
			mapManager.StartTileDown ();
		}
		PlayerControll ();

    }

	void PlayerControll(){
		if(Input.GetKeyDown(KeyCode.A)){
			GoLeft ();
		}
		if(Input.GetKeyDown(KeyCode.D)){
			GoRight();
		}
	}

	void GoLeft(){
		if (!gameOverControl.isDead) {
			if (x != 0) {
				z++;
			}
			if (z % 2 == 1 && x != 0) {
				x--;
			}
		}
		SetPlayerPosition ();
	}

	void GoRight(){
		if (!gameOverControl.isDead) {
			if (x != 4||z % 2 != 1) {
				z++;
			}
			if (z % 2 == 0 && x != 4) {
				x++;
			}
		}
		SetPlayerPosition ();
	}

	void SetPlayerPosition(){
		Transform playerPos =  mapManager.GetMapList()[z] [x].GetComponent<Transform> ();
        MeshRenderer meshRenderer = null;
        if (playerPos.tag == "Tile")
        {
            meshRenderer = playerPos.Find("tile_plane").GetComponent<MeshRenderer> ();
        }
        if (playerPos.tag == "SkySpikes"|| playerPos.tag == "Spikes")
        {
            meshRenderer = playerPos.Find("spikes_b").GetComponent<MeshRenderer>();
        }
        if (meshRenderer != null)
        {
            if (z % 2 == 0)
                meshRenderer.material.color = playerPosColor.colorOfMeshRenderOne;
            else
                meshRenderer.material.color = playerPosColor.colorOfMeshRenderTwo;
        }
        else
        {
            gameOverControl.GameOver();
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        gameObject.transform.position = playerPos.position + new Vector3(0, 0.254f / 2, 0);
        dataManager.AddGameScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Award")
        {
            PoolManager.PushObjectToPool(other.gameObject.GetComponentInParent<Transform>());
            dataManager.AddCoinScore();
        }
        if(other.tag == "SkySpikes"|| other.tag == "Spikes")
        {
            gameOverControl.GameOver();
        }
    }

}

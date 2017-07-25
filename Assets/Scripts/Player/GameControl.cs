using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
using UnityEngine.SceneManagement;

public class GameControl : Singleton<GameControl> {

    public bool isDead = false;
    public bool isPlaying = false;
    private GameUI gameUI;
    private PlayerControl playerControl;
    private CameraManager cameraManager;
    private MapManager mapManager;
    private DataManager dataManager;
    private ProbabilityManager probabilityManager;

    private void Start()
    {
        gameUI = GameUI.Instance();
        playerControl = PlayerControl.Instance();
        cameraManager = CameraManager.Instance();
        mapManager = MapManager.Instance();
        dataManager = DataManager.Instance();
        probabilityManager = ProbabilityManager.Instance();
    }
    public IEnumerator GameOver(bool isFall)
    {
        gameUI.ButtonStopMove();
        if (isFall)
            yield return new WaitForSeconds(1.5f);
        if (!isDead)
        {
            yield return new WaitForSeconds(0.5f);
            Time.timeScale = 0;
            gameUI.GameOverScene();
            isDead = true;
            DataManager.instance.SaveScore();
        }
    }

    public void ReStartGame()
    {
        gameUI.ButtonBeginMove();
        dataManager.gameScroe = 0;
        ResetProbability();
        ResetMap();
        ResetPlayer();
        ResetCamera();
        Time.timeScale = 1;
    }

    private void ResetPlayer()
    {
        Destroy(playerControl.GetComponent<Rigidbody>());
        playerControl.z = 3;
        playerControl.x = 2;
        isDead = false;
        playerControl.StartGame();
    }

    private void ResetMap()
    {
        Transform[] sonTransform = mapManager.GetComponentsInChildren<Transform>();
        for (int i = 1; i < sonTransform.Length; i++)
        {
            GameObject.Destroy(sonTransform[i].gameObject);
        }
        mapManager.mapIndex = 0;

        mapManager.GetMapList().Clear();

        mapManager.offSetZ = 0;

        mapManager.CreateMap();
    }

    private void ResetCamera()
    {
        cameraManager.transform.position = cameraManager.initPos;
    }

    private void ResetProbability()
    {
        probabilityManager.pb_hole = 0;
        probabilityManager.pb_sky_spikes = 0;
        probabilityManager.pb_spikes = 0;
    }
}

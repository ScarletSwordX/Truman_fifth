using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 单例模式，确保只有一个GameManager实例
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // 游戏状态枚举
    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    // 当前游戏状态
    private GameState currentState = GameState.Playing;


    

    private void Start()
    {
        SetState(GameState.Playing);
    }

    private void Update()
    {
        HandleInput();
    }

    // 处理玩家输入
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // 切换游戏状态
    private void SetState(GameState newState)
    {
        switch (newState)
        {                       
            case GameState.Playing:
                OnPlaying();
                break;
            case GameState.Paused:
                OnPaused();
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
        }
        currentState = newState;
    }  

    /// <summary>
    /// 暂停/恢复游戏
    /// </summary>
    public void TogglePause()
    {
        if (currentState == GameState.Playing)
        {
            SetState(GameState.Paused);
            //这里可以写其他逻辑，比如激活暂停选项面板等等

        }
        else if (currentState == GameState.Paused)
        {
            SetState(GameState.Playing);


        }
    }

    /// <summary>
    /// 结束游戏
    /// </summary>
    public void EndGame()
    {
        SetState(GameState.GameOver);
    }

    // 状态切换时的处理逻辑


    private void OnPlaying()
    {
        Time.timeScale = 1f;
     
    }

    private void OnPaused()
    {
        Time.timeScale = 0f;
       
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        
    }

    /// <summary>
    /// 跳转场景（关卡名）
    /// </summary>
    /// <param name="sceneName"></param>
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

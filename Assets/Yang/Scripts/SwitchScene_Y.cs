using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchScene_Y : MonoBehaviour
{
    private GameObject Sign;
    private bool isInDoor = false;
    private GameObject Player;

    [Header("此门去往的下一个场景")]
    public GameState NextScene;
    [Header("Y轴位移距离")]
    public int Y_dis;


    public enum GameState
    {
        M_LivingRoom,
        O_LivingRoom,
        MainBedRoom,
        OtherBedRoom
    }


    private void Start()
    {
        // 获取第一个子物体的 GameObject
        Transform firstChildTransform = transform.GetChild(0);
        Sign = firstChildTransform.gameObject;
        Sign.SetActive(false);
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isInDoor == true)
        {
            VoiceManager.Instance.DoorVoice();
            switch(NextScene)
            {
                case GameState.M_LivingRoom:
                    Player.transform.position += new Vector3(0, -Y_dis, 0);
                    break;
                case GameState.O_LivingRoom:
                    Player.transform.position += new Vector3(0, Y_dis, 0);
                    break;
                case GameState.MainBedRoom:
                    Player.transform.position += new Vector3(0, Y_dis, 0);
                    break;
                case GameState.OtherBedRoom:
                    Player.transform.position += new Vector3(0, -Y_dis, 0);
                    break;
            }
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInDoor = true;
            Sign.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInDoor = false;
            Sign.SetActive(false);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter6SwithScene : MonoBehaviour
{
    public bool isF;
    public Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Switch();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isF = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isF = false;
    }
    void Switch()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            GameObject player = GameObject.FindWithTag("Player"); // 找到 Player 对象
        if (player != null) // 确保 Player 对象存在
        {
            player.transform.position = playerPosition; // 改变 Player 的位置
        }
        else
        {
            Debug.LogWarning("Player object not found! Make sure it has the correct tag.");
        }
    }
    }
}

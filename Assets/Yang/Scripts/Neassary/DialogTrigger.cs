using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject Sign;
    private bool isIn = false;
    [Header("配置对话系统")]
    public GameObject Dialog;

    private void Start()
    {
        Dialog.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isIn == true 
            && Chapter4CheckWin.Instance.AreAllCoinsActive() == false)
            Dialog.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isIn = true;
            Sign.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isIn = false;
            Sign.SetActive(false);
        }
    }

}

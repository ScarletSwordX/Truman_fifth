using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Sprites;
using UnityEngine;

public class CoinObtainer : MonoBehaviour
{
    private GameObject Sign;
    private bool isPlayerInSigin;
    [Header("过关检测脚本")]
    public Chapter4CheckWin Chacker;

   
    void Start()
    {
        Transform firstChildTransform = transform.GetChild(0);
        Sign = firstChildTransform.gameObject;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && isPlayerInSigin == true)
        {
            Chapter4CheckWin.Instance.CoinImages[Chapter4CheckWin.Instance.i].SetActive(true);
            Chapter4CheckWin.Instance.i += 1;
            Debug.Log(Chapter4CheckWin.Instance.i);
            Destroy(this.gameObject);
        }
        //else Sign.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sign.SetActive(true);
        Debug.Log("正在读取");
        isPlayerInSigin = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Sign.SetActive(false);
        isPlayerInSigin = false;
        //dialogBox.SetActive(false);
    }
}

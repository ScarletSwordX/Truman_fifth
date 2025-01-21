using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchScene_Y : MonoBehaviour
{
    private GameObject Sign;
    private bool isInDoor = false;
    [Header("此门去往的下一个场景名")]
    public string NextScene;

    private void Start()
    {
        Sign = GameObject.Find("Sign");
        Sign.SetActive(false);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) GameManager.Instance.SwitchScene(NextScene);
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

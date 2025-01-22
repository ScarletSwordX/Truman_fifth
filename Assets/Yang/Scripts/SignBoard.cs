using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBoard : MonoBehaviour
{
    private GameObject dialogBox;


    private bool isPlayerInSigin;

    // Start is called before the first frame update
    void Start()
    {
        Transform firstChildTransform = transform.GetChild(0);
        dialogBox = firstChildTransform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.F) &&*/ isPlayerInSigin)
        {
            dialogBox.SetActive(true);
        }
        else dialogBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //signText.SetActive(true);
        Debug.Log("ÕýÔÚ¶ÁÈ¡");
        isPlayerInSigin = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //signText.SetActive(false);
        isPlayerInSigin = false;
        //dialogBox.SetActive(false);
    }
}

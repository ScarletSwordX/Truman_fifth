using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isF;
    int a;
    int b;
    int c;
    public GameObject TextBox;
    public TextMeshProUGUI Text1;
    public string npcText1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        password();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isF = true;
        a = 0;
        b = 0;
        c = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isF=false;
        TextBox.SetActive(false);
        a = 0;
        b = 0;
        c = 0;
    }

    void password()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(true);
        }   
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            a = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) & a == 1)
        {
            b = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&  b == 1)
        {
            c = 1;
        }
        if (a == 1 & b == 1 & c == 1&Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(false);
            GameObject.Find("Closet").GetComponent<Closet>().enabled = true;
            this.enabled = false;
        }
    }
}

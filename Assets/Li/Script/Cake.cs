using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI Text;
    public GameObject Image;
    public string npcText;
    public bool isF;
    public bool isG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interaction();
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
        isF=false;
        if (isG)
        {
            TextBox.SetActive(false);
            Image.SetActive(false);
            GameObject One = this.gameObject;
            One.SetActive(false);
        }
    }

    void interaction()
    {
        if (isF&Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(true);
            Image.SetActive(true);
            Text.text = npcText;
            isG=true;
        }
        
    }
}

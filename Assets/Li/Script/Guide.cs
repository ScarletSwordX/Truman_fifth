using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI Text;
    public string npcText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TextBox.SetActive(true);
        Text.text = npcText;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextBox.SetActive(false);
    }
}

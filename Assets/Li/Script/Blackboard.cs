using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI Text;
    public string npcText;
    public bool isF;
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
        isF = false;
        TextBox.SetActive(false);
    }

    void interaction()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(true);
            Text.text = npcText;
        }

    }
}

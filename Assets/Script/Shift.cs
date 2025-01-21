using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shift : MonoBehaviour
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
        shift();
    }

    void shift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TextBox.SetActive(true);
            Text.text = npcText;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            TextBox.SetActive(false);
        }
    }
}

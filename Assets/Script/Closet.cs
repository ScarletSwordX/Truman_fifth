using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Closet : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI Text;
    public string npcText;
    public bool isF;
    public bool isG;   
    public GameObject Image;
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
        Image.SetActive(false);
        if (isG)
        {
            SceneManager.LoadScene("Scene2",LoadSceneMode.Single);
        }
    }

    void interaction()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(true);
            Image.SetActive(true);
            Text.text = npcText;
            isG = true;
        }

    }
}

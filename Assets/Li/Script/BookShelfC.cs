using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading;

public class BookShelfC : MonoBehaviour
{
    public bool isF;
    public GameObject Diary1;
    public TextMeshProUGUI Text1;
    public GameObject Diary2;
    public TextMeshProUGUI Text2;
    public GameObject Diary3;
    public TextMeshProUGUI Text3;
    public GameObject Number;
    public TextMeshProUGUI Text4;

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
        Diary1.SetActive(false);
        Diary2.SetActive(false);
        Diary3.SetActive(false);
        Number.SetActive(false);
    }

    void interaction()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            Diary1.SetActive(true);
            Diary2.SetActive(false);
            Diary3.SetActive(false);
            Number.SetActive(false);
        }
        if (isF & Input.GetKeyDown(KeyCode.G))
        {
            Diary1.SetActive(false);
            Diary2.SetActive(true);
            Diary3.SetActive(false);
            Number.SetActive(false);
        }
        if (isF & Input.GetKeyDown(KeyCode.H))
        {
            Diary1.SetActive(false);
            Diary2.SetActive(false);
            Diary3.SetActive(true);
            Number.SetActive(false);
        }
        if (isF & Input.GetKeyDown(KeyCode.R))
        {
            Diary1.SetActive(false);
            Diary2.SetActive(false);
            Diary3.SetActive(false);
            Number.SetActive(true);
        }
    }

}

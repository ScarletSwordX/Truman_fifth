using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chapter4CheckWin : MonoBehaviour
{

    public GameObject[] CoinImages;
    [HideInInspector]
    public int i = 0;
    private DialogManager dialogManager;
    [Header("���ù��ذ�ť")]
    public GameObject NextBut;
    [Header("���ø�̾��")]
    public GameObject FinSign;

    private bool isFinish = false;

    public static Chapter4CheckWin Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }


    void Start()
    {
        FinSign.SetActive(false);
        NextBut.SetActive(false);
        dialogManager =GetComponent<DialogManager>();
        foreach (var item in CoinImages)
        {
            item.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
            if (AreAllCoinsActive())
            {
                FinSign.SetActive(true);
            if (dialogManager != null)           
            dialogManager.enabled = false;
                
                if(Input.GetKeyDown(KeyCode.F) && isFinish == true)
                NextBut.SetActive(true);
            }
      
    }

    public bool AreAllCoinsActive()
    {
        if (CoinImages == null || CoinImages.Length == 0)
        {
            //Debug.LogWarning("û��Ӳ��ͼ�񱻷���");
            return false;
        }
        foreach (GameObject coinImage in CoinImages)
        {
            if (coinImage == null)
            {
                //Debug.LogWarning("Ӳ��ͼ�������д��ڿ�����");
                return false;
            }

            if (!coinImage.activeInHierarchy)
            {
                //Debug.Log($"Ӳ��ͼ�� {coinImage.name} δ����");
                return false;
            }
        }

        return true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFinish = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFinish = false;
        }
    }






}

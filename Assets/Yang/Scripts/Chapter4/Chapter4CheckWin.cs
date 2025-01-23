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
    [Header("配置过关按钮")]
    public GameObject NextBut;
    [Header("配置感叹号")]
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
            //Debug.LogWarning("没有硬币图像被分配");
            return false;
        }
        foreach (GameObject coinImage in CoinImages)
        {
            if (coinImage == null)
            {
                //Debug.LogWarning("硬币图像数组中存在空引用");
                return false;
            }

            if (!coinImage.activeInHierarchy)
            {
                //Debug.Log($"硬币图像 {coinImage.name} 未激活");
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

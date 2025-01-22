using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeveSelections : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("关卡选择")]
    public GameObject Levels;


    public void OnPointerEnter(PointerEventData eventData)
    {
        // 检查音效资源是否为空
        Levels.SetActive(true);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // Levels.SetActive(false);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeveSelections : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("�ؿ�ѡ��")]
    public GameObject Levels;


    public void OnPointerEnter(PointerEventData eventData)
    {
        // �����Ч��Դ�Ƿ�Ϊ��
        Levels.SetActive(true);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // Levels.SetActive(false);
    }

}
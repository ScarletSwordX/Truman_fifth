using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("鼠标悬停后放大尺寸")]
    public float zoomSize = 1.2f; // 默认值为1.2

    [Header("鼠标进入时播放的声音")]
    [SerializeField] private AudioClip enterSound;

    [Header("鼠标离开时播放的声音")]
    [SerializeField] private AudioClip exitSound;

    [Header("鼠标点击时播放的声音")]
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    private void Start()
    {
        // 获取或添加 AudioSource 组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 检查音效资源是否为空
        if (enterSound != null)
        {
            audioSource.PlayOneShot(enterSound);
        }

        // 放大 UI 元素
        transform.localScale = new Vector3(zoomSize, zoomSize, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 检查音效资源是否为空
        if (exitSound != null)
        {
            audioSource.PlayOneShot(exitSound);
        }

        // 还原 UI 元素大小
        transform.localScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 检查音效资源是否为空
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
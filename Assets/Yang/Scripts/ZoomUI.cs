using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("�����ͣ��Ŵ�ߴ�")]
    public float zoomSize = 1.2f; // Ĭ��ֵΪ1.2

    [Header("������ʱ���ŵ�����")]
    [SerializeField] private AudioClip enterSound;

    [Header("����뿪ʱ���ŵ�����")]
    [SerializeField] private AudioClip exitSound;

    [Header("�����ʱ���ŵ�����")]
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    private void Start()
    {
        // ��ȡ����� AudioSource ���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // �����Ч��Դ�Ƿ�Ϊ��
        if (enterSound != null)
        {
            audioSource.PlayOneShot(enterSound);
        }

        // �Ŵ� UI Ԫ��
        transform.localScale = new Vector3(zoomSize, zoomSize, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // �����Ч��Դ�Ƿ�Ϊ��
        if (exitSound != null)
        {
            audioSource.PlayOneShot(exitSound);
        }

        // ��ԭ UI Ԫ�ش�С
        transform.localScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // �����Ч��Դ�Ƿ�Ϊ��
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
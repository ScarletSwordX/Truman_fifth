using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using TMPro;

public class LoadingAnimation : MonoBehaviour
{
    public GameObject eventObj;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
           this.gameObject.SetActive(true);
    }

    public void EnterScene(string Sn)
    {
        // ��鲢���� Loading ����
        if (!this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(true);
            UnityEngine.Debug.LogWarning("Loading �����Ѽ���");
        }

        UnityEngine.Debug.Log("�ѷ���");

        StartCoroutine(LoadScene(Sn));
    }

    IEnumerator LoadScene(string Scenename)
    {
        animator.SetBool("Load in", true);
        animator.SetBool("Load out", false);
        yield return new WaitForSeconds(2.4f);

        AsyncOperation async = SceneManager.LoadSceneAsync(Scenename);
        async.completed += OnLoadedScene;

        // �ȴ��������
        while (!async.isDone)
        {
            yield return null;
        }
    }
    private void OnLoadedScene(AsyncOperation obj)
    {
        // ���»�ȡ animator ����
        animator = GameObject.Find("Loading").GetComponent<Animator>();
        animator.SetBool("Load in", false);
        animator.SetBool("Load out", true);
   
    }

}
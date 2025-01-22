using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonEntering : MonoBehaviour
{
    public GameObject targetObject; // 要更改文字的目标对象
    private TMP_Text textMeshPro;   // TextMeshPro 组件引用
    public int number = 0;

    void Start()
    {
        if (targetObject != null)
        {
            textMeshPro = targetObject.GetComponent<TMP_Text>();
            if (textMeshPro == null)
            {
                Debug.LogWarning("TMP_Text component not found on target object.");
            }
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }

public void AppendText(string newText)
{
    if (textMeshPro != null)
    {
        // 将传入的字符串拼接到当前文本后
        textMeshPro.text += newText;
    }
    else
    {
        Debug.LogWarning("TextMeshPro component not found on target object.");
    }
}

    public void ClearText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = string.Empty;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not found on target object.");
        }
    }

    public void IsTextEqualTo()
    {
        if (textMeshPro != null)
        {
// textMeshPro.text == number;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not found on target object.");
            // return false;
        }
    }

    void Update()
    {
        
    }
}
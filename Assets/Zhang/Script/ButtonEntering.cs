using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEntering : MonoBehaviour
{
    public GameObject targetObject; // 要更改文字的目标对象
    private Text uiText;           // UI Text 组件引用
    public int number = 0;

    void Start()
    {
        if (targetObject != null)
        {
            uiText = targetObject.GetComponent<Text>();
            if (uiText == null)
            {
                Debug.LogWarning("Text (Legacy) component not found on target object.");
            }
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }

    public void AppendText(string newText)
    {
        if (uiText != null)
        {
            // 将传入的字符串拼接到当前文本后
            uiText.text += newText;
        }
        else
        {
            Debug.LogWarning("Text (Legacy) component not found on target object.");
        }
    }

    public void ClearText()
    {
        if (uiText != null)
        {
            uiText.text = string.Empty;
        }
        else
        {
            Debug.LogWarning("Text (Legacy) component not found on target object.");
        }
    }

    public void IsTextEqualTo()
    {
        // if (uiText == number.ToString())
        // {
        //     // 检查文本内容是否等于 number（可进一步实现逻辑）
        //     // if (uiText.text == number.ToString()) { ... }
        // }
        // else
        // {
        //     Debug.LogWarning("Text (Legacy) component not found on target object.");
        // }
    }

    void Update()
    {
        // 可添加需要实时执行的逻辑
    }
}

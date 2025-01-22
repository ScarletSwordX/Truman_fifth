using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class DialogManager : MonoBehaviour
{
    /// <summary>
    /// 对话文件. csv格式
    /// </summary>
    public UnityEngine.TextAsset dialogDataFile;
    /// <summary>
    /// 左右两侧角色头像
    /// </summary>
    // Start is called before the first frame update
/*    public Sprite spriteLeft;
    public Sprite spriteRight;*/
    [Header("两位对话者姓名框")]
    //public Text nameText1;
    //public Text nameText2;
    public GameObject nameBar1;
    public GameObject nameBar2;
    [Header("场景中的对话文本显示处")]
    public Text dialogText;
    /*[Header("播放列表")]
    public List<Sprite> sprites = new List<Sprite>();*/

    //Dictionary<string,Sprite> imageDic = new Dictionary<string,Sprite>();

    public int DialogIndex; //当前索引
    private string[] DialogRows; //对话数组
    [Header("下一句对话配置按钮")]
    public Button nextButton;
    /// <summary>
    /// 选项按钮预制体
    /// </summary>
    [Header("选项按钮预制体")]
    public GameObject Selection;
    /// <summary>
    /// 选项按钮父节点，用于自动排列
    /// </summary>
    public Transform buttonGroup;

    private void Awake()
    {
        //imageDic["博士"] = sprites[0];
       // imageDic["乌安比尔"] = sprites[1];

    }

    void Start()
    {
        ReadText(dialogDataFile);//初始化文本，并分行
        ShowDialogRow();
    }

    public void UpdateText(string _text)
    {
        dialogText.text = _text;
    }
    public void UpdateImage(/*string _name,*/string _pos)//根据字符判断左右
    {
        if (_pos == "左")
        {
            //spriteLeft = imageDic[_name];
            nameBar2.SetActive(true);
            nameBar1.SetActive(false);
        }
        else if(_pos == "右")
        {
          //  spriteRight = imageDic[_name];
            nameBar1.SetActive(true);
            nameBar2.SetActive(false);
        }
    }

    public void ReadText(UnityEngine.TextAsset _textAsset)
    {
        DialogRows = _textAsset.text.Split('\n');//按照换行来将本文分为数组
        /*foreach (var row in rows)
        {
            string[] cell = row.Split(",");//cell字符串数组用“，”（逗号）隔开
        }*/
        Debug.Log("读取成功");
    }
    public void ShowDialogRow()
    {
        for (int i = 0; i < DialogRows.Length; i++)
        {
            string[] cell = DialogRows[i].Split(",");//cell字符串数组用“，”（逗号）隔开
            if (cell[0] == "#" && int.Parse(cell[1]) == DialogIndex)
            {
                nextButton.gameObject.SetActive(true);
                UpdateText(cell[4]);//第五位元素为 正文文本
                UpdateImage(/*cell[2],*/ cell[3]);//第三位元素图片名 第四位元素根据“左”或者“右”
                DialogIndex = int.Parse(cell[5]);
                break;
            }
            else if (cell[0] == "&" && int.Parse(cell[1]) == DialogIndex)//判断选项去向
            {
                nextButton.gameObject.SetActive(false);
                GenerateSelection(i);
            }
            else if (cell[0] == "END" && int.Parse(cell[1]) == DialogIndex)
            {
    
                this.gameObject.SetActive(false);
            }
               
        }
    }

    public void OnClickNext()
    {
        ShowDialogRow();
        
    }

    public void GenerateSelection(int _index)
    {
        string[] cell = DialogRows[_index].Split(",");
        if (DialogRows[_index].Split(',')[0]=="&")
        {
        GameObject button = Instantiate(Selection, buttonGroup);
            //绑定button触发的事件
            button.GetComponentInChildren<Text>().text = cell[4];
            button.GetComponent<Button>().onClick.AddListener(delegate {
                OnOptionClick(int.Parse(cell[5]));
                }) ;
        GenerateSelection(_index + 1);
        }
      
    }

    public void OnOptionClick(int _id)
    {
        DialogIndex = _id;
        ShowDialogRow();
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }

}

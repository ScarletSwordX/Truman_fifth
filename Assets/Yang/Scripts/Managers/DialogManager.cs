using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class DialogManager : MonoBehaviour
{
    /// <summary>
    /// �Ի��ļ�. csv��ʽ
    /// </summary>
    public UnityEngine.TextAsset dialogDataFile;
    /// <summary>
    /// ���������ɫͷ��
    /// </summary>
    // Start is called before the first frame update
/*    public Sprite spriteLeft;
    public Sprite spriteRight;*/
    [Header("��λ�Ի���������")]
    //public Text nameText1;
    //public Text nameText2;
    public GameObject nameBar1;
    public GameObject nameBar2;
    [Header("�����еĶԻ��ı���ʾ��")]
    public Text dialogText;
    /*[Header("�����б�")]
    public List<Sprite> sprites = new List<Sprite>();*/

    //Dictionary<string,Sprite> imageDic = new Dictionary<string,Sprite>();

    public int DialogIndex; //��ǰ����
    private string[] DialogRows; //�Ի�����
    [Header("��һ��Ի����ð�ť")]
    public Button nextButton;
    /// <summary>
    /// ѡ�ťԤ����
    /// </summary>
    [Header("ѡ�ťԤ����")]
    public GameObject Selection;
    /// <summary>
    /// ѡ�ť���ڵ㣬�����Զ�����
    /// </summary>
    public Transform buttonGroup;

    private void Awake()
    {
        //imageDic["��ʿ"] = sprites[0];
       // imageDic["�ڰ��ȶ�"] = sprites[1];

    }

    void Start()
    {
        ReadText(dialogDataFile);//��ʼ���ı���������
        ShowDialogRow();
    }

    public void UpdateText(string _text)
    {
        dialogText.text = _text;
    }
    public void UpdateImage(/*string _name,*/string _pos)//�����ַ��ж�����
    {
        if (_pos == "��")
        {
            //spriteLeft = imageDic[_name];
            nameBar2.SetActive(true);
            nameBar1.SetActive(false);
        }
        else if(_pos == "��")
        {
          //  spriteRight = imageDic[_name];
            nameBar1.SetActive(true);
            nameBar2.SetActive(false);
        }
    }

    public void ReadText(UnityEngine.TextAsset _textAsset)
    {
        DialogRows = _textAsset.text.Split('\n');//���ջ����������ķ�Ϊ����
        /*foreach (var row in rows)
        {
            string[] cell = row.Split(",");//cell�ַ��������á����������ţ�����
        }*/
        Debug.Log("��ȡ�ɹ�");
    }
    public void ShowDialogRow()
    {
        for (int i = 0; i < DialogRows.Length; i++)
        {
            string[] cell = DialogRows[i].Split(",");//cell�ַ��������á����������ţ�����
            if (cell[0] == "#" && int.Parse(cell[1]) == DialogIndex)
            {
                nextButton.gameObject.SetActive(true);
                UpdateText(cell[4]);//����λԪ��Ϊ �����ı�
                UpdateImage(/*cell[2],*/ cell[3]);//����λԪ��ͼƬ�� ����λԪ�ظ��ݡ��󡱻��ߡ��ҡ�
                DialogIndex = int.Parse(cell[5]);
                break;
            }
            else if (cell[0] == "&" && int.Parse(cell[1]) == DialogIndex)//�ж�ѡ��ȥ��
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
            //��button�������¼�
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

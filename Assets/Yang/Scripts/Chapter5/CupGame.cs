using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CupGame : MonoBehaviour
{
    [Header("���ز���")]
    public GameObject Win;

    public GameObject[] cups; // �������Ӷ���
    public Image coin; // Ӳ�Ҷ���
    public Button startButton; // ��ʼ��ť
    public Canvas canvas; // Canvas����
    public RectTransform panelRectTransform; // Panel��RectTransform
    public float moveDuration = 0.5f; // �ƶ�����ʱ��


    private int coinIndex; // ��ǰӲ�����ڱ��ӵ�����
    private bool isPlaying = false; // ��Ϸ�Ƿ���������
    private Vector3[] initialCupPositions; // �����ʼλ��

    void Start()
    {
        InitializeGame();

        // ����ÿ�����ӵĳ�ʼλ��
        initialCupPositions = new Vector3[cups.Length];
        for (int i = 0; i < cups.Length; i++)
        {
            initialCupPositions[i] = cups[i].transform.localPosition;
        }
    }

    void InitializeGame()
    {
        // ���ó�ʼ״̬
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = false; // ��ʼʱ���ɵ��
        }

        // ��Ӳ�ҷ����ڳ�ʼ���ӣ�B���ӣ�
        coin.rectTransform.SetParent(cups[1].GetComponent<RectTransform>(), false);
        coinIndex = 1;

        // ���ÿ�ʼ��ť�ļ�����
        startButton.onClick.AddListener(StartGame);

        // ȷ����ʼ��ť�ɵ��
        startButton.interactable = true;

        // ������Ϸ״̬��־
        isPlaying = false;
    }

    void StartGame()
    {
        if (!isPlaying)
        {
            isPlaying = true;

            // B��������λ��
            StartCoroutine(MoveDownCup(cups[1]));

            // �ӳ�һ��ʱ���ʼ����
            StartCoroutine(DelayAndSwapCups());
        }
    }

    IEnumerator MoveDownCup(GameObject cup)
    {
        Vector3 targetPosition = new Vector3(cup.transform.position.x, cups[0].transform.position.y, cup.transform.position.z);
        float startTime = Time.time;

        while (Time.time - startTime < moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            cup.transform.position = Vector3.Lerp(cup.transform.position, targetPosition, t);
            yield return null;
        }

        cup.transform.position = targetPosition;

        coinIndex = 1;
        coin.rectTransform.SetParent(cups[coinIndex].GetComponent<RectTransform>(), false);
    }

    IEnumerator DelayAndSwapCups()
    {
        yield return new WaitForSeconds(moveDuration + 0.5f); // �ȴ�B�����ƶ����

        // Ӳ�ұ�Ϊ͸��
        coin.color = new Color(1, 1, 1, 0);

        // ��ʼ��������λ��
        StartCoroutine(SwapCups());
    }

    IEnumerator SwapCups()
    {
        for (int i = 0; i < 10; i++)
        {
            int cupA = UnityEngine.Random.Range(0, 3);
            int cupB = UnityEngine.Random.Range(0, 3);

            // ����ѡ��ͬһ������
            while (cupA == cupB)
                cupB = UnityEngine.Random.Range(0, 3);

            // ����λ��
            StartCoroutine(MoveToPosition(cups[cupA], cups[cupB].GetComponent<RectTransform>().anchoredPosition));
            StartCoroutine(MoveToPosition(cups[cupB], cups[cupA].GetComponent<RectTransform>().anchoredPosition));

            // ����Ӳ��λ��
            if (coin.transform.parent == cups[cupA].transform)
            {
                coin.rectTransform.SetParent(cups[cupB].GetComponent<RectTransform>(), false);
                coinIndex = cupB;
            }
            else if (coin.transform.parent == cups[cupB].transform)
            {
                coin.rectTransform.SetParent(cups[cupA].GetComponent<RectTransform>(), false);
                coinIndex = cupA;
            }

            yield return new WaitForSeconds(0.4f); // ÿ�ν�����ȴ�һ��
        }

        // ����������������
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator MoveToPosition(GameObject obj, Vector2 targetPosition)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        float startTime = Time.time;

        while (Time.time - startTime < moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, t);
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
    }

    void CheckWin(GameObject selectedCup)
    {
        if (selectedCup == coin.transform.parent.gameObject)
        {
            Debug.Log("You win!");
            if (Win != null)
                Win.SetActive(true);
            coin.color = new Color(1, 1, 1, 1); // Ӳ�ұ�Ϊ��͸��
        }
        else
        {
            
            Debug.Log("You lose.");
            coin.color = new Color(1, 1, 1, 1);
            ResetGame(); // �������÷���
        }

        // ʹ���б��ӱ�Ϊ��͸��
        foreach (var cup in cups)
        {
            cup.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        // �������а�ť
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = false;
        }
    }

    void ResetGame()
    {
        // �ָ�ÿ�����ӵĳ�ʼλ��
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.localPosition = initialCupPositions[i];
        }

        // ����Ӳ��λ�õ���ʼ���ӣ�B���ӣ�
        coin.rectTransform.SetParent(cups[1].GetComponent<RectTransform>(), false);
        coinIndex = 1;

        // �������б��Ӱ�ť
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = false;
        }

        // ���ÿ�ʼ��ť
        startButton.interactable = true;

        // ������Ϸ״̬��־
        isPlaying = false;
    }

    void OnEnable()
    {
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().onClick.AddListener(() => CheckWin(cup));
        }
    }
}
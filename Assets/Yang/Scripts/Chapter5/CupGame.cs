using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CupGame : MonoBehaviour
{
    [Header("过关播报")]
    public GameObject Win;

    public GameObject[] cups; // 三个杯子对象
    public Image coin; // 硬币对象
    public Button startButton; // 开始按钮
    public Canvas canvas; // Canvas对象
    public RectTransform panelRectTransform; // Panel的RectTransform
    public float moveDuration = 0.5f; // 移动持续时间


    private int coinIndex; // 当前硬币所在杯子的索引
    private bool isPlaying = false; // 游戏是否正在运行
    private Vector3[] initialCupPositions; // 保存初始位置

    void Start()
    {
        InitializeGame();

        // 保存每个杯子的初始位置
        initialCupPositions = new Vector3[cups.Length];
        for (int i = 0; i < cups.Length; i++)
        {
            initialCupPositions[i] = cups[i].transform.localPosition;
        }
    }

    void InitializeGame()
    {
        // 设置初始状态
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = false; // 初始时不可点击
        }

        // 将硬币放置在初始杯子（B杯子）
        coin.rectTransform.SetParent(cups[1].GetComponent<RectTransform>(), false);
        coinIndex = 1;

        // 设置开始按钮的监听器
        startButton.onClick.AddListener(StartGame);

        // 确保开始按钮可点击
        startButton.interactable = true;

        // 重置游戏状态标志
        isPlaying = false;
    }

    void StartGame()
    {
        if (!isPlaying)
        {
            isPlaying = true;

            // B杯子向下位移
            StartCoroutine(MoveDownCup(cups[1]));

            // 延迟一段时间后开始交换
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
        yield return new WaitForSeconds(moveDuration + 0.5f); // 等待B杯子移动完成

        // 硬币变为透明
        coin.color = new Color(1, 1, 1, 0);

        // 开始交换杯子位置
        StartCoroutine(SwapCups());
    }

    IEnumerator SwapCups()
    {
        for (int i = 0; i < 10; i++)
        {
            int cupA = UnityEngine.Random.Range(0, 3);
            int cupB = UnityEngine.Random.Range(0, 3);

            // 避免选择同一个杯子
            while (cupA == cupB)
                cupB = UnityEngine.Random.Range(0, 3);

            // 交换位置
            StartCoroutine(MoveToPosition(cups[cupA], cups[cupB].GetComponent<RectTransform>().anchoredPosition));
            StartCoroutine(MoveToPosition(cups[cupB], cups[cupA].GetComponent<RectTransform>().anchoredPosition));

            // 更新硬币位置
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

            yield return new WaitForSeconds(0.4f); // 每次交换后等待一秒
        }

        // 交换结束后允许点击
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
            coin.color = new Color(1, 1, 1, 1); // 硬币变为不透明
        }
        else
        {
            
            Debug.Log("You lose.");
            coin.color = new Color(1, 1, 1, 1);
            ResetGame(); // 调用重置方法
        }

        // 使所有杯子变为不透明
        foreach (var cup in cups)
        {
            cup.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        // 禁用所有按钮
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = false;
        }
    }

    void ResetGame()
    {
        // 恢复每个杯子的初始位置
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.localPosition = initialCupPositions[i];
        }

        // 重置硬币位置到初始杯子（B杯子）
        coin.rectTransform.SetParent(cups[1].GetComponent<RectTransform>(), false);
        coinIndex = 1;

        // 禁用所有杯子按钮
        foreach (var cup in cups)
        {
            cup.GetComponent<Button>().interactable = false;
        }

        // 启用开始按钮
        startButton.interactable = true;

        // 重置游戏状态标志
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
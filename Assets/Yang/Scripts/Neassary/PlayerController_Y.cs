using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Y : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Filp();
        Voice();
    }

    private void Move()
    {
        Vector2 movement = rb.velocity;
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = movement;
        //����ƶ��ٶȾ���ֵ�Ƿ������ ����boolֵ
        bool isMove = Mathf.Abs(movement.x) > Mathf.Epsilon;
        anim.SetBool("isMove",isMove);
        
    }


    private void Voice()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            VoiceManager.Instance.walkVoice();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            VoiceManager.Instance.StopWalk();
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.R))
        {
            VoiceManager.Instance.FVoice();
        }
        /*else if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.R))
        {
            VoiceManager.Instance.StopF();
        }*/

    }


    private void Filp()
    {
        bool Speed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;//
        if (rb.velocity.x > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (rb.velocity.x < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //����һ����ת����Χ�� z ����ת z �ȡ�Χ�� x ����ת x �ȡ�Χ�� y ����ת y �ȣ�����˳��Ӧ��)
        }

    }


}

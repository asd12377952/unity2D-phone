using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    public FixedJoystick variableJoystick;

    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    Animator m_Animator;

    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //判断如果没有输入再获取摇杆的值
        horizontal = horizontal == 0 ? variableJoystick.Horizontal : horizontal;
        vertical = vertical == 0 ? variableJoystick.Vertical : vertical;


        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        //方法接受两个 float 参数，并返回布尔值；
        //如果两个 float 数值大致相等，则返回 true，
        //否则返回 false。
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalINput = !Mathf.Approximately(vertical, 0f);

        //根据水平和垂直数值，如果有一个移动就代表着行走
        bool isWalking = hasHorizontalInput || hasVerticalINput;

        m_Animator.SetBool("IsWalking", isWalking);
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //RotateTowards 接受四个参数：前两个是 Vector3，分别是旋转时背离和朝向的矢量。
        //接下来的两个参数是起始矢量和目标矢量之间的变化量：首先是角度变化（以弧度为单位），然后是大小变化。
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,
            m_Movement, turnSpeed * Time.deltaTime, 0f);

        m_Rotation = Quaternion.LookRotation(desiredForward);
    }


    void OnAnimatorMove()
    {
        //Animator 的 deltaPosition 是由于可以应用于此帧的根运动而导致的位置变化
        m_Rigidbody.MovePosition(m_Rigidbody.position + 
            m_Movement * m_Animator.deltaPosition.magnitude);

        m_Rigidbody.MoveRotation(m_Rotation);
    }
}

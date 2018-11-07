using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : CharacterBase {

    /// <summary>
         /// ゴーストの種類
         /// </summary>
    [SerializeField]
    enum Type
    {
        Near,  //悪霊(近)
        Far,  //悪霊(遠)
    }
    Type m_type = Type.Near;

    [SerializeField]
    bool m_canMove = true; //悪霊(遠)用　移動可能か

    /// <summary>
    /// スポーンの仕方
    /// </summary>
    [SerializeField]
    enum Spawn
    {
        Defalt,   // 最初からいる
        Approach, // 近づいたら出現
    }
    Spawn m_spawn = Spawn.Defalt;

    /// <summary>
    ///  ゴーストの状態
    /// </summary>
    enum MoveState
    {
        BeforBirth,//生まれる前
        Wait,      //その場待機
        Patrol,    //徘徊
        Chase,     //追跡

    }
    MoveState m_moveState;

    CharacterBase m_charcterBese;

    public GameObject m_syoujo;
    public GameObject m_akuryou;
    // Use this for initialization
    void Start()
    {
        m_charcterBese = GetComponent<CharacterBase>();

        //移動状態の初期値を作る
        switch (m_type)
        {
            case Type.Near:
                {
                    m_canMove = true; //悪霊(近)は移動可能

                    switch (m_spawn)
                    {
                        case Spawn.Defalt:
                            m_moveState = MoveState.Patrol;
                            break;
                        case Spawn.Approach:
                            m_moveState = MoveState.BeforBirth;
                            break;
                    }
                }
                break;
            case Type.Far:
                {
                    switch (m_spawn)
                    {
                        case Spawn.Defalt:
                            m_moveState = MoveState.Patrol;
                            break;
                        case Spawn.Approach:
                            m_moveState = MoveState.BeforBirth;
                            break;
                    }
                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_moveState)
        {
            case MoveState.BeforBirth:
                BeforBirth();
                break;

            case MoveState.Wait:
                Wait();
                break;

            case MoveState.Patrol:
                Patrol();
                break;

            case MoveState.Chase:
                Chase();
                break;
        }
    }
    void BeforBirth()
    {
       
    }
    void Wait()
    {
      
    }
    protected void Patrol()
    {
        Vector2 scale = transform.localScale;
        if (scale.x < 0)
        {
            base.m_moveSpeed *= 1f;
            Move();
        }
        else
        {
            base.m_moveSpeed *= -1f;
            Move();
        }

        transform.localScale = scale;
    }
    protected void Chase()
    {
        if (m_canMove == true)
        {
            Vector2 syoujoPos = m_syoujo.transform.position;
            Vector2 akuryouPos = m_akuryou.transform.position;
            Vector2 scale = transform.localScale;
            float moveDis = m_moveSpeed * Time.deltaTime;

            if (akuryouPos.x > syoujoPos.x)
            {

                if (scale.x < 0)
                {
                    scale.x *= -1f;
                }
                if (akuryouPos.x - syoujoPos.x > moveDis)
                {
                    m_moveSpeed *= -1f;
                    Move();
                }

            }
            else
            {
                if (scale.x > 0)
                {
                    scale.x *= -1f;
                }
                if (syoujoPos.x - akuryouPos.x > moveDis)
                {
                    m_moveSpeed *= 1f;
                    Move();
                }
            }
            transform.localScale = scale;
        }
    }
}

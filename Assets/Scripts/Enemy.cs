using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float m_hp = 100;
    private bool m_isAlive = true;
    public float Hp { get { return m_hp; }
        set { 
            m_hp = value;
            if(m_hp <= 0)
            {
                m_isAlive = false;
                Debug.Log("Bad Dude is now dead.");
            }
        } 
    }
    public bool IsAlive { 
        get { return m_isAlive; }
    }
}

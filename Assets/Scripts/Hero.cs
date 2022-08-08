using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
// Hero is inherited by Warrior, Wizard, and Priest classes
public class Hero : MonoBehaviour
{
    private float m_hp = 100;
    private float m_mp = 100;
    private float m_damageResistance = 1;
    private float m_jumpForce = 5;
    private Rigidbody m_heroRb;
    private UIHandler m_gameUI;

    protected bool m_isSelected = false;


    // ENCAPSULATION
    public float Hp { get { return m_hp; } set { m_hp = value; } }
    public float Mp { get { return m_mp; } set { m_mp = value; } }
    protected float DamageResistance { get { return m_damageResistance; } set { m_damageResistance = value; } }
    protected Rigidbody HeroRb { get { return m_heroRb; } set { m_heroRb = value; } }
    public bool IsSelected { get { return m_isSelected; } set { m_isSelected = value; } }
    public UIHandler GameUI { get { return m_gameUI; } set { m_gameUI = value; } }

    public Camera mainCamera;
    public Enemy badDude;

    // Start is called before the first frame update
    void Start()
    {
        m_heroRb = GetComponent<Rigidbody>();
        GameUI = FindObjectOfType<UIHandler>();
        if(GameUI == null)
        {
            Debug.LogError("Could not set m_gameUI!");
        }
        else
        {
            Debug.Log("GameUI set to " + GameUI.name);
        }
        StartCoroutine(PersistentDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            MovePlayer(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
    }

    public IEnumerator PersistentDamage()
    {
        while (Hp > 0 && badDude.IsAlive)
        {
            Hp -= 5 / DamageResistance;
            GameUI.UpdateHeroStats();
            yield return new WaitForSeconds(2);
        }
    }

    // ABSTRACTION
    public virtual void MovePlayer(float verticalInput, float horizontalInput)
    {
        var dirForward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized;
        var dirRight = new Vector3(mainCamera.transform.right.x, 0, mainCamera.transform.right.z).normalized;

        // transform.position = transform.position + ((dirForward + dirRight) * Time.deltaTime);
        if(HeroRb != null)
        {
            HeroRb.AddForce(dirForward * verticalInput);
            HeroRb.AddForce(dirRight * horizontalInput);
        }
    }

    // POLYMORPHISM
    // Unless overridden, such as by Priest and Wizard classes, a hero will have
    // the default action of jumping.
    public virtual void DoHeroAction()
    {
        // Check if hero has health and energy first!
        if(Hp > 0 && Mp > 0)
        {
            Mp -= 5;
            HeroRb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            if (Mp < 0)
            {
                Mp = 0;
            }
            GameUI.UpdateHeroStats();
        }
    }
}

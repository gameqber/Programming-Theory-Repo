using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Hero
{
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        HeroRb = GetComponent<Rigidbody>();
        GameUI = FindObjectOfType<UIHandler>();
        DamageResistance = 2;
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(PersistentDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                MovePlayer(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DoHeroAction();
            }
        }
    }

    // POLYMORPHISM
    // Overrides the method that makes the hero jump.
    public override void DoHeroAction()
    {
        // Check if hero has health and energy first!
        if (Hp > 0 && Mp > 0)
        {
            Mp -= 5;
            foreach(var player in players)
            {
                player.GetComponentInParent<Hero>().Hp += 10;
                if(player.GetComponentInParent<Hero>().Hp > 100)
                {
                    player.GetComponentInParent<Hero>().Hp = 100;
                }
            }
            if (Mp < 0)
            {
                Mp = 0;
            }
            GameUI.UpdateHeroStats();
        }
    }
}

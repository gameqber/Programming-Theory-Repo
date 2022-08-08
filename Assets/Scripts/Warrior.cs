using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{

    // Start is called before the first frame update
    void Start()
    {
        HeroRb = GetComponent<Rigidbody>();
        GameUI = FindObjectOfType<UIHandler>();
        DamageResistance = 10;
        StartCoroutine(PersistentDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected) {
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
}

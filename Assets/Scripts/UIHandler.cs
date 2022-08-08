using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    private Hero m_selectedHero = null;
    private Enemy m_enemy = null;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerEnergyText;
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyHealthText;

    // ENCAPSULATION
    // Protects m_selectedHero by making get private, only allowing UIHandler to retrieve it.
    public Hero SelectedHero { set { m_selectedHero = value; } private get { return m_selectedHero; } }
    // Start is called before the first frame update
    void Start()
    {
        m_enemy = FindObjectOfType<Enemy>();
        if (m_enemy != null)
        {
            enemyNameText.SetText(MainManager.Instance.EnemyName);
            enemyHealthText.SetText("Health: " + m_enemy.Hp.ToString("0.0"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHeroStats()
    {
        if(SelectedHero != null)
        {
            playerNameText.SetText(m_selectedHero.name);
            playerHealthText.SetText("Health: " + m_selectedHero.Hp.ToString("0.0"));
            playerEnergyText.SetText("Energy: " + m_selectedHero.Mp.ToString("0.0"));
        }
        if (m_enemy != null)
        {
            enemyNameText.SetText(MainManager.Instance.EnemyName);
            enemyHealthText.SetText("Health: " + m_enemy.Hp.ToString("0.0"));
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

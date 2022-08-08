using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject marker;
    public GameObject[] players;

    private Hero m_Selected = null;
    private UIHandler m_gameUI;
    // Start is called before the first frame update
    void Start()
    {
        marker.SetActive(false);
        players = GameObject.FindGameObjectsWithTag("Player");
        m_gameUI = FindObjectOfType<UIHandler>();
    }

    public void HandleSelection()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var hero = hit.collider.GetComponentInParent<Hero>();
            m_Selected = hero;
            foreach(var singleHero in players)
            {
                singleHero.GetComponentInParent<Hero>().IsSelected = false;
            }
            if(hero != null)
            {
                hero.IsSelected = true;
                m_gameUI.SelectedHero = hero;
            }
            m_gameUI.UpdateHeroStats();
            //check if the hit object have a IUIInfoContent to display in the UI
            //if there is none, this will be null, so this will hid the panel if it was displayed
            /* var uiInfo = hit.collider.GetComponentInParent<UIMainScene.IUIInfoContent>();
            UIMainScene.Instance.SetNewInfoContent(uiInfo); */
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }

        MarkerHandling();
    }

    void MarkerHandling()
    {
        if (m_Selected == null && marker.activeInHierarchy)
        {
            marker.SetActive(false);
            marker.transform.SetParent(null);
        }
        else if (m_Selected != null && marker.transform.parent != m_Selected.transform)
        {
            marker.SetActive(true);
            // marker.transform.SetParent(m_Selected.transform, false);
            // marker.transform.localPosition = Vector3.zero;
            marker.transform.position = m_Selected.transform.position;
        }
    }
}

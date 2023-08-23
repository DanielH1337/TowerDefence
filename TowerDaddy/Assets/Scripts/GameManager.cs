using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    int UILayer;
    public GameObject SlidePanelGO;
    public Animator SlidePanel;
    private bool sliderCheck;
    //private float slidePanelPosition;
    public BuildManager buildManager;
    private List<bool> SlidePanelCheckList = new List<bool>();
    public GameObject[] enemyList;

    private void Start()
    {

        
        
        UILayer = LayerMask.NameToLayer("UI");
        sliderCheck =true;
        StartCoroutine(PanelSlider());
        SlidePanelCheckList.Add(false);
        SlidePanelCheckList.Add(true);
    }

    private void Update()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        // print(IsPointerOverUIElement() ? "Over UI" : "Not over UI");
        if (Input.GetKeyDown("space"))
        {
            for (int i = 0; i < SlidePanelCheckList.Count; i++)
            {
                Debug.Log(SlidePanelCheckList[i]);
            }
        }
    }
    public void FirstPanelSlide()
    {
        if(buildManager.towerLevels.Count == 1)
        {
            StartCoroutine(SlidePanelDelayAway());
        }
    }

     
    IEnumerator PanelSlider()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (sliderCheck)
            {
                SlidePanelCheckList.Insert(0, IsPointerOverUIElement());
                if (IsPointerOverUIElement() && SlidePanelCheckList[0] != SlidePanelCheckList[1])
                {
                    sliderCheck = false;
                    StartCoroutine(SlidePanelDelayBack());

                }
                if(!IsPointerOverUIElement() && SlidePanelCheckList[0] != SlidePanelCheckList[1])
                {
                    sliderCheck = false;
                    StartCoroutine(SlidePanelDelayAway());
                }
            }
            if(SlidePanelCheckList.Count > 2)
            {
                SlidePanelCheckList.RemoveAt(2);
            }
        }
    }
    IEnumerator SlidePanelDelayBack()
    {
        if (SlidePanel.isActiveAndEnabled) SlidePanel.SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
        sliderCheck = true;
    }
    IEnumerator SlidePanelDelayAway()
    {
        if (SlidePanel.isActiveAndEnabled) SlidePanel.SetTrigger("Away");
        yield return new WaitForSeconds(0.5f);
        sliderCheck = true;

    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

}

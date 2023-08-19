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
    private float slidePanelPosition;
    //private float slidePanelPosition;
    private List<bool> SlidePanelCheckList = new List<bool>();

    private void Start()
    {
        
        slidePanelPosition = SlidePanelGO.transform.position.x;
        Debug.Log(slidePanelPosition);
        UILayer = LayerMask.NameToLayer("UI");
        sliderCheck =true;
        StartCoroutine(PanelSlider());
        SlidePanelCheckList.Add(false);
        SlidePanelCheckList.Add(true);
    }

    private void Update()
    {

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
        StartCoroutine(SlidePanelDelayAway());
    }

     
    IEnumerator PanelSlider()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.1f);
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
       // Debug.Log("Back");
       // SlidePanelGO.layer = 0;
        if (SlidePanel.isActiveAndEnabled) SlidePanel.SetTrigger("Back");
        yield return new WaitForSeconds(1f);
        sliderCheck = true;
      //  SlidePanelGO.layer = 5;
     
        
    }
    IEnumerator SlidePanelDelayAway()
    {
       // Debug.Log("Away");
      //  SlidePanelGO.layer = 0;
        if (SlidePanel.isActiveAndEnabled) SlidePanel.SetTrigger("Away");
        yield return new WaitForSeconds(1f);
        sliderCheck = true;
      //  SlidePanelGO.layer = 5;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class SetNavigation : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPostion = Vector3.zero;
    private int currentFloor = 1;

    private bool lineToggle = false;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    // Update is called once per frame
    private void Update()
    { 
        if (lineToggle && targetPostion != Vector3.zero){
            NavMesh.CalculatePath(transform.position, targetPostion, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            Vector3[] calculatePathAndOffset = AddLineOffset();
            line.SetPositions(calculatePathAndOffset);
        }
    }

    public void SetCurrentNavigationTarget(int selectedValue){
        targetPostion = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null){
            if (!line.enabled){
                ToggleVisibility();
            }
            targetPostion = currentTarget.PositionObject.transform.position;
        }
    }

    public void ToggleVisibility(){
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber){
        currentFloor = floorNumber;
        SetNavigationTargetDropDownOptions(currentFloor);
    }


    private Vector3[] AddLineOffset(){
        if (navigationYOffset.value == 0){
            return path.corners;
        }
        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++){
            calculatedLine[i] = path.corners[i] + new Vector3(0,navigationYOffset.value, 0);
        }
        return calculatedLine;
    }

    private void SetNavigationTargetDropDownOptions(int floorNumber){
        navigationTargetDropDown.ClearOptions();
        navigationTargetDropDown.value = 0;

        if (line.enabled){
            ToggleVisibility();
        }
        if (floorNumber == 1){
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("401"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("402"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("403"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("404"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("405"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("406a"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("406b"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("407"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("408"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("409"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("410"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("411"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Washroom1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Washroom2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RightEntryExit1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LeftEntryExit1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Cabine1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Cabine2"));
        }
        if (floorNumber == 2){
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("501"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("502"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("503"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("504"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("505"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("506a"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("506b"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("507"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("508"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("509"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("510"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("511"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Washroom11"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Washroom22"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RightEntryExit2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LeftEntryExit2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Cabine11"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Cabine22"));
        }
    }
}

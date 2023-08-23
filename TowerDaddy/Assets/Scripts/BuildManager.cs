using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public int towerLevel;
    public int maxLevels;
    public GameObject selectedTurret;
    public List<GameObject> towerLevels;
    public TowerLevel currentLevel; 
    public int levelHeight = 10;
    public GameObject levelPrefab;
    public GameObject towerBase;
    public GameObject cameraRotator;
    public GameObject levelSettingsPanel;
    public Text currentLevelSettings;
    public float turretAmount;
    public float turretAngle; 
    public Text turretAmountText;
    public Text turretAngleText;
    public Slider amountSlider;
    public Slider angleSlider; 





    // Start is called before the first frame update
    void Start()
    {
        towerBase = GameObject.FindGameObjectWithTag("TowerBase");
        currentLevelSettings = levelSettingsPanel.transform.Find("CurrentLevelText").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevel()
    {
        if(levelSettingsPanel.activeSelf == false)
        {
            levelSettingsPanel.SetActive(true);
            ShowTurrets();

        }

        
        if (towerLevels.Count < maxLevels)
        {
            GameObject level =  Instantiate(levelPrefab, towerBase.transform.position + new Vector3(0, 8 + 10 * (towerLevels.Count), 0), Quaternion.identity);
            currentLevel = level.GetComponent<TowerLevel>();
            level.transform.parent = towerBase.transform;
            towerLevels.Add(level);
            towerLevel = towerLevels.Count;
            MoveCamera(towerLevels.Count);

        }


    }

    public void ShowTurrets()
    {
        Object[] TurretPrefabs = Resources.LoadAll("Turrets", typeof(GameObject));

        foreach (Object turretObject in TurretPrefabs)
        {
            GameObject turret = Instantiate(Resources.Load("TurretButton") as GameObject);
            turret.transform.SetParent(levelSettingsPanel.transform.Find("SelectTurret").GetChild(0).transform);
            turret.transform.GetChild(0).GetComponent<Text>().text = turretObject.name;
            //turret.GetComponent<Button>().onClick.AddListener(() => this.SelectTurret(turretObject.name));
           // tempButton.onClick.AddListener(() => ButtonOnClick(i));
            turret.GetComponent<Button>().onClick.AddListener(() => SelectTurret(turretObject.name));

        }

        /*
        GameObject turret = Instantiate(Resources.Load("TurretButton"), levelSettingsPanel.transform.Find("SelectTurret").GetChild(0).transform.position + new Vector3(-80, -50, 0), Quaternion.identity) as GameObject;
        turret.transform.parent = levelSettingsPanel.transform.Find("SelectTurret").GetChild(0).transform;
        */
    }

    public void SelectTurret(string turret)
    {
        selectedTurret = Resources.Load("Turrets/"+turret) as GameObject;
        PopulateTurrets(turretAmount, turretAngle);
    }

    public void PopulateTurrets(float amt, float ang)
    {
        currentLevel.installedTurrets.Clear();
        Destroy(GameObject.Find("LevelParent"+towerLevel));
        GameObject levelParent = new GameObject();
        levelParent.name = "LevelParent"+towerLevel;
        levelParent.transform.position = towerLevels[towerLevel - 1].transform.position;
        levelParent.transform.SetParent(towerLevels[towerLevel - 1].transform);
        

        for (int i = 0; i < amt; i++)
        {
            GameObject emptyGO = new GameObject();
            emptyGO.name = "TurrentParent";
            //Instantiate(emptyGO, towerLevels[towerLevel-1].transform.position, Quaternion.identity);
            
            GameObject tur = Instantiate(selectedTurret, emptyGO.transform.position, Quaternion.identity);
            tur.transform.SetParent(emptyGO.transform);
            tur.transform.position += new Vector3(0, 0, 5);

            
            emptyGO.transform.position = towerLevels[towerLevel - 1].transform.position;
            emptyGO.transform.rotation = Quaternion.Euler(0, (ang / amt)*i, 0);
            currentLevel.installedTurrets.Add(emptyGO);
            emptyGO.transform.SetParent(levelParent.transform);
        }
        currentLevel.level = towerLevel;
        currentLevel.amountOfTurrets = currentLevel.installedTurrets.Count;
        currentLevel.angle = Mathf.RoundToInt(ang);


    }

    public void NextLevel()
    {
        if (towerLevel < towerLevels.Count)
        {
            towerLevel++;
            MoveCamera(towerLevel);
        }
    }

    public void PreviousLevel()
    {
        if (towerLevel > 1)
        {
            towerLevel--;
            MoveCamera(towerLevel);
        }
    }

    public void MoveCamera(int currentLevelNumber)
    {
        
        currentLevelSettings.text = currentLevelNumber.ToString();
        currentLevel = towerLevels[currentLevelNumber - 1].GetComponent<TowerLevel>();
        turretAmount = currentLevel.installedTurrets.Count;
        turretAngle = currentLevel.angle;
        amountSlider.value = currentLevel.installedTurrets.Count;
        angleSlider.value = currentLevel.angle;
        
        turretAmountText.text = currentLevel.installedTurrets.Count.ToString();
        turretAngleText.text = currentLevel.angle.ToString();
        StopAllCoroutines();
        Vector3 beginPos = cameraRotator.transform.position;
        Vector3 endPos = new Vector3(towerBase.transform.position.x, towerBase.transform.position.y +10*currentLevelNumber, towerBase.transform.position.z);
        
        StartCoroutine(Move(beginPos, endPos, 1));

    }

    public void AdjustTurretAmount(float amt)
    {
        turretAmount = amt;
        turretAmountText.text = Mathf.RoundToInt(amt).ToString();
        if (currentLevel.installedTurrets.Count > 0)
        {
            currentLevel.AdjustTurretAmount(Mathf.RoundToInt(amt));
        }

    }

    public void AdjustAngleAmount(float amt)
    {
        turretAngle = amt; 
        turretAngleText.text = Mathf.RoundToInt(amt).ToString();

        
        if (currentLevel.installedTurrets.Count > 0)
        {
            currentLevel.AdjustTurretAngle(Mathf.RoundToInt(amt));
        }
        


    }
     

    IEnumerator Move(Vector3 beginPos, Vector3 endPos, float time)
    {
        cameraRotator.GetComponent<RotateCamera>().canMove = false;
        
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            cameraRotator.transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
       
        cameraRotator.GetComponent<RotateCamera>().canMove = true;
    }


    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Current Level: " + towerLevel);
        if (selectedTurret)
        {
            GUI.Label(new Rect(10, 30, 100, 20), "Selected Turret: " + selectedTurret.name);
        }
        GUI.Label(new Rect(10, 50, 100, 20), "CurrentLevel: " + currentLevel);
    }


}

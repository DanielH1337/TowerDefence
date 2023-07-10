using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : MonoBehaviour
{

    public int level;
    public List<GameObject> installedTurrets;
    public int amountOfTurrets; 
    public int angle;
    //public GameObject selectedTurret;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustTurretAmount(int amount)
    {

        if(amount > installedTurrets.Count)
        {
            Addturret();
        }

        if(amount < installedTurrets.Count)
        {
            RemoveTurret();
        }


    }

    public void AdjustTurretAngle(int newAngle)
    {
        angle = newAngle;
        int i = 0;
        foreach (GameObject tur in installedTurrets)
        {
            tur.transform.rotation  = Quaternion.Euler(0, (angle / installedTurrets.Count) * i, 0);
            i++;
        }
        

    }

    public void UpdateTurretPositions()
    {
        

    }

    public void Addturret()
    {
        GameObject newTurret =  Instantiate(installedTurrets[0]);
        newTurret.transform.position = installedTurrets[0].transform.position;
        newTurret.transform.SetParent(installedTurrets[0].transform.parent);
        installedTurrets.Add(newTurret);
        AdjustTurretAngle(angle);
    }

    public void RemoveTurret()
    {
        Destroy(installedTurrets[installedTurrets.Count - 1]);
        installedTurrets.RemoveAt(installedTurrets.Count - 1);     
        AdjustTurretAngle(angle);
        

    }

}

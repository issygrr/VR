using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<GameObject> doors;
    public List<GameObject> switches;

    public Dictionary<GameObject, GameObject> switchDoorMap;

    void Start()
    {
        switchDoorMap = new Dictionary<GameObject, GameObject>();
        if(doors.Count != switches.Count)
        {
            Debug.LogError("numb of doors and switches dont matchs");
            return;
        }

        for (int i = 0; i < switches.Count; i++)
        {
            GameObject door = doors[i];
            GameObject switchObj = switches[i];
            switchDoorMap.Add(switchObj, door);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SwitchActivateManage();
    }

    void SwitchActivateManage()
    {
        for (int i = 0; i < switches.Count; i++)
        {
            GameObject switchObj = switches[i];

            DoorSwitch1 switchComponent = switchObj.GetComponent<DoorSwitch1>();
            if (switchComponent.isActivated)
            {
                if (switchDoorMap.ContainsKey(switchObj))
                {
                    GameObject door = switchDoorMap[switchObj];
                    OpenDoor(door);
                }
            }
        }
    }
    public void OpenDoor(GameObject door)
    {
        Door doorComponent = door.GetComponent<Door>();
        doorComponent.Open();
    }
}

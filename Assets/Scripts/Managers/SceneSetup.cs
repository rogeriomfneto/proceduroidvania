using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetup : MonoBehaviour
{
    void Start() {
        setKey();
        setDoors();
    }

    private void setKey() {
        Debug.Log("setKey:");
        SceneData sceneData = ScenesManager.instance.getSceneData(SceneManager.GetActiveScene().name);
        Debug.Log("keyType = " + sceneData.keyType);
        GameObject key = GameObject.Find("Key");
        key.SetActive(sceneData.keyType != KeysEnum.None); 
    }

    private void setDoors() {
        Debug.Log("setDoors:");
        for (int i = 1; i <= 4; i++) {
            string doorString = "Door" + i;
            DoorData doorData = ScenesManager.instance.getDoorData(SceneManager.GetActiveScene().name, doorString);
            GameObject door = GameObject.Find(doorString);
            door.SetActive(doorData.active);
            DoorAnimation da = door.GetComponent<DoorAnimation>();
            da.keyType = doorData.keyType;
            Debug.Log(doorString + ": " + doorData.keyType);
        }
    }
        
}

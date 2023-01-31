using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerSingleton instance;

    private PlayerController playerController;

    void Awake() {
        if (instance == null) {
            instance = this;
            playerController = GetComponent<PlayerController>();
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}

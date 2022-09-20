using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private PlayerController player;
    private PlayerKeysManager playerKeys;

    [SerializeField]
    private Collider2D doorBlocker;

    [SerializeField]
    private float distanceToOpen = 7.5f;

    [SerializeField]
    private KeysEnum keyType;

    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start() {
        player = PlayerSingleton.instance.GetComponent<PlayerController>();
        playerKeys = PlayerSingleton.instance.GetComponent<PlayerKeysManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldOpenDoor()) {
            anim.SetBool("isOpenning", true);
            doorBlocker.enabled = false;
        } else {
            anim.SetBool("isOpenning", false);
            doorBlocker.enabled = true;
        }
    }

    private bool shouldOpenDoor() {
        return Vector3.Distance(transform.position, player.transform.position) < distanceToOpen
            && playerKeys.hasKey(keyType);
    }
}

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
    private KeysEnum keyType = KeysEnum.None;

    private Animator anim;

    private SpriteRenderer sprite;

    void Awake() {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start() {
        player = PlayerSingleton.instance.GetComponent<PlayerController>();
        playerKeys = PlayerSingleton.instance.GetComponent<PlayerKeysManager>();
        // sprite.color = getDoorColor(keyType);
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = getDoorColor(keyType);
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
    
    private Color getDoorColor(KeysEnum key) {
        switch(key) {
            case KeysEnum.Blue:
                return new Color(.2f, .2f, 1, 1);
            case KeysEnum.Orange:
                return new Color(1, .5f, 0, 1);
            case KeysEnum.Purple:
                return new Color(.5f, 0, 1, 1);
            case KeysEnum.Red:
                return new Color(1, .2f, .2f, 1);
            default:
                return new Color(1, 1, 1, 1);
        }
    }
}

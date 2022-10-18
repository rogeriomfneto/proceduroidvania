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

    public KeysEnum keyType = KeysEnum.None;

    [SerializeField]
    private GameObject keyTypeDisplay;

    [SerializeField]
    private Sprite[] keysArray;

    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start() {
        player = PlayerSingleton.instance.GetComponent<PlayerController>();
        playerKeys = PlayerSingleton.instance.GetComponent<PlayerKeysManager>();
       
        setSprite();
    }

    private void setSprite() {
        SpriteRenderer keyTypeDisplayRenderer = keyTypeDisplay.GetComponent<SpriteRenderer>();
        if (keyType != KeysEnum.None) {
            keyTypeDisplayRenderer.sprite = getSpriteByKeyType(keyType);
        } else {
            keyTypeDisplayRenderer.sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        setSprite();
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

    public Sprite getSpriteByKeyType(KeysEnum keyType) {
        return keysArray[(int) keyType];
    }
}

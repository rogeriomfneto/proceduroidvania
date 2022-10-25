using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAction : MonoBehaviour
{
    [SerializeField]
    public KeysEnum keyType;

    [SerializeField]
    private Sprite[] keysArray;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        spriteRenderer.sprite = getSpriteByKeyType(keyType);
    }

    private void Update() {
        spriteRenderer.sprite = getSpriteByKeyType(keyType);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerKeysManager manager = other.GetComponent<PlayerKeysManager>();
            manager.addKey(keyType);
            Destroy(gameObject);
        }   
    }

    public Sprite getSpriteByKeyType(KeysEnum keyType) {
        return keysArray[(int) keyType];
    }


}

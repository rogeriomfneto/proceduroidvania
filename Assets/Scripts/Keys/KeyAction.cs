using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAction : MonoBehaviour
{
    [SerializeField]
    private KeysEnum keyType;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerKeysManager manager = other.GetComponent<PlayerKeysManager>();
            manager.addKey(keyType);
            Destroy(gameObject);
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeysManager : MonoBehaviour
{
    private List<KeysEnum> keys = new List<KeysEnum>{ KeysEnum.None };

    public void addKey(KeysEnum newKey) {
        keys.Add(newKey);
    }

    public bool hasKey(KeysEnum keyType) {
        return keys.Contains(keyType);
    }
}

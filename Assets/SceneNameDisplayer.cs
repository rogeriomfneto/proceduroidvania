using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneNameDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro tmp;

    void Start()
    {
        string sceneName = ScenesManager.instance.getCurrentSceneName();
        tmp.SetText(sceneName.ToUpper());
    }

}

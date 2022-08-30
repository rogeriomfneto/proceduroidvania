using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private float distanceToOpen = 7.5f;

    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToOpen) {
            anim.SetBool("isOpenning", true);
        } else {
            anim.SetBool("isOpenning", false);
        }
    }
}

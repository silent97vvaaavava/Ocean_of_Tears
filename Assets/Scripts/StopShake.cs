using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopShake : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void Stop()
    {
        animator.SetBool("Hit", false);
    }
}

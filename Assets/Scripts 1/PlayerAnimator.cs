using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    
    private const string IS_WALKING = "IsWalking";
    
    [SerializeField] protected Player player;
    
    protected Animator animator;

    protected virtual void Awake() {
       animator = GetComponent<Animator>();
       
    }

    protected virtual void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
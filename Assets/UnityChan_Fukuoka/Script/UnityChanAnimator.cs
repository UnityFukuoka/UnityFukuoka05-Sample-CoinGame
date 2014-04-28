using UnityEngine;
using System.Collections;

public class UnityChanAnimator {
    private Animator unitychanAnimator;
    public UnityChanAnimator(GameObject unitychan)
    {
        unitychanAnimator = unitychan.GetComponent<Animator>();
        unitychanAnimator.speed = 1.5F;
    }

    public void SetLocomotion(float speed, float direction)
    {
        unitychanAnimator.SetFloat("Speed", speed);
        unitychanAnimator.SetFloat("Direction", direction);
    }

    public void SetJump()
    {
        // 既にジャンプ状態なら何もしない
        if(unitychanAnimator.GetBool("Jump")){return;}
        unitychanAnimator.SetTrigger("Jump");
    }

    public void SetWin()
    {
        unitychanAnimator.speed=1;
        unitychanAnimator.SetTrigger("Win");
    }

    public void SetLose()
    {
        unitychanAnimator.speed=1;
        unitychanAnimator.SetTrigger("Lose");
    }
}

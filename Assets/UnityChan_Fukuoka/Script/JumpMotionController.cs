using UnityEngine;
using System.Collections;

public class JumpMotionController : MonoBehaviour {

    private UnityChan parent;
    private Animator animator;
    /// <summary>
    /// アニメーションのデフォルトの再生速度
    /// </summary>
    private float defaultSpeed;

    void Start()
    {
        parent = GetComponent<UnityChan>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// ジャンプモーションで、足が離れる瞬間に呼び出されるメソッド
    /// </summary>
    void OnJumpStart()
    {
        defaultSpeed = animator.speed;
        // キャラクターをジャンプさせる
        rigidbody.AddForce(Vector3.up * parent.parameter.jump, ForceMode.VelocityChange);
    }

    /// <summary>
    /// ジャンプモーションで、頂点のフレームで呼び出されるメソッド
    /// </summary>
    void OnJumpTopPoint()
    {
        // アニメーションを停止して、着地判定のチェックを行う
        animator.speed = 0;
        StartCoroutine(CheckFall());
    }

    /// <summary>
    /// ジャンプモーションで、足が地上に着いたときに呼ばれるメソッド
    /// </summary>
    void OnJumpEnd()
    {
        animator.SetBool("Jump",false);
    }

    /// <summary>
    /// 足下との距離を計算して、一定距離まで近づいたらアニメーションを再会させる
    /// </summary>
    /// <returns>The fall.</returns>
    IEnumerator CheckFall()
    {
        // 着地判定を調べる回数
        int fallCheckLimit = 100;
        // 着地判定チェックを行う時間間隔
        float waitTime = 0.05F;
        // 着地モーションへの移項を許可する距離。ジャンプ力に比例する
        float landingDistance = parent.parameter.jump / 3F;
        // 規定回数チェックして成功しない場合も着地モーションに移行する
        for(int count = 0;count < fallCheckLimit; count++)
        {
            if(IsLandingRange(landingDistance)) break;
            yield return new WaitForSeconds(waitTime);
        }
        animator.speed = defaultSpeed;
    }

    /// <summary>
    /// 床との距離を計算して、着地モーションに移行してよいかを返す
    /// </summary>
    /// <returns><c>true</c> if this instance is landing range the specified landingDistance; otherwise, <c>false</c>.</returns>
    /// <param name="landingDistance">Landing distance.</param>
    private bool IsLandingRange(float landingDistance)
    {
        var raycast = new RaycastHit();
        var raycastSuccess = Physics.Raycast(transform.position, Vector3.down, out raycast);
        if(raycastSuccess)
        {
            if(raycast.collider.gameObject.tag == "Coin") return false;
            // レイを飛ばして、成功且つ一定距離内であった場合、着地モーションへ移項させる
            return raycast.distance < landingDistance;
        }
        return false;
    }
}

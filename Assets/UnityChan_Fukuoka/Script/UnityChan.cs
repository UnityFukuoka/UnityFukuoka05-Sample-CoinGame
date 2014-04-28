using UnityEngine;
using System.Collections;

public class UnityChan : MonoBehaviour {

    private bool canCharacterControll = true;
    private UnityChanAnimator animator;
    public UnityChanParameter parameter;
    // Use this for initialization
    void Start () {
        animator = new UnityChanAnimator(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(!canCharacterControll){
            animator.SetLocomotion(0,0);
            return;
        }
        float h = Input.GetAxis("Horizontal");				// 入力デバイスの水平軸をhで定義
        float v = Input.GetAxis("Vertical");				// 入力デバイスの垂直軸をvで定義
        animator.SetLocomotion(v,h);
        Move(v,h);

        if(Input.GetButtonDown("Jump")){ animator.SetJump(); }

    }
    
    private void Move(float vertical, float horizontal)
    {
        var velocity = new Vector3(0, 0, vertical);        // 上下のキー入力からZ軸方向の移動量を取得
        // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);
        // キーを後ろに入力していた場合、速度は半減する
        float speedCoefficient = vertical <= -0.1F ? 0.5F : 1F;
        velocity *= parameter.speed * speedCoefficient;
        transform.localPosition += velocity * Time.fixedDeltaTime;

        // 左右のキー入力でキャラクタをY軸で旋回させる
        transform.Rotate(0, horizontal * parameter.rotate, 0);            
    }

    public void GameClear()
    {
        canCharacterControll = false;
        animator.SetWin();
    }

    public void GameOver()
    {
        canCharacterControll = false;
        animator.SetLose();
    }
}

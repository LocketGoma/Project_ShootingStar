using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpPower = 10f;
    public Animator anim;
    private Rigidbody rbody;
    [SerializeField]
    private float inputH;
    [SerializeField]
    private float inputV;
    [SerializeField]
    private bool jump = false;


    private void Start() {
        //rbody = playerCharactor.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("jump", jump);

        // 캐릭 '실제 이동' 부분
        float moveX = ReduceMovement(inputH) * speed * Time.deltaTime;
        float moveZ = ReduceBackMovement(inputV) * speed * Time.deltaTime;

        transform.Translate(moveX, 0f, moveZ);
        transform.rotation = Quaternion.Euler(0,transform.GetChild(1).transform.rotation.eulerAngles.y,0);

        if (Input.GetKeyUp(KeyCode.Space)) {
            anim.Play("JUMP01B", -1, 0f);
            //Invoke("JumpAction", 0.5f);
            JumpAction();
            Invoke("JumpRelease", 1f);
        }
        
    }
    private float ReduceBackMovement(float input) {
        return input > 0 ? input : input / 10;
    }
    private float ReduceMovement(float input) {
        return input / 2;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);
       // if (other.gameObject.tag == "Room")
       jump = false;
    }
    private void JumpAction() {
        gameObject.GetComponentInChildren<Rigidbody>().AddForce(Vector3.up * speed * gameObject.GetComponentInChildren<Rigidbody>().mass, ForceMode.Impulse);        
        jump = true;
    }
    private void JumpRelease() {
        jump = false;
    }

}

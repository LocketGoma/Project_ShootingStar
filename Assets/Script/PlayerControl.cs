using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [Range(1f, 100f)]
    public float maxPower;
    [Range(1f, 25f)]
    public float minPower;

    [Range(0.0f, 3.0f)]
    public float powerChargeTime = 2f;       //기 모으기, 'N' 초 만큼 모으면 최대 힘
    [SerializeField] private float power = 1f;

    [SerializeField] private Text text;
    [SerializeField] private bool autoCharge = false;


    private void Start() {
        power = minPower;
        text.text = power.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((maxPower / powerChargeTime) * (Time.deltaTime));
        if (Input.GetMouseButton(0)){
            power += (Mathf.Log(Mathf.Pow(power,5), powerChargeTime) * Time.deltaTime);     //속도 올라가는걸 지수함수 말고 로그함수로 해야할거같은데.
            if (power > maxPower || autoCharge)
                power = maxPower;

            text.text = power.ToString();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            autoCharge = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            autoCharge = false;
        }

        if (Input.GetMouseButtonUp(0)) {
            ShootBullet();
            power = minPower;
        }
    }

    void ShootBullet() {
        Debug.Log("shoot");
        Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>().AddForce(transform.GetComponentInChildren<CrosshairCustom>().getTargetVector() * power, ForceMode.Impulse);
    }
    

}

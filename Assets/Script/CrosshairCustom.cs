using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//레이, 레이캐스트 직접 구현!
public class CrosshairCustom : MonoBehaviour
{

    [Header("Base Setting")]    
    [Range(0.1f, 25.0f)]
    public float Reach = 25.0F;          //인식 사거리

    [Header("CrossHair")]
    [SerializeField] private GameObject normalCrosshairPrefab;
    [SerializeField] private GameObject selectedCrosshairPrefab;
    [HideInInspector] private GameObject normalCrosshairPrefabInstance;         //기본 크로스헤어 복사본
    [HideInInspector] private GameObject selectedCrosshairPrefabInstance;       //선택 크로스헤어 복사본

    [Header("Target")]
    [SerializeField] private Vector3 targetVector;

    [Header("Debug Setting")]
    [SerializeField] private bool isOn = true;
    [SerializeField] private Color debugRayColor;   //디버그 레이 시각화 색상
    [Range(0.0f, 1.0f)]
    [SerializeField] private float opacity = 1.0f;   //투명도

    // Start is called before the first frame update
    void Start() {
        if (normalCrosshairPrefab != null) {
            normalCrosshairPrefabInstance = normalCrosshairPrefab;
        }
        else {
            Debug.LogError("System : NormalCrosshair Image was not found!!");
        }
        if (selectedCrosshairPrefab != null) {
            selectedCrosshairPrefabInstance = selectedCrosshairPrefab;
        }
        else {
            Debug.LogError("System : SelectedCrosshair Image was not found!!");
        }


        debugRayColor.a = opacity;

    }

    // Update is called once per frame
    void Update() {
        Ray ray = gameObject.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));       //메인 카메라
        //Debug.Log("ray:" + ray);
        Camera cam = gameObject.GetComponent<Camera>();
       // Debug.Log((cam.transform.rotation * Vector3.zero * cam.nearClipPlane) + cam.transform.position);

        /*
         1. Ray의 첫번째 값 : 카메라 Viewport의 시작지점 (카메라 앞의 '사각형') => 카메라 시작 좌표 * 카메라 로테이션 회전 + near값 만큼 전진.
         2. Ray의 두번째 값 : 1번 값에 수직인 벡터
         
         */

        CustomRay m_ray = CameraViewToRay(cam);
       // Debug.Log(m_ray.Direction);

        RaycastHit hit;         //얘는 걍 있는거 쓰기.
      // if (Physics.Raycast(ray, out hit, Reach)) {
      //      Debug.Log("Ray hit : " + hit.collider.tag);
      // }

        if (isOn == true) {
            Debug.DrawRay(m_ray.Origin, m_ray.Direction * Reach, debugRayColor);
        }

    }

    //카메라 정보 -> MyRay 값 리턴.
    CustomRay CameraViewToRay(Camera cam) {
        Vector3 original = (cam.transform.forward * cam.nearClipPlane) + cam.transform.position;
        //https://answers.unity.com/questions/46583/how-to-get-the-look-or-forward-vector-of-the-camer.html
        Vector3 direction = cam.transform.forward;
        targetVector = direction;
        return new CustomRay(original,direction);
    }
    //https://hombody.tistory.com/113
    bool MyRayCast() {
        
        return false;
    }
    public Vector3 getTargetVector() {
        return targetVector;
    }

}



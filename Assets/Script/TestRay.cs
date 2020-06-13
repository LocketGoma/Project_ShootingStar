using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    public int mass = 100;
    public float reach = 5f;
    Vector3[] vt;
    Ray[] ry;
    // Start is called before the first frame update
    void Start()
    {
        vt = new Vector3[mass];
        ry = new Ray[mass];
        MakeRays();

        Invoke("BulletClear", 3);
    }


    public void MakeRays() {
        for (int i = 0; i < mass; i++) {
            vt[i] = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            ry[i] = new Ray((vt[i] * MaxInVector3(gameObject.transform.localScale)) + gameObject.transform.position, vt[i]);
            //Debug.Log(vt[i]);
            //Debug.DrawRay(ry[i].Origin, ry[i].Direction * reach, new Color((vt[i].x+1)/2, (vt[i].y + 1) / 2, (vt[i].z + 1) / 2));
        }

    }
    public void Update() {
        for (int i = 0; i < mass; i++) {
            ry[i] = new Ray((vt[i] * MaxInVector3(gameObject.transform.localScale)) + gameObject.transform.position, vt[i]);
            Debug.DrawRay(ry[i].origin, ry[i].direction * reach, new Color((vt[i].x + 1) / 2, (vt[i].y + 1) / 2, (vt[i].z + 1) / 2));
            RaycastHit hit;
            if (Physics.Raycast(ry[i], out hit, reach)&& !hit.collider.tag.Equals("Untagged")) {
                Debug.Log("Ray hit : "+hit.collider.tag);
                Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
                hit.collider.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity);
            }
        }
    }
    private float MaxInVector3(Vector3 vt) {
        float result;
        result = vt.x>vt.y?vt.x:vt.y;
        result = result>vt.z?result:vt.z;

        return result;
    }
    private void BulletClear() {
        Destroy(gameObject);
    }
}

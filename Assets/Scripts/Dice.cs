using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject parent;
    public DiceManager diceManager;
    public Transform diceCheck;
    int value;
    Rigidbody rb;
    bool selected;
    [SerializeField] LayerMask layerMask;
    private void Start()
    {
        selected = false;
        rb = GetComponent<Rigidbody>();
        float xTorque = Random.Range(-550f, 550f);
        float zTorque = Random.Range(-550f, 550f);
        float yTorque = Random.Range(-550f, 550f);
        rb.AddForce(new Vector3(Random.Range(100f, 500f), 0, 0));
        rb.AddTorque(new Vector3 (xTorque, yTorque, zTorque));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!selected) StartCoroutine(CheckNumber());
    }

    IEnumerator CheckNumber()
    {
        while (!selected)
        {
            if (rb.velocity == Vector3.zero)
            {
                diceCheck.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2f);
                RaycastHit hit;
                if (Physics.Raycast(diceCheck.position, Vector3.forward, out hit, 4f, layerMask))
                {
                    Debug.DrawRay(diceCheck.position, Vector3.forward * 4f, Color.green);
                    value = int.Parse(hit.collider.gameObject.name);
                    SendValue();
                    StartCoroutine(SelfDestruction());
                }
                else
                {
                    Debug.DrawRay(diceCheck.position, Vector3.forward * 4f, Color.red);
                }
                selected = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    void SendValue()
    {
        diceManager.ReceiveValues(value);
    }

    IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(2);
        Destroy(parent);
    }
}

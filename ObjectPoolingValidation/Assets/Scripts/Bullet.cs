using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float TimeBeforeInactive = 2f;
    private float count = 0f;

    private void Start()
    {
        count = TimeBeforeInactive;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy || gameObject.activeSelf)
        {
            //First this was an invoke, but that's not good! Only on Awake and Start
            count -= Time.deltaTime;
            if (count < 0)
            {
                SetBulletInactive();
            }
        }
    }

    private void SetBulletInactive()
    {
        gameObject.SetActive(false);
        count = TimeBeforeInactive;
        //Fixes the direction of the bullet by erasing the "AddForce" when activating the bullet
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
            gameObject.SetActive(false);
    }
}

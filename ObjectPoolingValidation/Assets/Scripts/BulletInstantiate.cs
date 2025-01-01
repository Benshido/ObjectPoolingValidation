using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour
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
        Destroy(gameObject);
        count = TimeBeforeInactive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float trapCoolDown = 1;
    private float timeSinceLastTrap;

    void Start()
    {
        timeSinceLastTrap = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeSinceLevelLoad - timeSinceLastTrap > trapCoolDown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeSinceLastTrap = Time.timeSinceLevelLoad;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed = 6.0f;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // “ü—Í‚ðŽó‚¯Žæ‚é
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(inputX, 0, inputY);
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

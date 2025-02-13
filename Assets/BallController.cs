using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;

    void Start()
    {
        //Get a reference to Rigidbody
        ballRB = GetComponent<Rigidbody>();

        // Launch ball when the space bar is pressed
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall() 
    {
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}

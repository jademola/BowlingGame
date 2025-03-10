using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager;
    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        //Get a reference to Rigidbody
        ballRB = GetComponent<Rigidbody>();

        // Launch ball when the space bar is pressed
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ResetBall();
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }

    private void LaunchBall() 
    {
        
        if (isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}

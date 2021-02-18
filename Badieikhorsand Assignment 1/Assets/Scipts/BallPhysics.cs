using UnityEngine.Assertions;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vTargetPos;
    [SerializeField]
    private Vector3 m_vInitialVel;
    [SerializeField]
    private bool m_bDebugKickBall = false;

    private Rigidbody m_rb = null;
    private GameObject m_TargetDisplay = null;

    private bool m_bIsGrounded = true;

    private float m_fDistanceToTarget = 0f;

    private Vector3 vDebugHeading;

    // Start is called before the first frame update
    void Start()
    {      //Here we are getting our velocity and physic components 
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "No RigidBody Attached");

       
        m_fDistanceToTarget = (m_TargetDisplay.transform.position - transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TargetDisplay != null && m_bIsGrounded)
        {
            m_TargetDisplay.transform.position = m_vTargetPos;
            vDebugHeading = m_vTargetPos - transform.position;
        }

        if (m_bDebugKickBall && m_bIsGrounded)
        {
            m_bDebugKickBall = false;

        }

    }

   


   
}

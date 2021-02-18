using UnityEngine.Assertions;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class ProjectileComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vInitialVelocity = Vector3.zero;

    public static Rigidbody m_rb = null;

    private GameObject m_landingDisplay = null;

   

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "No RigidBody Attached");

        CreateLandingDisplay();
    }

    private void Update()
    {   
        UpdateLandingPosition();
        
    }

    private void CreateLandingDisplay()
    {  //creating a red object cylinder shape to show our landing spot to the player
        m_landingDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_landingDisplay.transform.position = Vector3.zero;
        m_landingDisplay.transform.localScale = new Vector3(1f, 0.1f, 1f);

        m_landingDisplay.GetComponent<Renderer>().material.color = Color.red;
        m_landingDisplay.GetComponent<Collider>().enabled = false;
    }

    private void UpdateLandingPosition()
    { //updating our landing marker position whiich is our red cylinder
        if (m_landingDisplay != null )
        {
            m_landingDisplay.transform.position = GetLandingPosition();
        }
    }

    private Vector3 GetLandingPosition()
    {
        //Calculating our landing spot with the the ball hits ground, at y =0 with our kinematic formulas
        float fTime = 2f * (0f - m_vInitialVelocity.y / Physics.gravity.y);

        Vector3 vFlatVel = m_vInitialVelocity;
        vFlatVel.y = 0;
        vFlatVel *= fTime;

        return transform.position + vFlatVel;
    }
   
   

    #region CALLBACKS
    public void OnLaunchProjectile()
    {
        //Adding velocity to reach the calculated landing spot

        m_landingDisplay.transform.position = GetLandingPosition();
        

        transform.LookAt(m_landingDisplay.transform.position, Vector3.up);

        m_rb.velocity = m_vInitialVelocity;

        m_vInitialVelocity = Vector3.zero;
    }

   

    public void OnMoveRight(float fDelta)
    {   //calculating our angle with our delta
        m_vInitialVelocity.z += fDelta;
    }

    public void OnMoveLeft(float fDelta)
    {
        m_vInitialVelocity.z -= fDelta;
    }
    public void Power(float fDelta, float time)
    { //Adding to initial velocity in both y direction and x direction 
        m_vInitialVelocity.x -= fDelta;
        m_vInitialVelocity.y += fDelta * time* 2;
    }

    #endregion
}

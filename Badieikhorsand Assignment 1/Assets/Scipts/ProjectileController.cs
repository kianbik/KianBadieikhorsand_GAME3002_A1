using UnityEngine.Assertions;
using UnityEngine;

//[RequireComponent(typeof(ProjectileComponent))]
public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float m_fInputDeltaVal = 0.1f; //Changed my delta value in the editor t
    private float time = 0; // for realizing how long we held down space
    private ProjectileComponent m_projectile = null;
    //our projectile coponents
    // Start is called before the first frame update
    void Start()
    {
        m_projectile = GetComponent<ProjectileComponent>();
        Assert.IsNotNull(m_projectile, "No RigidBody Attached");
    }

    // Update is called once per frame
    void Update()
    {
        HandleUserInput();
    }

    private void HandleUserInput()
    {
       
        //realising space button to lunch. Set the time to 0 so we reset the time that we held space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            time = 0;
            m_projectile.OnLaunchProjectile();
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        { //adding angle to projectile 
            m_projectile.OnMoveRight(m_fInputDeltaVal);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_projectile.OnMoveLeft(m_fInputDeltaVal);
        }
        if (Input.GetKey(KeyCode.Space))
        { // Calculating how much time we held space button 
            time += Time.deltaTime;
            m_projectile.Power(m_fInputDeltaVal,time);
        }
    }
}

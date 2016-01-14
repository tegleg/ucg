using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    public Transform Target;
    public Transform LookAtTarget;
    public float PositionFolowForce = 5f;
    public float RotationFolowForce = 5f;
    void Start()
    {
        if (!Target)
        {
            Target = GameObject.FindWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (!Target)
        {
           LookAtTarget = GameObject.FindWithTag("Player").transform;
            Target = GameObject.Find("camtarget").transform;
            GameObject.FindWithTag("Player").GetComponent<CamChanger>().ChaseCam = GetComponent<Camera>();
        }
 
        var vector = Vector3.forward;
        var dir = Target.rotation * Vector3.forward;
        dir.y = 0f;
        if (dir.magnitude > 0f) vector = dir / dir.magnitude;

        transform.position = Vector3.Lerp(transform.position, Target.position, PositionFolowForce * Time.deltaTime);
        gameObject.transform.LookAt(LookAtTarget);// transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAtTarget), RotationFolowForce * Time.deltaTime);
    }
}



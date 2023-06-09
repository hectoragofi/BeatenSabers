using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEditor.Experimental.GraphView;

public class continuousMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    public float gravity = -9.81f;
    public LayerMask groundLayer;

    private float fallingspeed;
    public XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, rig.transform.eulerAngles.y, 0);
        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(headYaw * direction * Time.fixedDeltaTime * speed);

        bool isGrounded = CheckIfGrounded();

        if(isGrounded)
        {
            fallingspeed = 0;
        }
        else
        {
            fallingspeed += gravity * Time.fixedDeltaTime;
        }

        fallingspeed += gravity * Time.deltaTime;
        character.Move(Vector2.up * fallingspeed * Time.deltaTime);
    }
    
    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        
        return hasHit;
    }

    void CapsuleFollowHeadset()
    {
        float height = rig.transform.InverseTransformPoint(Camera.main.transform.position).y;
        character.height = Mathf.Clamp(height + 0.2f, 0.5f, 2f);
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
        if (device != null && device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position))
        {
            Vector3 capsuleCenter = transform.InverseTransformPoint(position);
            character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
        }
    }
}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    public void Map()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class IKTargetFollowVRRig : MonoBehaviour
{
    [Range(0,1)]
    public float turnSmoothness = 0.1f;
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;



    public Transform leftHandTargetM;
    public Transform rightHandTargetM;

    public XRInputModalityManager inputModalityManager;
    public Transform leftHandTarget;
    public Transform rightHandTarget;


    public Vector3 headBodyPositionOffset;
    public float headBodyYawOffset;

    //void Update()
    //{
    //    switch (inputModalityManager.m_LeftInputMode)
    //    {
    //        case XRInputModalityManager.InputMode.MotionController:
    //            leftHand.vrTarget = leftHandTargetM;
    //            leftHand.Map();
    //            rightHand.Map();
    //            break;
    //        case XRInputModalityManager.InputMode.TrackedHand:
    //            leftHand.vrTarget = leftHandTarget;
    //            leftHand.Map();
    //            rightHand.Map();
    //            break;

    //        case XRInputModalityManager.InputMode.None:
    //            break;
    //    }

    //    switch (inputModalityManager.m_RightInputMode)
    //    {
    //        case XRInputModalityManager.InputMode.MotionController:
    //            rightHand.vrTarget = rightHandTargetM;
    //            leftHand.Map();
    //            rightHand.Map();
    //            break;
    //        case XRInputModalityManager.InputMode.TrackedHand:
    //            rightHand.vrTarget = rightHandTarget;
    //            leftHand.Map();
    //            rightHand.Map();
    //            break;

    //        case XRInputModalityManager.InputMode.None:
    //            break;
    //    }
    //}
  
    void LateUpdate()
    {
        transform.position = head.ikTarget.position + headBodyPositionOffset;
        float yaw = head.vrTarget.eulerAngles.y;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(transform.eulerAngles.x, yaw, transform.eulerAngles.z),turnSmoothness);

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] Transform startTransform, endTransform;
    [SerializeField] int segmentCount = 10;
    [SerializeField] float totalLenght = 10;

    [SerializeField] float totalweight = 10;
    [SerializeField] float drag = 1;
    [SerializeField] float angularDrag = 1;

    Transform[] segments;
    [SerializeField] Transform segmentParent;

    private void Start()
    {
        segments = new Transform[segmentCount];
        GenerateSegments();
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < segments.Length; i++) 
        {
            Gizmos.DrawWireSphere(segments[i].position, 0.1f);
        }
    }

    private void GenerateSegments()
    {
        JoinSegment(startTransform, null, true);
        Transform prevTransform = startTransform;

        Vector3 direction = endTransform.position - startTransform.position;

        for (int i = 0; i < segmentCount; i++) 
        {
            GameObject segment = new GameObject($"segment_{i}");
            segment.transform.SetParent(segmentParent);
            segments[i] = segment.transform;

            Vector3 pos =prevTransform.position + (direction / segmentCount);
            segment.transform.position = pos;

            JoinSegment(segment.transform, prevTransform);

            prevTransform = segment.transform;
        }

        JoinSegment(endTransform, prevTransform, true, true);
    }

    private void JoinSegment(Transform current, Transform connectedTransform, bool isKinetic = false, bool isCloseConnected = false)
    {
        Rigidbody rigidbody = current.AddComponent<Rigidbody>();
        rigidbody.isKinematic = isKinetic;
        rigidbody.mass = totalweight / segmentCount;
        rigidbody.drag = drag;
        rigidbody.angularDrag = angularDrag;

        if (connectedTransform != null) 
        { 
            ConfigurableJoint joint = current.AddComponent<ConfigurableJoint>();

            joint.connectedBody = connectedTransform.GetComponent<Rigidbody>();

            joint.autoConfigureConnectedAnchor = false;
            if (isCloseConnected)
            {
                joint.connectedAnchor = Vector3.forward * 0.1f;
            }
            else 
            { 
                joint.connectedAnchor = Vector3.forward * (totalLenght / segmentCount);
            }

            joint.xMotion = ConfigurableJointMotion.Locked;
            joint.yMotion = ConfigurableJointMotion.Locked;
            joint.zMotion = ConfigurableJointMotion.Locked;

            joint.angularXMotion = ConfigurableJointMotion.Free;
            joint.angularYMotion = ConfigurableJointMotion.Free;
            joint.angularZMotion = ConfigurableJointMotion.Limited;

            SoftJointLimit softJointLimit = new SoftJointLimit();
            softJointLimit.limit = 0;
            joint.angularZLimit = softJointLimit;

            JointDrive jointDrive = new JointDrive();
            jointDrive.positionDamper = 0;
            jointDrive.positionSpring = 0;
            joint.angularXDrive = jointDrive;
            joint.angularYZDrive = jointDrive;
        }
    }
}


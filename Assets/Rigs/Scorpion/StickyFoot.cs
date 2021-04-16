using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class StickyFoot : MonoBehaviour
{
    public Transform stepPosition;
    public AnimationCurve verticalStepMovement;

    private Quaternion startingRotation;

    private Vector3 previousPlantedPosition;
    private Quaternion previousPlantedRotation = Quaternion.identity;

    private Vector3 plantedPosition;
    private Quaternion plantedRotation = Quaternion.identity;

    private float timeLength = .25f;
    private float timeCurrent = 0;

    public static float moveThresold = 1;

    public bool isAnimating {
        get 
        {
            return (timeCurrent < timeLength);
        }
    }

    public bool footHasMoved = false;

    Transform kneePole;

    // Start is called before the first frame update
    void Start()
    {
        kneePole = transform.GetChild(0);

        startingRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        if(isAnimating)
        {
            timeCurrent += Time.deltaTime;

            float p = timeCurrent / timeLength;

            Vector3 finalPosition = AnimMath.Lerp(previousPlantedPosition, plantedPosition, p);

            finalPosition.y += verticalStepMovement.Evaluate(p);

            transform.position = finalPosition;
            transform.rotation = AnimMath.Lerp(previousPlantedRotation, plantedRotation, p);

            Vector3 vFromCenter = transform.position - transform.parent.position;
            vFromCenter.y = 0;
            vFromCenter.Normalize();
            vFromCenter *= 3;
            vFromCenter.y += 2.5f;
            vFromCenter += transform.position;

            kneePole.position = AnimMath.Slide(kneePole.position, vFromCenter, 0.001f);

        }
        else
        {
            transform.position = AnimMath.Slide(transform.position, plantedPosition, 0.001f);
            transform.rotation = AnimMath.Slide(transform.rotation, plantedRotation, 0.001f);
        }

    }

    public bool TryToStep()
    {
        if (isAnimating) return false;

        if (footHasMoved) return false;

        Vector3 vBetween = transform.position - stepPosition.position;

        if (vBetween.sqrMagnitude < moveThresold * moveThresold) return false;

        Ray ray = new Ray(stepPosition.position + Vector3.up, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * 3);

        if (Physics.Raycast(ray, out RaycastHit hit, 3))
        {
            //setup for animation
            previousPlantedPosition = transform.position;
            previousPlantedRotation = transform.rotation;

            transform.localRotation = startingRotation;

            //setup end animation
            plantedPosition = hit.point;
            plantedRotation =
                Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            //begin animation
            timeCurrent = 0;

            footHasMoved = true;

            return true;
        }
        return false;
    }
}

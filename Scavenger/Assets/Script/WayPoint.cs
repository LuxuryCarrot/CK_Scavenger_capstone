using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public WayPoint rightPoint;
    public WayPoint leftPoint;

    Vector3 rightPos = Vector3.zero;
    Vector3 leftPos=Vector3.zero;

    private void Awake()
    {
        if (rightPoint != null)
        {
            rightPos = rightPoint.transform.position - transform.position;
            rightPos = Vector3.Normalize(rightPos);
        }

        if (leftPoint != null)
        {
            leftPos = leftPoint.transform.position - transform.position;
            leftPos = Vector3.Normalize(leftPos);
        }
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(PlayerCharacterController.playerSingleton.transform.position
            - transform.position) <= 1.0f)
        {
            
            if (Vector3.SqrMagnitude(PlayerCharacterController.playerSingleton.transform.position
            - transform.position) <= 0.01f)
            {
                PlayerCharacterController.playerSingleton.rightPos = 
                    Vector3.Normalize(rightPoint.transform.position
                                      - PlayerCharacterController.playerSingleton.transform.position);
                PlayerCharacterController.playerSingleton.leftPos = 
                    Vector3.Normalize(leftPoint.transform.position
                - PlayerCharacterController.playerSingleton.transform.position);
            }

            else if(Vector3.Dot(PlayerCharacterController.playerSingleton.transform.position-transform.position,
                                  rightPos)>=0)
            {
                PlayerCharacterController.playerSingleton.rightPos =
                    Vector3.Normalize(rightPoint.transform.position 
                    - PlayerCharacterController.playerSingleton.transform.position);
                PlayerCharacterController.playerSingleton.leftPos =
                    -PlayerCharacterController.playerSingleton.rightPos;
            }

            else
            {
                PlayerCharacterController.playerSingleton.leftPos =
                    Vector3.Normalize(leftPoint.transform.position
                    - PlayerCharacterController.playerSingleton.transform.position);
                PlayerCharacterController.playerSingleton.rightPos =
                    -PlayerCharacterController.playerSingleton.leftPos;
            }
        }
    }
}

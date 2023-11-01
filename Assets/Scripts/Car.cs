using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float stopingDistance = .5f;
    [SerializeField] Transform raycastPos;
    
    int includedLayers;

    bool isGoingToStreetEnd = true;
    Street currentStreet;
    Street destinationStreet;

    public void SetDestination(Street street) {
        destinationStreet = street;
    }

    private void Start() {

        includedLayers = LayerMask.GetMask("Default", "Obstacle");             
        transform.position = transform.position + (transform.forward * moveSpeed * Time.deltaTime);        
    }

    private void Update() {
        if (Vector3.Distance(transform.position, destinationStreet.StreetEnd) < 1f)
            return;


        if (Physics.Raycast(raycastPos.position, transform.forward,out RaycastHit hit, stopingDistance, includedLayers, QueryTriggerInteraction.Ignore)) {

        }
        else {
            Vector3 newPosition = transform.position + (transform.forward * moveSpeed * Time.deltaTime);
            
            if(Vector3.Distance(newPosition, currentStreet.StreetEnd) < .1f) {
                currentStreet = destinationStreet;
                isGoingToStreetEnd = false;
            }

            transform.position += newPosition;
            transform.LookAt(isGoingToStreetEnd ? currentStreet.StreetEnd : currentStreet.StreetStart, Vector3.up);
        }
        
    }

}

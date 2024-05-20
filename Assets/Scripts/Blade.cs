using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private bool slicing;
    private Camera maincamera;
    private Collider col;
    private TrailRenderer trail;

    public Vector3 direction {get; private set;}
    public float minVelocity=0.01f;
    public float force=5f;

    private void Awake()
    {
        maincamera=Camera.main;
        col=GetComponent<Collider>();
        trail=GetComponentInChildren<TrailRenderer>();

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartSlicing();
        }else if(Input.GetMouseButtonUp(0)){
            StopSlicing();
        }else if(slicing){
            ContinueSlicing();
        }
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void StartSlicing()
    {
        Vector3 newPosition=maincamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z=0f;
        transform.position=newPosition;
        slicing=true;
        col.enabled=true;
        trail.enabled=true;
        trail.Clear();
    }

    private void StopSlicing()
    {
        slicing=false;
        col.enabled=false;
        trail.enabled=false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition=maincamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z=0f;

        direction=transform.position-newPosition;

        float velocity=direction.magnitude/Time.deltaTime;
        col.enabled=velocity>minVelocity;

        transform.position=newPosition;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header ("Movement")]
    public float speed;
    public Camera cam;
    public float camSize;
    public float camMaxZoom;
    public float camZoom;
    public float shakeDuration;
    public float shakeDurationSet;
    public float shakeAmount;
    public float decreaseFactor;
    public LegController legs;
    public Animator anim;
    int stopYEETing;
    public float throwCooldownMax = .07f;
    float throwCooldown;
    public AudioSource myAudio;
    public AudioClip yeet, owat, oof;

    [Header("Hammer")]
    public GameObject hammerSpawn;
    public GameObject hammer;
    public float powerScaling;
    public float powerMax;
    public float power;
    Vector3 direction;

    void Update()
    {
        if (stopYEETing == 1)
        {
            stopYEETing = 0;
            anim.SetBool("YEETing", false);
        }
        cam.orthographicSize = camZoom;
        if (Input.GetMouseButton(0) && throwCooldown <= 0 || (power <= 3 && power > 0))
        {
            power += Time.deltaTime * powerScaling;
            if (power > powerMax)
            {
                power = powerMax;
                anim.SetBool("isCharged", true);
            }
            float temp = power / powerMax;
            temp *= 3;
            camZoom = camSize - temp;
            shakeDurationSet = temp / 3;
            anim.SetBool("isCharging", true);
        }
        if (Input.GetMouseButtonUp(0) && power > 3)
        {
            if (power < 15)
            {
                myAudio.clip = oof;
            }
            if (power > 15)
            {
                myAudio.clip = owat;
            }
            if (power > 30)
            {
                myAudio.clip = yeet;
            }
            Hammer(power);
            anim.SetBool("isCharged", false);
            anim.SetBool("isCharging", false);
            anim.SetBool("YEETing", true);
            stopYEETing = 1;
        }
        throwCooldown -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        legs.UD = 0;
        legs.LR = 0;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            legs.UD = 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            legs.UD = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            legs.LR = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            legs.LR = 2;
        }
        if (legs.UD == 0 && legs.LR == 0)
        {
            legs.anim.SetBool("isWalking", false);
            anim.SetBool("isWalking", false);
        }
        else
        {
            legs.anim.SetBool("isWalking", true);
            anim.SetBool("isWalking", true);
        }
        transform.position = new Vector3(transform.position.x, 0.9f, transform.position.z);
        cam.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        CamShake();

        //Top half rotates to camera
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            hit.point = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Debug.DrawLine(transform.position, hit.point);
            transform.LookAt(hit.point);
            direction = hit.point - transform.position;
        }

        legs.transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
        legs.PointLegs(legs.LR, legs.UD);
    }

    void OnCollisionStay(Collision collision)
    {
        var thisCollider = GetComponent<Collider>();

        if (!thisCollider)
        {
            return;
        }

        var collider = collision.collider;

        Vector3 otherPosition = collider.gameObject.transform.position;
        Quaternion otherRotation = collider.gameObject.transform.rotation;

        Vector3 direction;
        float distance;

        bool overlapped = Physics.ComputePenetration(thisCollider, transform.position, transform.rotation, collider, otherPosition, otherRotation, out direction, out distance);

        if (overlapped)
        {
            transform.position += (direction * distance);
        }
    }

    void Hammer(float ThrowPower)
    {
        GameObject thisHammer = Instantiate(hammer);
        thisHammer.transform.position = new Vector3(hammerSpawn.transform.position.x, hammerSpawn.transform.position.y, hammerSpawn.transform.position.z);
        direction += new Vector3(0, 2, 0);
        direction = Vector3.Normalize(direction);
        thisHammer.GetComponent<Rigidbody>().AddForce(direction * ThrowPower, ForceMode.Impulse);
        thisHammer.GetComponent<Rigidbody>().AddTorque(transform.right * ThrowPower, ForceMode.Impulse);
        power = 0;
        camZoom = camSize;
        shakeDuration = shakeDurationSet;
        throwCooldown = throwCooldownMax;
        myAudio.Play();
    }

    void CamShake()
    {
        if (shakeDuration > 0)
        {
            cam.transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
        }
    }
}

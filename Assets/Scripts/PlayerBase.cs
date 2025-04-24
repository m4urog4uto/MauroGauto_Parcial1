using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] LayerMask m_floorMask;
    [SerializeField] Transform m_bulletSpawner;
    [SerializeField] GameObject m_bullet;

    CharacterController _controller;
    Rigidbody m_playerRigidBody;

    float _posV;
    float _posH;
    float _gravity = -9.8f;
    float m_camRayLenght = 100f;
    float m_coldDown = 0.2f;
    float m_coldDownTimer;

    Vector3 _playerVelocity;
    Vector3 _spherePhysics;

    Ray m_camRay;
    RaycastHit m_floorHit;
    Vector3 m_playerToMouse;

    [SerializeField] float _speed = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        m_playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_coldDownTimer += Time.deltaTime;

        Move();
        Turning();

        if(Input.GetButton("Fire1") && m_coldDownTimer > m_coldDown)
        {
            Shoot();
        }
    }

    void Move()
    {
        if (IsGrounded() && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0;
        }

        _posV = Input.GetAxis("Vertical");
        _posH = Input.GetAxis("Horizontal");

        _playerVelocity.x = _posH * _speed;
        _playerVelocity.z = _posV * _speed;
        _playerVelocity.y += _gravity;

        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    bool IsGrounded()
    {
        _spherePhysics = new Vector3(transform.position.x, transform.position.y - 0.71f, transform.position.z);
        return Physics.CheckSphere(_spherePhysics, 0.3f);
    }

    void Turning()
    {
        m_camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(m_camRay, out m_floorHit, m_camRayLenght, m_floorMask))
        {
            m_playerToMouse = m_floorHit.point - transform.position;
            m_playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(m_playerToMouse, Vector3.up);
            m_playerRigidBody.MoveRotation(newRotation);
        }
    }

    void Shoot()
    {
        Instantiate(m_bullet, m_bulletSpawner.position, m_bulletSpawner.rotation);
    }
}

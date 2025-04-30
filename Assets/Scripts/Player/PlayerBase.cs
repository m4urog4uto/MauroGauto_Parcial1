using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    CharacterController _controller;
    PlayerRespawn playerRespawn;

    float health = 100f;
    int lives = 3;
    float _posV;
    float _posH;
    float _gravity = -9.8f;

    Vector3 _playerVelocity;
    Vector3 _spherePhysics;

    [SerializeField] float _speed = 0;

    // Start is called before the first frame update
    void Awake()
    {
        playerRespawn = GetComponent<PlayerRespawn>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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

    public void RemoveLive()
    {
        if (lives != 0)
        {
            playerRespawn.Respawn();
            health = 100f;
            lives -= 1;
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            RemoveLive();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetLives()
    {
        return lives;
    }
}

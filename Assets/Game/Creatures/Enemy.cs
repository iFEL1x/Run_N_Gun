﻿using System;
using System.Collections;
using UnityEngine;

namespace Game.Creatures
{
    public class Enemy : Creature
    {
        [SerializeField] private GameObject _tomb;
        [SerializeField] private GameObject _explosion;
        private Player _player;
        private Transform _parent;
        private Vector3 _tombLocalPosition;
        private Vector3 _explosionLocalPosition;
        private static Action player_loos;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _parent = transform.parent;
            _tombLocalPosition = _tomb.transform.localPosition;
            _explosionLocalPosition = _explosion.transform.localPosition;

            player_loos += StopEnemy;
        }
        
        private void OnEnable()
        {
            if (_tomb.activeInHierarchy)
            {
                _tomb.SetActive(false);
                _tomb.transform.SetParent(transform);
                _tomb.transform.localPosition = _tombLocalPosition;
                _explosion.transform.SetParent(transform);
                _explosion.transform.localPosition = _explosionLocalPosition;
            }
        }

        private void OnDestroy()
        {
            player_loos -= StopEnemy;
        }

        private void OnMouseDown()
        {
            if(_player.shootReady.IsReady)
                StartCoroutine(PlayerShoot());
            else _player.ShootFail();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                player_loos();
            }
        }

        private IEnumerator PlayerShoot()
        {
            StartCoroutine(_player.Shoot());
            
            yield return new WaitForSeconds(0.35f);
            _tomb.transform.parent = _parent;
            _tomb.SetActive(true);
            _explosion.transform.parent = _parent;
            _explosion.SetActive(true);
            
            gameObject.SetActive(false);
        }

        private void StopEnemy()
        {
            if (gameObject.activeInHierarchy)
            {
                speed = 0f;
                animation.AnimationState.SetAnimation(0, "win", true);
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }
}
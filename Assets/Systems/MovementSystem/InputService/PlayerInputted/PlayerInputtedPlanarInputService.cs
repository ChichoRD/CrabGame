﻿using InputBox.Readable;
using InputBox.Writeable;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementSystem.InputService.PlayerInputted
{
    internal class PlayerInputtedPlanarInputService : MonoBehaviour, IInputService
    {
        [SerializeField] private InputActionReference _planarMovementActionReference;
        private IInputWriteable<Vector2> _inputWriteable;
        
        public bool TryGet<TInput>(out IInputReadable<TInput> inputReadable)
        {
            inputReadable = GetComponentInChildren<IInputReadable<TInput>>();
            return (inputReadable != null);
        }

        private void Update()
        {
            _inputWriteable.TrySet(_planarMovementActionReference.action.ReadValue<Vector2>());
        }

        private void Awake()
        {
            _inputWriteable = GetComponentInChildren<IInputWriteable<Vector2>>();
        }

        private void OnEnable()
        {
            _planarMovementActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _planarMovementActionReference.action.Disable();
        }


    }
}
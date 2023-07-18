using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dani
{
    public class MoveCamera : MonoBehaviour
    {
        public Transform player;

        void Update() {
            transform.position = player.transform.position;
        }
    }
}
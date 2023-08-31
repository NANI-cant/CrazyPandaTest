using UnityEngine;

namespace CodeBase.TemporalSystem {
    public struct TimeScaledBodyData {
        public float UnscaledMass;
        public float UnscaledGravity;
        
        public Vector2 UnscaledLinearVelocity;
        public float UnscaledAngularVelocity;
        
        public Vector2 LastLinearVelocity;
        public float LastAngularVelocity;
    }
}
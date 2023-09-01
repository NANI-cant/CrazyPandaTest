using System;

namespace CodeBase.TimeProviding {
    public interface ITimeProvider {
        float TimeScale { get; }
        float Time { get; }
        float DeltaTime { get; }
        float UnscaledTime { get; }
        float UnscaledDeltaTime { get; }

        event Action ScaleChanged;
        
        void SlowDown(float factor);
        void SpeedUp(float factor);
    }
}
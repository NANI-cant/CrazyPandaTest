namespace CodeBase.TimeProviding {
    public interface ITimeProvider {
        float TimeScale { get; }
        float Time { get; }
        float DeltaTime { get; }
        float UnscaledTime { get; }
        float UnscaledDeltaTime { get; }
        
        void SlowDown(float factor);
        void SpeedUp(float factor);
    }
}
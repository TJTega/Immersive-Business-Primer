public enum FingerType
{
    None,
    ThumbL,
    IndexL,
    MiddleL,
    RingL,
    PinkyL,
    ThumbR,
    IndexR,
    MiddleR,
    RingR,
    PinkyR
}

public class Finger
{
    public FingerType type = FingerType.None;
    public float current = 0.0f;
    public float target = 0.0f;

    public Finger(FingerType type)
    {

        this.type = type;
    }
}

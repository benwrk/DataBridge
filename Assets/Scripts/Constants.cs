using System.IO;

public static class Constants
{
    public const float ZeroGravityFloatStrength = 8.22f;
    public const float ZeroGravityRandomRotationStrength = 0.2f;
    public const float ZeroGravityRotationSpeed = 100f;
    public const float DefaultForwardSpeed = 5.0f;
    public const float DefaultBackwardSpeed = 3.0f;
    public const float DefaultStrafeSpeed = 3.0f;
    public const float DefaultJumpForce = 40f;
    public const float GrabbingCameraCenterRange = 3f;
    public const string GrabbableTag = "Pickable";
    
    public static class XmlParser
    {
        public static class Clues
        {
            public const string ConfigFilePath = "Assets/XmlConfigs/clues.xml";
            public const string LevelTagName = "Level";
            public const string ClueTagName = "Clue";
            public const string ClueTextAttributeName = "text";
        }

        public static class Problems
        {
            public const string ConfigFilePath = "Assets/XmlConfigs/problems.xml";
            public const string LevelTagName = "Level";
        }
    }
}
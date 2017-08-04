public static class Constants
{
    public const float DefaultForwardSpeed = 5.0f;
    public const float DefaultBackwardSpeed = 3.0f;
    public const float DefaultStrafeSpeed = 3.0f;
    public const float DefaultJumpForce = 40f;
    public const float GrabbingCameraCenterRange = 3f;
    public const float ZeroGravityFloatStrength = 10f;
    public const float ZeroGravityRandomRotationStrength = 0.2f;
    public const float ZeroGravityRotationSpeed = 100f;
    public const string CorrectChoiceTag = "Correct";
    public const string GrabbableTag = "Pickable";
    public const string UntaggedTag = "Untagged";

    public static class XmlParser
    {
        public const string XmlSchemaExceptionMessage = "Invalid XML Schema!";

        public static class Clues
        {
            public const string ConfigFilePath = "Assets/XmlConfigs/clues.xml";
            public const string LevelTagName = "Level";
            public const string TextAttributeName = "text";
        }

        public static class Problems
        {
            public const string ConfigFilePath = "Assets/XmlConfigs/problems.xml";
            public const string ContainsRuleTagName = "ContainsRule";
            public const string ChoiceProblemTagName = "ChoiceProblem";
            public const string InputProblemTagName = "InputProblem";
            public const string IsCorrectAttributeName = "correct";
            public const string LevelTagName = "Level";
            public const string MatchesRuleTagName = "MatchesRule";
            public const string PhraseAttributeName = "phrase";
            public const string PlaceholderAttributeName = "placeholder";
            public const string RuleValidationOptionAttributeName = "rule-validation";
            public const string TextAttributeName = "text";
            public const string ValidateAllAttributeValue = "all";
            public const string ValidateAnyAttributeValue = "any";
            public const string WithoutRuleTagName = "WithoutRule";
        }
    }
}
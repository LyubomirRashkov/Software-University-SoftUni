namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string str = obj as string;

            return !string.IsNullOrEmpty(str);
        }
    }
}

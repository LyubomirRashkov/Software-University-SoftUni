namespace Exam.Expressionist
{
    public class Expression
    {
        public string Id { get; set; }

        public string Value { get; set; }
        
        public ExpressionType Type { get; set; }
        
        public Expression LeftChild { get; set; }
        
        public Expression RightChild { get; set; }

        public Expression Parent { get; set; }

        public Expression()
        {
        }

        public Expression(string id, string value, ExpressionType type, Expression leftChild, Expression rightChild)
        {
            this.Id = id;
            this.Value = value;
            this.Type = type;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
    }
}

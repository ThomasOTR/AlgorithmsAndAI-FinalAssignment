namespace AlgorithmsAndAI_FinalAssignment.Common.Utilities
{
    public class Stack<T> where T : class
    {
        private List<T> values = new List<T>();
        public Stack() { }

        public void Push(T value) => values.Add(value);
        public void Pop(T value) => values.Remove(value);
        public void Peek() => values.First();
    }
}

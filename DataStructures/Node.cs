namespace DataStructures
{
    internal class Node<T>
    {
        internal T Data;
        internal Node<T> NextNode { get; set; }
        internal Node<T> PreviousNode { get; set; }

        internal Node(T data, Node<T> nextNode, Node<T> previousNode)
        {
            Data = data;
            NextNode = nextNode;
            PreviousNode = previousNode;
        }
    }
}
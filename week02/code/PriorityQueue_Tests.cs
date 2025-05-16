using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test that the item (which contains both data and priority) is added to the back of the queue.
    // Expected Result: [John (Pri:3), Bonny (Pri:5)]
    // Defect(s) Found: None
    public void TestPriorityQueueAddItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 3);
        priorityQueue.Enqueue("Bonny", 5);
        Assert.AreEqual(priorityQueue.ToString(), "[John (Pri:3), Bonny (Pri:5)]");
    }

    [TestMethod]
    // Scenario: Test that the Dequeue function removes the item with the highest priority.
    // Expected Result: Francesco
    // Defect(s) Found: Change line 27 in PriorityQueue from index < _queue.Count - 1 to index < _queue.Count;
    public void TestPriorityQueueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 3);
        priorityQueue.Enqueue("Bonny", 4);
        priorityQueue.Enqueue("Jane", 1);
        priorityQueue.Enqueue("Francesco", 5);
        priorityQueue.Enqueue("Mark", 2);
        var expected = priorityQueue.Dequeue();
        Assert.AreEqual(expected, "Francesco");
    }

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Expected Result: Francesco
    // Defect(s) Found: Change line 29 in PriorityQueue from if (_queue[index].Priority >= _queue to if (_queue[index].Priority > _queue.
    public void TestPriorityQueueFirstHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 1);
        priorityQueue.Enqueue("Francesco", 4);
        priorityQueue.Enqueue("Jane", 2);
        priorityQueue.Enqueue("Mark", 3);
        priorityQueue.Enqueue("Bonny", 4);
        var expected = priorityQueue.Dequeue();
        Assert.AreEqual(expected, "Francesco");
    }
    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown. 
    // Expected Result: The queue is empty.
    // Defect(s) Found: Nothing found
    public void TestPriorityQueueCheckIfEmpty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
        }
        catch (InvalidOperationException err)
        {
            Assert.AreEqual("The queue is empty.", err.Message);
        }
    }
}
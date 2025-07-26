using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority first.
    // Defect(s) Found: Original code did not remove the dequeued element from the list.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result); // B has the highest priority (3)
    }

    [TestMethod]
    // Scenario: Add items with the same priority and check FIFO order.
    // Expected Result: Items with the same priority should dequeue in the order they were added (FIFO).
    // Defect(s) Found: Original code incorrectly selected the last item with the highest priority instead of the first.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result); // A should be dequeued first (FIFO)
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None. Code already threw exception, just needed verification.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Multiple dequeues, ensuring the queue shrinks and order is maintained.
    // Expected Result: Items should dequeue in correct order and length should reduce each time.
    // Defect(s) Found: Original code didn't remove items from the queue after dequeue.
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // highest priority
        Assert.AreEqual("C", priorityQueue.Dequeue()); // next highest
        Assert.AreEqual("A", priorityQueue.Dequeue()); // last remaining
    }

    [TestMethod]
    // Scenario: Check ToString output for readability.
    // Expected Result: Should show all items with values and priorities in the queue.
    // Defect(s) Found: None, just a visual check.
    public void TestPriorityQueue_ToString()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);

        string output = priorityQueue.ToString();
        Assert.IsTrue(output.Contains("A (Pri:1)"));
        Assert.IsTrue(output.Contains("B (Pri:3)"));
    }
}

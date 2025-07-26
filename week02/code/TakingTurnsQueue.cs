using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the
/// back of the queue (FIFO). When GetNextPerson is called, the next person is returned,
/// and then added to the back of the queue depending on their remaining turns.
/// A person with 0 or less turns stays in the queue forever.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue.
    /// </summary>
    /// <param name="name">The person's name</param>
    /// <param name="turns">Number of turns (0 or less = infinite)</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person and decide whether to return them to the queue.
    /// </summary>
    /// <returns>The person whose turn it is</returns>
    /// <exception cref="InvalidOperationException">If queue is empty</exception>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns: always re-add
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Decrement turns and re-add
            person.Turns--;
            _people.Enqueue(person);
        }
        // If Turns == 1, do not re-add

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}

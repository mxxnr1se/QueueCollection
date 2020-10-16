using System.Linq;
using QueueCollection;
using Xunit;

namespace QCTests
{
    public class QueueCollectionTests
    {
        [Fact]
        public void Queue_Peek_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act & Assert
            Assert.Equal(1, queue.Peek);
        }

        [Fact]
        public void Queue_Last_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act & Assert
            Assert.Equal(6, queue.Last);
        }

        [Fact]
        public void Queue_Peek_Last_ReturnException()
        {
            //Arrange
            var queue = new Queue<int>();

            // Act & Assert
            Assert.Throws<QueueException>(() => queue.Peek);
            Assert.Throws<QueueException>(() => queue.Last);
        }

        [Fact]
        public void Queue_IsEmpty_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int>();

            // Act & Assert
            Assert.True(queue.IsEmpty);
        }

        [Fact]
        public void Queue_IsNot_Empty_ReturnFalse()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act & Assert
            Assert.False(queue.IsEmpty);
        }

        [Fact]
        public void Queue_Clear_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};
            // Act
            queue.Clear();
            // Assert
            Assert.True(queue.IsEmpty);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void Queue_Contains_ReturnTrue(int value)
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act & Assert
            Assert.True(queue.Contains(value));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(15)]
        public void Queue_Contains_ReturnFalse(int value)
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act & Assert
            Assert.False(queue.Contains(value));
        }

        [Theory]
        [InlineData(7)]
        [InlineData(-14)]
        public void Queue_Enqueue_Value_ReturnTrue(int value)
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};
            // Act
            queue.Enqueue(value);
            // Assert
            Assert.Equal(queue.Last, value);
        }

        [Fact]
        public void Queue_Dequeue_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};
            int expected = 2;
            // Act
            queue.Dequeue();
            // Assert
            Assert.Equal(queue.First(), expected);
        }

        [Fact]
        public void Queue_Dequeue_ReturnException()
        {
            //Arrange
            var queue = new Queue<int>();

            // Act & Assert
            Assert.Throws<QueueException>(() => queue.Dequeue());
        }

        [Fact]
        public void PushToQueueEvent_Raised()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act
            var raisedEvent = Assert.Raises<PushToQueueEventArgs<int>>(handler => queue.Pushed += handler,
                                                                       handler => queue.Pushed -= handler,
                                                                       () => queue.Enqueue(7));

            // Assert
            Assert.NotNull(raisedEvent);
            Assert.Equal(7, raisedEvent.Arguments.PushedItem);
            Assert.Equal("7 pushed", raisedEvent.Arguments.Message);
        }

        [Fact]
        public void PopFromQueueEvent_Raised()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act
            var raisedEvent = Assert.Raises<PopFromQueueEventArgs<int>>(handler => queue.Popped += handler,
                                                                        handler => queue.Popped -= handler,
                                                                        () => queue.Dequeue());

            // Assert
            Assert.NotNull(raisedEvent);
            Assert.Equal(1, raisedEvent.Arguments.PoppedItem);
            Assert.Equal("1 popped", raisedEvent.Arguments.Message);
        }

        [Fact]
        public void Queue_CopyTo_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int> {-10, 10};
            int[] array = {0, 1, 2, 3, 4, 5};
            int[] expectedArray = {0, 1, -10, 10, 4, 5};

            // Act
            queue.CopyTo(array, 2);

            //Assert
            Assert.Equal(expectedArray, array);
        }

        [Fact]
        public void Queue_CopyTo_ReturnException()
        {
            // Arrange
            var queue = new Queue<int> {-10, 10, 200};
            int[] array = {0, 1, 2};

            // Act & Assert
            Assert.Throws<QueueException>(() => queue.CopyTo(array, 1));
        }

        [Fact]
        public void Queue_Clone_ReturnTrue()
        {
            // Arrange
            var queue = new Queue<int> {1, 2, 3, 4, 5, 6};

            // Act
            var queueClone = (Queue<int>) queue.Clone();

            // Assert
            Assert.Equal(queue, queueClone);
        }
    }
}
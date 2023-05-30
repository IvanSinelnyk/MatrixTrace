using MatrixTrace;

namespace MatrixTraceTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Find_3x4_MatrixTrace()
        {
            // Arrange
            int[,] testData = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            int expected = 18;
            Matrix matrix = new Matrix(testData);

            // Assert
            int actual = matrix.GetMatrixTrace();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_1x1_MatrixTrace()
        {
            // Arrange
            int[,] testData = new int[,] { { 11 } };
            int expected = 11;
            Matrix matrix = new Matrix(testData);

            // Assert
            int actual = matrix.GetMatrixTrace();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_Empty_MatrixTrace()
        {
            // Arrange
            int[,] testData = new int[,] { { } };
            int expected = 0;
            Matrix matrix = new Matrix(testData);

            // Assert
            int actual = matrix.GetMatrixTrace();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_3x2_MatrixTrace()
        {
            // Arrange
            int[,] testData = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int expected = 5;
            Matrix matrix = new Matrix(testData);

            // Assert
            int actual = matrix.GetMatrixTrace();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Snail_2x3_MatrixOutput()
        {
            // Arrange
            int[,] testData = new int[,] { { 92, 65, 57 }, { 96, 55, 36 } };
            int[] expected = new int[] { 92, 65, 57, 36, 55, 96 };
            Matrix matrix = new Matrix(testData);

            // Assert
            int[] actual = matrix.GetSnailData();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Snail_3x4_MatrixOutput()
        {
            // Arrange
            int[,] testData = new int[,] { { 1, 2, 3, 4 }, { 8, 7, 6, 5 }, { 4, 3, 2, 9 } };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 9, 2, 3, 4, 8, 7, 6 };
            Matrix matrix = new Matrix(testData);

            // Assert
            int[] actual = matrix.GetSnailData();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
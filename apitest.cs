using NUnit.Framework;

namespace YourNamespace
{
    public class ApiChallenge
    {
        /// <summary>
        /// Using the following Reset Server https://jsonplaceholder.typicode.com
        /// You are expected to deserialize the response data
        /// </summary>

        /// <summary>
        /// Using the /users/n endpoint get the 5th user from typicode
        /// </summary>
        [Test]
        public void Get5thUser()
        {
            // Method implementation
        }

        /// <summary>
        /// Retrieve all the users from the /users endpoint and store them in a list
        /// </summary>
        [Test]
        public void GetAllUsers()
        {
            // Method implementation
        }

        /// <summary>
        /// Retrieve all the users from the /users endpoint, then find a user with the following street address
        /// Dayna Park
        /// </summary>
        [Test]
        public void GetAllUsersAndRefine()
        {
            // Method implementation
        }
    }
}

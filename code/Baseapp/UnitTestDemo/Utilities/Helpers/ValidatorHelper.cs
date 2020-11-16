namespace UnitTestDemo.Utilities.Helpers
{
    public class ValidatorHelper
    {
        public bool IsValidUsername(string username) 
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (username.Length < 3)
                return false;

            return true;
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 3)
                return false;

            return true;
        }
    }
}

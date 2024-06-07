namespace DigitasChallenge.BLL.Helpers
{
    public static class ErrorsHelper
    {
        public static string ErrorsMessage(Exception ex)
        {
            if (ex.InnerException != null && ex.Message.Contains("details"))
            {
                return ex.InnerException.Message.ToString();
            }

            return ex.Message;
        }
    }
}

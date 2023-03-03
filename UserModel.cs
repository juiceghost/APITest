using System;
namespace APITest
{
	public class UserModel
	{

		public string username { get; set; }

		public string password { get; set; }

        public IResult LoginSuccess()
        {
            return Results.Ok("");
        }

        public IResult LoginFailed()
        {
            return Results.Unauthorized();
        }
    }
}


namespace ThAmCo.Order_Management.WebAPI.Fakes.UserReviews
{
    public interface ICustomerReviewsFake
    {
        public Task<List<UsersReviewDto>> GetUsersReviewAsync(int numberOfUsers = 9);
    }
}

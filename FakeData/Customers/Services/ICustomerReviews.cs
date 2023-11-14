using FakeData.Customers.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeData.Customers.Services
{
    public interface ICustomerReviews
    {
        public Task<List<UsersReviewDto>> GetUsersReviewAsync(int numberOfUsers = 9);
    }
}

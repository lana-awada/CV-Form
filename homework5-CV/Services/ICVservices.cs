using homework5_CV.Models.CV;
using homework5_CV.Models.User;

namespace homework5_CV.Services
{
    public interface ICVservices
    {
        public Task<int> AddCv(BindingModel request);
        public List<DataModel> GetCVs();
        public Task<DataModel> GetById(int Id);
        public Task<IResult> DeleteCv(int id);
        public Task UpdateCv(int Id,BindingModelEdit updatedCv);
        public Task<int> Adduser(BindingModelAddUser user);




    }

}

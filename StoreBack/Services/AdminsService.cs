using StoreBack.Models;

namespace StoreBack.Services
{
    public class AdminsService
    {
        private List<Admin> allAdmins = new List<Admin>()
        {
            new Admin() {Email="qwe@qwe.com",Password="asdasd"},
            new Admin() {Email="rty@rty.com",Password="fghfgh"},
        };
        public Admin? GetAdminByEmail(string email)=>allAdmins.FirstOrDefault(x=>x.Email==email);
        public bool CheckPasswordForAdmin(Admin admin, string password)=>admin.Password==password;
    }
}

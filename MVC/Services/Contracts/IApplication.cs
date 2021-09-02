using DigicelApps.Models;
using DigicelApps.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigicelApps.Services.Contracts
{
    public interface IApplication
    {

        Task<List<ApplicationDetailDto>> getAll();

        Task<List<ApplicationDetailDto>> getAllByWord(string word);

        Task<Application> GetById(int id);

        Task<Application> GetByName(string name);

        Task<List<Application>> GetByCategory(int id);

        Task<bool> Update(Application app);

        Task<bool> Create(ApplicationCreationDto app);

        Task<bool> Delete(int id); 
    }
}
